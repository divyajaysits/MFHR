using MF.HR.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;

public class ApplicationDbContext : DbContext
{
    protected readonly IConfiguration Configuration;
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
    {
        Configuration = configuration;
    }

    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Employee>().Property(p => p.ID).ValueGeneratedOnAdd();
        builder.Entity<Employee>().ToTable($"MFHR_{nameof(this.Employees)}");
    }
}