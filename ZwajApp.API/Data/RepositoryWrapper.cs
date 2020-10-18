namespace ZwajApp.API.Data
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private DataContext _repoContext;
        private IAuthRepository _Auth;
        public IAuthRepository Auth {
            get {
                if(_Auth == null)
                {
                    _Auth = new AuthRepository(_repoContext);
                }
                return _Auth;
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