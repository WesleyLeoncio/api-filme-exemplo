using System.ComponentModel.DataAnnotations;

namespace api_filme_exemplo.Models.Filme.Request;

public class FilmeUpdateRequest
{   
    [Required(ErrorMessage = "O id do filme é obrigatório")]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O nome do filme é obrigatório")]
    public string? Nome { get; set; }
    
    [Required(ErrorMessage = "A descrição do filme é obrigatório")]
    public string? Descricao { get; set; }

    [Required(ErrorMessage = "A data do filme é obrigatório")]
    public DateTime DataLancamento { get; set; }

    [Required(ErrorMessage = "O duração do filme é obrigatório")]
    public string? Duracao { get; set; }

    [Required(ErrorMessage = "O imagem do filme é obrigatório")]
    public string? Imagem { get; set; }

    [Required(ErrorMessage = "O categoria do filme é obrigatório")]
    public string? Categoria { get; set; }
}