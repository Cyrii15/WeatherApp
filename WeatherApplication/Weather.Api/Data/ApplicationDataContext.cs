using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Weather.Api.Entities;

namespace Weather.Api.Data;

public class ApplicationDataContext : DbContext
{
    public ApplicationDataContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        var cusModel = builder.Entity<Customer>();

        cusModel.ToContainer("Customers")
            .HasNoDiscriminator()
            .HasKey(c => c.Id);

        //builder.Entity<Customer>()
        // .ToContainer(nameof(Customer))
        // .HasPartitionKey(c => c.Id)
        // .HasNoDiscriminator();

        builder.Entity<Order>()
         .ToContainer(nameof(Order))
         .HasPartitionKey(o => o.CustomerId)
         .HasNoDiscriminator();

        builder.Entity<Address>()
         .ToContainer(nameof(Address))
         .HasPartitionKey(c => c.CustomerId)
         .HasNoDiscriminator();

        builder.Entity<User>()
         .ToContainer(nameof(User))
         .HasPartitionKey(c => c.Id)
         .HasNoDiscriminator();
    }
}