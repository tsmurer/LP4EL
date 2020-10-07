using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopJoin.API.Models;

namespace ShopJoin.API.Data
{
    public class ProdutoResgateRepository 
    {
        private readonly DataContext _context;
        public ProdutoResgateRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ProdutoResgatado> ResgatarProduto(int idProduto, int idUsuario){

            var produto = await _context.produtos.FirstOrDefaultAsync(x => x.Id == idProduto);
            
            if(produto == null){
                throw new Exception("Produto não encontrado");
            }

            var user = await _context.users.FirstOrDefaultAsync(x => x.Id == idUsuario);

            if(user == null){
                throw new Exception("Usuário não encontrado");
            }

            int quantidade = await _context.produtosResgatados.CountAsync();

            var produtoResgatado = new ProdutoResgatado{
                Produto = produto,
                User = user,
                Id = quantidade + 1
            };

            await _context.produtosResgatados.AddAsync(produtoResgatado);
            await _context.SaveChangesAsync();

            return produtoResgatado;
            
        }

    }
}