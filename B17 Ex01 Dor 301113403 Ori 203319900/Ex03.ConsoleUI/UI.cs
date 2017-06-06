﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using Ex03.GarageLogic;
using System.Text;

public class UI
{
    private enum eUsersChoice
    {
        MainMenu = 1,
        Quit = 2
    }

    private enum eMenuOptions
    {
        Register_Vehicle = 1,
        Display_Vehicle_List,
        Change_Vehicle_Status,
        Inflate_Wheels,
        Refuel_Gas,
        Recharge_Electric,
        Display_Vehicle_Data
    }

    private GarageManager m_GarageManager;

    public UI()
    {
        m_GarageManager = new GarageManager();
    }

    public void RunGarage()
    {
        eUsersChoice choice = eUsersChoice.MainMenu;
        while (choice != eUsersChoice.Quit)
        {
            this.displayMainMenu();
            eMenuOptions usersChoice = (eMenuOptions)parseStringToObject(typeof(eMenuOptions), Console.ReadLine());
            this.routeToMethod(usersChoice);
            Console.WriteLine(@"
================================================
    1 - Return to main menu    |    2 - Quit          
================================================
            ");
            // validate using inputDataFromUser method
            choice = (eUsersChoice)Enum.Parse(typeof(eUsersChoice), Console.ReadLine());
        }
    }

    private void displayMainMenu()
    {
        printHeading("DorOri's Garage", "Please choose:");
        StringBuilder outputToPrint = formatToTextFromEnum(typeof(eMenuOptions));
        printFormatedOutput(outputToPrint);
    }

    private void printFormatedOutput(StringBuilder i_OutputToPrint)
    {
        Console.WriteLine(@" {0} 
================================", i_OutputToPrint);
    }

    // == Input Validation ==

    //private object inputDataFromUser(Type i_InputType)
    //{
    //    string userInput = Console.ReadLine();
    //    if (i_InputType.IsEnum)
    //    {
    //        isInvalidValidOption(i_InputType, userInput);
    //    }
    //    else
    //    {
    //        while(parseStringToObject)
    //        Console.WriteLine("Invalid input, please re-enter your choice");
    //        userInput = Console.ReadLine();
    //    }
    //    return Enum.Parse(i_InputType, userInput);
    //}

    private Boolean isInvalidValidOption(Type i_ValidOptions, string i_UserInput)
    {
        bool isInvalidInput = false;
        bool ignoreCase = true;
        try
        {
            object userInput = Enum.Parse(i_ValidOptions, i_UserInput, ignoreCase);
        }
        catch (ArgumentException aExp)
        {
            throw new ArgumentOutOfRangeException("there is no such type", aExp.InnerException);
            isInvalidInput = isInvalidValidOption(i_ValidOptions, i_UserInput);
        }
        catch(Exception ex)
        {
            throw new FormatException("there is something wrong with the input", ex.InnerException);
        }

        return isInvalidInput;
    }

    private eMenuOptions InputUsersChoice()
    {
        // TODO: change to try parse
        string userInput = Console.ReadLine();
        return (eMenuOptions)Enum.Parse(typeof(eMenuOptions), userInput);
    }

    private void routeToMethod(eMenuOptions i_UsersChoice)
    {
        Console.Clear();
        switch (i_UsersChoice)
        {
            case eMenuOptions.Register_Vehicle:
                registerVehicleMenu();
                break;
            case eMenuOptions.Display_Vehicle_List:
                DisplayVehicleListByStatusMenu();
                break;
            case eMenuOptions.Change_Vehicle_Status:
                changeVehicleStatusMenu();
                break;
            case eMenuOptions.Inflate_Wheels:
                inflateWheelsMenu();
                break;
            case eMenuOptions.Refuel_Gas:
                fuelGasMenu();
                break;
            //case eMenuOptions.Recharge_Electric:
            //    rechargeElectricMenu();
            //    break;
            case eMenuOptions.Display_Vehicle_Data:
                DisplayVehicleDataMenu();
                break;
            default:
                break;
        }
    }

    // == Printing ==

    private void printHeading(string i_MainHeading, string i_MessageToUser)
    {
        Console.Clear();
        Console.WriteLine(@"     
==================================
{0}
==================================

{1}
        ", i_MainHeading, i_MessageToUser);
    }

    private StringBuilder formatToTextFromEnum(Type i_EnumType)
    {
        StringBuilder formatedOutput = new StringBuilder();
        Array enumTypes = Enum.GetValues(i_EnumType);
        ushort index = 0;
        foreach (var enumType in enumTypes)
        {
            index++;
            formatedOutput.AppendFormat(@"{0}. {1}{2}", index, enumType.ToString(), Environment.NewLine);
        }

        return formatedOutput;
    }

    // == Register Vehicle ==

    private void registerVehicleMenu()
    {
        printHeading("Register a new vehicle", "Which vehicle would you like to register?");
        StringBuilder outputToPrint = formatToTextFromEnum(typeof(eVehicleType));
        printFormatedOutput(outputToPrint);
        eVehicleType chosenVehicleType = (eVehicleType)Enum.Parse(typeof(eVehicleType), Console.ReadLine());
        Dictionary<eVehicleAttribute, object> vehicleData = inputVehicleData(chosenVehicleType);
        bool doesExistInGarage;
        m_GarageManager.RegisterVehicle(chosenVehicleType, vehicleData, out doesExistInGarage);
        if (doesExistInGarage == true)
        {
            Console.WriteLine("Vehicle with this license number is already in the garage");
        }
    }

    private Dictionary<eVehicleAttribute, object> inputVehicleData(eVehicleType i_ChosenVehicleType)
    {
        // Reading attributes from the user according to the type of vehicle:
        List<Tuple<Type, eVehicleAttribute>> vehicleAttributes = m_GarageManager.GetVehicleAttributes(i_ChosenVehicleType);        
        Dictionary<eVehicleAttribute, object> vehicleData = new Dictionary<eVehicleAttribute, object>();

        foreach (var attribute in vehicleAttributes)
        {
            try
            {
                Type attributeType = attribute.Item1;
                eVehicleAttribute attributeName = attribute.Item2;
                Console.WriteLine(@"Please enter {0}", attributeName);
                string userInput = Console.ReadLine();
                object parsedInput = parseStringToObject(attributeType, userInput);
                vehicleData.Add(attributeName, Convert.ChangeType(parsedInput, attributeType));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
                Console.WriteLine("please try again");
                vehicleData = inputVehicleData(i_ChosenVehicleType);
            }
        }

        return vehicleData;
    }

    private object parseStringToObject(Type i_AttributesType, string i_UserInput)
    {

        object parsedInput = null;

        try
        {
            if (i_AttributesType.IsEnum && isInvalidValidOption(i_AttributesType, i_UserInput) == false)
            {
                bool i_IgnoreCase = true;
                parsedInput = Enum.Parse(i_AttributesType, i_UserInput, i_IgnoreCase);
            }
            else
            {
                parsedInput = Convert.ChangeType(i_UserInput, i_AttributesType);
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message.ToString());
            System.Console.WriteLine("please try amother input");
            string newUserInput = System.Console.ReadLine();
            parsedInput = parseStringToObject(i_AttributesType, newUserInput);
        }

        return parsedInput;
    }

    // == Display Vehicle List By Status ==
    public void DisplayVehicleListByStatusMenu()
    {
        Dictionary<string, Vehicle> vehicles = m_GarageManager.Vehicles;

        printHeading("Vehicle List (by status)", "Select which vehicles you want to view: ");
        StringBuilder outputToPrint = formatToTextFromEnum(typeof(eStatus));
        outputToPrint.Append("4. Print All");
        printFormatedOutput(outputToPrint);
        int userInput = (int)parseStringToObject(typeof(int), Console.ReadLine());
        // Displaying the list:
        this.printHeading("Vehicle List (by status)", "Vehicles currently in garage:");
        int printAllLicenseNumber = 4;
        int index = 0;
        eStatus chosenFilter;
        if (Enum.TryParse(userInput.ToString(), out chosenFilter))
        {
            foreach (var vehicle in vehicles)
            {
                if (userInput == printAllLicenseNumber || vehicle.Value.Status == chosenFilter)
                {
                    index++;
                    Console.WriteLine(@"{0}. {1}", index, vehicle.Value.LicenceNumber);
                }
            }
            if (index == 0)
            {
                Console.WriteLine("No vehicles for this filter {0}", chosenFilter);
            }
        }
        else
        {
            Console.WriteLine("no such option");
        }
    }

    // == Change Vehicle Status ==
    public void changeVehicleStatusMenu()
    {
        printHeading("Change Vehicle Status:", "please enter vehicle's license number and the new status:");
        string licenseNumber = Console.ReadLine();
        eStatus newStatus = (eStatus)parseStringToObject(typeof(eStatus), Console.ReadLine());
        m_GarageManager.ChangeVehicleStatus(licenseNumber, newStatus);
    }

    // == Inflate Wheels ==
    private void inflateWheelsMenu()
    {
        try
        {
            printHeading("Inflate Vehicle Wheels:", "please enter vehicle's license number:");
            string licenseNumber = Console.ReadLine();
            m_GarageManager.InflateWheels(licenseNumber);
        }
        catch(Exception ex)
        {
            Console.WriteLine("Invalid air pressure");
            inflateWheelsMenu();
        }
    }

    // == Refuel Gas ==
    private void fuelGasMenu()
    {
        try
        {
            printHeading("Refuel or Recharge Vehicle:", "please enter vehicle's license number, Gas Type, and ammount to fill");
            string licenseNumber = Console.ReadLine();
            eEnergySource energySource = (eEnergySource)parseStringToObject(typeof(eEnergySource), Console.ReadLine());
            float amountToFill = (float)parseStringToObject(typeof(float), Console.ReadLine());
            m_GarageManager.FuelVehicle(licenseNumber, energySource, amountToFill);
        }
        catch(Exception ex)
        {
            Console.WriteLine("Invalid amount");
            fuelGasMenu();
        }
    }

    // == Display Vehicle Data By License Number
    public void DisplayVehicleDataMenu()
    {
        //printHeading("Vehicle Data:", "please enter vehicle's license number:");
        //string licenseNumber = Console.ReadLine();        
        //Vehicle vehicle = m_GarageManager.getVehicle(licenseNumber);
        //Console.WriteLine(vehicle.ToString());
    }
}
