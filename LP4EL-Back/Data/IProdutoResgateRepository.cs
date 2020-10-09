using System.Collections.Generic;
using System.Threading.Tasks;
using ShopJoin.API.Models;

namespace ShopJoin.API.Data
{
    public interface IProdutoResgateRepository
    {

        Task<ProdutoResgatado> ResgatarProduto(int idProduto, int idUsuario);

        Task<List<ProdutoResgatado>> GetProdutosResgatadosCliente(int id);

        Task<ProdutoResgatado> GetProdutosResgatado(int id);

    }

}