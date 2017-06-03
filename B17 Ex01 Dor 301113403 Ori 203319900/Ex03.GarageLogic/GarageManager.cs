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
            createMembersList(vehicleActualType, ref vehicleAttributes);
            createMembersList(typeof(Vehicle), ref vehicleAttributes);

            return vehicleAttributes;
        }

        private void createMembersList(Type i_VehicleActualType, ref List<Tuple<Type, string>> io_VehicleAttributes)
        {
            FieldInfo[] vehicleMembers = i_VehicleActualType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var member in vehicleMembers)
            {
                Type memberType = member.FieldType;
                if (memberType.Name == "EnergyTank" || memberType.Name == "Owner" || memberType.Name == "Wheel")
                {
                    createMembersList(memberType, ref io_VehicleAttributes);
                }

                Tuple<Type, string> requestedAttribute = new Tuple<Type, string>(member.FieldType, member.Name);
                io_VehicleAttributes.Add(requestedAttribute);
            }

        }
    }
}
