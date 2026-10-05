using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class VehicleInputBuilder
    {
        private readonly GarageManager r_GarageManager;
        private readonly InputReader r_InputReader;
        private const int k_MaxEnergyPercentage = 100;

        public VehicleInputBuilder(GarageManager i_GarageManager, InputReader i_InputReader)
        {
            r_GarageManager = i_GarageManager;
            r_InputReader = i_InputReader;
        }

        public void InsertVehicleFromUser()
        {
            string licenseID = r_InputReader.ReadNonEmptyString("Enter license ID: ");

            if (r_GarageManager.IsVehicleInGarage(licenseID))
            {
                r_GarageManager.ChangeVehicleStatus(licenseID, eVehicleStatus.InRepair);
                Console.WriteLine("Vehicle already exists. Status changed to InRepair.");
            }
            else
            {
                insertNewVehicle(licenseID);
            }
        }

        private void insertNewVehicle(string i_LicenseID)
        {
            string vehicleType = readVehicleTypeFromUser();

            string modelName = r_InputReader.ReadNonEmptyString("Enter model name: ");
            string ownerName = r_InputReader.ReadNonEmptyString("Enter owner name: ");
            string ownerPhone = r_InputReader.ReadNonEmptyString("Enter owner phone: ");
            string wheelManufacturer = r_InputReader.ReadNonEmptyString("Enter wheel manufacturer: ");
            float currentAirPressure = r_InputReader.ReadPositiveFloat("Enter current air pressure: ");
            float energyPercentage = r_InputReader.ReadFloatInRange("Enter energy percentage: ", 0, k_MaxEnergyPercentage);

            Vehicle vehicle = VehicleCreator.CreateVehicle(vehicleType, i_LicenseID, modelName);

            if (vehicle == null)
            {
                throw new ArgumentException("Unsupported vehicle type.");
            }

            initializeVehicleFromUser(vehicle, wheelManufacturer, currentAirPressure, energyPercentage);

            r_GarageManager.AddVehicleToGarage(vehicle, ownerName, ownerPhone);
            Console.WriteLine("Vehicle inserted successfully.");
        }

        // $G$ DSN-002 (-10) The UI must not know specific types and their properties concretely.
        // It means that when adding a new type you'll have to change the code here too.
        private void initializeVehicleFromUser(Vehicle i_Vehicle, string i_WheelManufacturer, float i_CurrentAirPressure,
            float i_EnergyPercentage)
        {
            Car car = i_Vehicle as Car;
            Motorcycle motorcycle = i_Vehicle as Motorcycle;
            Truck truck = i_Vehicle as Truck;

            if (car != null)
            {
                eCarColor color = readCarColorFromUser();
                eNumOfDoors doors = readNumberOfDoorsFromUser();

                car.InitializeCar(i_WheelManufacturer, i_CurrentAirPressure, color, doors, i_EnergyPercentage);
            }
            else if (motorcycle != null)
            {
                eLicenseType licenseType = readLicenseTypeFromUser();
                int engineVolume = r_InputReader.ReadPositiveInt("Enter engine volume: ");

                motorcycle.InitializeMotorcycle(i_WheelManufacturer, i_CurrentAirPressure, licenseType, engineVolume,
                    i_EnergyPercentage);
            }
            else if (truck != null)
            {
                bool isCarryingRefrigeratedCargo = r_InputReader.ReadBool("Is carrying refrigerated cargo? true/false: ");
                float cargoVolume = r_InputReader.ReadPositiveFloat("Enter cargo volume: ");

                truck.InitializeTruck(i_WheelManufacturer, i_CurrentAirPressure, isCarryingRefrigeratedCargo, cargoVolume,
                    i_EnergyPercentage);
            }
        }

        private string readVehicleTypeFromUser()
        {
            int index = 1;

            Console.WriteLine("Choose vehicle type:");

            foreach (string vehicleType in VehicleCreator.SupportedTypes)
            {
                Console.WriteLine("{0}. {1}", index, vehicleType);
                index++;
            }

            int choice = r_InputReader.ReadIntInRange("Enter vehicle type number: ", 1, VehicleCreator.SupportedTypes.Count);

            return VehicleCreator.SupportedTypes[choice - 1];
        }

        // $G$ DSN-012 (-10) Code duplication. You have InputReader.ReadEnum method, you should have used it.
        // In addition the current implementation is not extensible. If in the future there will be a new enum value,
        // you will have to make changes here as well.
        private eCarColor readCarColorFromUser()
        {
            Console.WriteLine("Choose car color:");
            Console.WriteLine("1. Red");
            Console.WriteLine("2. Yellow");
            Console.WriteLine("3. Black");
            Console.WriteLine("4. Silver");

            int choice = r_InputReader.ReadIntInRange("Enter color number: ", 1, 4);

            eCarColor color = eCarColor.Red;

            switch (choice)
            {
                case 1:
                    color = eCarColor.Red;
                    break;
                case 2:
                    color = eCarColor.Yellow;
                    break;
                case 3:
                    color = eCarColor.Black;
                    break;
                case 4:
                    color = eCarColor.Silver;
                    break;
            }

            return color;
        }

        private eNumOfDoors readNumberOfDoorsFromUser()
        {
            Console.WriteLine("Choose number of doors:");
            Console.WriteLine("1. Two");
            Console.WriteLine("2. Three");
            Console.WriteLine("3. Four");
            Console.WriteLine("4. Five");

            int choice = r_InputReader.ReadIntInRange("Enter doors option: ", 1, 4);

            eNumOfDoors doors = eNumOfDoors.Two;

            switch (choice)
            {
                case 1:
                    doors = eNumOfDoors.Two;
                    break;
                case 2:
                    doors = eNumOfDoors.Three;
                    break;
                case 3:
                    doors = eNumOfDoors.Four;
                    break;
                case 4:
                    doors = eNumOfDoors.Five;
                    break;
            }

            return doors;
        }

        private eLicenseType readLicenseTypeFromUser()
        {
            Console.WriteLine("Choose license type:");
            Console.WriteLine("1. A");
            Console.WriteLine("2. A2");
            Console.WriteLine("3. B1");
            Console.WriteLine("4. AB");

            int choice = r_InputReader.ReadIntInRange("Enter license type number: ", 1, 4);

            eLicenseType licenseType = eLicenseType.A;

            switch (choice)
            {
                case 1:
                    licenseType = eLicenseType.A;
                    break;
                case 2:
                    licenseType = eLicenseType.A2;
                    break;
                case 3:
                    licenseType = eLicenseType.B1;
                    break;
                case 4:
                    licenseType = eLicenseType.AB;
                    break;
            }

            return licenseType;
        }
    }
}