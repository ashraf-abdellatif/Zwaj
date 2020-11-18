using System;

namespace ZwajApp.API.DTOs
{
    public class UserForListDTO
    {
         public int Id { get; set; }
        public string UserName { get; set; }  
        public string Gender { get; set; } 
        public int Age { get; set; }
        public string KnownAs { get; set; } 
        public System.DateTime CreatedDate  { get; set; }
        public DateTime LastActivate { get; set; }
        public string City { get; set; }
        public string Countery { get; set; }
        public string PhotoUrl { get; set; }
    }
}