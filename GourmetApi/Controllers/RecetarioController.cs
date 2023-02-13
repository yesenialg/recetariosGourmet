using Microsoft.AspNetCore.Mvc;
using Gourmet;
using GourmetApi.Repositories.Contracts;
using GourmetApi.Repositories;

namespace GourmetApi.Controllers
{
    [ApiController]
    [Route("api/Recetarios")]
    public class RecetarioController : Controller
    {
        private readonly ILogger<RecetarioController> _logger;
        private IRecetarioRepository recetarioRepository;
        public RecetarioController(ILogger<RecetarioController> logger)
        {
            _logger = logger;
            this.recetarioRepository = new RecetarioRepository(new DBRecetariosContext());
        }

        [HttpGet(Name = "GetRecetarios")]
        public IActionResult GetAll()
        {
            try
            {
                var context = new DBRecetariosContext();

                var recetarios = recetarioRepository.GetRecetarios();

                _logger.LogInformation($"Retorna todos los recetarios");

                return Ok(recetarios);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error con GetAll: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }

        }
    }

    [Route("api/RecetasDeRecetario")]
    public class RecetasRecetarioController : Controller
    {
        private readonly ILogger<RecetarioController> _logger;
        private IRecetarioRepository recetarioRepository;
        public RecetasRecetarioController(ILogger<RecetarioController> logger)
        {
            _logger = logger;
            this.recetarioRepository = new RecetarioRepository(new DBRecetariosContext());
        }

        [HttpGet(Name = "GetRecetasDeRecetario")]
        public IActionResult GetReecetasDeRecetario(int id)
        {
            try
            {
                var context = new DBRecetariosContext();

                var recetasRecetario = recetarioRepository.RecetasDeUnRecetario(id);

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