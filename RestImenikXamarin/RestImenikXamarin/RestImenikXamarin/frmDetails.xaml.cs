using Newtonsoft.Json;
using RestImenik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RestImenikXamarin
{
    public partial class frmDetails : ContentPage
    {
        private Kontakt k;

        public frmDetails(Kontakt k)
        {
            InitializeComponent();

            this.k = k;

            Title = "Detalji: " + k.ImePrezime;

            showData(k.Id.ToString(), "Id korisnika");
            showData(k.ImePrezime, "Ime i prezime");
            showData(k.Ulica, "Ulica");
            showData(k.Broj, "Broj");
            showData(k.Mesto.Naziv, "Mesto");
            showData(k.Mesto.PostanskiBroj, "PTT");
            showData(k.Drzava.Ime, "Drzava");
            foreach (Telefon t in k.Telefons)
            {
                var l1 = new Label() { Text = "Telefon (" + t.TelefonTip.Naziv + ")", FontSize = 14, TextColor = Color.Yellow };
                var l2 = new Label() { Text = t.Broj, FontSize = 20 };
                l2.GestureRecognizers.Add(new TapGestureRecognizer((view) => Device.OpenUri(new Uri("tel:" + t.Broj))));
                Root.Children.Add(l1);
                Root.Children.Add(l2);
            }
            foreach (Email e in k.Emails)
                showData(e.Adresa, "Email");

            foreach (Im i in k.Ims)
                showData(i.IMKontaktPodatak, i.ImTip.Naziv);

            showData(k.Beleska, "Beleska");

            //web sajt:
            var w1 = new Label() { Text = "Web sajt", FontSize = 14, TextColor = Color.Yellow };
            var w2 = new Label() { Text = k.WebSajt, FontSize = 20 };
            w2.GestureRecognizers.Add(new TapGestureRecognizer((view) => Device.OpenUri(new Uri(k.WebSajt))));
            Root.Children.Add(w1);
            Root.Children.Add(w2);


        }

        private void showData(string text, string title)
        {
            Root.Children.Add(new Label() { Text = title, FontSize = 14, TextColor = Color.Yellow });
            Root.Children.Add(new Label() { Text = text, FontSize = 20 });
        }

        private async void Brisi(object sender, EventArgs e)
        {
            var confirmed = await DisplayAlert("Brisanje?", "Da li ste sigurni?", "Da", "Ne");
            if (!confirmed)
                return;

            var deleted = await RestService.Delete(k);
            
            if (deleted)
            {
                await DisplayAlert("Obaveštenje", "Uspešno obrisan korisnik", "U redu");
                await Navigation.PopAsync();
            }  
        }
    }
}
