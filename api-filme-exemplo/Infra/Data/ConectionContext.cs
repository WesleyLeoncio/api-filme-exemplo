using api_filme_exemplo.Models.Filme.Entity;
using Microsoft.EntityFrameworkCore;

namespace api_filme_exemplo.Infra.Data;

public class ConectionContext : DbContext
{
    public ConectionContext(DbContextOptions<ConectionContext> opts)
        : base(opts)
    {}
    
    public DbSet<Filme>? FilmeBd { get; set; }
}