using Microsoft.EntityFrameworkCore;

public class FurnitureStoreContext : DbContext
{

    public DbSet<Client> Clients { get; set; }
    public DbSet<Furniture> Furnitures { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Carpenter> Carpenters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder); optionsBuilder.UseNpgsql(@"Host=localhost;
                                                                    Database=furnitureStore;
                                                                    Username=furnitureStore;
                                                                    Password=password")
            .UseSnakeCaseNamingConvention()
            .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole())).EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>().Property(cl => cl.id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Furniture>().Property(fu => fu.id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Order>().Property(or => or.id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Driver>().Property(dr => dr.id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Carpenter>().Property(car => car.id).ValueGeneratedOnAdd();

        modelBuilder.Entity<Client>().HasMany(cl => cl.orders).WithOne(or => or.client);
        modelBuilder.Entity<Order>().HasMany(or => or.furnitures).WithMany(fu => fu.orders);
        modelBuilder.Entity<Carpenter>().HasMany(ca => ca.orders).WithOne(or => or.carpenter);
        modelBuilder.Entity<Driver>().HasMany(dr => dr.orders).WithOne(or => or.driver);
    }


}


