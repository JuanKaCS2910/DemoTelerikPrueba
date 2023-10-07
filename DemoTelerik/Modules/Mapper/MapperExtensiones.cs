using AutoMapper;
using DemoTelerik.Transversal.Mapper;

namespace DemoTelerik.Modules.Mapper
{
	public static class MapperExtensiones
	{
		public static IServiceCollection AddMapper(this IServiceCollection services)
		{
			// Auto Mapper Configurations
			var mappingConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new MappingsProfile());
			});
			IMapper mapper = mappingConfig.CreateMapper();
			services.AddSingleton(mapper);

			return services;
		}
	}
}
