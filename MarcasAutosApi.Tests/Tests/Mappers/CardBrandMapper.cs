using AutoMapper;
using MarcasAutosApi.Utils.Mappers;
using Xunit;

namespace MarcasAutosApi.Tests.Mappers
{
	public class CarBrandMapperTests
	{
		[Fact]
		public void CarBrandMapper_Configuration_IsValid()
		{
		
			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<CarBrandMapper>();
			});

		
			config.AssertConfigurationIsValid();
		}
	}
}
