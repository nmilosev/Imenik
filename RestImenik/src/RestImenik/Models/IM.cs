using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace RestImenik
{
    public class Im
    {
        [Required]
        [Key]
        public int Id { get; set; }

        public ImTip ImTip { get; set; }
        public int ImTipId { get; set; }
 
        public string IMKontaktPodatak { get; set; }

        [JsonIgnore] 
        public int KontaktId {get; set;}
        [JsonIgnore] 
        public virtual Kontakt Korisnik {get;set;}
    }
}

