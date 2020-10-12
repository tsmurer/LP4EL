using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopJoin.API.Dtos;
using ShopJoin.API.Models;

namespace ShopJoin.API.Data
{
    public class DoacaoRepository : IDoacaoRepository
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

        public async Task<Doacao> AlterarStatus(int idDoacao, int idHospital){

            var doacao = await _context.doacoes.FirstOrDefaultAsync(x => x.Id == idDoacao);

            doacao.Realizado = true;

            if(doacao.Hospital.Id != idHospital){
                throw new Exception("Hospital não tem relação com essa doação.");
            }

            await _context.doacoes.AddAsync(doacao);
            await _context.SaveChangesAsync();

            var usuario = await _context.users.FirstOrDefaultAsync(x => x.Id == doacao.User.Id);

            if(usuario == null){
                throw new Exception("Usuario não existe");
            }

            usuario.pontos = usuario.pontos + 100;

            await _context.users.AddAsync(usuario);
            await _context.SaveChangesAsync();

            return doacao;

        }

        public async Task<List<Doacao>> GetDoacoesCliente(int id)
        {
            return await _context.doacoes.Where(x => x.User.Id == id).ToListAsync();

        }

        public async Task<Doacao> GetDoacao(int id)
        {
            return await _context.doacoes.FirstOrDefaultAsync(x => x.Id == id);

        }


    }

}