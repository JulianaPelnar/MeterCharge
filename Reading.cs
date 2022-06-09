using System.Collections.Generic;

namespace MeterCharge
{
    public enum MeterType
    {
        Electricity = 4,
        Water,
        Heating
    }

    public class Meter
    {
        public string Id { get; set; }
        public MeterType MeterType { get; set; }
        public IEnumerable<int> Readings { get; set; }
        public int Cost { get; set; }
    }
    public class Cost
    {
        public const int Electricity = 4;
        public const int Water = 3;
        public const int Heating = 5;
    }
}