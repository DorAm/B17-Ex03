using System;
using System.Collections.Generic;
using System.Reflection;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private List<Vehicle> m_Vehicles = null;

        public GarageManager()
        {

        }

        //public List<Tuple<string, string>> GetVehicleAttributes(eVehicleType i_VehicleType)
        //{
        //    List<Tuple<Type, string>> vehicleAttributes = new List<Tuple<Type, string>>();
        //    Type vehicleType = Type.GetType(i_VehicleType.ToString());
        //    FieldInfo[] vehicleMembers = vehicleType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

        //    foreach (var member in vehicleMembers)
        //    {

        //        Console.Write("{0}", member.Name);
        //        //Tuple<Type, string> requestedAttribute = new Tuple<var, var>(member.FieldType, member.Name);

        //    }
        //}
    }
}
