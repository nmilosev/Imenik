using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RestImenik
{
    public class Email
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string Adresa { get; set;}

        [JsonIgnore] 
        public int KontaktId {get;set;}
        [JsonIgnore] 
        public virtual Kontakt Kontakt {get;set;}
    }
}

