using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKata.Extensions
{
    internal static class BetweenExtensions
    {
        //lb <= val <= ub
        internal static bool IsBetween<T>(this T value, T lowerBound, T upperBound) where T : IComparable<T>
        {
            return (lowerBound.CompareTo(value) <= 0) && (upperBound.CompareTo(value) >= 0);
        }

        //lb < val <= ub
        internal static bool IsBetweenExclusiveLowerBound<T>(this T value, T lowerBound, T upperBound) where T: IComparable<T>
        {
            return (lowerBound.CompareTo(value) < 0) && (value.CompareTo(upperBound) <= 0);
        }

        //lb <= val < ub
        internal static bool IsBetweenExlusiveUpperBound<T>(this T value, T lowerBound, T upperBound) where T: IComparable<T>
        {
            return (lowerBound.CompareTo(value) <= 0) && (upperBound.CompareTo(value) > 0);
        }

        //lb < val < ub
        internal static bool IsBetweenExclusiveBounds<T>(this T value, T lowerBound, T upperBound) where T:IComparable<T>
        {
            return (lowerBound.CompareTo(value) < 0) && (upperBound.CompareTo(value) > 0);
        }
    }
}
