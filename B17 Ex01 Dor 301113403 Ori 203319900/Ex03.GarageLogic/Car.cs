using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public enum eColor
    {
        Yellow,
        White,
        Black,
        Blue
    }

    public sealed class Car : Vehicle
    {
        private static readonly List<Tuple<Type, eVehicleAttribute>> s_InheritedObjectCreationList = new List<Tuple<Type, eVehicleAttribute>>
        {
            Tuple.Create(typeof(eColor), eVehicleAttribute.Color),
            Tuple.Create(typeof(float), eVehicleAttribute.NumOfDoors)
        };

        private const int k_NumOfWheels = 4;
        private eColor m_Color;
        private int m_NumOfDoors;
        
        public static List<Tuple<Type, eVehicleAttribute>> InheritedObjectCreationList { get => s_InheritedObjectCreationList; }
        public eColor Color { get => m_Color; }
        public int NumOfDoors { get => m_NumOfDoors; }

        public Car(string i_ModelName, string i_LicenseNumber, eEnergySource i_EnergySource,
            float i_MaxEnergyCapacity, float i_CurrEnergyStatus, string i_WheelManufaturer,
            float i_MaxAirPressure, float i_CurrAirPressure, string i_OwnerName, string i_OwnerPhone, eColor i_Color, int i_NumOfDoors)
        : base(i_ModelName, i_LicenseNumber, i_EnergySource, i_MaxEnergyCapacity, i_CurrEnergyStatus, i_WheelManufaturer,
            i_MaxAirPressure, i_CurrAirPressure, i_OwnerName, i_OwnerPhone)
        {
            this.m_Color = i_Color;
            this.m_NumOfDoors = i_NumOfDoors;
        }

        public Car(Dictionary<eVehicleAttribute, object> i_VehicleAttributs) : base
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
            for (int i = 0; i < k_NumOfWheels; i++)
            {
                this.Wheels.Add(new Wheel((string)i_VehicleAttributs[eVehicleAttribute.WheelManufacturer],
                    (float)i_VehicleAttributs[eVehicleAttribute.WheelMaxAirPressure],
                    (float)i_VehicleAttributs[eVehicleAttribute.WheelCurrentAirPressure]));
            }

            m_Color = (eColor)i_VehicleAttributs[eVehicleAttribute.Color];
            m_NumOfDoors = (int)i_VehicleAttributs[eVehicleAttribute.NumOfDoors];
        }

    }
}
