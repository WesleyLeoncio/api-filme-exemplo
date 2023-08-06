﻿
using api_filme_exemplo.Models.Filme.Request;
using api_filme_exemplo.Models.Filme.Response;
using api_filme_exemplo.Service.Filme;
using Microsoft.AspNetCore.Mvc;

namespace api_filme_exemplo.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{

   private FilmeService _service;

   public FilmeController(FilmeService service)
   {
      _service = service;
   }
    

   [HttpGet]
   public IEnumerable<FilmeResponse> RecuperaFilmes([FromQuery] int skip = 0,
      [FromQuery] int take = 50)
   {
      return _service.ListarFilmes();
   }
   
   [HttpGet("{id}")]
   public IActionResult DetalharFilme(int id)
   {
     FilmeResponseDetalhado filme =  _service.ListarFilme(id);
     if (filme == null) return NotFound();
     return Ok(filme);
   }
   
   [HttpPost]
   public IActionResult AdicionarFilme([FromBody] FilmeCreateRequest filmeCreate)
   {
      FilmeResponseDetalhado response = _service.AdicionarFilme(filmeCreate);
      return CreatedAtAction(nameof(DetalharFilme), new { id = response.Id }, response);
   }
   
   [HttpPut]
   public IActionResult AtualizarFilme([FromBody] FilmeUpdateRequest filmeUpdateRequest)
   {
      FilmeResponseModificacao response = _service.AtualizarFilme(filmeUpdateRequest);
      return Ok(response);
   }
   
   [HttpDelete("{id}")]
   public IActionResult DeletarFilme(int id)
   {
      _service.DeletarFilme(id);
      return NoContent();
   }
   
}