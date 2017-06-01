using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public enum eStatus
    {
        InRepair,
        Repaired,
        Paid
    }

    public class Vehicle
    {

        private string m_ModelName;
        private string m_LicenceNumber;
        private EnergyTank m_EnergyTank;
        private List<Wheel> m_Wheels;
        private Owner m_Owner;
        private eStatus m_Status;

        public string ModelName { get => m_ModelName; }
        public string LicenceNumber { get => m_LicenceNumber; }
        public eStatus Status { get => m_Status; }

        public Vehicle(string i_ModelName, string i_LicenseNumber, eEnergySource i_EnergySource,
            float maxEnergyCapacity, string i_OwnerName, string i_OwnerPhone)
        {
            throw new System.Exception("Not implemented");
        }

        public void InflateWheelsToMax()
        {
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
    }
}
