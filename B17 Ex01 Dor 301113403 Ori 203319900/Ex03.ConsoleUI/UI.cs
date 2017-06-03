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

    public void RunGarage()
    {
        this.DisplayMainMenu();
        this.InputUsersChoice();
    }

    private GarageManager m_GarageManager;

    public UI()
    {
        m_GarageManager = new GarageManager();
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

    // TOOD: implement
    //private displayEnumOptions(enum)
    //{

    //}

    public void InputUsersChoice()
    {
        // TODO: change to try parse
        eMenuOptions usersChoice = (eMenuOptions)Enum.Parse(typeof(eMenuOptions), Console.ReadLine());
        //typeof(GarageManager).GetMethod("DisplayMainMenu").Invoke(this, new[] { "world" });
        this.routeToMethod(usersChoice);
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

        // Reading attributes from the user according to the type of vehicle:
        List<Tuple<Type, string>> vehicleAttributes = m_GarageManager.GetVehicleAttributes(chosenVehicleType);
        Dictionary<string, object> vehicleData = new Dictionary<string, object>();

        foreach (var vehicleAttribute in vehicleAttributes)
        {
            Type attributesType = vehicleAttribute.Item1;
            string attributesName = vehicleAttribute.Item2;

            Console.WriteLine(@"Please enter {0}", attributesName);            
            string userInput = Console.ReadLine();
            vehicleData.Add(attributesName, Convert.ChangeType(userInput, attributesType));
        }
    }

    //private void displayVehicleListMenu()
    //{        
    //    foreach (var  m_GarageManager.vehicles)
    //    {
            
    //    }
    //}

    //private void changeVehicleStatusMenu()
    //{

    //}

    //private void inflateWheelsMenu()
    //{

    //}

    //private void refuelGasMenu()
    //{

    //}

    //private void rechargeElectricMenu()
    //{

    //}

    //private void displayVehicleDataMenu()
    //{

    //}
    //public void RegisterVehicle(int i_LicenseNumber)
    //{
    //    string message = String.Format(
    //        @"Please insert the car's license number:"
    //    );

    //    string userInput = Console.ReadLine();
    //    public Vehicle(string i_ModelName, string i_LicenseNumber, eEnergySource i_EnergySource,
    //        float maxEnergyCapacity, string i_OwnerName, string i_OwnerPhone)
    //    {

    //        Vehicle newVehicle = new Vehicle();
    //        m_Vehicles.Add();
    //    }

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

    //public void ChangeVehicleStatus()
    //{
    //    //public void ChangeVehicleStatus(int i_LicenseNumber, eStatus VehicleStatus)
    //    {
    //        // TODO: is this O(n) access?
    //        //m_Vehicles[i_LicenseNumber].status = i_
    //    }
    //    public void InflateToMax()
    //    {

    //    }
    //    public void FuelCar(int i_LicenseNumber, eEnergySource iEnergySource, float iAmount)
    //    {

    //    }
    //    public void ChargeCar(int i_LicenseNumber, float iAmount)
    //    {

    //    }
    //    private void DisplayCarData(int i_LicenseNumber)
    //    {

    //    }

    }
