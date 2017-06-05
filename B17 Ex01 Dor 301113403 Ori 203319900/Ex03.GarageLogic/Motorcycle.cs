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

    public sealed class Motorcycle : Vehicle
    {
        private eLicenseType m_LicenseType;
        private float m_EngineVolume;
        private static readonly List<Tuple<Type, eVehicleAttribute>> s_InheritedObjectCreationList = new List<Tuple<Type, eVehicleAttribute>>
        {
            Tuple.Create(typeof(eLicenseType), eVehicleAttribute.LicenseType),
            Tuple.Create(typeof(float), eVehicleAttribute.EngineVolume)
        };
        private Dictionary<string, object> i_VehicleAttributs;
        private const int k_NumOfWheels = 2;

        public Motorcycle(string i_ModelName, string i_LicenseNumber, eEnergySource i_EnergySource,
            float i_MaxEnergyCapacity, float i_CurrEnergyStatus, string i_WheelManufaturer,
            float i_MaxAirPressure, float i_CurrAirPressure, string i_OwnerName,
            string i_OwnerPhone, eLicenseType i_LicenseType, float i_EngineVolume)
        : base(i_ModelName, i_LicenseNumber, i_EnergySource, i_MaxEnergyCapacity, i_CurrEnergyStatus, i_WheelManufaturer,
            i_MaxAirPressure, i_CurrAirPressure, i_OwnerName, i_OwnerPhone)
        {

            this.m_LicenseType = i_LicenseType;
            this.m_EngineVolume = i_EngineVolume;
        }

        public Motorcycle(Dictionary<eVehicleAttribute, object> i_VehicleAttributs) : base
            ((string)i_VehicleAttributs[eVehicleAttribute.ModelName], 
            (string)i_VehicleAttributs[eVehicleAttribute.LicenseNumber],
            (eEnergySource)i_VehicleAttributs[eVehicleAttribute.EnergySource], 
            (float)i_VehicleAttributs[eVehicleAttribute.MaxEnergyCapacity],
            (float)i_VehicleAttributs[eVehicleAttribute.CurrentEnergyStatus],
            (string)i_VehicleAttributs[eVehicleAttribute.WheelManufacturer],
            (float)i_VehicleAttributs[eVehicleAttribute.WheelMaxAirPressure],
            (float)i_VehicleAttributs[eVehicleAttribute.WheelCurrentAirPressure], 
            (string)i_VehicleAttributs[eVehicleAttribute.OwnerName], 
            (string)i_VehicleAttributs[eVehicleAttribute.OwnerPhoneNumber])
        {
            try
            {
                for (int i = 0; i < k_NumOfWheels; i++)
                {
                    this.Wheels.Add(new Wheel((string)i_VehicleAttributs[eVehicleAttribute.WheelManufacturer],
                        (float)i_VehicleAttributs[eVehicleAttribute.WheelMaxAirPressure],
                        (float)i_VehicleAttributs[eVehicleAttribute.WheelCurrentAirPressure]));
                }
                m_EngineVolume = (float)i_VehicleAttributs[eVehicleAttribute.EngineVolume];
                m_LicenseType = (eLicenseType)i_VehicleAttributs[eVehicleAttribute.LicenseType];
            }
            catch(Exception ex)
            {
                throw new ArgumentNullException("one or more of the Motorcycle   properties have failed to init", ex.InnerException);
            }
        }

        public static List<Tuple<Type, eVehicleAttribute>> InheritedObjectCreationList { get => s_InheritedObjectCreationList;  }
        public eLicenseType LicenseType { get => m_LicenseType; }
        public float EngineVolume { get => m_EngineVolume; }
    }
}
