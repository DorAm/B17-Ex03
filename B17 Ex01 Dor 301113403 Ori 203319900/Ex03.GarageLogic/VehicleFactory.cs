using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public enum eVehicleType
    {
        Car,
        Motorcycle,
        Truck
    }

    public enum eSupportedVehicle
    {
        RregularBike,
        ElectricBike,
        RegularCar,
        ElectricCar,
        Truck
    }

    public class VehicleFactory
    {
        public Vehicle BuildNewVehicle(eSupportedVehicle i_Type, Dictionary<string,object> i_VehicleAttributs)
        {
            switch (i_Type)
            {
                case eSupportedVehicle.RregularBike:

                    break;
                case eSupportedVehicle.ElectricBike:
                    break;
                case eSupportedVehicle.RegularCar:
                    break;
                case eSupportedVehicle.ElectricCar:
                    break;
                case eSupportedVehicle.Truck:
                    break;
                default:
                    break;
            }

            Vehicle dummy = new Vehicle();
            return dummy;
        }
        
        new Truck(Inputs[m_Tpe], input[])
    }
}
