using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RestImenik
{
    public class Drzava
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string Ime { get; set; }

        [JsonIgnore] 
        public virtual List<Kontakt> Kontakts { get;set; }
    }
}

