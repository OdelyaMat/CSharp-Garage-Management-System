namespace Ex03.GarageLogic
{
    public class FuelCar : Car
    {
        private const float k_MaxFuelAmount = 51f;

        public FuelCar(string i_LicenseID, string i_ModelName)
            : base(i_LicenseID, i_ModelName)
        {
            EnergySource = new FuelEnergy(eFuelType.Octan95, k_MaxFuelAmount);
        }
    }
}