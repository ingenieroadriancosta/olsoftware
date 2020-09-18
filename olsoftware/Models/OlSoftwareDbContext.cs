using System;
using Microsoft.EntityFrameworkCore;
using olsoftware.Models.AllModelsParams;
/* 
dotnet ef migrations add OlSoftwareDbContext
dotnet ef migrations remove
dotnet ef database update 
//
https://referbruv.com/blog/posts/working-with-stored-procedures-in-aspnet-core-ef-core
https://www.yogihosting.com/stored-procedures-entity-framework-core/
https://www.entityframeworktutorial.net/efcore/working-with-stored-procedure-in-ef-core.aspx
//
*/
namespace olsoftware.Models
{
    public class OlSoftwareDbContext : DbContext
    {
        public DbSet<ClientesParams> Clientes { get; set; }
        public DbSet<ProyectosParams> Proyectos { get; set; }
        //
        public OlSoftwareDbContext(DbContextOptions<OlSoftwareDbContext> options) : base(options)
        {
            // COMPRUEBA QUE LA BD ESTÁ CREADA Y SI NO LA CREA.
            Database.EnsureCreated();
        }
        //
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //
            modelBuilder.Entity<ProyectosParams>()
                .HasOne(p => p.ClientesParams)
                .WithMany(b => b.PPAR)
                .HasForeignKey(p => p.iduser)
                .HasPrincipalKey(b => b.idcard);
            modelBuilder.Entity<ClientesParams>().Property(a => a.idcard).ValueGeneratedNever();
            modelBuilder.Entity<ProyectosParams>().Property(a => a.iduser).ValueGeneratedNever();
            //
        }
        //
    }
}// END_NAME_SPACE