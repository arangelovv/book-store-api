using Microsoft.EntityFrameworkCore;

namespace book_store_api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
}