using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MinValue;
        private float m_MaxValue;

        // Getters & Setters
        public float MinValue { get => m_MinValue; set => value = m_MinValue; }
        public float MaxValue { get => m_MaxValue; set => value = m_MaxValue; }

        // Ctor
        public ValueOutOfRangeException(Exception i_InnerException, float i_MinValue, float i_MaxValue)
            : base(string.Format("Error: Please supply a valid value from {0} to {1}", i_MinValue, i_MaxValue), i_InnerException)
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }
    }
}
