using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Reflection;

public class Garage_Manager
{
    private List<Vehicle> m_Vehicles;

    private enum eMenuOptions
    {
        Register_Vehicle,
        Display_Vehicle_List,
        Change_Vehicle_Status,
        Inflate_Wheels,
        Refuel_Gas,
        Recharge_Electric,
        Display_Vehicle_Data
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
        foreach (var option in menuOptions)
        {
            string optionStr = option.ToString();
            Console.WriteLine("{0}. {1}", index, optionStr);
            index++;
        }

        Console.WriteLine(@"
==========================="
        );
    }

    public void InputUsersChoice()
    {
        // TODO: change to try parse
        eMenuOptions usersChoice = (eMenuOptions)Enum.Parse(typeof(eMenuOptions), Console.ReadLine());
        typeof(Garage_Manager).GetMethod("DisplayMainMenu").Invoke(this, new[] { "world"});
    }

    private void routeToFunction(eMenuOptions usersChoice)
    {
        switch (usersChoice)
        {
            case eMenuOptions.Change_Vehicle_Status:
                ChangeVehicleStatus();
                break;
            case eMenuOptions.Display_Vehicle_Data:
                DisplayCarData();
                break;
            default:
                break;
        }

    }
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

    public void ChangeVehicleStatus()
    {
        //public void ChangeVehicleStatus(int i_LicenseNumber, eStatus VehicleStatus)
        {
            // TODO: is this O(n) access?
            //m_Vehicles[i_LicenseNumber].status = i_
        }
        public void InflateToMax(int i_LicenseNumber)
        {

        }
        public void FuelCar(int i_LicenseNumber, eEnergySource i_EnergySource, float i_Amount)
        {

        }
        public void ChargeCar(int i_LicenseNumber, float i_Amount)
        {

        }
        private void DisplayCarData(int i_LicenseNumber)
        {

        }

    }
