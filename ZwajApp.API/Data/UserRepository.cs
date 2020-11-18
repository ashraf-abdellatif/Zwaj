using ZwajApp.API.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace ZwajApp.API.Data
{
    public class UserRepository: RepositoryBase<User>, IUserRepository
    {
        public UserRepository(DataContext datacontext ):base(datacontext)
        {  
        }
       
     }
}