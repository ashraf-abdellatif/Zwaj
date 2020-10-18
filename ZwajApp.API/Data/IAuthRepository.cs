using System.Threading.Tasks;
using ZwajApp.API.Models;

namespace ZwajApp.API.Data
{
    public interface IAuthRepository: IRepositoryBase<User>
    {
         Task<User> Register (User user  , string PassWord);
         Task<User> Login(string UserName , string PassWord);
         Task<bool> IsExistUser(string UserName);
    }
}