using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MappingTables
{
    public class CustomerTable : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Ignore(x => x.Notifications);
            
            builder.ToTable("Customers");
            builder.HasKey(x => x.Id).HasName("PK_Customer");
            builder.Property(x => x.Id).HasColumnType("varchar(36)");
            builder.Property(x => x.CompanyName).HasColumnType("varchar(45)").IsRequired();
            builder.Property(x => x.FantasyName).HasColumnType("varchar(45)").IsRequired();
            builder.Property(x => x.CNPJ).HasColumnType("varchar(14)").IsRequired();
            builder.Property(x => x.Active).HasColumnType("bit").IsRequired().HasDefaultValue(1);
            
            builder.HasIndex(x => x.CompanyName).HasDatabaseName("idx_CompanyName");
            builder.HasIndex(x => x.FantasyName).HasDatabaseName("idx_FantasyName");
            builder.HasIndex(x => x.CNPJ).IsUnique().HasDatabaseName("idx_CNPJ");
            builder.HasIndex(x => x.Active).HasDatabaseName("idx_Active");

            builder.HasOne<CAT>( cus => cus.CAT ).WithMany(c => c.ListCustomer).HasForeignKey(cust => cust.IdCAT);
        }
    }
}