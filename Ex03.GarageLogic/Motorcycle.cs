namespace Ex03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        protected const int k_NumberOfWheels = 2;
        protected const float k_MaxAirPressure = 30f;

        private eLicenseType m_LicenseType;
        private int m_EngineVolume;

        protected Motorcycle(string i_LicenseID, string i_ModelName)
            : base(i_LicenseID, i_ModelName)
        {
        }

        public eLicenseType LicenseType
        {
            get { return m_LicenseType; }
            set { m_LicenseType = value; }
        }

        public int EngineVolume
        {
            get { return m_EngineVolume; }
            set { m_EngineVolume = value; }
        }

        public void InitializeMotorcycle(string i_WheelManufacturerName, float i_CurrentAirPressure, eLicenseType i_LicenseType,
            int i_EngineVolume, float i_EnergyPercentage)
        {
            base.InitializeWheels(k_NumberOfWheels, i_WheelManufacturerName, i_CurrentAirPressure, k_MaxAirPressure);

            m_LicenseType = i_LicenseType;
            m_EngineVolume = i_EngineVolume;
            EnergySource.SetEnergyByPercentage(i_EnergyPercentage);
        }
    }
}