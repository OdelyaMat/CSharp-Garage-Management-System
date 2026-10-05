using System;

namespace Ex03.GarageLogic
{
    public class FuelEnergy : EnergySource
    {
        private readonly eFuelType r_FuelType;

        public FuelEnergy(eFuelType i_FuelType, float i_MaxFuelAmount)
            : base(i_MaxFuelAmount)
        {
            r_FuelType = i_FuelType;
        }

        public eFuelType FuelType
        {
            get { return r_FuelType; }
        }

        public void Refuel(eFuelType i_FuelType, float i_FuelAmountToAdd)
        {
            if (i_FuelType != r_FuelType)
            {
                throw new ArgumentException("Wrong fuel type.");
            }

            base.AddEnergy(i_FuelAmountToAdd);
        }
    }
}