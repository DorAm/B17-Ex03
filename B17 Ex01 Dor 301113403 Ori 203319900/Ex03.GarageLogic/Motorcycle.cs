using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public enum eLicenseType
    {
        A,
        AB,
        A2,
        B1
    }

    public class Motorcycle : Vehicle
    {
        private eLicenseType m_LicenseType;
        private float m_EngineVolume;
        private static readonly List<Tuple<Type, string>> s_InheritedObjectCreationList = new List<Tuple<Type, string>> {
            Tuple.Create(typeof(eLicenseType), "License Type"),
            Tuple.Create(typeof(float), "Engine Volume")
        };

        public Motorcycle(string i_ModelName, string i_LicenseNumber, eEnergySource i_EnergySource, float maxEnergyCapacity, float i_CurrEnsergyStatus,
                          string i_OwnerName, string i_OwnerPhone, eLicenseType i_LicenseType, float i_EngineVolume)
        : base(i_ModelName, i_LicenseNumber, i_EnergySource, maxEnergyCapacity, i_CurrEnsergyStatus, i_OwnerName, i_OwnerPhone)
        {
            this.m_LicenseType = i_LicenseType;
            this.m_EngineVolume = i_EngineVolume;
        }

        public eLicenseType LicenseType { get => m_LicenseType; }
        public float EngineVolume { get => m_EngineVolume; }
    }
}
