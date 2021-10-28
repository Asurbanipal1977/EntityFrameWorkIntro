using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaEntityFrameWork
{
	class Program
	{
		static void Main(string[] args)
		{
			using (pruebasEntities db = new pruebasEntities())
			{
				foreach (alumnos alumno in db.alumnos)
				{
					Console.WriteLine($"{alumno.Nombre} - {alumno.Apellidos}");
				}
			}

			Console.ReadLine();
		}
	}
}
