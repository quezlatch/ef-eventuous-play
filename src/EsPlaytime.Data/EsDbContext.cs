using Microsoft.EntityFrameworkCore;

namespace EsPlaytime.Data;

public class EsDbContext : DbContext
{
    public EsDbContext(DbContextOptions<EsDbContext> options) : base(options)
    {
    }
}