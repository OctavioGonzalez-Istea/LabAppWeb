using Entidades;
using LaboratorioApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaboratorioWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EncuestaController : ControllerBase
    {
        private readonly IEncuestaService _encuestaService;

        public EncuestaController(IEncuestaService encuestaService)
        {
            _encuestaService = encuestaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Encuesta>>> GetEncuestas()
        {
            var encuestas = await _encuestaService.GetEncuestasAsync();
            return Ok(encuestas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Encuesta>> GetEncuesta(int id)
        {
            var encuesta = await _encuestaService.GetEncuestaByIdAsync(id);
            if (encuesta == null) return NotFound();

            return Ok(encuesta);
        }

        [HttpPost]
        public async Task<ActionResult<Encuesta>> CreateEncuesta(Encuesta nuevaEncuesta)
        {
            List<string> listerrores = await _encuestaService.ValidarCampos(nuevaEncuesta);

            if (listerrores.Count > 0)
            {
                string msg = "";

                foreach (string error in listerrores)
                {
                    if (msg.Length == 0)
                        msg += error;
                    else
                    {
                        msg += Environment.NewLine;
                        msg += error;
                    }
                }
                return BadRequest(msg);
            }

            var encuestaCreada = await _encuestaService.CreateEncuestaAsync(nuevaEncuesta);
            return CreatedAtAction(nameof(GetEncuesta), new { id = encuestaCreada.Id }, encuestaCreada);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEncuesta(int id)
        {
            var eliminado = await _encuestaService.DeleteEncuestaAsync(id);
            if (!eliminado) return NotFound();

            return NoContent();
        }
    }
}
