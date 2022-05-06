using System;

namespace LazyRobot
{
    public static class Util
    {
        public static double AU(double num)
        {
            return num * 40000;
        }

        public static double LY(double num)
        {
            return num * 2400000D;
        }

        public static double ConvertDegreesToDroneRange(double degrees)
        {
            return Math.Cos(degrees / 180.0 * Math.PI);
        }
    }
}
