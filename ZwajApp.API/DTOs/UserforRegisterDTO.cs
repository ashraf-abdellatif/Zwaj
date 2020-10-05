using System.ComponentModel.DataAnnotations;

namespace ZwajApp.API.DTOs
{
    public class UserforRegisterDTO
    {
        [Required]
        public string UserName { get; set; }   
        [Required]
        [MinLength(5)]
        public string PassWord { get; set; }      
    }
}