using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RestImenik
{
    public class ImTip
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }

        [JsonIgnore] 
        public virtual List<Im> IMs {get;set;}
    }
}

