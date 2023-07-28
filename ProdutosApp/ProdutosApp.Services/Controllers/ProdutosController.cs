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
            try
            { 
                var produtoRepository = new ProdutoRepository();
                var produto = produtoRepository.PesquisaId(model.Id);          

                if(produto!=null)
                {                    
                    produto.Nome = model.Nome;
                    produto.Preco = model.Preco;
                    produto.Quantidade = model.Quantidade;
                    produto.DataHoraUltimaAtualizacao = DateTime.Now;

                    produtoRepository.Alterar(produto);

                    return StatusCode(200, EntityToModel(produto));
                }
                else
                {
                    return StatusCode(400, new {mensagem = "Produto inválido. Verifique o ID informado"});
                }               
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }       
        }

        #endregion

        #region DELETE

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProdutosGetModel), 200)]
        public IActionResult Delete(Guid? id)
        {
            try
            {
                var produtoRepository = new ProdutoRepository();
                var produto = produtoRepository.PesquisaId(id);

                if (produto != null)
                {
                    produtoRepository.Apagar(produto);

                    return StatusCode(200, EntityToModel(produto));
                }
                else
                {
                    return StatusCode(400, new { mensagem = "Produto inválido. Verifique o ID informado" });
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }          
        }

        #endregion

        #region PESQUISAS

        [HttpGet]
        [ProducesResponseType(typeof(List<ProdutosGetModel>), 200)]
        public IActionResult GetAll()
        {
            try
            {
                var produtoRepository = new ProdutoRepository();
                var lista = new List<ProdutosGetModel>();

                foreach(var item in produtoRepository.PesquisaTodos())
                {
                    lista.Add(EntityToModel(item));                    
                }

                return StatusCode(200, lista);               
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }            
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProdutosGetModel), 200)]
        public IActionResult GetById(Guid? id)
        {
            try
            {
                var produtoRepository = new ProdutoRepository();
               
                if(produtoRepository.PesquisaId(id)!=null)
                {
                    return StatusCode(200, EntityToModel(produtoRepository.PesquisaId(id)));
                }
                else
                {
                    return StatusCode(204);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
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
