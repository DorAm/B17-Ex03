using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
            case eMenuOptions.Change_Vehicle_Status:
                changeVehicleStatusMenu();
                break;
            case eMenuOptions.Inflate_Wheels:
                inflateWheelsMenu();
                break;
            //case eMenuOptions.Refuel_Gas:
            //    refuelGasMenu();
            //    break;
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
        Dictionary<string, object> vehicleData = inputVehicleData(chosenVehicleType);
        //m_GarageManager.RegisterVehicle(vehicleData);
    }

    private Dictionary<string, object> inputVehicleData(eVehicleType i_ChosenVehicleType)
    {
        // Reading attributes from the user according to the type of vehicle:
        List<Tuple<Type, string>> vehicleAttributes = m_GarageManager.GetVehicleAttributes(i_ChosenVehicleType);
        Dictionary<string, object> vehicleData = new Dictionary<string, object>();

        foreach (var vehicleAttribute in vehicleAttributes)
        {
            Type attributesType = vehicleAttribute.Item1;
            string attributesName = vehicleAttribute.Item2;
            Console.WriteLine(@"Please enter {0}", attributesName);
            string userInput = Console.ReadLine();
            object parsedInput = parseStringToObject(attributesType, userInput);
            vehicleData.Add(attributesName, Convert.ChangeType(parsedInput, attributesType));
        }

        return vehicleData;
    }

    private object parseStringToObject(Type i_AttributesType, string i_UserInput)
    {
        object parsedInput;
        if (i_AttributesType.IsEnum)
        {
            parsedInput = Enum.Parse(i_AttributesType, i_UserInput);
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
        List<Vehicle> vehicles = new List<Vehicle>()
        {
            new Vehicle("Mazda", "L125215", eEnergySource.Electric, 100, 60, "Dor", "104215"),
            new Vehicle("Pegueot", "L56458", eEnergySource.Octan95, 120, 60, "Ori", "23906832"),
            new Vehicle("Fiat", "L51205809", eEnergySource.Soler, 1000, 650, "Dana", "01285125"),
            new Vehicle("Subaru", "L238512", eEnergySource.Octan98, 1000, 1, "Greg", "0582951")
        };
        //List<Vehicle> vehicles = this.m_GarageManager.Vehicles;

        printHeading("Vehicle List (by status)", "Select which vehicles you want to view: ");
        printListFromEnum(typeof(eStatus));
        string userInput = inputDataFromUser(typeof(eStatus));
        eStatus chosenFilter = (eStatus)Enum.Parse(typeof(eStatus), userInput);

        // Displaying the list:
        this.printHeading("Vehicle List (by status)", "Vehicles currently in garage:");

        int index = 0;
        foreach (var vehicle in vehicles)
        {
            if (vehicle.Status == chosenFilter)
            {
                index++;
                Console.WriteLine(@"{0}. {1}", index, vehicle.LicenceNumber);
            }
        }
        if (index == 0)
        {
            Console.WriteLine("No vehicles are available for filter {0}", chosenFilter);
        }
    }

    // == Change Vehicle Status ==
    public void changeVehicleStatusMenu()
    {
        printHeading("Change Vehicle Status:", "please enter vehicle's license number and the new status:");
        string licenseNumber = Console.ReadLine();
        string newStatus = Console.ReadLine();
        Vehicle vehicle = m_GarageManager.getVehicle(licenseNumber);
        vehicle.Status = (eStatus)Enum.Parse(typeof(eStatus), newStatus);            
    }

    // == Inflate Wheels ==
    private void inflateWheelsMenu()
    {
        printHeading("Inflate Vehicle Wheels:", "please enter vehicle's license number:");
        string licenseNumber = Console.ReadLine();
        Vehicle vehicle = m_GarageManager.getVehicle(licenseNumber);
        vehicle.InflateWheelsToMax();
    }

    // == Refuel Gas ==
    private void refuelGasMenu()
    {
        //printHeading("Refuel or Recharge Vehicle:", "please enter vehicle's license number, Gas Type, and ammount to fill");
        //string licenseNumber = Console.ReadLine();
        //Vehicle vehicle = m_GarageManager.getVehicle(licenseNumber);
        //vehicle.FillEnergySource();
    }
    // == Display Vehicle Data By License Number
    public void DisplayVehicleDataMenu()
    {
        printHeading("Vehicle Data:", "please enter vehicle's license number:");
        string licenseNumber = Console.ReadLine();
        Vehicle vehicle = m_GarageManager.getVehicle(licenseNumber);
        Console.WriteLine(vehicle.ToString());
    }
}
