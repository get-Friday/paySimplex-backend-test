using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using paySimplex.Domain.Models;

namespace paySimplex.Infra.Data.Mappings
{
    internal class ChoreMap : IEntityTypeConfiguration<Chore>
    {
        public void Configure(EntityTypeBuilder<Chore> builder)
        {
            builder.ToTable("CHORES");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id)
                .HasColumnName("ID");
            builder
                .Property(a => a.Name)
                .HasColumnName("NAME")
                .HasColumnType("VARCHAR")
                .HasMaxLength(300)
                .IsRequired();
            builder
                .Property(a => a.StartDate)
                .HasColumnName("START_DATE")
                .HasColumnType("DATETIME")
                .IsRequired();
            builder
                .Property(a => a.EndDate)
                .HasColumnName("END_DATE")
                .HasColumnType("DATETIME")
                .IsRequired();
            builder
                .Property(a => a.Status)
                .HasColumnName("STATUS")
                .HasColumnType("INT")
                .IsRequired();
            builder
                .HasOne<User>(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .IsRequired();
        }
    }
}
