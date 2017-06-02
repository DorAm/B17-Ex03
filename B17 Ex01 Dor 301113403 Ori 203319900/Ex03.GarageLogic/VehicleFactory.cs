using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public enum eVehicleType
    {
        RregularBike,
        ElectricBike,
        RegularCar,
        ElectricCar,
        Truck
    }
    public class VehicleFactory
    {
        public Vehicle BuildNewVehicle(eVehicleType i_Type, Dictionary<string,object> i_VehicleAttributs)
        {
            switch (i_Type)
            {
                case eVehicleType.RregularBike:

                    break;
                case eVehicleType.ElectricBike:
                    break;
                case eVehicleType.RegularCar:
                    break;
                case eVehicleType.ElectricCar:
                    break;
                case eVehicleType.Truck:
                    break;
                default:
                    break;
            }

            Vehicle dummy = new Vehicle();
            return dummy;
        }
    }
}
