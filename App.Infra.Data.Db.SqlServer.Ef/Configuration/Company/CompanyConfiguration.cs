using Microsoft.EntityFrameworkCore;
using App.Domain.Core.Hw20.Company.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace App.Infra.Data.Db.SqlServer.Ef.Configuration.Company
{
    public class CompanyConfiguration : IEntityTypeConfiguration<App.Domain.Core.Hw20.Company.Entities.Company>
    {
        public void Configure(EntityTypeBuilder<Domain.Core.Hw20.Company.Entities.Company> builder)
        {
            builder.HasData(
                
                new List<Domain.Core.Hw20.Company.Entities.Company>
                {
                    new Domain.Core.Hw20.Company.Entities.Company
                    {
                        Id = 1,
                        Name = "IranKhodro",
                    },
                    new Domain.Core.Hw20.Company.Entities.Company
                    {
                        Id = 2,
                        Name = "Shaipa"
                    },
                }
                
                
                
                );
        }
    }
}
