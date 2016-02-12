using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace RestImenik
{
    public class Kontakt
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Jmbg { get; set; }

        public string Ulica { get; set; }
        public string Broj { get; set; }

        public int MestoId { get; set; }
        public virtual Mesto Mesto { get; set; }

        public int DrzavaId { get;set; }
        public virtual Drzava Drzava { get; set;}

        public List<Email> Emails { get; set; }
        public List<Telefon> Telefons { get;set; }
        public List<Im> Ims { get;set; }

        public string WebSajt { get;set; }
        public string Nadimak { get;set; }

        public int GrupaId { get;set;}
        public virtual Grupa Grupa { get; set; }

        public string Beleska { get; set; }

        public int KorisnikId { get; set;}
        public virtual Korisnik Korisnik {get;set;}
    }
}

