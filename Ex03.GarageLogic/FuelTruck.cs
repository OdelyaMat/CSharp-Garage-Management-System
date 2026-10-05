namespace Ex03.GarageLogic
{
    public class FuelTruck : Truck
    {
        private const float k_MaxFuelAmount = 125f;

        public FuelTruck(string i_LicenseID, string i_ModelName)
            : base(i_LicenseID, i_ModelName)
        {
            EnergySource = new FuelEnergy(eFuelType.Soler, k_MaxFuelAmount);
        }
    }
}