using ConsolaNetCoreEntityFrameWork.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ConsolaNetCoreEntityFrameWork
{
	class Program
	{
		static void Main(string[] args)
		{
			var builder = new ConfigurationBuilder()
			  .SetBasePath(Directory.GetCurrentDirectory())
			  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
			IConfiguration configuration = builder.Build();

			using (EFContext context = new EFContext(configuration))
			{
				foreach (Alumno alumno in context.Alumnos)					
					Console.WriteLine($"El alumno {alumno.Nombre} {alumno.Apellidos}");
			}
			Console.ReadLine();
		}
	}
}
