using SirenaTravel.Abstractions;
using SirenaTravel.Models;
using System;

namespace SirenaTravel.Servicies
{
    public class DistanceCalculator : IDistanceCalculator
    {
        public double Calculate(Airport airport1, Airport airport2)
        {
            const double EarthRadius = 6371;

            double dLat = ToRadians(airport2.Latitude - airport1.Latitude);
            double dLon = ToRadians(airport2.Longitude - airport1.Longitude);

            double radLat1 = ToRadians(airport1.Latitude);
            double radLat2 = ToRadians(airport2.Latitude);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distance = EarthRadius * c;

            return distance;
        }

        private static double ToRadians(double degrees)
        {
            return degrees * (Math.PI / 180);
        }
    }
}
