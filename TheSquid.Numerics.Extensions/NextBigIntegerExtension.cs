﻿using System;
using System.Numerics;

namespace TheSquid.Numerics
{
    /// <summary>
    /// C# implementation of an extension method to generate
    /// random BigInteger value. By Nikolai TheSquid.
    /// </summary>
    public static partial class NextBigIntegerExtension
    {
        /// <summary>
        /// Random BigInteger value that is within a specified range.
        /// </summary>
        /// <param name="random">
        /// Basic pseudo-random number generator with defined seed.
        /// </param>
        /// <param name="min">
        /// Inclusive lower bound.
        /// </param>
        /// <param name="max">
        /// Inclusive upper bound.
        /// </param>
        /// <returns>
        /// It returns BigInteger value greater than or equal <paramref name="min"/> and less or equal than <paramref name="max"/>.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Max value can not be less then min value.
        /// </exception>
        public static BigInteger NextBigInteger(this Random random, BigInteger min, BigInteger max)
        {
            const string maxCannotBeLessMessage = "Max value can not be less then min value.";
            if (max < min) throw new ArgumentOutOfRangeException(maxCannotBeLessMessage);
            var residual = max - min;
            var buffer = residual.ToByteArray();
            random.NextBytes(buffer);
            var multiplier = new BigInteger(buffer);
            var addendum = residual & multiplier;
            if (addendum < 0) addendum *= -1;
            return min + addendum;
        }
    }
}