using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Data.Entities
{
    public class Produto
    {
        #region Declaração de Atributos

        private Guid? id;
        private string? nome;
        private decimal? preco;
        private int? quantidade;
        private DateTime? dataHoraCriacao;
        private DateTime? dataHoraUltimaAtualizacao;

        #endregion

        #region Sets e Gets

        public Guid? Id { get => id; set => id = value; }
        public string? Nome { get => nome; set => nome = value; }
        public decimal? Preco { get => preco; set => preco = value; }
        public int? Quantidade { get => quantidade; set => quantidade = value; }
        public DateTime? DataHoraCriacao { get => dataHoraCriacao; set => dataHoraCriacao = value; }
        public DateTime? DataHoraUltimaAtualizacao { get => dataHoraUltimaAtualizacao; set => dataHoraUltimaAtualizacao = value; }

        #endregion

    }
}
