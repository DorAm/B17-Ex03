using System;
using System.Collections.Generic;
using System.Reflection;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private Dictionary<string,Vehicle> m_Vehicles = null;

        public Dictionary<string, Vehicle> Vehicles { get => m_Vehicles; }

        public GarageManager()
        {

        }

        public void RegisterVehicle(eVehicleType i_VehicleType ,Dictionary<eVehicleAttribute, object> i_VehicleData)
        {
            string licenseNumber = (string)i_VehicleData[eVehicleAttribute.LicenseNumber];
            if (Vehicles.ContainsKey(licenseNumber))
            {
                Vehicles[licenseNumber].Status = eStatus.InRepair;
            }
            else
            {
                Vehicles.Add(licenseNumber, VehicleFactory.BuildNewVehicle(i_VehicleType, i_VehicleData));
            }
        }

        public List<Tuple<Type, eVehicleAttribute>> GetVehicleAttributes(eVehicleType i_VehicleType)
        {
            List<Tuple<Type, eVehicleAttribute>> vehicleAttributes = new List<Tuple<Type, eVehicleAttribute>>();

            switch (i_VehicleType)
            {
                case eVehicleType.Car:
                    vehicleAttributes = Car.InheritedObjectCreationList;

                    break;
                case eVehicleType.Motorcycle:
                    vehicleAttributes = Motorcycle.InheritedObjectCreationList;

                    break;
                case eVehicleType.Truck:
                    vehicleAttributes = Truck.InheritedObjectCreationList;

                    break;

                default:
                    vehicleAttributes = Vehicle.ObjectCreationList;
                    break;
            }

            return vehicleAttributes;
        }
    }
}
