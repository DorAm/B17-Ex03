using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public enum eStatus
    {
        InRepair = 1,
        Repaired,
        Paid
    }

    public abstract class Vehicle
    {
        private static readonly List<Tuple<Type, eVehicleAttribute>> s_ObjectCreationList = new List<Tuple<Type, eVehicleAttribute>>
        {
            Tuple.Create(typeof(string), eVehicleAttribute.ModelName),
            Tuple.Create(typeof(string), eVehicleAttribute.LicenseNumber),
            Tuple.Create(typeof(eEnergySource), eVehicleAttribute.EnergySource),
            Tuple.Create(typeof(float), eVehicleAttribute.MaxEnergyCapacity),
            Tuple.Create(typeof(float), eVehicleAttribute.CurrentEnergyStatus),
            Tuple.Create(typeof(string), eVehicleAttribute.WheelManufacturer),
            Tuple.Create(typeof(float), eVehicleAttribute.WheelMaxAirPressure),
            Tuple.Create(typeof(float), eVehicleAttribute.WheelCurrentAirPressure),
            Tuple.Create(typeof(string), eVehicleAttribute.OwnerName),
            Tuple.Create(typeof(string), eVehicleAttribute.OwnerPhoneNumber)
        };

        private readonly string m_ModelName;
        private readonly string m_LicenceNumber;
        private readonly EnergyTank m_EnergyTank;
        private List<Wheel> m_Wheels;
        private readonly Owner m_Owner;
        private eStatus m_Status;

        public static List<Tuple<Type, eVehicleAttribute>> ObjectCreationList { get => s_ObjectCreationList; }

        public string ModelName { get => m_ModelName; }

        public string LicenceNumber { get => m_LicenceNumber; }

        public eStatus Status { get => m_Status; set => m_Status = value; }

        public List<Wheel> Wheels { get => m_Wheels; set => m_Wheels = value; }

        public Owner Owner { get => m_Owner; }

        public Vehicle(string i_ModelName, string i_LicenseNumber, eEnergySource i_EnergySource, float i_MaxEnergyCapacity, float i_CurrEnergyStatus, string i_OwnerName, string i_OwnerPhone)
        {
            m_ModelName = i_ModelName;
            m_LicenceNumber = i_LicenseNumber;
            m_EnergyTank = new EnergyTank(i_EnergySource, i_MaxEnergyCapacity, i_CurrEnergyStatus);
            Wheels = new List<Wheel>();
            m_Owner = new Owner(i_OwnerName, i_OwnerPhone);
            m_Status = eStatus.InRepair;
        }

        public void InflateWheelsToMax()
        {
            foreach (Wheel item in Wheels)
            {
                float airToAdd = item.MaxAirPressure - item.CurrAirPressure;
                item.Inflate(airToAdd);
            }
        }

        public void FillEnergySource(float i_EnergyAmount, eEnergySource i_EnergySource)
        {
            if (i_EnergyAmount + m_EnergyTank.CurrEnergyStatus <= m_EnergyTank.MaxEnergyCapacity && i_EnergySource == m_EnergyTank.EnergySource)
            {
                m_EnergyTank.CurrEnergyStatus = i_EnergyAmount;
            }
            else
            {
                throw new ArgumentException("invalid energy source or amount has been provided");
            }
        }

        public eEnergySource getEnergyType()
        {
            return m_EnergyTank.EnergySource;
        }

        public float getMaxEnergy()
        {
            return m_EnergyTank.MaxEnergyCapacity;
        }

        public float getEnergyStatus()
        {
            return m_EnergyTank.CurrEnergyStatus;
        }
    }
}
