using RestImenik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RestImenikXamarin
{
    public partial class frmNew : ContentPage
    {
        private int drzavaId, mestoId, grupaId, telefonTipId, imTipId;

        public frmNew()
        {
            InitializeComponent();

            foreach (Grupa g in Constants.Grupe)
                pGrupa.Items.Add(g.Naziv);
            pGrupa.SelectedIndexChanged += (s, o) => grupaId = Constants.Grupe[pGrupa.SelectedIndex].Id;

            foreach (Mesto m in Constants.Mesta)
                pMesto.Items.Add(m.Naziv);
            pMesto.SelectedIndexChanged += (s, o) => mestoId = Constants.Mesta[pMesto.SelectedIndex].Id;

            foreach (Drzava d in Constants.Drzave)
                pDrzava.Items.Add(d.Ime);
            pDrzava.SelectedIndexChanged += (s, o) => drzavaId = Constants.Drzave[pDrzava.SelectedIndex].Id;

            foreach (TelefonTip tt in Constants.TelefonTipovi)
                pTelefonTip.Items.Add(tt.Naziv);
            pTelefonTip.SelectedIndexChanged += (s, o) => telefonTipId = Constants.TelefonTipovi[pTelefonTip.SelectedIndex].Id;

            foreach (ImTip it in Constants.ImTipovi)
                pImTip.Items.Add(it.Naziv);
            pImTip.SelectedIndexChanged += (s, o) => imTipId = Constants.ImTipovi[pImTip.SelectedIndex].Id;
        }

        private List<Email> emailovi = new List<Email>();
        private void DodajEmail(object sender, EventArgs e)
        {
            var email = txtEmail.Text;
            if (string.IsNullOrEmpty(txtEmailovi.Text))
                txtEmailovi.Text += email;
            else
                txtEmailovi.Text += "\n" + email;
            emailovi.Add(new Email() { Adresa = email });
            txtEmail.Text = string.Empty;
        }

        private List<Telefon> telefoni = new List<Telefon>();
        private void DodajTelefon(object sender, EventArgs e)
        {
            var telefon = txtTelefon.Text;
            if (string.IsNullOrEmpty(txtTelefoni.Text))
                txtTelefoni.Text += telefon + $" ({pTelefonTip.Items[pTelefonTip.SelectedIndex]})";
            else
                txtTelefoni.Text += "\n" + telefon + $" ({pTelefonTip.Items[pTelefonTip.SelectedIndex]})";
            telefoni.Add(new Telefon() { Broj = telefon, TelefonTipId = telefonTipId });
            txtTelefon.Text = string.Empty;
        }

        private List<Im> im = new List<Im>();
        private void DodajIm(object sender, EventArgs e)
        {
            var imKontakt = txtIm.Text;
            if (string.IsNullOrEmpty(txtImovi.Text))
                txtImovi.Text += imKontakt + $" ({pImTip.Items[pImTip.SelectedIndex]})";
            else
                txtImovi.Text += "\n" + imKontakt + $" ({pImTip.Items[pImTip.SelectedIndex]})";

            im.Add (new Im() {IMKontaktPodatak = imKontakt, ImTipId = imTipId });
            txtIm.Text = string.Empty;
        }

        private async void Novi(object sender, EventArgs e)
        {
            var k = new Kontakt()
            {
                Ime = txtIme.Text,
                Prezime = txtPrezime.Text,
                Jmbg = txtJmbg.Text,
                Beleska = txtBeleska.Text,
                Ulica = txtUlica.Text,
                Broj = txtBroj.Text,
                WebSajt = txtWeb.Text,
                Nadimak = txtNadimak.Text,
                KorisnikId = Constants.LoggedInUser.Id,
                DrzavaId = drzavaId,
                GrupaId = grupaId,
                MestoId = mestoId,
                Telefons = telefoni,
                Ims = im,
                Emails = emailovi
            };

            var ok = await RestService.NewContact(k);

            if (ok)
            {
                await DisplayAlert("Uspešno dodat kontakt!", "Uspešno ste snimili novi kontakt!", "Ok");
                await Navigation.PopAsync();
            } else
            {
                await DisplayAlert("Greška", "Pokušajte ponovo...", "Ok");
            }
        }
    }
}
