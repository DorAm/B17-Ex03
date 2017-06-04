using System;
using System.Collections.Generic;
using System.Reflection;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private Dictionary<string,Vehicle> m_Vehicles = null;

        public GarageManager()
        {

        }

        public void RegisterVehicle(eVehicleType i_VehicleType ,Dictionary<eVehicleAttribute, object> i_VehicleData)
        {
            string licenseNumber = (string)i_VehicleData[eVehicleAttribute.LicenseNumber];
            if (m_Vehicles.ContainsKey(licenseNumber))
            {
                m_Vehicles[licenseNumber].Status = eStatus.InRepair;
            }
            else
            {
                m_Vehicles.Add(licenseNumber, VehicleFactory.BuildNewVehicle(i_VehicleType, i_VehicleData));
            }
        }

        public List<Tuple<Type, eVehicleAttribute>> GetVehicleAttributes(eVehicleType i_VehicleType)
        {
            List<Tuple<Type, eVehicleAttribute>> vehicleAttributes;

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
