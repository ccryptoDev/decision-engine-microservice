using System;

namespace DecisionEngine.Services
{
    public static class NumberExtension
    {
        public static double RoundUp(this double input, int places)
        {
            double multiplier = Math.Pow(10, Convert.ToDouble(places));
            return Math.Ceiling(input * multiplier) / multiplier;
        }
    }
}
