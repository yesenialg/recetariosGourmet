using Microsoft.AspNetCore.Mvc;
using Gourmet.Services.Contracts;

namespace GourmetApi.Controllers
{
    [ApiController]
    [Route("api/Recetarios")]
    public class RecetarioController : Controller
    {
        private readonly ILogger<RecetarioController> _logger;
        private readonly IRecetarioService _recetarioService;

        public RecetarioController(ILogger<RecetarioController> logger, IRecetarioService recetarioService)
        {
            _logger = logger;
            _recetarioService = recetarioService;
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

        [HttpGet("GetRecetasDeRecetario")]
        public IActionResult GetReecetasDeRecetario(long id)
        {
            try
            {
                var recetasRecetario = _recetarioService.RecetasDeUnRecetario(id);

                _logger.LogInformation($"Retorna todos las recetas del recetario");

                return Ok(recetasRecetario);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error con GetRecetasDeRecetario: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }

        }
    }

}