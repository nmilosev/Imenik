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
    public partial class frmRegistration : ContentPage
    {
        public frmRegistration()
        {
            InitializeComponent();
        }

        private async void BtnRegister_Clicked(object sender, EventArgs e)
        {
            Busy.IsRunning = true;
            txtStatus.Text = "Molim sačekajte...";

            var ok = await RestService.Register(txtUsername.Text, txtPassword.Text);

            if (ok)
            {
                txtStatus.Text = "Uspešna registracija! Ulogujte se!";
            }
            else
            {
                txtStatus.Text = "Neuspešna registracija!";
            }

            Busy.IsRunning = false;
        }
    }
}
