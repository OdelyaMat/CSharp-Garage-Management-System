using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GaragePrinter
    {
        public void PrintMainMenu()
        {
            Console.WriteLine("Garage Management System");
            Console.WriteLine("1. Load vehicles from file");
            Console.WriteLine("2. Insert vehicle to garage");
            Console.WriteLine("3. Show license IDs");
            Console.WriteLine("4. Change vehicle status");
            Console.WriteLine("5. Inflate vehicle wheels to max");
            Console.WriteLine("6. Refuel vehicle");
            Console.WriteLine("7. Charge electric vehicle");
            Console.WriteLine("8. Show full vehicle details");
            Console.WriteLine("9. Exit");
        }

        public void PrintLicenseIDs(List<string> i_LicenseIDs)
        {
            foreach (string licenseID in i_LicenseIDs)
            {
                Console.WriteLine(licenseID);
            }
        }

        // $G$ DSN-002 (-5) The UI layer should not know any of the internal properties or structure of a Vehicle. 
        // Instead, individual components should override 'ToString()' to handle their own 
        // string representation, which the UI can simply fetch and print.
        public void PrintFullVehicleDetails(GarageVehicle i_GarageVehicle)
        {
            Vehicle vehicle = i_GarageVehicle.Vehicle;

            Console.WriteLine("License ID: {0}", vehicle.LicenseID);
            Console.WriteLine("Model name: {0}", vehicle.ModelName);
            Console.WriteLine("Owner name: {0}", i_GarageVehicle.OwnerName);
            Console.WriteLine("Owner phone: {0}", i_GarageVehicle.OwnerPhone);
            Console.WriteLine("Garage status: {0}", i_GarageVehicle.Status);
            Console.WriteLine("Energy percentage: {0}%", vehicle.EnergyPercentage);

            printWheels(vehicle);
            printEnergyDetails(vehicle);
            printSpecificVehicleDetails(vehicle);
        }

        private void printWheels(Vehicle i_Vehicle)
        {
            Console.WriteLine("Wheels:");

            for (int i = 0; i < i_Vehicle.Wheels.Count; i++)
            {
                Wheel wheel = i_Vehicle.Wheels[i];

                Console.WriteLine("Wheel {0}: manufacturer: {1}, air pressure: {2}/{3}", i + 1, wheel.ManufacturerName,
                    wheel.CurrentAirPressure, wheel.MaxAirPressure);
            }
        }

        private void printEnergyDetails(Vehicle i_Vehicle)
        {
            FuelEnergy fuelEnergy = i_Vehicle.EnergySource as FuelEnergy;
            ElectricEnergy electricEnergy = i_Vehicle.EnergySource as ElectricEnergy;

            if (fuelEnergy != null)
            {
                Console.WriteLine("Fuel type: {0}", fuelEnergy.FuelType);
                Console.WriteLine("Current fuel amount: {0}/{1}", fuelEnergy.CurrentAmount, fuelEnergy.MaxAmount);
            }
            else if (electricEnergy != null)
            {
                Console.WriteLine("Current battery time: {0}/{1}", electricEnergy.CurrentAmount, electricEnergy.MaxAmount);
            }
        }

        private void printSpecificVehicleDetails(Vehicle i_Vehicle)
        {
            Car car = i_Vehicle as Car;
            Motorcycle motorcycle = i_Vehicle as Motorcycle;
            Truck truck = i_Vehicle as Truck;

            if (car != null)
            {
                Console.WriteLine("Car color: {0}", car.CarColor);
                Console.WriteLine("Number of doors: {0}", car.NumOfDoors);
            }
            else if (motorcycle != null)
            {
                Console.WriteLine("License type: {0}", motorcycle.LicenseType);
                Console.WriteLine("Engine volume: {0}", motorcycle.EngineVolume);
            }
            else if (truck != null)
            {
                Console.WriteLine("Is carrying refrigerated cargo: {0}", truck.IsCarryingRefrigeratedCargo);
                Console.WriteLine("Cargo volume: {0}", truck.CargoVolume);
            }
        }
    }
}