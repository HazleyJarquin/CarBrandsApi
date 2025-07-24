using MarcasAutosApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MarcasAutosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarBrandsController : Controller
    {
        private readonly ICarBrandService _service;

        public CarBrandsController(ICarBrandService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var marcas = await _service.GetCarBrandsAsync();
            return Ok(marcas);
        }
    }
}
