using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace EfCore.Data
{
    public class DesignTimeDbInassContextFactory : IDesignTimeDbContextFactory<EFContext>
    {
        public EFContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<EFContext>();
            var connStr = "data source = DESKTOP-VGPBEL0; initial catalog = Study; user id = sa; password = jym0927*SqlServer";

            builder.UseSqlServer(connStr,
                b => b.MigrationsAssembly("EfCore"));

            return new EFContext(builder.Options);
        }
    }
}
