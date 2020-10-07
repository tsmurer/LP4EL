using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopJoin.API.Dtos;
using ShopJoin.API.Models;

namespace ShopJoin.API.Data
{
    public class DoacaoRepository 
    {
        private readonly DataContext _context;
        public DoacaoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Doacao> CadastrarDoacao(DoacaoCadastroDto dto){

            var usuario = await _context.users.FirstOrDefaultAsync(x => x.Id == dto.IdUser);

            if(usuario == null){
                throw new Exception("Usuário não encontrado");
            }

            var hospital = await _context.hospitais.FirstOrDefaultAsync(x => x.Id == dto.IdUser);

            if(hospital == null){
                throw new Exception("Hospital não encontrado");
            }

            Doacao doacao = new Doacao{
                User = usuario,
                Hospital = hospital,
                Horario = dto.Horario,
                Realizado = false
            };

            await _context.doacoes.AddAsync(doacao);
            await _context.SaveChangesAsync();

            return doacao;

        }

        public async Task<Doacao> AlterarStatus(int idDoacao){

            var doacao = await _context.doacoes.FirstOrDefaultAsync(x => x.Id == idDoacao);

            doacao.Realizado = true;

            await _context.doacoes.AddAsync(doacao);
            await _context.SaveChangesAsync();

            return doacao;

        }


    }

}