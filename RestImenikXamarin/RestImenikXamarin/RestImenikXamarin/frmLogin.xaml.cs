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
    public partial class frmLogin : ContentPage
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            Busy.IsRunning = true;
            txtStatus.Text = "Molim sačekajte...";
            var loggedIn = await RestService.Login(txtUsername.Text, txtPassword.Text);
            if (loggedIn)
            {
                await Navigation.PopAsync();
                await Navigation.PushAsync(new frmMain());
            }
            else
            {
                txtStatus.Text = "Pogrešan username ili password";
            }
            Busy.IsRunning = false;            
        }
        private void BtnRegister_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new frmRegistration());
        }
    }
}
