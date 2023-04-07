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
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .HasColumnName("ID");
            builder
                .Property(c => c.Name)
                .HasColumnName("NAME")
                .HasColumnType("VARCHAR")
                .HasMaxLength(300)
                .IsRequired();
            builder
                .Property(c => c.StartDate)
                .HasColumnName("START_DATE")
                .HasColumnType("DATETIME")
                .IsRequired();
            builder
                .Property(c => c.EndDate)
                .HasColumnName("END_DATE")
                .HasColumnType("DATETIME")
                .IsRequired();
            builder
                .Property(c => c.Status)
                .HasColumnName("STATUS")
                .HasColumnType("INT")
                .IsRequired();
            builder
                .Property(c => c.File)
                .HasColumnName("FILE")
                .HasColumnType("VARBINARY");
            builder
                .HasOne<User>(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .IsRequired();
        }
    }
}
