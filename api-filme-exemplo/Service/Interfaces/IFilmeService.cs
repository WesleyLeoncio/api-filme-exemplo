using api_filme_exemplo.Models.Filme.Request;
using api_filme_exemplo.Models.Filme.Response;

namespace api_filme_exemplo.Service.Interfaces;

public interface IFilmeService
{
    IEnumerable<FilmeResponseDetalhado> ListarTodosFilmes(int skip = 0, int take = 10);

    FilmeResponseDetalhado ListarFilmePorId(int id);

    FilmeResponseDetalhado AdicionarFilme(FilmeCreateRequest filmeCreate);

    FilmeResponseModificacao AtualizarFilme(FilmeUpdateRequest updateRequest);

    void DeletarFilme(int id);

}