using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private readonly Dictionary<string, Vehicle> m_Vehicles = null;

        public Dictionary<string, Vehicle> Vehicles { get => m_Vehicles; }

        public GarageManager()
        {
            m_Vehicles = new Dictionary<string, Vehicle>();
        }

        public void RegisterVehicle(eVehicleType i_VehicleType, Dictionary<eVehicleAttribute, object> i_VehicleData, out bool o_IsExist)
        {
            string licenseNumber = (string)i_VehicleData[eVehicleAttribute.LicenseNumber];
            if (o_IsExist = Vehicles.ContainsKey(licenseNumber))
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
            List<Tuple<Type, eVehicleAttribute>> vehicleAttributes = null;

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
            }

            vehicleAttributes.AddRange(Vehicle.ObjectCreationList);
            return vehicleAttributes;
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, eStatus i_NewStatus)
        {
            if (m_Vehicles.ContainsKey(i_LicenseNumber))
            {
                m_Vehicles[i_LicenseNumber].Status = i_NewStatus;
            }
            else
            {
                throw new ItemNotFoundException(i_LicenseNumber);
            }
        }

        public void InflateWheels(string i_LicenseNumber)
        {
            if (m_Vehicles.ContainsKey(i_LicenseNumber))
            {
                foreach (var wheel in m_Vehicles[i_LicenseNumber].Wheels)
                {
                    wheel.Inflate(wheel.MaxAirPressure - wheel.CurrAirPressure);
                }
            }
            else
            {
                throw new ItemNotFoundException(i_LicenseNumber);
            }
        }

        public void ChargeVehicle(string i_LicenseNumber, float i_MinutesToCharge)
        {
            if (m_Vehicles.ContainsKey(i_LicenseNumber))
            {
                m_Vehicles[i_LicenseNumber].FillEnergySource(i_MinutesToCharge, eEnergySource.Electric);
            }
            else
            {
                throw new ItemNotFoundException(i_LicenseNumber);
            }
        }

        public void FuelVehicle(string i_LicenseNumber, eEnergySource i_SelectedFuel, float i_Liters)
        {
            if (m_Vehicles.ContainsKey(i_LicenseNumber))
            {
                m_Vehicles[i_LicenseNumber].FillEnergySource(i_Liters, i_SelectedFuel);
            }
            else
            {
                throw new ItemNotFoundException(i_LicenseNumber);
            }
        }

        public Vehicle getVehicle(string i_LicenseNumber)
        {
            Vehicle vehicle = null;
            if (m_Vehicles.ContainsKey(i_LicenseNumber))
            {
                vehicle = m_Vehicles[i_LicenseNumber];
            }
            else
            {
                throw new ItemNotFoundException(i_LicenseNumber);
            }

            return vehicle;
        }
    }
}
