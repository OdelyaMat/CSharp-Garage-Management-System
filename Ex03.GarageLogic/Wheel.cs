namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string r_ManufacturerName;
        private float m_CurrentAirPressure;
        private readonly float r_MaxAirPressure;
        private const int k_MinAirPressure = 0;

        public Wheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            if (i_CurrentAirPressure < k_MinAirPressure || i_CurrentAirPressure > i_MaxAirPressure)
            {
                throw new ValueRangeException(k_MinAirPressure, i_MaxAirPressure);
            }

            r_ManufacturerName = i_ManufacturerName;
            m_CurrentAirPressure = i_CurrentAirPressure;
            r_MaxAirPressure = i_MaxAirPressure;
        }

        public string ManufacturerName
        {
            get { return r_ManufacturerName; }
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
        }

        public float MaxAirPressure
        {
            get { return r_MaxAirPressure; }
        }

        public void Inflate(float i_AirToAdd)
        {
            if (i_AirToAdd < k_MinAirPressure || m_CurrentAirPressure + i_AirToAdd > r_MaxAirPressure)
            {
                throw new ValueRangeException(k_MinAirPressure, r_MaxAirPressure - m_CurrentAirPressure);
            }

            m_CurrentAirPressure += i_AirToAdd;
        }

    }
}