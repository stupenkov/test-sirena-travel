using System;

namespace SirenaTravel.Models
{
    public class Airport : IEquatable<Airport>
    {
        public Airport(string name, double longitude, double latitude)
        {
            Name = name ?? throw new ArgumentNullException("name");
            Longitude = longitude;
            Latitude = latitude;
        }

        public string Name { get; }
        public double Longitude { get; }
        public double Latitude { get; }

        public bool Equals(Airport other)
        {
            if (other == null)
                return false;

            return Name == other.Name;
        }
    }
}
