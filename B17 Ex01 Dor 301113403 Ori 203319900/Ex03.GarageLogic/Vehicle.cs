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
        private string m_ModelName;
        private string m_LicenceNumber;
        private EnergyTank m_EnergyTank;
        private List<Wheel> m_Wheels;
        private Owner m_Owner;
        private eStatus m_Status;
        private static readonly List<Tuple<Type, string>> s_ObjectCreationList = new List<Tuple<Type, string>>
        {
            Tuple.Create(typeof(string), "model name"),
            Tuple.Create(typeof(string), "License Number"),
            Tuple.Create(typeof(string), "License Number"),
            Tuple.Create(typeof(eEnergySource), "Energy Source"),
            Tuple.Create(typeof(float), "Max Energy Capacity"),
            Tuple.Create(typeof(float), "Current energy status"),
            Tuple.Create(typeof(string), "Owner name"),
            Tuple.Create(typeof(string), "Owner Phone Number")
        };

        public string ModelName { get => m_ModelName; }
        public string LicenceNumber { get => m_LicenceNumber; }
        public eStatus Status { get => m_Status; set => m_Status = value; }        

        public Vehicle(string i_ModelName, string i_LicenseNumber, eEnergySource i_EnergySource,
            float i_MaxEnergyCapacity, float i_CurrEnergyStatus, string i_OwnerName, string i_OwnerPhone)
        {
            m_ModelName = i_ModelName;
            m_LicenceNumber = i_LicenseNumber;
            m_EnergyTank = new EnergyTank(i_EnergySource, i_MaxEnergyCapacity, i_CurrEnergyStatus);
            m_Wheels = new List<Wheel>();
            m_Owner = new Owner(i_OwnerName, i_OwnerPhone);
            m_Status = eStatus.InRepair;
        }


        public void InflateWheelsToMax()
        {

            foreach (Wheel item in m_Wheels)
            {
                float airToAdd = item.MaxAirPressure - item.CurrAirPressure;
                item.Inflate(airToAdd);
            }

        }

        public void FillEnergySource(float i_EnergyAmount, eEnergySource i_EnergySource)
        {

        }

        public eEnergySource getEnergyType()
        {
            return eEnergySource.Electric;
        }

        public float getMaxEnergy()
        {
            return 1;
        }

        public float getEnergyStatus()
        {

            return 1;
        }

        public abstract override string ToString();
    }

    public class failedToInflateException : Exception
    {
        int m_WheelIdx;

        public failedToInflateException() { }
        public failedToInflateException(string i_message, int i_WheelIdx) : base(i_message)
        {
            m_WheelIdx = i_WheelIdx;
        }
    }


}
