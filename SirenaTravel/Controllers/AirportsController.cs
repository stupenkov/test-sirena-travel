using Microsoft.AspNetCore.Mvc;
using SirenaTravel.Abstractions;
using System.Threading.Tasks;

namespace SirenaTravel.Controllers
{
    [Route("airports/[controller]")]
    [ApiController]
    public class AMSController : ControllerBase
    {
        private readonly IAirportDirectory _airportDirectory;
        private readonly IDistanceCalculator _distanceCalculator;

        public AMSController(IAirportDirectory airportDirectory, IDistanceCalculator distanceCalculator)
        {
            _airportDirectory = airportDirectory;
            _distanceCalculator = distanceCalculator;
        }

        [HttpGet()]
        public ActionResult<string> Get([FromQuery] string airport1, [FromQuery] string airport2)
        {
            if (string.IsNullOrEmpty(airport1) || string.IsNullOrEmpty(airport2))
                return BadRequest("Должно быть указано два аэропорта");

            var airportFirst = _airportDirectory.FindByName(airport1);
            if (airportFirst == null)
                return NotFound($"Аэропорт с кодом {airport1} не найден");

            var airportSecond = _airportDirectory.FindByName(airport2);
            if (airportSecond == null)
                return NotFound($"Аэропорт с кодом {airport2} не найден");

            double distance = _distanceCalculator.Calculate(airportFirst, airportSecond);
            return Ok(distance);
        }
    }
}
