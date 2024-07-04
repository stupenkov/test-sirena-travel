using SirenaTravel.Models;

namespace SirenaTravel.Abstractions
{
    public interface IAirportDirectory
    {
        void Add(Airport airport);
        Airport FindByName(string name);
    }
}