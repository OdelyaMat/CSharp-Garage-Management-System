namespace Ex03.GarageLogic
{
    public abstract class EnergySource
    {
        protected float m_CurrentAmount;
        protected readonly float r_MaxAmount;
        private const int k_MaxEnergyPercentage = 100;


        protected EnergySource(float i_MaxAmount)
        {
            r_MaxAmount = i_MaxAmount;
            m_CurrentAmount = 0;
        }

        public float CurrentAmount
        {
            get { return m_CurrentAmount; }
        }

        public float MaxAmount
        {
            get { return r_MaxAmount; }
        }

        public float EnergyPercentage
        {
            get { return (m_CurrentAmount / r_MaxAmount) * 100; }
        }

        protected void AddEnergy(float i_AmountToAdd)
        {
            if (i_AmountToAdd < 0 || m_CurrentAmount + i_AmountToAdd > r_MaxAmount)
            {
                throw new ValueRangeException(0, r_MaxAmount - m_CurrentAmount);
            }

            m_CurrentAmount += i_AmountToAdd;
        }

        public void SetEnergyByPercentage(float i_EnergyPercentage)
        {
            if (i_EnergyPercentage < 0 || i_EnergyPercentage > k_MaxEnergyPercentage)
            {
                throw new ValueRangeException(0, k_MaxEnergyPercentage);
            }

            m_CurrentAmount = r_MaxAmount * i_EnergyPercentage / 100;
        }
    }
}