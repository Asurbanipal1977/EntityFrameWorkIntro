using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EntityFrameWorkIntro.Models;

namespace EntityFrameWorkIntro.Data
{
    public class EFIntroContext : DbContext
    {
        public EFIntroContext (DbContextOptions<EFIntroContext> options)
            : base(options)
        {
        }

        public DbSet<EntityFrameWorkIntro.Models.Pais> Paises { get; set; }

        public DbSet<EntityFrameWorkIntro.Models.Alumno> Alumnos { get; set; }
    }
}
