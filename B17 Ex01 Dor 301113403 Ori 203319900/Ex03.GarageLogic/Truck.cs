using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private static readonly List<Tuple<Type, eVehicleAttribute>> s_InheritedObjectCreationList = new List<Tuple<Type, eVehicleAttribute>> {
            Tuple.Create(typeof(bool), eVehicleAttribute.IsHazmat),
            Tuple.Create(typeof(float), eVehicleAttribute.MaxLoad)
        };

        private bool m_IsHazMat;
        private float m_MaxLoad;

        public Truck(Dictionary<eVehicleAttribute, object> i_VehicleAttributs) : base((string)i_VehicleAttributs[eVehicleAttribute.ModelName], (string)i_VehicleAttributs[eVehicleAttribute.LicenseNumber],
            (eEnergySource)i_VehicleAttributs[eVehicleAttribute.EnergySource], (float)i_VehicleAttributs[eVehicleAttribute.MaxEnergyCapacity],
            (float)i_VehicleAttributs[eVehicleAttribute.CurrentEnergyStatus],
            (string)i_VehicleAttributs[eVehicleAttribute.WheelManufacturer],
            (float)i_VehicleAttributs[eVehicleAttribute.WheelMaxAirPressure],
            (float)i_VehicleAttributs[eVehicleAttribute.WheelCurrentAirPressure], (string)i_VehicleAttributs[eVehicleAttribute.OwnerName], (string)i_VehicleAttributs[eVehicleAttribute.OwnerPhoneNumber])
        {
            m_IsHazMat = (bool)i_VehicleAttributs[eVehicleAttribute.IsHazmat];
            m_MaxLoad = (float)i_VehicleAttributs[eVehicleAttribute.MaxLoad];
        }

        public Truck(string i_ModelName, string i_LicenseNumber, eEnergySource i_EnergySource,
            float i_MaxEnergyCapacity, float i_CurrEnergyStatus, string i_WheelManufaturer,
            float i_MaxAirPressure, float i_CurrAirPressure, string i_OwnerName, string i_OwnerPhone, bool i_IsHazMat, float i_MaxLoad)
        : base(i_ModelName, i_LicenseNumber, i_EnergySource, i_MaxEnergyCapacity, i_CurrEnergyStatus, i_WheelManufaturer,
            i_MaxAirPressure, i_CurrAirPressure, i_OwnerName, i_OwnerPhone)
        {
            this.m_IsHazMat = i_IsHazMat;
            this.m_MaxLoad = i_MaxLoad;
        }

        public static List<Tuple<Type, eVehicleAttribute>> InheritedObjectCreationList { get => s_InheritedObjectCreationList; }
        public bool IsHazMat { get => m_IsHazMat; }
        public float MaxLoad { get => m_MaxLoad; }
    }
}
