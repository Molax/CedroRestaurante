using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedro.Projeto.Restaurante.Infra.Data.Contexto
{
    public class ProjetoModelContexto : DbContext
    {
        public ProjetoModelContexto()
    : base("Server=DESKTOP-B6FJ5HN;Database=CedroRestaurante;Trusted_Connection=True;")
        {
        }

        public DbSet<Domain.Entities.Restaurante> Restaurante { get; set; }
        public DbSet<Domain.Entities.Prato> Prato { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.Restaurante>().HasKey(t => t.IdRestaurante);
            modelBuilder.Entity<Domain.Entities.Restaurante>().Property(t => t.IdRestaurante)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Domain.Entities.Prato>().HasKey(t => t.IdPrato);
            modelBuilder.Entity<Domain.Entities.Prato>().Property(t => t.IdPrato)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }
    }
}
