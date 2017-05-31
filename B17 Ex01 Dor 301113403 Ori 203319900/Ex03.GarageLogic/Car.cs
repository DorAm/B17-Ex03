using System;

namespace Ex03.GarageLogic
{
    public enum eColor
    {
        Yellow,
        White,
        Black,
        Blue
    }

    public class Car : Vehicle
    {
        private eColor m_Color;
        private int m_NumOfDoors;

        public Car(string i_ModelName, string i_LicenseNumber, eEnergySource i_EnergySource, float maxEnergyCapacity, string i_OwnerName,
                   string i_OwnerPhone, eColor i_Color, int i_NumOfDoors)
        : base(i_ModelName, i_LicenseNumber, i_EnergySource, maxEnergyCapacity, i_OwnerName, i_OwnerPhone)
        {
            this.m_Color = i_Color;
            this.m_NumOfDoors = i_NumOfDoors;
        }

        public eColor Color { get => m_Color; }
        public int NumOfDoors { get => m_NumOfDoors; }
    }
}
