using System.ComponentModel.DataAnnotations;

namespace ProdutosApp.Services.Models
{
    public class ProdutosPostModel
    {
        [MinLength(8,ErrorMessage = "Por favor, informe no mínimo 8 caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo 150 caracteres")]
        [Required(ErrorMessage = "Por favor, informe o nome do produto.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o preço do produto.")]
        public decimal? Preco { get; set; }

        [Required(ErrorMessage = "Por favor, informe a quamtidade do produto.")]
        public int? Quantidade { get; set; }
    }
}
