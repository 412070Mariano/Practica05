using Actividad05_Back.Models.Entities;
using Actividad05_Back.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Actividad_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnosController : ControllerBase
    {
        private readonly ITurnoServicio _service;

        public TurnosController(ITurnoServicio service)
        {
            _service = service;
        }


        // GET: api/<TurnosController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_service.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno: {ex.Message}");
            }
        }

        // GET api/<TurnosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound("Id inválido");
                }
                return Ok(_service.Get(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno: {ex.Message}");
            }
        }

        // POST api/<TurnosController>
        [HttpPost]
        public IActionResult Post([FromBody] TTurno turno)
        {
            try
            {
                if (turno == null)
                    return BadRequest("Debe ingresar un identificador válido");
                var result = _service.Create(turno);
                if (result)
                    return Ok("Turno creado exitosamente");
                return StatusCode(500, "No se pudo crear el turno");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno: {ex.Message}");
            }
        }

        // PUT api/<TurnosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TTurno turno)
        {
            try
            {
                var result = _service.Update(id, turno);
                if (result)
                    return Ok("Turno actualizado");
                else
                    return StatusCode(500, "No se pudo editar el turno");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno: {ex.Message}");
            }
        }

        // DELETE api/<TurnosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, string motivo)
        {
            try
            {
                var result = _service.Delete(id, motivo);
                if (result)
                {
                    return Ok("Turno cancelado");
                }
                return StatusCode(500, "No se pudo cancelar el turno");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error interno: {ex.Message}");
            }
        }
    }
}
