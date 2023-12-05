using Microsoft.AspNetCore.Mvc;
using SmartPlantApi.Services;
using SmartPlantLib.Collection;
using SmartPlantLib.Dto;
using SmartPlantLib.Entities;
using SmartPlantLib.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartPlantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TempController : ControllerBase
    {
        private TemperatureCellection _data;
        private readonly TemperatureService _temperatureService;

        public TempController(TemperatureCellection collection, TemperatureService temperatureService)
        {
            _data = collection;
            _temperatureService = temperatureService;
        }


        // GET: api/<TempController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetLatest()
        {
            var temperatures = new List<Temperature>();
            try
            {
                temperatures = _temperatureService.GetLatest();
                if (temperatures.Any())
                {
                    return Ok(temperatures);
                }
                return NoContent();

            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound();
            }
        }

        // GET api/<TempController>/5
        [HttpGet]
        [Route("{rows}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int rows)
        {
            var temperatures = new List<Temperature>();
            try
            {
                if (rows <= 0)
                {
                    return RedirectToAction(nameof(GetLatest));
                }
                else
                {
                    temperatures = _temperatureService.Get(rows);
                }

                if (temperatures.Any())
                {
                    return Ok(temperatures);
                }
                return NoContent();

            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound();
            }
        }

        // POST api/<TempController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public IActionResult Post([FromBody] TemperatureDto dto)
        {           
            try
            {
                TemperatureEntity temperature = _temperatureService.Save(new TemperatureEntity() { Value = dto.Temp }  );
                return Created($"api/Temp/{temperature.Id}", temperature);
            }
            catch (KeyNotFoundException)
            {
                return UnprocessableEntity();
            }
        }
    }
}
