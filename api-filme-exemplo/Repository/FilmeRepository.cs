using api_filme_exemplo.Infra.Data;
using api_filme_exemplo.Models.Filme.Entity;
using api_filme_exemplo.Repository.interfaces;

namespace api_filme_exemplo.Repository;

public class FilmeRepository : IFilmeRepository
{
    private ConectionContext _context;
    
    public FilmeRepository(ConectionContext context)
    {
        _context = context;
    }


    public IEnumerable<Filme> GetAll(int skip = 0, int take = 10)
    {
        return _context.FilmeBd!.Skip(skip).Take(take);
    }

    public Filme? GetById(int id)
    {
        return _context.FilmeBd!.FirstOrDefault(filme => filme.Id == id);
    }

    public Filme Insert(Filme filme)
    {
        _context.FilmeBd!.Add(filme);
        _context.SaveChanges();
        return filme;
    }

    public Filme Update(Filme filme)
    {
        _context.SaveChanges();
        return filme;
    }

    public void Delete(Filme filme)
    {
        _context.FilmeBd!.Remove(filme);
        _context.SaveChanges();
    }
}