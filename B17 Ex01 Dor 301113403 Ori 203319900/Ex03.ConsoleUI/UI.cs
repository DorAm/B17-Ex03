using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Ex03.GarageLogic;


public class UI
{
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
        this.DisplayMainMenu();
        this.routeToMethod(InputUsersChoice());
    }

    public void DisplayMainMenu()
    {
        Console.WriteLine(@"
===========================
===== DorOri's Garage =====
===========================

--- Please choose ---
        ");

        Array menuOptions = Enum.GetValues(typeof(eMenuOptions));
        ushort index = 1;
        foreach (eMenuOptions menuOption in menuOptions)
        {
            Console.WriteLine("{0}. {1}", index, menuOption.ToString());
            index++;
        }

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
        switch (i_UsersChoice)
        {
            case eMenuOptions.Register_Vehicle:
                registerVehicleMenu();
                break;
            //case eMenuOptions.Display_Vehicle_List:
            //    displayVehicleListMenu();
            //    break;
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
            //    displayVehicleDataMenu();
            //    break;
            default:
                break;
        }
    }

    // == Register Vehicle ==

    private void registerVehicleMenu()
    {
        Console.WriteLine(@"
==================================
===== Register a new vehicle =====
==================================

Which vehicle would you like to register?
        ");

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
        Dictionary<string, object> vehicleData = getVehicleData(chosenVehicleType);
        m_GarageManager.RegisterVehicle(vehicleData);
    }

    private Dictionary<string, object> getVehicleData(eVehicleType i_ChosenVehicleType)
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

   

    //public void ShowVehicleListByStatus(eStatus VehicleStatus)
    //{
    //    // Asking the user for a filter:

    //    Console.WriteLine("Which vehicles do you want to view?{0}", Environment.NewLine);
    //    Array availableStatus = Enum.GetValues(typeof(eStatus));
    //    foreach (var status in availableStatus)
    //    {
    //        Console.WriteLine("{0} / ", status);
    //    }

    //    eStatus chosenStatus = (eStatus)Enum.Parse(typeof(eStatus), Console.ReadLine());

    //    // Displaying the list:

    //    Console.WriteLine(
    //        @"Vehicles currently in garage:
    //          ============================={0}"
    //    , Environment.NewLine);

    //    foreach (var vehicle in m_Vehicles)
    //    {
    //        if (vehicle.status == chosenStatus)
    //        {
    //            Console.WriteLine(@"|     {0}|      {1}|", vehicle.Status, vehicle.LicenceNumber);
    //        }
    //    }
    //}

}
