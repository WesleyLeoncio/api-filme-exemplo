using api_filme_exemplo.Models.Filme.Request;
using api_filme_exemplo.Models.Filme.Response;
using AutoMapper;

namespace api_filme_exemplo.Models.Filme.Profiles;

public class FilmeProfile : Profile
{
    public FilmeProfile()
    {
        CreateMap<Entity.Filme, FilmeResponse>();
        CreateMap<Entity.Filme, FilmeResponseDetalhado>();
        CreateMap<Entity.Filme, FilmeResponseModificacao>();
        CreateMap<FilmeCreateRequest, Entity.Filme>();
        CreateMap<FilmeUpdateRequest, Entity.Filme>();
    }
    
}