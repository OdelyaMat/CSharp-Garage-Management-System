using System;
using System.IO;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    // $G$ DSN-002 (-5) This class should be in the Logic project. It is a logic layer responsibilities to load data from a DB.
    public class VehicleFileLoader
    {
        private readonly GarageManager r_GarageManager;

        public VehicleFileLoader(GarageManager i_GarageManager)
        {
            r_GarageManager = i_GarageManager;
        }

        public void LoadVehiclesFromFile(string i_FileName)
        {
            string[] lines = File.ReadAllLines(i_FileName);

            foreach (string line in lines)
            {
                if (line.StartsWith("*****"))
                {
                    break;
                }

                loadVehicleFromLine(line);
            }
        }

        private void loadVehicleFromLine(string i_Line)
        {
            string[] parts = i_Line.Split(',');

            string vehicleType = parts[0];
            string licenseID = parts[1];
            string modelName = parts[2];
            float energyPercentage = float.Parse(parts[3]);
            string wheelManufacturer = parts[4];
            float currentAirPressure = float.Parse(parts[5]);
            string ownerName = parts[6];
            string ownerPhone = parts[7];

            Vehicle vehicle = VehicleCreator.CreateVehicle(vehicleType, licenseID, modelName);

            initializeVehicle(vehicle, wheelManufacturer, currentAirPressure, energyPercentage, parts);

            r_GarageManager.AddVehicleToGarage(vehicle, ownerName, ownerPhone);
        }

        private void initializeVehicle(Vehicle i_Vehicle, string i_WheelManufacturer, float i_CurrentAirPressure,
            float i_EnergyPercentage, string[] i_Parts)
        {
            Car car = i_Vehicle as Car;
            Motorcycle motorcycle = i_Vehicle as Motorcycle;
            Truck truck = i_Vehicle as Truck;

            if (car != null)
            {
                eCarColor color = (eCarColor)Enum.Parse(typeof(eCarColor), i_Parts[8]);
                eNumOfDoors doors = (eNumOfDoors)int.Parse(i_Parts[9]);

                car.InitializeCar(i_WheelManufacturer, i_CurrentAirPressure, color, doors, i_EnergyPercentage);
            }
            else if (motorcycle != null)
            {
                eLicenseType licenseType = (eLicenseType)Enum.Parse(typeof(eLicenseType), i_Parts[8]);
                int engineVolume = int.Parse(i_Parts[9]);

                motorcycle.InitializeMotorcycle(i_WheelManufacturer, i_CurrentAirPressure, licenseType, engineVolume,
                    i_EnergyPercentage);
            }
            else if (truck != null)
            {
                bool isCarryingRefrigeratedCargo = bool.Parse(i_Parts[8]);
                float cargoVolume = float.Parse(i_Parts[9]);

                truck.InitializeTruck(i_WheelManufacturer, i_CurrentAirPressure, isCarryingRefrigeratedCargo, cargoVolume,
                    i_EnergyPercentage);
            }
        }

    }
}