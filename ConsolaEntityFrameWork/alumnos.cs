//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsolaEntityFrameWork
{
    using System;
    using System.Collections.Generic;
    
    public partial class alumnos
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Dni { get; set; }
        public string FechaNacimiento { get; set; }
        public Nullable<long> Pais { get; set; }
        public string EstadoCivil { get; set; }
    
        public virtual paises paises { get; set; }
    }
}