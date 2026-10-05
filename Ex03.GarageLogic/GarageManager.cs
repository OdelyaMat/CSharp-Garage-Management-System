using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private readonly Dictionary<string, GarageVehicle> r_GarageVehicles;

        public GarageManager()
        {
            r_GarageVehicles = new Dictionary<string, GarageVehicle>();
        }

        public bool IsVehicleInGarage(string i_LicenseID)
        {
            return r_GarageVehicles.ContainsKey(i_LicenseID);
        }

        public void AddVehicleToGarage(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhone)
        {
            if (IsVehicleInGarage(i_Vehicle.LicenseID))
            {
                r_GarageVehicles[i_Vehicle.LicenseID].Status = eVehicleStatus.InRepair;
            }
            else
            {
                GarageVehicle garageVehicle = new GarageVehicle(i_Vehicle, i_OwnerName, i_OwnerPhone);

                r_GarageVehicles.Add(i_Vehicle.LicenseID, garageVehicle);
            }
        }

        public List<string> GetLicenseIDs()
        {
            return new List<string>(r_GarageVehicles.Keys);
        }

        public List<string> GetLicenseIDsByStatus(eVehicleStatus i_Status)
        {
            List<string> licenseIDs = new List<string>();

            foreach (KeyValuePair<string, GarageVehicle> pair in r_GarageVehicles)
            {
                if (pair.Value.Status == i_Status)
                {
                    licenseIDs.Add(pair.Key);
                }
            }

            return licenseIDs;
        }

        public void ChangeVehicleStatus(string i_LicenseID, eVehicleStatus i_NewStatus)
        {
            GarageVehicle garageVehicle = getGarageVehicle(i_LicenseID);
            garageVehicle.Status = i_NewStatus;
        }

        public void InflateVehicleWheelsToMax(string i_LicenseID)
        {
            GarageVehicle garageVehicle = getGarageVehicle(i_LicenseID);
            garageVehicle.Vehicle.InflateWheelsToMax();
        }

        public GarageVehicle GetGarageVehicleDetails(string i_LicenseID)
        {
            return getGarageVehicle(i_LicenseID);
        }

        private GarageVehicle getGarageVehicle(string i_LicenseID)
        {
            if (!r_GarageVehicles.ContainsKey(i_LicenseID))
            {
                throw new ArgumentException("Vehicle does not exist in the garage.");
            }

            return r_GarageVehicles[i_LicenseID];
        }
        public void RefuelVehicle(string i_LicenseID, eFuelType i_FuelType, float i_FuelAmountToAdd)
        {
            GarageVehicle garageVehicle = getGarageVehicle(i_LicenseID);
            FuelEnergy fuelEnergy = garageVehicle.Vehicle.EnergySource as FuelEnergy;

            if (fuelEnergy == null)
            {
                throw new ArgumentException("This vehicle is not fuel based.");
            }

            fuelEnergy.Refuel(i_FuelType, i_FuelAmountToAdd);
        }

        public void ChargeVehicle(string i_LicenseID, float i_MinutesToAdd)
        {
            GarageVehicle garageVehicle = getGarageVehicle(i_LicenseID);
            ElectricEnergy electricEnergy = garageVehicle.Vehicle.EnergySource as ElectricEnergy;

            if (electricEnergy == null)
            {
                throw new ArgumentException("This vehicle is not electric.");
            }

            electricEnergy.Charge(i_MinutesToAdd / 60f);
        }
    }
}