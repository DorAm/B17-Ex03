using Ex03.GarageLogic;
using System;
using System.Collections.Generic;

public class Garage_Manager
{
    private List<Vehicle> m_Vehicles;


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
    public void ShowVehicleListByStatus(eStatus VehicleStatus)
    {
        string message = String.Format(
            @"Vehicles currently in garage:"
        );

        foreach (var vehicle in m_Vehicles)
        {
            Console.WriteLine(@"|     {0}|    {1}|", vehicle.Status);
        }
    }

    public void ChangeVehicleStatus(int i_LicenseNumber, eStatus VehicleStatus)
    {

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
    public void ShowCarData(int i_LicenseNumber)
    {

    }

}
