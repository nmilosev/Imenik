using System.Collections.Generic;
using Newtonsoft.Json;

namespace RestImenik
{
    public class Korisnik
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Guid { get; set; }
        
    }
}

