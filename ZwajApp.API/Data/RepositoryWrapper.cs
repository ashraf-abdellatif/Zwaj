namespace ZwajApp.API.Data
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private DataContext _repoContext;
        private IAuthRepository _Auth;
        private IUserRepository _User;
        public IAuthRepository Auth {
            get {
                if(_Auth == null)
                {
                    _Auth = new AuthRepository(_repoContext);
                }
                return _Auth;
            }
        }
        public IUserRepository User {
            get {
                if(_User == null)
                {
                    _User= new UserRepository(_repoContext);
                }
                return _User;
            }
        }
        public RepositoryWrapper(DataContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}