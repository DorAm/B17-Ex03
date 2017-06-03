using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private static readonly List<Tuple<Type, string>> m_ObjectCreationList = new List<Tuple<Type, string>>
        { Tuple.Create(typeof(string), "model name"), Tuple.Create(typeof(string), "License Number"), Tuple.Create(typeof(string), "License Number"), Tuple.Create(typeof(eEnergySource), "Energy Source"),
           Tuple.Create(typeof(float), "Max Energy Capacity"), Tuple.Create(typeof(float), "Current energy status"), Tuple.Create(typeof(string), "Owner name"), Tuple.Create(typeof(string), "Owner Phone Number"),
           Tuple.Create(typeof(bool), "Does contain hazardous Material")), Tuple.Create(typeof(float), "Maximum load")
           };
        private bool m_IsHazMat;
        private float m_MaxLoad;

        public Truck(string i_ModelName, string i_LicenseNumber, eEnergySource i_EnergySource, float maxEnergyCapacity, float i_CurrEnsergyStatus,
                     string i_OwnerName, string i_OwnerPhone, bool i_IsHazMat, float i_MaxLoad)
        : base(i_ModelName, i_LicenseNumber, i_EnergySource, maxEnergyCapacity, i_CurrEnsergyStatus, i_OwnerName, i_OwnerPhone)
        {
            this.m_IsHazMat = i_IsHazMat;
            this.m_MaxLoad = i_MaxLoad;
        }

        public bool IsHazMat { get => m_IsHazMat; }
        public float MaxLoad { get => m_MaxLoad; }
    }
}
