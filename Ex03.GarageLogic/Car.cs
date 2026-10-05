namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        protected const int k_NumberOfWheels = 5;
        protected const float k_MaxAirPressure = 31f;

        private eCarColor m_CarColor;
        private eNumOfDoors m_NumOfDoors;

        protected Car(string i_LicenseID, string i_ModelName)
            : base(i_LicenseID, i_ModelName)
        {
        }

        public eCarColor CarColor
        {
            get { return m_CarColor; }
            set { m_CarColor = value; }
        }

        public eNumOfDoors NumOfDoors
        {
            get { return m_NumOfDoors; }
            set { m_NumOfDoors = value; }
        }

        public void InitializeCar(string i_WheelManufacturerName, float i_CurrentAirPressure, eCarColor i_CarColor,
            eNumOfDoors i_NumOfDoors, float i_EnergyPercentage)
        {
            base.InitializeWheels(k_NumberOfWheels, i_WheelManufacturerName, i_CurrentAirPressure, k_MaxAirPressure);

            m_CarColor = i_CarColor;
            m_NumOfDoors = i_NumOfDoors;
            EnergySource.SetEnergyByPercentage(i_EnergyPercentage);
        }
    }
}