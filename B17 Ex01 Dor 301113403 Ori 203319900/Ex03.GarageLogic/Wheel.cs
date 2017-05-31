using System;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_Manufacturer;
        private float m_MaxAirPressure;
        private float m_CurrAirPressure;

        public Wheel(string i_Manufacturer, float i_MaxAirPressure)
        {
            this.m_Manufacturer = i_Manufacturer;
            this.m_MaxAirPressure = i_MaxAirPressure;
            this.m_CurrAirPressure = this.m_MaxAirPressure;
        }

        public string Manufacturer { get => m_Manufacturer; }
        public float MaxAirPressure { get => m_MaxAirPressure; }
        public float CurrAirPressure { get => m_CurrAirPressure; }

        public void Inflate(ref object float_)
        {
            throw new System.Exception("Not implemented");
        }
    }
}
