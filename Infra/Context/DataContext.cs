using System.Reflection;
using Domain.Entities;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options){}
        
        DbSet<CAT> CATs {get;set;}
        DbSet<Customer> Customers {get;set;}
        DbSet<Access> Accesses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
            modelBuilder.Entity<Notification>().HasNoKey();

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            base.OnModelCreating(modelBuilder);
        }        
    }
}