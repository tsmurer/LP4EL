using System.Threading.Tasks;
using ShopJoin.API.Models;

namespace ShopJoin.API.Data
{
    public interface IAuthRepository
    {
        Task<Hospital> Register(Hospital hospital, string password);
         Task<User> Register(User user, string password);
         Task<User> Login(string email, string password);
         Task<Hospital> LoginHospital(string cnpj, string password);
         void UserExists(string cpf, string email);
         Task<bool> HospitalExists(string cnpj);
    }
}