using EfHw.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfHw.Data;

public class DataContext:DbContext
{
    public DbSet<Player> Players { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options){}
}