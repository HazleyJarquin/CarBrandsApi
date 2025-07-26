using MarcasAutosApi.Dtos;
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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CarBrandDto dto)
        {
            try
            {
                await _service.AddAsync(dto);
                return Ok(new { message = "Marca creada correctamente." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
