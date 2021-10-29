using ConsolaNetCoreEntityFrameWork.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace ConsolaNetCoreEntityFrameWork
{
	class Program
	{
		static void Main(string[] args)
		{
			//Configuración para leer el fichero json.
			var builder = new ConfigurationBuilder()
			  .SetBasePath(Directory.GetCurrentDirectory())
			  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
			IConfiguration configuration = builder.Build();

			//Service para la inyección
			var services = new ServiceCollection()
				.AddDbContext<EFContext>(options =>
					options.UseSqlServer(configuration.GetConnectionString("EFIntroContext")))
				.BuildServiceProvider();

			//inyección de dependencia
			using (EFContext context = services.GetService<EFContext>())
			{
				foreach (Alumno alumno in context.Alumnos)
					Console.WriteLine($"El alumno {alumno.Nombre} {alumno.Apellidos}");
			}
			Console.ReadLine();
		}
	}
}
