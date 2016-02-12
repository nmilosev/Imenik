using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RestImenik
{
    public class Korisnik
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Guid { get; set; }

        [JsonIgnore] 
        public virtual List<Kontakt> Kontakts { get;set; }

    }
}

