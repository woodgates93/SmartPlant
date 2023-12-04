using Microsoft.AspNetCore.Mvc;
using SmartPlantApiData.Repos;
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
        private readonly TemperatureRepo _temperatureRepo;

        public TempController(TemperatureCellection collection, TemperatureRepo temperatureRepo)
        {
            _data = collection;
            _temperatureRepo = temperatureRepo;
        }


        // GET: api/<TempController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Get()
        {
            IEnumerable<Temperature> temperatures = _data.GetAll();

            if (temperatures.ToList().Count== 0)
            {
                return NoContent();
            }
            return Ok(temperatures);
        }

        // GET api/<TempController>/5
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            try
            {
                Temperature temperature = _data.GetById(id);
                return Ok(temperature);
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
                TemperatureEntity temperature = _temperatureRepo.Save(new TemperatureEntity() { Value = dto.Temp }  );
                return Created($"api/Temp/{temperature.Id}", temperature);
            }
            catch (KeyNotFoundException)
            {
                return UnprocessableEntity();
            }
          
        }

        // PUT api/<TempController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TempController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
