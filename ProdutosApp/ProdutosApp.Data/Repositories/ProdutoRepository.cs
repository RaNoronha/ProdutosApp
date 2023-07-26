using ProdutosApp.Data.Contexts;
using ProdutosApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Data.Repositories
{
    public class ProdutoRepository
    {
        public void Cadastrar(Produto produto)
        {
            using(var dataContext = new DataContext())
            {
                dataContext.Produto.Add(produto);
                dataContext.SaveChanges();
            }
        }

        public void Alterar(Produto produto)
        {
            using(var dataContext = new DataContext())
            {
                dataContext.Produto.Update(produto);
                dataContext.SaveChanges();
            }
        }

        public void Apagar(Produto produto)
        {
            using(var dataContext = new DataContext())
            {
                dataContext.Produto.Remove(produto);
                dataContext.SaveChanges();
            }
        }

        public List<Produto> PesquisaTodos()
        {
            using(var dataContext = new DataContext())
            {
                return dataContext.Produto.OrderBy(p => p.Nome).ToList();
            }
        }

        public Produto? PesquisaId(Guid? id)
        {
            using(var dataContext = new DataContext())
            {
                return dataContext.Produto.Find(id);
            }
        }
    }
}
