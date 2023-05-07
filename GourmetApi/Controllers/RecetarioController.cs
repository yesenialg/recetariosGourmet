using Microsoft.AspNetCore.Mvc;
using Gourmet.Services.Contracts;
using Gourmet;

namespace GourmetApi.Controllers
{
    [ApiController]
    [Route("api/Recetarios")]
    public class RecetarioController : Controller
    {
        private readonly ILogger<RecetarioController> _logger;
        private readonly IRecetarioService _recetarioService;
        private readonly IRecetaService _recetaService;

        public RecetarioController(ILogger<RecetarioController> logger, IRecetarioService recetarioService, IRecetaService recetaService)
        {
            _logger = logger;
            _recetarioService = recetarioService;
            _recetaService = recetaService;
        }

        [HttpGet("GetRecetarios")]
        public IActionResult GetAll()
        {
            try
            {
                var recetarios = _recetarioService.GetAll();

                _logger.LogInformation($"Retorna todos los recetarios");

                return Ok(recetarios);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error con GetAll: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }

        }


        [HttpPost("CreateRecetario")]
        public IActionResult CreateRecetario(long id, string titulo)
        {
            try
            {

                var recetario = new Recetario { Id = id, Titulo = titulo };
                _recetarioService.Add(recetario);

                _logger.LogInformation($"Se creó el recetario");

                return Ok(recetario);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error con CreateRecetario: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("GetRecetas")]
        public IActionResult GetRecetas()
        {
            try
            {
                var recetasRecetario = _recetaService.GetAll();

                _logger.LogInformation($"Retorna todos las recetas");

                return Ok(recetasRecetario);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error con GetRecetas: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }

        }

        [HttpPost("CreateReceta")]
        public IActionResult CreateReceta(long id, string titulo)
        {
            try
            {

                var receta = new Receta { Id = id, Titulo = titulo };
                _recetaService.Add(receta);

                _logger.LogInformation($"Se creó la receta");

                return Ok(receta);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error con CreateReceta: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }

}