using Microsoft.AspNetCore.Mvc;
using Gourmet;

namespace GourmetApi.Controllers
{
    [ApiController]
    [Route("api/Recetas")]
    public class RecetasController : Controller
    {
        private readonly ILogger<RecetasController> _logger;

        public RecetasController(ILogger<RecetasController> logger)
        {
            _logger = logger;
        }


        [HttpGet(Name = "GetRecetasDeRecetario")]
        public IActionResult GetReecetasDeRecetario(int id)
        {
            try
            {
                var context = new DBRecetariosContext();

                var recetario = context.Recetarios.Find((long)id);

                var recetasRecetario = recetario.RecetasDeUnRecetario();

                _logger.LogInformation($"Retorna todos los recetarios");

                return Ok(recetasRecetario);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error con GetAll: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }

        }
    }
}
