using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopJoin.API.Models;

namespace ShopJoin.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> Login(string email, string password)
        {
            var user = await _context.users.FirstOrDefaultAsync(x => x.Email == email);

            if (user == null)
                return null;
            
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;
            
            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i = 0; i < computedHash.Length; i++)
                {
                    if(computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            
        }

        public async Task<User> Register(User user, string password)
        {
            if(await ValidacaoCpf(user.Cpf)){
                throw new Exception("Cpf inválido");
            }

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> UserExists(string email)
        {
            string email_lower = email.ToLower();
            if(await _context.users.AnyAsync(x => x.Email.ToLower() == email_lower))
                return true;
                
            return false;
        }

        private async Task<Boolean> ValidacaoCpf(string cpf){
            string tempCpf;
		    string digito;
		    int soma;
		    int resto;

           if (cpf.Length != 11)
		     return false;
		   tempCpf = cpf.Substring(0, 9);
		   soma = 0;
           
		   for(int i=0; i<9; i++)
		       soma += int.Parse(tempCpf[i].ToString()) * cpf[i];
		   resto = soma % 11;
		   if ( resto < 2 )
		       resto = 0;
		   else
		      resto = 11 - resto;
		   digito = resto.ToString();
		   tempCpf = tempCpf + digito;
		   soma = 0;
		   for(int i=0; i<10; i++)
		       soma += int.Parse(tempCpf[i].ToString()) * cpf[i];
		   resto = soma % 11;
		   if (resto < 2)
		      resto = 0;
		   else
		      resto = 11 - resto;
		   digito = digito + resto.ToString();
		   return cpf.EndsWith(digito);
        }

    }
}