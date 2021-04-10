

using EfCore.Data.Configuration;
using EfCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace EfCore.Data
{
    public class EFContext: DbContext
    {
        private readonly string _connectionString;
        public DbSet<Alumno> Alumnos { get; set; }
        public EFContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {   
            if(!options.IsConfigured)
                options.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {

            //new AlumnoConfiguration().Configure(modelBuilder.Entity<Alumno>());
            //Es la misma forma de hacer lo anterior
            modelBuilder.ApplyConfiguration(new AlumnoConfiguration());

           // modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
           //Se utiliza para aplicar todos los configuration que se hayan de definido en el assembly
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges() => SaveChangesAsync().Result;

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var now = DateTime.UtcNow;

            ChangeTracker.Entries<BaseModel>()
                .Where(entity => entity.State == EntityState.Added)
                .ToList().ForEach(item => item.Entity.CreateAt = item.Entity.UpdateAt = now);

            ChangeTracker.Entries<BaseModel>()
                .Where(entity => entity.State == EntityState.Modified)
                .ToList().ForEach(item => item.Entity.UpdateAt = now);

            return await base.SaveChangesAsync(cancellationToken);

        }
    }
}
