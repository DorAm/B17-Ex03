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

        public eEnergySource GetM_EnergySource()
        {
            return this.m_EnergySource;
        }
        public void FillEnergySource(ref object float_, ref object eEnergySource)
        {
            throw new System.Exception("Not implemented");
        }
        public EnergyTank(ref object eEnergySource, ref object float_)
        {
            throw new System.Exception("Not implemented");
        }
        public float GetM_MaxEnergyCapacity()
        {
            return this.m_MaxEnergyCapacity;
        }
    }
}
