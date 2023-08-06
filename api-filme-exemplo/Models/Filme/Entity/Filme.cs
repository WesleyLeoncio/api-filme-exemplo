using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_filme_exemplo.Models.Filme.Entity;

[Table("filmes")]
public class Filme
{   
    [Key]
    [Required]
    [Column(name:"id")]
    public int Id { get; set; }
    [Required]
    [Column(name:"nome")]
    public string? Nome { get; set; }
    [Required]
    [Column(name:"descricao")]
    public string? Descricao { get; set; }
    [Required]
    [Column(name:"data_lancamento")]
    public DateTime DataLancamento { get; set; }
    [Required]
    [Column(name:"duracao")]
    public string? Duracao { get; set; }
    [Required]
    [Column(name:"imagem")]
    public string? Imagem { get; set; }
    [Required]
    [Column(name:"categoria")]
    public string? Categoria { get; set; }

    public Filme(int id, string? nome, string? descricao, DateTime dataLancamento, string? duracao, string? imagem, string? categoria)
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
        DataLancamento = dataLancamento;
        Duracao = duracao;
        Imagem = imagem;
        Categoria = categoria;
    }

    public Filme()
    {
    }
}
