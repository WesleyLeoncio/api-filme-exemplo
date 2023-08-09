namespace api_filme_exemplo.Models.Filme.Response;

public class FilmeResponseModificacao
{
    public string? Nome { get; set; }
    
    public string? Descricao { get; set; }

    public DateTime DataLancamento { get; set; }

    public string? Duracao { get; set; }

    public string? Imagem { get; set; }

    public string? Categoria { get; set; }
    
    public DateTime DataOperacao { get; set; } = DateTime.Now;
}