using System.ComponentModel.DataAnnotations;

namespace ZwajApp.API.DTOs
{
    public class UserforLoginDTO
    {
        [Required]
        public string UserName { get; set; }   
        [Required]
        public string PassWord { get; set; }      
    }
}