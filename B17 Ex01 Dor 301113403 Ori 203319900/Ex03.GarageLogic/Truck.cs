using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private static readonly List<Tuple<Type, string>> s_InheritedObjectCreationList = new List<Tuple<Type, string>> {
            Tuple.Create(typeof(bool), "Does contain hazardous Material"),
            Tuple.Create(typeof(float), "Maximum load")
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

        public override string ToString()
        {
//            string str = String.Format(@"
//License Number: {0}
//Model Number: {1}
//Owner: {2},
//Status: {3},
//Wheels Data: {4},
//Gas Type: {5}
//", LicenceNumber, ModelName, Owner.toString(), Status, Wheel, EnergyTank.);
//            return str;
        }
    }
}
