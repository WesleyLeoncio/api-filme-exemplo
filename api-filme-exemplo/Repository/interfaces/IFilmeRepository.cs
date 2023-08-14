using api_filme_exemplo.Models.Filme.Entity;

namespace api_filme_exemplo.Repository.Interfaces;

public interface IFilmeRepository
{
    public IEnumerable<Filme> GetAll(int skip = 0, int take = 10);

    public Filme? GetById(int id);

    public Filme Insert(Filme filme);

    public Filme Update(Filme filme);

    public void Delete(Filme filme);

}