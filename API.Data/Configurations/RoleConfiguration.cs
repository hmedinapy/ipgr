using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using API.Data.Entities;

namespace API.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<AspNetRole> //IdentityRole>
    {
        public void Configure(EntityTypeBuilder<AspNetRole> builder)
        {
            builder.HasData(
                new AspNetRole
                {
                    Id = "1",
                    Name = "User",
                    NormalizedName = "USER"
                },
                new AspNetRole
                {
                    Id = "2",
                    Name = "Administrador",
                    NormalizedName = "ADMINISTRADOR"
                },
                new AspNetRole
                {
                    Id = "3",
                    Name = "Auditor",
                    NormalizedName = "AUDITOR"
                },
                new AspNetRole
                {
                    Id = "4",
                    Name = "Auditado",
                    NormalizedName = "AUDITADO"
                }
            );
        }
    }
}
