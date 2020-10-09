using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopJoin.API.Models;

namespace ShopJoin.API.Data
{
    public class ProdutoResgateRepository : IProdutoResgateRepository
    {
        private readonly DataContext _context;
        public ProdutoResgateRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ProdutoResgatado> ResgatarProduto(int idProduto, int idUsuario)
        {

            var produto = await _context.produtos.FirstOrDefaultAsync(x => x.Id == idProduto);

            if (produto == null)
            {
                throw new Exception("Produto não encontrado");
            }

            var user = await _context.users.FirstOrDefaultAsync(x => x.Id == idUsuario);

            if (user == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            int quantidade = await _context.produtosResgatados.CountAsync();

            var produtoResgatado = new ProdutoResgatado
            {
                Produto = produto,
                User = user
            };

            await _context.produtosResgatados.AddAsync(produtoResgatado);
            await _context.SaveChangesAsync();

            return produtoResgatado;

        }

        public async Task<List<ProdutoResgatado>> GetProdutosResgatadosCliente(int id)
        {
            return await _context.produtosResgatados.Where(x => x.User.Id == id).ToListAsync();
        }

        public async Task<ProdutoResgatado> GetProdutosResgatado(int id)
        {
            return await _context.produtosResgatados.FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}