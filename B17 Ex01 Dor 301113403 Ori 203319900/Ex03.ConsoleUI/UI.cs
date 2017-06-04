using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using Ex03.GarageLogic;


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
            this.routeToMethod(InputUsersChoice());
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
        printListFromEnum(typeof(eMenuOptions));
        Console.WriteLine(@"
==========================="
        );
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
            //case eMenuOptions.Change_Vehicle_Status:
            //    changeVehicleStatusMenu();
            //    break;
            //case eMenuOptions.Inflate_Wheels:
            //    inflateWheelsMenu();
            //    break;
            //case eMenuOptions.Refuel_Gas:
            //    refuelGasMenu();
            //    break;
            //case eMenuOptions.Recharge_Electric:
            //    rechargeElectricMenu();
            //    break;
            //case eMenuOptions.Display_Vehicle_Data:
            //    DisplayVehicleDataMenu();
            //    break;
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

    private void printListFromEnum(Type i_EnumType)
    {
        Array enumTypes = Enum.GetValues(i_EnumType);
        ushort index = 0;
        foreach (var enumType in enumTypes)
        {
            index++;
            Console.WriteLine("{0}. {1}", index, enumType.ToString());
        }
    }

    // == Input Validation ==

    private object inputDataFromUser(Type i_InputType)
    {
        string userInput = Console.ReadLine();
        while (isInvalidValidOption(i_InputType, userInput))
        {
            Console.WriteLine("Invalid input, please re-enter your choice");
            userInput = Console.ReadLine();
        }
        return Enum.Parse(i_InputType, userInput);
    }

    private Boolean isInvalidValidOption(Type i_ValidOptions, string i_UserInput)
    {
        //return i_ValidOptions.IsDefined(i_ValidOptions, i_UserInput);
        return false;
    }

    // == Register Vehicle ==

    private void registerVehicleMenu()
    {
        printHeading("Register a new vehicle", "Which vehicle would you like to register?");

        Array vehicleTypes = Enum.GetValues(typeof(eVehicleType));
        ushort index = 1;
        foreach (var vehicleType in vehicleTypes)
        {
            Console.WriteLine("{0}. {1}", index, vehicleType.ToString());
            index++;
        }
        Console.WriteLine(@"
Please choose from the above list
        ");

        eVehicleType chosenVehicleType = (eVehicleType)Enum.Parse(typeof(eVehicleType), Console.ReadLine());
        Dictionary<eVehicleAttribute, object> vehicleData = inputVehicleData(chosenVehicleType);
        m_GarageManager.RegisterVehicle(chosenVehicleType, vehicleData);
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
            string userInput = Console.ReadLine();
            object parsedInput = parseStringToObject(attributeType, userInput);
            vehicleData.Add(attributeName, Convert.ChangeType(parsedInput, attributeType));
        }

        return vehicleData;
    }

    private object parseStringToObject(Type i_AttributesType, string i_UserInput)
    {
        object parsedInput;
        if (i_AttributesType.IsEnum)
        {
            bool i_IgnoreCase = true;
            parsedInput = Enum.Parse(i_AttributesType, i_UserInput, i_IgnoreCase);
        }
        else
        {
            parsedInput = Convert.ChangeType(i_UserInput, i_AttributesType);
        }
        return parsedInput;
    }

    // == Display Vehicle List By Status ==
    public void DisplayVehicleListByStatusMenu()
    {
        Dictionary<string, Vehicle> vehicles = m_GarageManager.Vehicles;

        printHeading("Vehicle List (by status)", "Select which vehicles you want to view: ");
        printListFromEnum(typeof(eStatus));
        eStatus chosenFilter = (eStatus)inputDataFromUser(typeof(eStatus));

        // Displaying the list:
        this.printHeading("Vehicle List (by status)", "Vehicles currently in garage:");

        int index = 0;
        foreach (var vehicle in vehicles)
        {
            if (vehicle.Value.Status == chosenFilter)
            {
                index++;
                Console.WriteLine(@"{0}. {1}", index, vehicle.Value.LicenceNumber);
            }
        }
        if (index == 0)
        {
            Console.WriteLine("No vehicles are available for filter {0}", chosenFilter);
        }
    }

    // == Change Vehicle Status ==
    //public void changeVehicleStatusMenu()
    //{
    //    printHeading("Change Vehicle Status:", "please enter vehicle's license number and the new status:");
    //    string licenseNumber = Console.ReadLine();
    //    string newStatus = Console.ReadLine();        
    //    Vehicle vehicle = m_GarageManager.GetVehicle(licenseNumber);
    //    vehicle.Status = (eStatus)Enum.Parse(typeof(eStatus), newStatus);            
    //}

    // == Inflate Wheels ==
    //private void inflateWheelsMenu()
    //{
    //    printHeading("Inflate Vehicle Wheels:", "please enter vehicle's license number:");
    //    string licenseNumber = Console.ReadLine();
    //    Vehicle vehicle = m_GarageManager.getVehicle(licenseNumber);
    //    vehicle.InflateWheelsToMax();
    //}

    // == Refuel Gas ==
    private void refuelGasMenu()
    {
        //printHeading("Refuel or Recharge Vehicle:", "please enter vehicle's license number, Gas Type, and ammount to fill");
        //string licenseNumber = Console.ReadLine();
        //Vehicle vehicle = m_GarageManager.getVehicle(licenseNumber);
        //vehicle.FillEnergySource();
    }

    // == Display Vehicle Data By License Number
    //public void DisplayVehicleDataMenu()
    //{
    //    printHeading("Vehicle Data:", "please enter vehicle's license number:");
    //    string licenseNumber = Console.ReadLine();
    //    Vehicle vehicle = m_GarageManager.getVehicle(licenseNumber);
    //    Console.WriteLine(vehicle.ToString());
    //}
}
