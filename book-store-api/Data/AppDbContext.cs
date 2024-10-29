using book_store_api.Models;
using Microsoft.EntityFrameworkCore;

namespace book_store_api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<UserModel> Users { get; set; }

    
}