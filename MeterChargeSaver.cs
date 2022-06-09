using System;
using System.Collections.Generic;

namespace MeterCharge
{
    public class MeterChargeSaver
    {
        public void CalculateChargeAndSave(IEnumerable<Meter> meters)
        {
            foreach (Meter meter in meters)
                FilePersistance.Instance.Save(meter, CalculateChargeByMeterType(meter));
        }

        public List<Tuple<int, int>> CalculateChargeByMeterType(Meter meter)
        {
            switch (meter.MeterType)
            {
                case MeterType.Electricity:
                    meter.Cost = Cost.Electricity;
                    return GetReadingChargeValues(meter, ElectricityCalculator.GetCharge);
                case MeterType.Heating:
                    meter.Cost = Cost.Heating;
                    return GetReadingChargeValues(meter, HeatingCalculator.GetCharge);
                case MeterType.Water:
                    meter.Cost = Cost.Water;
                    return GetReadingChargeValues(meter, WaterCalculator.GetCharge);
                default:
                    return null;
            }
        }

        public List<Tuple<int, int>> GetReadingChargeValues(Meter meter, Func<int, int> getCharge)
        {
            List<Tuple<int, int>> readingCharges = new List<Tuple<int, int>>();
            foreach (int reading in meter.Readings)
                readingCharges.Add(Tuple.Create(reading, getCharge(reading)));

            return readingCharges;
        }
    }
}
