using api_filme_exemplo.Data;
using api_filme_exemplo.Models.Filme.Request;
using api_filme_exemplo.Models.Filme.Response;
using AutoMapper;


namespace api_filme_exemplo.Service.Filme;

public class FilmeService
{
    private ConectionContext _context;

    private IMapper _mapper;

    public FilmeService(ConectionContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<FilmeResponse> ListarFilmes(int skip = 0, int take = 10)
    {
        return _mapper.Map<List<FilmeResponse>>(_context.FilmeBd!.Skip(skip).Take(take));
    }

    public FilmeResponseDetalhado ListarFilme(int id)
    {
        return _mapper.Map<FilmeResponseDetalhado>(_context.FilmeBd!.FirstOrDefault(filme => filme.Id == id));
    }

    public FilmeResponseDetalhado AdicionarFilme(FilmeCreateRequest filmeCreate)
    {
        var filme = _mapper.Map<Models.Filme.Entity.Filme>(filmeCreate);
        _context.FilmeBd!.Add(filme);
        _context.SaveChanges();
        return _mapper.Map<FilmeResponseDetalhado>(filme);
    }
    
    
    public FilmeResponseModificacao AtualizarFilme(FilmeUpdateRequest updateRequest)
    {
        var filme = GetFilmeId(updateRequest.Id);
        _mapper.Map(updateRequest, filme);
        _context.SaveChanges();
        return _mapper.Map<FilmeResponseModificacao>(filme);
    }

    public void DeletarFilme(int id)
    {
        var filme = GetFilmeId(id);
        _context.FilmeBd!.Remove(filme);
        _context.SaveChanges();
    }


    private Models.Filme.Entity.Filme GetFilmeId(int id)
    {
        var filme = _context.FilmeBd!.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) throw new Exception("Filme não encontrado");
        return filme;
    }
    
}