using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.Configuration.Role
{
    public class RoleConfiguration : IEntityTypeConfiguration<App.Domain.Core.Hw20.Role.Entities.Role>
    {
        public void Configure(EntityTypeBuilder<Domain.Core.Hw20.Role.Entities.Role> builder)
        {
            builder.HasData
                (
                new List<App.Domain.Core.Hw20.Role.Entities.Role>
                {
                    new Domain.Core.Hw20.Role.Entities.Role()
                    {
                        Id = 1,
                        Title = "Admin"
                    },

                    new App.Domain.Core.Hw20.Role.Entities.Role()
                    {
                        Id = 2,
                        Title = "Memmber"
                    }
                }
                
                );
        }
    }
}
