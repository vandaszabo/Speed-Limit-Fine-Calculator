using System;
using Codecool.SpeedLimitFineCalculator.Model;
using Codecool.SpeedLimitFineCalculator.Service;

namespace Codecool.SpeedLimitFineCalculator.UI
{
    public class FineCalculatorUi
    {
        private readonly ISpeedLimitFineCalculator _speedLimitFineCalculator;

        public FineCalculatorUi(ISpeedLimitFineCalculator speedLimitFineCalculator)
        {
            _speedLimitFineCalculator = speedLimitFineCalculator;
        }

        public void Run()
        {
            GreetUser();

            var vehicleTypeEnum = SelectVehicleType();
            var roadTypeEnum = SelectRoadType();
            var speed = GetSpeed();

            double fine = _speedLimitFineCalculator.CalculateSpeedLimitFine(vehicleTypeEnum, roadTypeEnum, speed);

            if (fine == 0)
            {
                Console.WriteLine("You are within speed limits! No fine applies.");
            }
            else
            {
                Console.WriteLine($"Your fine is {fine} CodeCoins :(");
            }
        }

        private static VehicleType SelectVehicleType()
        {
            Console.WriteLine("Please select a vehicle type:");
            Console.WriteLine("1. Car");
            Console.WriteLine("2. Truck");
            Console.WriteLine("3. Bus");

            while (true)
            {
                Console.Write("Enter the number corresponding to your choice: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 3)
                {
                    return (VehicleType)(choice - 1);
                }

                Console.WriteLine("Invalid input. Please enter a valid number from 1 to 3.");
            }
        }

        private static RoadType SelectRoadType()
        {
            Console.WriteLine("Please select a road type:");
            Console.WriteLine("1. Urban");
            Console.WriteLine("2. MainRoad");
            Console.WriteLine("3. Highway");

            while (true)
            {
                Console.Write("Enter the number corresponding to your choice: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 3)
                {
                    return (RoadType)(choice - 1);
                }

                Console.WriteLine("Invalid input. Please enter a valid number from 1 to 3.");
            }
        }

        private static int GetSpeed()
        {
            Console.WriteLine("Please enter the speed:");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int speed))
            {
                return speed;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid speed.");
                return GetSpeed();
            }
        }

        private static void GreetUser()
        {
            Console.WriteLine(
                "Hi! You were on the road again, but you were a bit too fast, weren't you? No worries, let's see how much it will cost you!");
        }
    }
}
