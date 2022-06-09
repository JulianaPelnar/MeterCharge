using System;

namespace MeterCharge
{
    public static class ElectricityCalculator
    {
        public static bool isNightTime => DateTimeProvider.Now.TimeOfDay.Hours < 8 || DateTimeProvider.Now.TimeOfDay.Hours > 20;
        public static int GetCharge(int consumption)
        {
            return isNightTime ?
                consumption * (Cost.Electricity / 2) :
                consumption * Cost.Electricity;
        }
    }
    public class WaterCalculator
    {
        public static int GetCharge(int consumption)
        {
            return consumption * Cost.Water;
        }
    }
    public class HeatingCalculator
    {
        public static int GetCharge(int consumption)
        {
            return consumption * Cost.Heating;
        }
    }

    #region Helper Methods
    public static class DateTimeProvider
    {
        private static Func<DateTime> _dateTimeNowFunc = () => DateTime.Now;
        public static DateTime Now => _dateTimeNowFunc();

        public static void Set(Func<DateTime> dateTimeNowFunc)
        {
            _dateTimeNowFunc = dateTimeNowFunc;
        }
    }
    #endregion
}

