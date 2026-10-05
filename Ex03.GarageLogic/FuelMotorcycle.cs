namespace Ex03.GarageLogic
{
    public class FuelMotorcycle : Motorcycle
    {
        private const float k_MaxFuelAmount = 5.6f;

        public FuelMotorcycle(string i_LicenseID, string i_ModelName)
            : base(i_LicenseID, i_ModelName)
        {
            EnergySource = new FuelEnergy(eFuelType.Octan98, k_MaxFuelAmount);
        }
    }
}