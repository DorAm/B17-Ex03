using System;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_IsHazMat;
        private float m_MaxLoad;

        public Truck(string i_ModelName, string i_LicenseNumber, eEnergySource i_EnergySource, float maxEnergyCapacity,
                     string i_OwnerName, string i_OwnerPhone, bool i_IsHazMat, float i_MaxLoad)
        : base(i_ModelName, i_LicenseNumber, i_EnergySource, maxEnergyCapacity, i_OwnerName, i_OwnerPhone)
        {
            this.m_IsHazMat = i_IsHazMat;
            this.m_MaxLoad = i_MaxLoad;
        }

        public bool IsHazMat { get => m_IsHazMat; }
        public float MaxLoad { get => m_MaxLoad; }
    }
}
