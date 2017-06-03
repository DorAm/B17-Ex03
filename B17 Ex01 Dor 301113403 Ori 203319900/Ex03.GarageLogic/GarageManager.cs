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

        public List<Tuple<Type, string>> GetVehicleAttributes(eVehicleType i_VehicleType)
        {
            List<Tuple<Type, string>> vehicleAttributes = new List<Tuple<Type, string>>();
            Type vehicleActualType = Type.GetType("Ex03.GarageLogic." + i_VehicleType.ToString());
            FieldInfo[] vehicleMembers = vehicleActualType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var member in vehicleMembers)
            {

                Console.Write("{0}", member.Name);
                Tuple<Type, string> requestedAttribute = new Tuple<Type, string>(member.FieldType, member.Name);
                vehicleAttributes.Add(requestedAttribute);
            }

            return vehicleAttributes;
        }
    }
}
