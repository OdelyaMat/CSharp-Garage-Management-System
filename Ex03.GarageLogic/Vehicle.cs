using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_LicenseID;
        private readonly string r_ModelName;
        private readonly List<Wheel> r_Wheels;
        
        // $G$ DSN-999 (-5) This field should be readonly.
        private EnergySource m_EnergySource;

        protected Vehicle(string i_LicenseID, string i_ModelName)
        {
            r_LicenseID = i_LicenseID;
            r_ModelName = i_ModelName;
            r_Wheels = new List<Wheel>();
        }

        public string LicenseID
        {
            get { return r_LicenseID; }
        }

        public string ModelName
        {
            get { return r_ModelName; }
        }

        public List<Wheel> Wheels
        {
            get { return r_Wheels; }
        }

        public EnergySource EnergySource
        {
            get { return m_EnergySource; }
            protected set { m_EnergySource = value; }
        }

        public float EnergyPercentage
        {
            get { return m_EnergySource.EnergyPercentage; }
        }

        protected void InitializeWheels(int i_NumberOfWheels, string i_WheelManufacturerName, float i_CurrentAirPressure,
            float i_MaxAirPressure)
        {
            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                r_Wheels.Add(new Wheel(i_WheelManufacturerName, i_CurrentAirPressure, i_MaxAirPressure));
            }
        }

        public void InflateWheelsToMax()
        {
            foreach (Wheel wheel in r_Wheels)
            {
                wheel.Inflate(wheel.MaxAirPressure - wheel.CurrentAirPressure);
            }
        }


    }
}