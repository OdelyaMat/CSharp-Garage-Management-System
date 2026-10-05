namespace Ex03.GarageLogic
{
    public class ElectricCar : Car
    {
        private const float k_MaxBatteryTime = 4.6f;

        public ElectricCar(string i_LicenseID, string i_ModelName)
            : base(i_LicenseID, i_ModelName)
        {
            EnergySource = new ElectricEnergy(k_MaxBatteryTime);
        }
    }
}