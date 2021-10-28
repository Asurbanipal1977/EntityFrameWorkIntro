using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameWorkIntro.Models
{
	public class Alumno
	{
		public long Id { get; set; }
		public string Nombre { get; set; }
		public string Apellidos { get; set; }
		public string Dni { get; set; }

		[Display(Name = "Fecha de Nacimiento")]
		public string FechaNacimiento { get; set; }
		public long Pais { get; set; }

		[Display(Name = "Estado Civil")]
		public string EstadoCivil { get; set; }
	}
}
