using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
//primary contructor oluyor aslında classın içinde
{
    public DbSet<AppUser> Users { get; set; }
}
