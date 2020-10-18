using System.Threading.Tasks;
using ZwajApp.API.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ZwajApp.API.Data
{
    public class AuthRepository : RepositoryBase<User>, IAuthRepository
    {
        public AuthRepository(DataContext datacontext ):base(datacontext)
        {  
        }
        public async Task<bool> IsExistUser(string UserName)
        {
           return  await RepositoryContext.Users.AnyAsync(x=>x.UserName == UserName);
        }
        public async Task<User> Login(string UserName, string PassWord)
        {
            var user  = await RepositoryContext.Users.FirstOrDefaultAsync(x=>x.UserName == UserName);
            if(user == null)return null;
            if(!verifyPassWordHash(PassWord ,  user.PassWordHash , user.SaltPassword))
            return null;
            return user;
        }

        private bool verifyPassWordHash(string passWord, byte[] passWordHash, byte[] saltPassword)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(saltPassword))
            {
            var ComputedpassWordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(passWord)); 
            for (int i = 0; i < ComputedpassWordHash.Length; i++)
            {
                if(ComputedpassWordHash[i]!= passWordHash[i])
                return false;
            }  
            }
            return true;

        }

        public async Task<User> Register(User user, string PassWord)
        {
            byte[] PassWordHash , PassWordSalt;
            CreatePassWordHash( PassWord , out PassWordHash, out PassWordSalt);
            user.PassWordHash = PassWordHash;
            user.SaltPassword = PassWordSalt;
           await  RepositoryContext.Users.AddAsync(user);
            await RepositoryContext.SaveChangesAsync();
            return user;
       }

        private void CreatePassWordHash(string passWord, out byte[] passWordHash, out byte[] passWordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
            passWordSalt = hmac.Key;
            passWordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(passWord));   
            }
        }
    }
}