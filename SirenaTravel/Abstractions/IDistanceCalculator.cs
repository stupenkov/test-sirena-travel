using SirenaTravel.Models;

namespace SirenaTravel.Abstractions
{
    public interface IDistanceCalculator
    {
        double Calculate(Airport airport1, Airport airport2);
    }
}