namespace api_filme_exemplo.Models.Filme.Response;

public class FilmeResponseDetalhado
{   
    public int Id { get; set; }
    
    public string? Nome { get; set; }
    
    public string? Descricao { get; set; }

    public DateTime DataLancamento { get; set; }

    public string? Duracao { get; set; }

    public string? Imagem { get; set; }

    public string? Categoria { get; set; }

    public FilmeResponseDetalhado(int id, string? nome, string? descricao, DateTime dataLancamento, string? duracao, string? imagem, string? categoria)
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
        DataLancamento = dataLancamento;
        Duracao = duracao;
        Imagem = imagem;
        Categoria = categoria;
    }
}