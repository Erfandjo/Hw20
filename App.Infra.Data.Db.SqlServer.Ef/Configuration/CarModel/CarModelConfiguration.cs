using Microsoft.EntityFrameworkCore;
using App.Domain.Core.Hw20.CarModel.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.Data.Db.SqlServer.Ef.Configuration.CarModel
{
    public class CarModelConfiguration : IEntityTypeConfiguration<App.Domain.Core.Hw20.CarModel.Entities.CarModel>
    {
        public void Configure(EntityTypeBuilder<Domain.Core.Hw20.CarModel.Entities.CarModel> builder)
        {
            builder.HasData
                (
                new List<App.Domain.Core.Hw20.CarModel.Entities.CarModel>
                {
                    new Domain.Core.Hw20.CarModel.Entities.CarModel()
                    {
                        Id = 1,
                        Name = "Peugeot 206",
                        CompanyId = 1,
                    },

                    new Domain.Core.Hw20.CarModel.Entities.CarModel()
                    {
                        Id = 2,
                        Name = "Peugeot Pars",
                        CompanyId = 1,
                    },

                    new Domain.Core.Hw20.CarModel.Entities.CarModel()
                    {
                        Id = 3,
                        Name = "Tara",
                        CompanyId = 1,
                    },

                    new Domain.Core.Hw20.CarModel.Entities.CarModel()
                    {
                        Id = 4,
                        Name = "Dena",
                        CompanyId = 1,
                    },

                    new Domain.Core.Hw20.CarModel.Entities.CarModel()
                    {
                        Id = 5,
                        Name = "Rira",
                        CompanyId = 1,
                    },

                    new Domain.Core.Hw20.CarModel.Entities.CarModel()
                    {
                        Id = 6,
                        Name = "Rira",
                        CompanyId = 1,
                    },

                    new Domain.Core.Hw20.CarModel.Entities.CarModel()
                    {
                        Id = 7,
                        Name = "Pride 111",
                        CompanyId = 2,
                    },


                    new Domain.Core.Hw20.CarModel.Entities.CarModel()
                    {
                        Id = 8,
                        Name = "Pride 131",
                        CompanyId = 2,
                    },


                    new Domain.Core.Hw20.CarModel.Entities.CarModel()
                    {
                        Id = 9,
                        Name = "Quick",
                        CompanyId = 2,
                    },

                    new Domain.Core.Hw20.CarModel.Entities.CarModel()
                    {
                        Id = 10,
                        Name = "Tiba",
                        CompanyId = 2,
                    },


                    new Domain.Core.Hw20.CarModel.Entities.CarModel()
                    {
                        Id = 11,
                        Name = "Shahin",
                        CompanyId = 2,
                    },



                }







                );
        }
    }
}
