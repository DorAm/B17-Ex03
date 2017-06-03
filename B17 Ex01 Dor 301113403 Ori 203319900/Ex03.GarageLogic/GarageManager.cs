using System;
using System.Collections.Generic;
using System.Reflection;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private List<Vehicle> m_Vehicles = new List<Vehicle>()
        {
            new Vehicle("Mazda", "L125215", eEnergySource.Electric, 100, 60, "Dor", "104215"),
            new Vehicle("Pegueot", "L56458", eEnergySource.Octan95, 120, 60, "Ori", "23906832"),
            new Vehicle("Fiat", "L51205809", eEnergySource.Soler, 1000, 650, "Dana", "01285125"),
            new Vehicle("Subaru", "L238512", eEnergySource.Octan98, 1000, 1, "Greg", "0582951")
        };
        public List<Vehicle> Vehicles { get => m_Vehicles; }
    
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
                    continue;
                }

                Tuple<Type, string> requestedAttribute = new Tuple<Type, string>(member.FieldType, member.Name);
                io_VehicleAttributes.Add(requestedAttribute);
            }

        }
        
    }
}
