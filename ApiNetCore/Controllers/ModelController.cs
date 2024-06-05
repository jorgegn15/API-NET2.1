using ApiNetCore.Models;
using ApiNetCore.Repository;
using ApiNetCore.Request;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : Controller
    {
        private readonly IModelItemRepository _modelRepository;
        public ModelController(IModelItemRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }
        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ModelRequest request)
        {
            var entity = new ModelItem
            {
                EsCliente = true,
                Nombre = request.Nombre
            };

            await _modelRepository.AddModelItem(entity);
            return Ok();
        }
    }
}
