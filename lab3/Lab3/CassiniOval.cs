﻿using System;

namespace Lab3
{
    public static class CassiniOval
    {
        public static double CalculatePointOnTheGraph(double coeffA, double coeffC, double x)
        {
            return Math.Sqrt(Math.Sqrt(Math.Pow(coeffA, 4) + (4 * Math.Pow(x, 2) * Math.Pow(coeffC, 2))) - Math.Pow(x, 2) - Math.Pow(coeffC, 2));
        }
    }
}
