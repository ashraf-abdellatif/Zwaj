using System;
using System.Collections.Generic;

namespace ZwajApp.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PassWordHash { get; set; }   
        public byte[] SaltPassword { get; set; }   
        public string Gender { get; set; } 
        public DateTime BirthOfDate { get; set; }
        public string KnownAs { get; set; } 
        public DateTime CreatedDate  { get; set; }
        public DateTime LastActivate { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Countery { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}