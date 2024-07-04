using SirenaTravel.Abstractions;
using SirenaTravel.Models;
using System.Collections.Generic;
using System.Linq;

namespace SirenaTravel.Controllers
{
    public class AirportDirectory : IAirportDirectory
    {
        private readonly List<Airport> _airports = new List<Airport>();

        public void Add(Airport airport)
        {
            if (_airports.Contains(airport))
                return;

            _airports.Add(airport);
        }

        public Airport FindByName(string name)
        {
            return _airports.FirstOrDefault(a => a.Name == name);
        }
    }
}
