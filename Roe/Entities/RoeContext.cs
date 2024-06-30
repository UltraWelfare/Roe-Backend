using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Roe.Entities;

public class RoeContext : IdentityDbContext<IdentityUser>
{
    public DbSet<UserFactory> UserFactories { get; set; } = null!;
    public DbSet<Factory> Factories { get; set; } = null!;

    public DbSet<Customer> Customers { get; set; } = null!;

    public DbSet<Supplier> Suppliers { get; set; } = null!;

    public DbSet<SupplyOrder> SupplyOrders { get; set; } = null!;

    public DbSet<Order> Orders { get; set; } = null!;
    
    public DbSet<OrderStatus> OrderStatuses { get; set; } = null!;
    
    public DbSet<OrderProcess> OrderProcesses { get; set; } = null!;

    public DbSet<OrderProcessStatus> OrderProcessStatuses { get; set; } = null!;

    public DbSet<OrderTemplate> OrderTemplates { get; set; } = null!;

    public DbSet<OrderTemplateProcess> OrderTemplateProcesses { get; set; } = null!;

    public DbSet<Process> Processes { get; set; } = null!;


    public RoeContext(DbContextOptions<RoeContext> options) : base(options)
    {
    }
}