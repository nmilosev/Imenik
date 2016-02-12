using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace RestImenik
{
    public class Telefon
    {
        [Required]
        [Key]
        public int Id { get; set; }

        public string Broj { get; set; }

        public int TelefonTipId { get; set;}

        public TelefonTip TelefonTip { get; set; }

        [JsonIgnore] 
        public int KontaktId { get;set; }
        [JsonIgnore] 
        public virtual Kontakt Kontakt { get;set; }

    }
}

