namespace Ex03.GarageLogic
{
    public class ElectricEnergy : EnergySource
    {
        public ElectricEnergy(float i_MaxBatteryTime)
            : base(i_MaxBatteryTime)
        {
        }

        public void Charge(float i_HoursToAdd)
        {
            base.AddEnergy(i_HoursToAdd);
        }
    }
}