namespace ZwajApp.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PassWordHash { get; set; }   
        public byte[] SaltPassword { get; set; }    
    }
}