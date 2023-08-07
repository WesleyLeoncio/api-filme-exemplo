
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

    public IEnumerable<FilmeResponse> ListarFilmes(int skip = 0, int take = 10)
    {
        return _mapper.Map<List<FilmeResponse>>(_repository.GetAll(skip, take));
    }

    public FilmeResponseDetalhado ListarFilme(int id)
    {
        return _mapper.Map<FilmeResponseDetalhado>(_repository.GetById(id));
    }

    public FilmeResponseDetalhado AdicionarFilme(FilmeCreateRequest filmeCreate)
    {
        var newFilme = _mapper.Map<Models.Filme.Entity.Filme>(filmeCreate);
        var filme = _repository.Insert(newFilme);
        return _mapper.Map<FilmeResponseDetalhado>(filme);
    }
    
    
    public FilmeResponseModificacao AtualizarFilme(FilmeUpdateRequest updateRequest)
    {
        var filme = _repository.GetById(updateRequest.Id);
        _mapper.Map(updateRequest, filme);
        var filmeUp = _repository.Update(filme);
        return _mapper.Map<FilmeResponseModificacao>(filmeUp);
    }

    public void DeletarFilme(int id)
    {
        var filme = _repository.GetById(id);
        if(filme != null) _repository.Delete(filme);
    }



    
}