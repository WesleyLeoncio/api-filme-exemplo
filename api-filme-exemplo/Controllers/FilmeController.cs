
using api_filme_exemplo.Models.Filme.Request;
using api_filme_exemplo.Models.Filme.Response;
using api_filme_exemplo.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api_filme_exemplo.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{

   private IFilmeService _service;

   public FilmeController(IFilmeService service)
   {
      _service = service;
   }
    

   [HttpGet]
   public IEnumerable<FilmeResponse> ListarFilmes([FromQuery] int skip = 0,
      [FromQuery] int take = 10)
   {
      return _service.ListarTodosFilmes();
   }
   
   [HttpGet("{id}")]
   public IActionResult DetalharFilme(int id)
   {
     FilmeResponseDetalhado filme =  _service.ListarFilmePorId(id);
     return Ok(filme);
   }
   
   [HttpPost]
   public IActionResult CadastrarFilme([FromBody] FilmeCreateRequest filmeCreate)
   {
      FilmeResponseDetalhado response = _service.AdicionarFilme(filmeCreate);
      return CreatedAtAction(nameof(DetalharFilme), new { id = response.Id }, response);
   }
   
   [HttpPut]
   public IActionResult EditarFilme([FromBody] FilmeUpdateRequest filmeUpdateRequest)
   {
      FilmeResponseModificacao response = _service.AtualizarFilme(filmeUpdateRequest);
      return Ok(response);
   }
   
   [HttpDelete("{id}")]
   public IActionResult ExcluirFilme(int id)
   {
      _service.DeletarFilme(id);
      return NoContent();
   }
   
}