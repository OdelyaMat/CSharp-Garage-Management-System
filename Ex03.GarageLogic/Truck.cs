namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        protected const int k_NumberOfWheels = 14;
        protected const float k_MaxAirPressure = 28f;

        private bool m_IsCarryingRefrigeratedCargo;
        private float m_CargoVolume;

        protected Truck(string i_LicenseID, string i_ModelName)
            : base(i_LicenseID, i_ModelName)
        {
        }

        public bool IsCarryingRefrigeratedCargo
        {
            get { return m_IsCarryingRefrigeratedCargo; }
            set { m_IsCarryingRefrigeratedCargo = value; }
        }

        public float CargoVolume
        {
            get { return m_CargoVolume; }
            set { m_CargoVolume = value; }
        }

        public void InitializeTruck(string i_WheelManufacturerName, float i_CurrentAirPressure,
            bool i_IsCarryingDangerousMaterials, float i_CargoVolume, float i_EnergyPercentage)
        {
            base.InitializeWheels(k_NumberOfWheels, i_WheelManufacturerName, i_CurrentAirPressure, k_MaxAirPressure);

            m_IsCarryingRefrigeratedCargo = i_IsCarryingDangerousMaterials;
            m_CargoVolume = i_CargoVolume;
            EnergySource.SetEnergyByPercentage(i_EnergyPercentage);
        }
    }
}