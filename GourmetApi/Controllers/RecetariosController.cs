using Microsoft.AspNetCore.Mvc;
using Gourmet;

namespace GourmetApi.Controllers
{
    [ApiController]
    [Route("api/Recetarios")]
    public class RecetariosController : Controller
    {
        private readonly ILogger<RecetariosController> _logger;

        public RecetariosController(ILogger<RecetariosController> logger)
        {
            _logger = logger;
        }


        [HttpGet(Name = "GetRecetarios")]
        public IActionResult GetAll()
        {
            try
            {
                var context = new DBRecetariosContext();

                var recetarios = context.Recetarios.ToList();

                _logger.LogInformation($"Retorna todos los recetarios");

                return Ok(recetarios);
            } catch(Exception ex) 
            {
                _logger.LogError($"Error con GetAll: { ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
            
        }
    }
}
