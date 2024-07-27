using Microsoft.EntityFrameworkCore;

namespace EsPlaytime;

public class EsDbContext : DbContext
{
    public EsDbContext(DbContextOptions<EsDbContext> options) : base(options)
    {
    }
}