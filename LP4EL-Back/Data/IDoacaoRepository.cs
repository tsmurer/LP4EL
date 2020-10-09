using System.Collections.Generic;
using System.Threading.Tasks;
using ShopJoin.API.Dtos;
using ShopJoin.API.Models;

namespace ShopJoin.API.Data
{
    public interface IDoacaoRepository{

        Task<Doacao> CadastrarDoacao(DoacaoCadastroDto dto);

        Task<Doacao> AlterarStatus(int idDoacao, int idHospital);

        Task<List<Doacao>> GetDoacoesCliente(int id);

        Task<Doacao> GetDoacao(int id);

    }
}