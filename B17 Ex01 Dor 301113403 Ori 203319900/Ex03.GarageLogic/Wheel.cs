using System;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_Manufacturer;
        private float m_MaxAirPressure;
        private float m_CurrAirPressure;

        public Wheel(string i_Manufacturer, float i_MaxAirPressure, float i_CurrAirPressure)
        {
            this.m_Manufacturer = i_Manufacturer;
            this.m_MaxAirPressure = i_MaxAirPressure;
            this.m_CurrAirPressure = i_CurrAirPressure;
        }

        public string Manufacturer { get => m_Manufacturer; }
        public float MaxAirPressure { get => m_MaxAirPressure; }
        public float CurrAirPressure { get => m_CurrAirPressure; }

        public void Inflate(float i_AddedAirVolume)
        {
           if(m_CurrAirPressure + i_AddedAirVolume <= m_MaxAirPressure)
            {
                m_CurrAirPressure += i_AddedAirVolume;
            }
           else
            {
                throw new InvalidOperationException("you can not inflate the tire more than its max capacity");
            }
        }
    }
}
