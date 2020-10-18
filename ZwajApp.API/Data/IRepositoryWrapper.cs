namespace ZwajApp.API.Data
{
    public interface IRepositoryWrapper
    {
        IAuthRepository Auth { get; }
        void Save();
    }
}