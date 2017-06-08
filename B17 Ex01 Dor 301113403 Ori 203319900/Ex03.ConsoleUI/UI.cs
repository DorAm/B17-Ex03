using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;
using Ex03.GarageLogic;
using System.Text;

public class UI
{
    private enum eMenuOption
    {
        Register_Vehicle = 1,
        Display_Vehicle_List,
        Change_Vehicle_Status,
        Inflate_Wheels,
        Refuel_Gas,
        Recharge_Electric,
        Display_Vehicle_Data
    }

    private enum eUserAction
    {
        MainMenu = 1,
        Quit = 2
    }

    private GarageManager m_GarageManager;

    public UI()
    {
        Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us");
        m_GarageManager = new GarageManager();
    }

    public void RunGarage()
    {
        eUserAction selectedAction;
        do
        {
            displayMainMenu();
            eMenuOption selectedOption = (eMenuOption)getInput(typeof(eMenuOption));
            routeToMethod(selectedOption);
            Console.WriteLine(@"
================================================
    1 - Return to main menu    |    2 - Quit          
================================================
            ");
            selectedAction = (eUserAction)getInput(typeof(eUserAction));

        } while (selectedAction != eUserAction.Quit);
    }

    private void displayMainMenu()
    {
        printHeading("DorOri's Garage", "Please choose:");
        StringBuilder outputToPrint = formatTextFromEnum(typeof(eMenuOption));
        printFormatedOutput(outputToPrint);
    }

    // ===== Getting Input =====

    // A generic funciton for getting an input from the user
    // The function will only return a value after the user entered a valid input
    private object getInput(Type i_Type)
    {
        string userInput = Console.ReadLine();
        object parsedInput = parseStringToObject(i_Type, userInput);
        while (parsedInput == null)
        {
            Console.WriteLine(@"Please re-enter your choice:");
            userInput = Console.ReadLine();
            parsedInput = parseStringToObject(i_Type, userInput);
        }
        return parsedInput;
    }

    // A generic function for parsing a string to an object of a given type    
    private object parseStringToObject(Type i_Type, string i_String)
    {
        object parsedString = null;
        try
        {
            if (i_Type.IsEnum)
            {
                const bool k_IgnoreCase = true;
                parsedString = Enum.Parse(i_Type, i_String, k_IgnoreCase);
                if (Enum.IsDefined(i_Type, parsedString) == false)
                {
                    parsedString = null;
                    throw new ArgumentException();
                }
            }
            else
            {
                parsedString = Convert.ChangeType(i_String, i_Type);
            }
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (OverflowException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (InvalidCastException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (FormatException ex)
        {
            Console.WriteLine(ex.Message);
        }
        return parsedString;
    }

    // ===== Routing =====

    private void routeToMethod(eMenuOption i_UsersChoice)
    {
        Console.Clear();
        switch (i_UsersChoice)
        {
            case eMenuOption.Register_Vehicle:
                registerVehicleMenu();
                break;
            case eMenuOption.Display_Vehicle_List:
                DisplayVehicleListByStatusMenu();
                break;
            case eMenuOption.Change_Vehicle_Status:
                changeVehicleStatusMenu();
                break;
            case eMenuOption.Inflate_Wheels:
                inflateWheelsMenu();
                break;
            case eMenuOption.Refuel_Gas:
                fuelGasMenu();
                break;
            case eMenuOption.Recharge_Electric:
                chargeElectricMenu();
                break;
            case eMenuOption.Display_Vehicle_Data:
                DisplayVehicleDataMenu();
                break;
            default:
                break;
        }
    }

    private void chargeElectricMenu()
    {
        printHeading("Refuel or Recharge Vehicle:", "please enter vehicle's license number and minutes to fill");
        Console.WriteLine("License Number:");
        string licenseNumber = (string)getInput(typeof(string));
        Console.WriteLine("Minutes to fill:");
        float amountToFill = (float)getInput(typeof(float));
        try
        {
            m_GarageManager.ChargeVehicle(licenseNumber, amountToFill);
        }
        catch (ItemNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    // ===== Printing =====

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

    private StringBuilder formatTextFromEnum(Type i_EnumType)
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

    private void printFormatedOutput(StringBuilder i_OutputToPrint)
    {
        Console.WriteLine(@"{0} 
================================", i_OutputToPrint);
    }

    // ===== Register Vehicle =====

    private void registerVehicleMenu()
    {
        printHeading("Register a new vehicle", "Which vehicle would you like to register?");
        StringBuilder outputToPrint = formatTextFromEnum(typeof(eVehicleType));
        printFormatedOutput(outputToPrint);

        eVehicleType chosenVehicleType = (eVehicleType)getInput(typeof(eVehicleType));
        Dictionary<eVehicleAttribute, object> vehicleData = inputVehicleData(chosenVehicleType);
        bool doesExistInGarage = false;
        m_GarageManager.RegisterVehicle(chosenVehicleType, vehicleData, out doesExistInGarage);
        if (doesExistInGarage)
        {
            Console.WriteLine("Vehicle with this license number is already in the garage");
        }
        else
        {
            Console.WriteLine("Vehicle registered succesfuly");
        }
    }

    private Dictionary<eVehicleAttribute, object> inputVehicleData(eVehicleType i_ChosenVehicleType)
    {
        // Reading attributes from the user according to the type of vehicle:
        List<Tuple<Type, eVehicleAttribute>> vehicleAttributes = m_GarageManager.GetVehicleAttributes(i_ChosenVehicleType);
        Dictionary<eVehicleAttribute, object> vehicleData = new Dictionary<eVehicleAttribute, object>();

        foreach (var attribute in vehicleAttributes)
        {
            Type attributeType = attribute.Item1;
            eVehicleAttribute attributeName = attribute.Item2;
            Console.WriteLine(@"Please enter {0}", attributeName);
            object parsedInput = getInput(attributeType);
            vehicleData.Add(attributeName, parsedInput);
            //vehicleData.Add(attributeName, Convert.ChangeType(parsedInput, attributeType));
        }
        return vehicleData;
    }

    // == Display Vehicle List By Status ==
    // TODO: fix invalid input problems
    public void DisplayVehicleListByStatusMenu()
    {
        Dictionary<string, Vehicle> vehicles = m_GarageManager.Vehicles;

        printHeading("Vehicle List (by status)", "Select which vehicles you want to view: ");
        StringBuilder outputToPrint = formatTextFromEnum(typeof(eStatus));
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
                Console.WriteLine("No vehicles for filter: {0}", chosenFilter);
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
        Console.WriteLine("License Number:");
        string licenseNumber = (string)getInput(typeof(string));
        Console.WriteLine("New Status:");
        eStatus newStatus = (eStatus)getInput(typeof(eStatus));
        try
        {
            m_GarageManager.ChangeVehicleStatus(licenseNumber, newStatus);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    // == Inflate Wheels ==
    private void inflateWheelsMenu()
    {
        printHeading("Inflate Vehicle Wheels:", "please enter vehicle's license number:");
        Console.WriteLine("License Number:");
        string licenseNumber = (string)getInput(typeof(string));

        try
        {
            m_GarageManager.InflateWheels(licenseNumber);
        }
        catch (ItemNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    // == Refuel Gas ==
    private void fuelGasMenu()
    {
        printHeading("Refuel or Recharge Vehicle:", "please enter vehicle's license number, Energy Source, and ammount to fill");
        Console.WriteLine("License Number:");
        string licenseNumber = (string)getInput(typeof(string));
        Console.WriteLine("Energy Source:");
        eEnergySource energySource = (eEnergySource)getInput(typeof(eEnergySource));
        Console.WriteLine("Ammount to fill:");
        float amountToFill = (float)getInput(typeof(float));
        try
        {
            m_GarageManager.FuelVehicle(licenseNumber, energySource, amountToFill);
        }
        catch (ItemNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    // == Display Vehicle Data By License Number
    public void DisplayVehicleDataMenu()
    {
        printHeading("Vehicle Data:", "please enter vehicle's license number:");
        string licenseNumber = (string)getInput(typeof(string));
        try
        {
            Vehicle vehicle = m_GarageManager.getVehicle(licenseNumber);
            StringBuilder outputString = new StringBuilder();

            outputString.AppendFormat(@"{0}== General Data: ==", Environment.NewLine);
            outputString.AppendFormat(@"
License Number: {0},
Model Name: {1},
Owner: {2},
Vehicle Status: {3}
", vehicle.LicenceNumber, vehicle.ModelName, vehicle.Owner, vehicle.Status);

            outputString.AppendFormat(@"{0}== Wheels Data: ==", Environment.NewLine);
            foreach (Wheel wheel in vehicle.Wheels)
            {
                outputString.AppendFormat(@"
Air presure: {0},
Manufacaturer {1}
", wheel.CurrAirPressure, wheel.Manufacturer);
            }
            outputString.AppendFormat(@"{0}== Energy Source Data: ==", Environment.NewLine);
            outputString.AppendFormat(@"
Status: {0},
Source: {1}", vehicle.getEnergyStatus(), vehicle.getEnergyType());

            Console.WriteLine(outputString);
        }
        catch (ItemNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}


