
using api_filme_exemplo.Models.Filme.Request;
using api_filme_exemplo.Models.Filme.Response;
using api_filme_exemplo.Repository.interfaces;
using AutoMapper;


namespace api_filme_exemplo.Service.Filme;

public class FilmeService
{
    
    private IMapper _mapper;

    private IFilmeRepository _repository;

    public FilmeService(IMapper mapper, IFilmeRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public IEnumerable<FilmeResponse> ListarTodosFilmes(int skip = 0, int take = 10)
    {
        return _mapper.Map<List<FilmeResponse>>(_repository.GetAll(skip, take));
    }

    public FilmeResponseDetalhado ListarFilmePorId(int id)
    {
        return _mapper.Map<FilmeResponseDetalhado>(VerificarFilme(id));
    }

    public FilmeResponseDetalhado AdicionarFilme(FilmeCreateRequest filmeCreate)
    {
        var newFilme = _mapper.Map<Models.Filme.Entity.Filme>(filmeCreate);
        _repository.Insert(newFilme);
        return _mapper.Map<FilmeResponseDetalhado>(newFilme);
    }
    
    
    public FilmeResponseModificacao AtualizarFilme(FilmeUpdateRequest updateRequest)
    {
        var filme = VerificarFilme(updateRequest.Id);
        _mapper.Map(updateRequest, filme);
        _repository.Update(filme);
        return _mapper.Map<FilmeResponseModificacao>(filme);
    }

    public void DeletarFilme(int id)
    {
        _repository.Delete(VerificarFilme(id));
    }


    private Models.Filme.Entity.Filme VerificarFilme(int id)
    {
        var filme = _repository.GetById(id);
        if (filme == null) throw new Exception("Filme não encontrado!");
        return filme;
    }   
    
}