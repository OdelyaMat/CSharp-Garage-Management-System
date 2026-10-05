using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageApplication
    {
        private readonly GarageManager r_GarageManager;
        private readonly InputReader r_InputReader;
        private readonly GaragePrinter r_Printer;
        private readonly VehicleFileLoader r_FileLoader;
        private readonly VehicleInputBuilder r_VehicleInputBuilder;

        public GarageApplication()
        {
            r_GarageManager = new GarageManager();
            r_InputReader = new InputReader();
            r_Printer = new GaragePrinter();
            r_FileLoader = new VehicleFileLoader(r_GarageManager);
            r_VehicleInputBuilder = new VehicleInputBuilder(r_GarageManager, r_InputReader);
        }

        public void Run()
        {
            bool isQuitting = false;

            while (!isQuitting)
            {
                try
                {
                    r_Printer.PrintMainMenu();
                    int choice = r_InputReader.ReadIntInRange("Choose option: ", 1, 9);
                    isQuitting = handleMenuChoice(choice);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                }

                Console.WriteLine();
            }
        }

        private bool handleMenuChoice(int i_Choice)
        {
            bool isQuitting = false;

            switch (i_Choice)
            {
                case 1:
                    r_FileLoader.LoadVehiclesFromFile("VehiclesDB.txt");
                    Console.WriteLine("Vehicles loaded successfully.");
                    break;
                case 2:
                    r_VehicleInputBuilder.InsertVehicleFromUser();
                    break;
                case 3:
                    printLicenseIDs();
                    break;
                case 4:
                    changeVehicleStatus();
                    break;
                case 5:
                    inflateWheelsToMax();
                    break;
                case 6:
                    refuelVehicle();
                    break;
                case 7:
                    chargeVehicle();
                    break;
                case 8:
                    printFullVehicleDetails();
                    break;
                case 9:
                    isQuitting = true;
                    break;
            }

            return isQuitting;
        }

        private void printLicenseIDs()
        {
            bool isFilteredByStatus = r_InputReader.ReadBool("Would you like to filter by status? true/false: ");

            if (isFilteredByStatus)
            {
                eVehicleStatus status = r_InputReader.ReadEnum<eVehicleStatus>("Choose status");
                r_Printer.PrintLicenseIDs(r_GarageManager.GetLicenseIDsByStatus(status));
            }
            else
            {
                r_Printer.PrintLicenseIDs(r_GarageManager.GetLicenseIDs());
            }
        }

        private void changeVehicleStatus()
        {
            string licenseID = r_InputReader.ReadNonEmptyString("Enter license ID: ");
            eVehicleStatus status = r_InputReader.ReadEnum<eVehicleStatus>("Enter new status");

            r_GarageManager.ChangeVehicleStatus(licenseID, status);
            Console.WriteLine("Vehicle status changed successfully.");
        }

        private void inflateWheelsToMax()
        {
            string licenseID = r_InputReader.ReadNonEmptyString("Enter license ID: ");

            r_GarageManager.InflateVehicleWheelsToMax(licenseID);
            Console.WriteLine("Wheels inflated successfully.");
        }

        private void refuelVehicle()
        {
            string licenseID = r_InputReader.ReadNonEmptyString("Enter license ID: ");
            eFuelType fuelType = r_InputReader.ReadEnum<eFuelType>("Enter fuel type");
            float amount = r_InputReader.ReadPositiveFloat("Enter fuel amount to add: ");

            r_GarageManager.RefuelVehicle(licenseID, fuelType, amount);
            Console.WriteLine("Vehicle refueled successfully.");
        }

        private void chargeVehicle()
        {
            string licenseID = r_InputReader.ReadNonEmptyString("Enter license ID: ");
            float minutes = r_InputReader.ReadPositiveFloat("Enter minutes to charge: ");

            r_GarageManager.ChargeVehicle(licenseID, minutes);
            Console.WriteLine("Vehicle charged successfully.");
        }

        private void printFullVehicleDetails()
        {
            string licenseID = r_InputReader.ReadNonEmptyString("Enter license ID: ");
            GarageVehicle garageVehicle = r_GarageManager.GetGarageVehicleDetails(licenseID);

            r_Printer.PrintFullVehicleDetails(garageVehicle);
        }
    }
}