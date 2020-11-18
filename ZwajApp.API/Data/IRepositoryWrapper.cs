namespace ZwajApp.API.Data
{
    public interface IRepositoryWrapper
    {
        IAuthRepository Auth { get; }
        IUserRepository User {get;}
        void Save();
    }
}