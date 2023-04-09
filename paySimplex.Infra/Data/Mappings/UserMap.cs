using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using paySimplex.Domain.Models;

namespace paySimplex.Infra.Data.Mappings
{
    internal class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("USERS");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .HasColumnName("ID");
            builder
                .Property(u => u.Name)
                .HasColumnName("NAME")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255)
                .IsRequired();
            builder
                .Property(u => u.Email)
                .HasColumnName("EMAIL")
                .HasColumnType("VARCHAR")
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
