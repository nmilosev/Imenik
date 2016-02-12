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
    public partial class frmMain : ContentPage
    {
        public frmMain()
        {
            InitializeComponent();
            Title = $"Zdravo, {Constants.LoggedInUser.Username}!";
        }
        
        private async void Lv_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var kontakt = e.Item as Kontakt;
            await Navigation.PushAsync(new frmDetails(kontakt));
            
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            Root.Children.Clear();
            Busy.IsRunning = true;
            Busy.IsVisible = true;
            txtStatus.IsVisible = true;

            Constants.Drzave = await RestService.Drzave();
            Constants.Mesta = await RestService.Mesta();
            Constants.Grupe = await RestService.Grupe();
            Constants.ImTipovi = await RestService.ImTipovi();
            Constants.TelefonTipovi = await RestService.TelefonTipovi();

            FillUi(await RestService.Load());
            
            Busy.IsRunning = false;
            Busy.IsVisible = false;
            txtStatus.IsVisible = false;
        }

        private void FillUi(List<Kontakt> l)
        {
            if (l != null)
            {
                var lv = new ListView();

                lv.ItemsSource = l;
                var dataTemplate = new DataTemplate(typeof(TextCell));

                dataTemplate.SetBinding(TextCell.TextProperty, "ImePrezime");
                dataTemplate.SetBinding(TextCell.DetailProperty, "Info");

                lv.ItemTemplate = dataTemplate;
                lv.ItemTapped += Lv_ItemTapped;

                Root.Children.Clear();
                Root.Children.Add(lv);
            }
        }

        private async void Trazi(object sender, EventArgs e)
        {
            FillUi(await RestService.Load(txtSearch.Text));
        }

        private async void Sluzbeni(object sender, EventArgs e)
        {
            FillUi(await RestService.LoadForGrupa(Constants.Grupe.Where(_ => _.Naziv == "Službeni kontakti" ).Single().Id.ToString()));
        }

        private async void Privatni(object sender, EventArgs e)
        {
            FillUi(await RestService.LoadForGrupa(Constants.Grupe.Where(_ => _.Naziv == "Privatni kontakti").Single().Id.ToString()));
        }

        private async void Svi(object sender, EventArgs e)
        {
            FillUi(await RestService.Load());
            txtSearch.Text = string.Empty;
        }

        private async void Novi(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new frmNew());
            
        }
    }
}
