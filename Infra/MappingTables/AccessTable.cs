using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MappingTables
{
    public class AccessTable : IEntityTypeConfiguration<Access>
    {
        public void Configure(EntityTypeBuilder<Access> builder)
        {
            builder.Ignore(x => x.Notifications);
            
            builder.ToTable("Accesses");

            builder.HasKey(x => x.Id).HasName("PK_Access");
            builder.Property(x => x.Id).HasColumnType("varchar(36)");
            builder.Property(x => x.Title).HasColumnType("varchar(45)").IsRequired();
            builder.Property(x => x.Description).HasColumnType("text").IsRequired();
            builder.Property(x => x.Active).HasColumnType("bit").IsRequired().HasDefaultValue(1);            
            
            builder.HasIndex(x => x.Title).HasDatabaseName("idx_Title");
            builder.HasIndex(x => x.Active).HasDatabaseName("idx_Active");

            builder.HasOne<Customer>( a => a.Customer ).WithMany(c => c.ListAccess).HasForeignKey(a => a.IdCustomer);
        }
    }
}