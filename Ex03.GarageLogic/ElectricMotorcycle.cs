namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : Motorcycle
    {
        private const float k_MaxBatteryTime = 3.0f;

        public ElectricMotorcycle(string i_LicenseID, string i_ModelName)
            : base(i_LicenseID, i_ModelName)
        {
            EnergySource = new ElectricEnergy(k_MaxBatteryTime);
        }
    }
}