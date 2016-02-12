
namespace RestImenik
{
    public class Telefon
    {
        public int Id { get; set; }

        public string Broj { get; set; }
             
        public int TelefonTipId { get; set; }   
        public TelefonTip TelefonTip { get; set; }
        
    }
}

