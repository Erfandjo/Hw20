using App.Domain.Core.Hw20.Car.Entities;
using App.Domain.Core.Hw20.CarModel.Entities;
using App.Domain.Core.Hw20.Company.Entities;
using App.Domain.Core.Hw20.Log.Entities;
using App.Domain.Core.Hw20.Request.Entities;
using App.Domain.Core.Hw20.Role.Entities;
using App.Domain.Core.Hw20.User.Entities;
using App.Infra.Data.Db.SqlServer.Ef.Configuration.CarModel;
using App.Infra.Data.Db.SqlServer.Ef.Configuration.Company;
using App.Infra.Data.Db.SqlServer.Ef.Configuration.Role;
using App.Infra.Data.Db.SqlServer.Ef.Configuration.User;
using Microsoft.EntityFrameworkCore;
namespace App.Infra.Data.Db.SqlServer.Ef.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarModelConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Log> Logs { get; set; }


    }
}
