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

            if (user.pontos < produto.Pontos)
            {
                throw new Exception("Usuário não tem pontos suficientes");
            }

            user.pontos = user.pontos - produto.Pontos;

            var rand = new Random();

            var produtoResgatado = new ProdutoResgatado
            {
                Codigo = new string(new char[]{
                    (char)rand.Next('A','Z'),
                    (char)rand.Next('A', 'Z'),
                    (char)rand.Next('0', '9'),
                    (char)rand.Next('0', '9'),
                    (char)rand.Next('0', '9'),
                    (char)rand.Next('0', '9'),
                    (char)rand.Next('A', 'Z'),
                    (char)rand.Next('A', 'Z')
                }),
                Produto = produto,
                User = user
            };

            await _context.produtosResgatados.AddAsync(produtoResgatado);
            await _context.SaveChangesAsync();

            await _context.SaveChangesAsync();

            return produtoResgatado;

        }

        public async Task<List<ProdutoResgatado>> GetProdutosResgatadosCliente(int id)
        {
            return await _context.produtosResgatados.Include(x => x.Produto).Include(x => x.User).Where(x => x.User.Id == id).ToListAsync();
        }

        public async Task<ProdutoResgatado> GetProdutosResgatado(int id)
        {
            return await _context.produtosResgatados.Include(x => x.Produto).Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}