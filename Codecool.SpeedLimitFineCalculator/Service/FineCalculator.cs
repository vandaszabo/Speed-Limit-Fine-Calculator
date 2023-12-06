using Codecool.SpeedLimitFineCalculator.Model;

namespace Codecool.SpeedLimitFineCalculator.Service
{
    public class FineCalculator : ISpeedLimitFineCalculator
    {
        private readonly IVehicleLimitCalculator _vehicleLimitCalculator;

        public FineCalculator(IVehicleLimitCalculator vehicleLimitCalculator)
        {
            _vehicleLimitCalculator = vehicleLimitCalculator;
        }

        public double CalculateSpeedLimitFine(VehicleType vehicleType, RoadType roadType, double actualSpeed)
        {
            int speedLimit = _vehicleLimitCalculator.GetVehicleLimitByRoadType(vehicleType, roadType);

            if (actualSpeed >= speedLimit)
            {
                double fine = (actualSpeed - speedLimit) * 1000 + 30000;
                return fine;
            }
            else
            {
                return 0;
            }
        }
    }
}
