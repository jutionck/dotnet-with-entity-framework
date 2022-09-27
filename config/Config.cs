using dotnet_menu_app.models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_menu_app.config;

public class Config: DbContext
{
    public DbSet<Student> Students { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string dsn = "Server=68.183.226.244;Database=db_siakad;User id=sa;Password=P@ssw0rd";
        optionsBuilder.UseSqlServer(dsn);
    }
}