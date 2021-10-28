using ConsolaNetCoreEntityFrameWork.Models;
using System;

namespace ConsolaNetCoreEntityFrameWork
{
	class Program
	{
		static void Main(string[] args)
		{
			using (EFContext context = new EFContext())
			{
				foreach (Alumno alumno in context.Alumnos)					
					Console.WriteLine($"El alumno {alumno.Nombre}");
			}
			Console.ReadLine();
		}
	}
}
