using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public enum eVehicleType
    {
        Car,
        Motorcycle,
        Truck
    }

    public enum eSupportedVehicle
    {
        RregularBike,
        ElectricBike,
        RegularCar,
        ElectricCar,
        Truck
    }

    public enum eVehicleAttribute
    {
        ModelName,
        LicenseNumber,
        EnergySource,
        MaxEnergyCapacity,
        CurrentEnergyStatus,
        WheelManufacturer,
        WheelMaxAirPressure,
        WheelCurrentAirPressure,
        OwnerName,
        OwnerPhoneNumber,
        LicenseType,
        EngineVolume,
        Color,
        NumOfDoors,
        IsHazmat,
        MaxLoad
    }


    public static class VehicleFactory
    {
        public static Vehicle BuildNewVehicle(eVehicleType i_Type, Dictionary<eVehicleAttribute,object> i_VehicleAttributs)
        {

            Vehicle newVehicle;

            switch (i_Type)
            {
                case eVehicleType.Car:
                    newVehicle = new Car(i_VehicleAttributs);
                    break;
                case eVehicleType.Motorcycle:
                    newVehicle = new Motorcycle(i_VehicleAttributs);
                    break;
                case eVehicleType.Truck:
                    newVehicle = new Truck(i_VehicleAttributs);
                    break;
                default:
                    newVehicle = null;
                    break;
            }

            
            return newVehicle;
        }

    }
}
