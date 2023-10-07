using DemoTelerik.Infraestructura.Data;

namespace DemoTelerik.Modules.Injection
{
	public static class InjectionExtensiones
	{
		public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddSingleton<IConfiguration>(configuration);
			services.AddSingleton<DapperContext>();

			//#region Aplication
			//services.AddScoped<IUsuariosAplicacion, UsuariosAplicacion>();
			//services.AddScoped<IDistritosAplicacion, DistritosAplicacion>();
			//services.AddScoped<ICamillasAplicacion, CamillasAplicacion>();
			//services.AddScoped<IPersonasAplicacion, PersonasAplicacion>();
			//services.AddScoped<IConsultaGenericaAplicacion, ConsultaGenericaAplicacion>();
			//services.AddScoped<IHistoricoAplicacion, HistoricoAplicacion>();
			//#endregion

			//#region Domain
			//services.AddScoped<IUsuariosDominio, UsuariosDominio>();
			//services.AddScoped<IDistritosDominio, DistritosDominio>();
			//services.AddScoped<ICamillasDominio, CamillasDominio>();
			//services.AddScoped<IPersonasDominio, PersonasDominio>();
			//services.AddScoped<IConsultaGenericaDominio, ConsultaGenericaDominio>();
			//services.AddScoped<IHistoricoDominio, HistoricoDominio>();
			//#endregion

			//#region Repository
			//services.AddScoped<IUsuariosRepository, UsuariosRepository>();
			//services.AddScoped<IDistritosRepository, DistritosRepository>();
			//services.AddScoped<ICamillasRepository, CamillasRepository>();
			//services.AddScoped<IPersonasRepository, PersonasRepository>();
			//services.AddScoped<IConsultaGenericaRepository, ConsultaGenericaRepository>();
			//services.AddScoped<IHistoricoRepository, HistoricoRepository>();
			//#endregion

			////services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
			//services.AddScoped<IUnitOfWork, UnitOfWork>();

			return services;

		}
	}
}
