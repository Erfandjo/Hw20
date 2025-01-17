using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.Data.Db.SqlServer.Ef.Configuration.User
{
    public class UserConfiguration : IEntityTypeConfiguration<App.Domain.Core.Hw20.User.Entities.User>
    {
        public void Configure(EntityTypeBuilder<Domain.Core.Hw20.User.Entities.User> builder)
        {
            builder.HasData(
                
                new List<Domain.Core.Hw20.User.Entities.User>()
                {

                    new Domain.Core.Hw20.User.Entities.User()
                    {
                        
                        Id = 1,
                        NationalCode= "1820521079",
                        PhoneNumber = "09102001248",
                        RoleId = 1,
                        Address = "Tehran , Niavaran",
                        
                    }

                }

            
                
                
                );
        }
    }
}
