using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApp.Data.Entities;
using ProdutosApp.Data.Repositories;
using ProdutosApp.Services.Models;

namespace ProdutosApp.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        #region POST

        [HttpPost]
        [ProducesResponseType(typeof(ProdutosGetModel), 200)]
        public IActionResult Post([FromBody] ProdutosPostModel model)
        {
            try
            {
                var produto = new Produto();
                var produtoRepository = new ProdutoRepository();
                

                produto.Id = Guid.NewGuid();
                produto.Nome = model.Nome;
                produto.Preco = model.Preco;
                produto.Quantidade = model.Quantidade;
                produto.DataHoraCriacao = DateTime.Now;
                produto.DataHoraUltimaAtualizacao = DateTime.Now;

                produtoRepository.Cadastrar(produto);                

                return StatusCode(200, EntityToModel(produto));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        #endregion

        #region PUT

        [HttpPut]
        [ProducesResponseType(typeof(ProdutosGetModel), 200)]
        public IActionResult Put([FromBody] ProdutosPutModel model)
        {
            return Ok();
        }

        #endregion

        #region DELETE

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProdutosGetModel), 200)]
        public IActionResult Delete(Guid? id)
        {
            return Ok();
        }

        #endregion

        #region PESQUISAS

        [HttpGet]
        [ProducesResponseType(typeof(List<ProdutosGetModel>), 200)]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProdutosGetModel), 200)]
        public IActionResult GetById(Guid? id)
        {
            return Ok();
        }

        #endregion

        #region Métodos Auxiliares

        private ProdutosGetModel EntityToModel(Produto produto)
        {
            var resultado = new ProdutosGetModel();

            resultado.Id = produto.Id;
            resultado.Nome = produto.Nome;
            resultado.Preco = produto.Preco;
            resultado.Quantidade = produto.Quantidade;
            resultado.Total = produto.Preco * produto.Quantidade;
            resultado.DataHoraCriacao = produto.DataHoraCriacao;
            resultado.DataHoraUltimaAtualizacao = produto.DataHoraUltimaAtualizacao;

            return resultado;
        }

        #endregion
    }
}
