using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Homework_16.Models;

public class AppDbContext : DbContext
{
    public AppDbContext() : base("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ClisntsStorage;Integrated Security=True;Pooling=False") {}
    public DbSet<Client> Clients { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasOptional(p => p.Client)  
            .WithMany(c => c.Products)   
            .HasForeignKey(p => p.Email); 

        base.OnModelCreating(modelBuilder);
    }
}