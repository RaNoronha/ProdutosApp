using System.ComponentModel.DataAnnotations;

namespace ProdutosApp.Services.Models
{
    public class ProdutosGetModel
    {        
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public decimal? Preco { get; set; }
        public int? Quantidade { get; set; }
        public decimal? Total { get; set; }
        public DateTime? DataHoraCriacao { get; set; }
        public DateTime? DataHoraUltimaAtualizacao { get; set; }
    }
}
