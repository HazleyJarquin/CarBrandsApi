using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarcasAutosApi.Controllers;
using MarcasAutosApi.Dtos;
using MarcasAutosApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using System.Text.Json;

namespace MarcasAutosApi.Tests.Controllers
{
    public class CarBrandsControllerTests
    {
        [Fact]
        public async Task Get_ReturnsOkResult_WithCarBrands()
        {
            // Arrange
            var mockService = new Mock<ICarBrandService>();
            mockService.Setup(s => s.GetCarBrandsAsync())
                       .ReturnsAsync(new List<CarBrandDto>
                       {
                           new CarBrandDto { Name = "Toyota" },
                           new CarBrandDto { Name = "Honda" }
                       });

            var controller = new CarBrandsController(mockService.Object);

            // Act
            var result = await controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var brands = Assert.IsType<List<CarBrandDto>>(okResult.Value);
            Assert.Equal(2, brands.Count);
        }

        [Fact]
        public async Task Post_ValidDto_ReturnsOkWithMessage()
        {
            // Arrange
            var dto = new CarBrandDto { Name = "Mazda" };
            var mockService = new Mock<ICarBrandService>();

            mockService.Setup(s => s.AddAsync(dto)).Returns(Task.CompletedTask);
            var controller = new CarBrandsController(mockService.Object);

            // Act
            var result = await controller.Post(dto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);

            var expected = JsonSerializer.Serialize(new { message = "Marca creada correctamente." });
            var actual = JsonSerializer.Serialize(okResult.Value);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task Post_InvalidDto_ReturnsBadRequest()
        {
            // Arrange
            var dto = new CarBrandDto { Name = "" };
            var mockService = new Mock<ICarBrandService>();

            mockService.Setup(s => s.AddAsync(dto))
                       .ThrowsAsync(new ArgumentException("Nombre inválido"));

            var controller = new CarBrandsController(mockService.Object);

            // Act
            var result = await controller.Post(dto);

            // Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(result);

            var expected = JsonSerializer.Serialize(new { error = "Nombre inválido" });
            var actual = JsonSerializer.Serialize(badRequest.Value);

            Assert.Equal(expected, actual);
        }
    }
}
