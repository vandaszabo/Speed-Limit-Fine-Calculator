using Codecool.SpeedLimitFineCalculator.Model;

namespace Codecool.SpeedLimitFineCalculator.Service
{
    public class SpeedLimitValue : IVehicleLimitCalculator
    {
        public int GetVehicleLimitByRoadType(VehicleType vehicleType, RoadType roadType)
        {
            switch (vehicleType)
            {
                case VehicleType.Car:
                    switch (roadType)
                    {
                        case RoadType.Urban: return 50;
                        case RoadType.MainRoad: return 90;
                        case RoadType.Highway: return 130;
                    }
                    break;
                case VehicleType.Bus:
                    switch (roadType)
                    {
                        case RoadType.Urban: return 50;
                        case RoadType.MainRoad: return 70;
                        case RoadType.Highway: return 100;
                    }
                    break;
                case VehicleType.Truck:
                    switch (roadType)
                    {
                        case RoadType.Urban: return 50;
                        case RoadType.MainRoad: return 70;
                        case RoadType.Highway: return 80;
                    }
                    break;
            }

            throw new ArgumentException("Invalid vehicle type or road type.");
        }
    }
}
