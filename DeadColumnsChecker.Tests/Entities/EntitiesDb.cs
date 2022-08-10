using Microsoft.EntityFrameworkCore;

namespace DeadColumnsChecker.Tests.Entities;

public class EntitiesDb : DbContext
{
    public DbSet<Article> Articles { get; set; }

    public DbSet<User> Users { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=WeRecruit-local;User ID=sa;Password=Password!");
    }
}