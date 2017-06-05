using System;

namespace Ex03.GarageLogic
{
    public enum eEnergySource
    {
        Soler,
        Octan95,
        Octan96,
        Octan98,
        Electric
    }

    public class EnergyTank
    {

        private eEnergySource m_EnergySource;
        private float m_MaxEnergyCapacity;
        private float m_CurrEnergyStatus;

        public eEnergySource EnergySource { get => m_EnergySource; }
        public float MaxEnergyCapacity { get => m_MaxEnergyCapacity; }
        public float CurrEnergyStatus { get => m_CurrEnergyStatus; set => m_CurrEnergyStatus = value; }

        public void FillEnergySource(float i_EnergyAmountToAdd, eEnergySource i_EnergySource)
        {
            if (CurrEnergyStatus + i_EnergyAmountToAdd <= MaxEnergyCapacity)
            {
                CurrEnergyStatus += i_EnergyAmountToAdd;
            }
            else
            {
                throw new InvalidOperationException("you can not charge/fuel a vehicle more than its max capacity");
            }
        }
        public EnergyTank(eEnergySource i_EnergySource, float i_MaxEnergyCapacity, float i_m_CurrEnergyStatus)
        {
            m_EnergySource = i_EnergySource;
            m_MaxEnergyCapacity = i_MaxEnergyCapacity;
            CurrEnergyStatus = i_m_CurrEnergyStatus;
        }
    }
}
