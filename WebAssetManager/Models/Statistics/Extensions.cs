using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAssetManager
{
    public static class Extensions
    {
        /// <summary>
        /// Check if a number is NaN or equal to zero
        /// </summary>
        /// <param name="value">The double value to check</param>
        public static bool IsNaNOrZero(this double value)
        {
            return double.IsNaN(value) || Math.Abs(value) < double.Epsilon;
        }

        /// <summary>
        /// Casts the specified input value to a decimal while acknowledging the overflow conditions
        /// </summary>
        /// <param name="input">The value to be cast</param>
        /// <returns>The input value as a decimal, if the value is too large or to small to be represented
        /// as a decimal, then the closest decimal value will be returned</returns>
        public static decimal SafeDecimalCast(this double input)
        {
            if (input <= (double)decimal.MinValue) return decimal.MinValue;
            if (input >= (double)decimal.MaxValue) return decimal.MaxValue;
            return (decimal)input;
        }


    }
}