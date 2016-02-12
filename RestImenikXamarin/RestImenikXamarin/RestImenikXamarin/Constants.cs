using RestImenik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestImenikXamarin
{
    public static class Constants
    {
        public static Korisnik LoggedInUser { get; set; }
        public static List<Drzava> Drzave { get; set; }
        public static List<Mesto> Mesta { get; set; }
        public static List<Grupa> Grupe { get; set; }
        public static List<TelefonTip> TelefonTipovi { get; set; }
        public static List<ImTip> ImTipovi { get; set; }
    }
}
