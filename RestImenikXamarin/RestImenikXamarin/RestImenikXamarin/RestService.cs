using Newtonsoft.Json;
using RestImenik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestImenikXamarin
{
    static class RestService
    {
        private const string BaseUri = "localhost";

        public static async Task<bool> Login(string user, string password)
        {
            var data = new { username = user, password = password };

            var client = new HttpClient();
            var response = await client.PostAsync($"{BaseUri}/login",
                new StringContent(JsonConvert.SerializeObject(data),
                Encoding.UTF8,
                "application/json"));

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseText = await response.Content.ReadAsStringAsync();
                var k = JsonConvert.DeserializeObject<Korisnik>(responseText);
                Constants.LoggedInUser = k;
                return true;
            }
            else
            {
                return false;
            }
        } 

        public static async Task<List<Kontakt>> Load()
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"{BaseUri}/kontakt?guid={Constants.LoggedInUser.Guid}");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseText = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<Kontakt>>(responseText);

                return list;
            }
            else
                return null;
        }
        
        public static async Task<List<Kontakt>> Load(string query)
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"{BaseUri}/kontakt/search?guid={Constants.LoggedInUser.Guid}&query={query}");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseText = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<Kontakt>>(responseText);

                return list;
            }
            else
                return null;
        }

        public static async Task<List<Kontakt>> LoadForGrupa(string grupaId)
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"{BaseUri}/kontakt/grupa?guid={Constants.LoggedInUser.Guid}&grupaId={grupaId}");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseText = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<Kontakt>>(responseText);

                return list;
            }
            else
                return null;
        }

        public static async Task<List<Grupa>> Grupe()
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"{BaseUri}/grupa");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseText = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<Grupa>>(responseText);
                return list;
            }
            else
                return null;
        }

        public static async Task<List<ImTip>> ImTipovi()
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"{BaseUri}/imtip");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseText = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<ImTip>>(responseText);
                return list;
            }
            else
                return null;

        }

        public static async Task<List<TelefonTip>> TelefonTipovi()
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"{BaseUri}/telefontip");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseText = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<TelefonTip>>(responseText);
                return list;
            }
            else
                return null;
        }

        public static async Task<List<Drzava>> Drzave()
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"{BaseUri}/drzava");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseText = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<Drzava>>(responseText);
                return list;
            }
            else
                return null;
        }

        public static async Task<List<Mesto>> Mesta()
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"{BaseUri}/mesto");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseText = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<Mesto>>(responseText);
                return list;
            }
            else
                return null;
        }

        public static async Task<bool> Delete(Kontakt k)
        {
            var client = new HttpClient();
            var response = await client.DeleteAsync($"{BaseUri}/kontakt/{k.Id}?guid={Constants.LoggedInUser.Guid}");

            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            else
                return false;
        }

        public static async Task<bool> Register(string username, string password)
        {
            var data = new { username = username, password = password };

            var client = new HttpClient();
            var response = await client.PostAsync($"{BaseUri}/register",
                new StringContent(JsonConvert.SerializeObject(data),
                Encoding.UTF8,
                "application/json"));

            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            else
                return false;
        }

        public static async Task<bool> NewContact(Kontakt k)
        {
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(k);
            var response = await client.PostAsync($"{BaseUri}/kontakt?guid={Constants.LoggedInUser.Guid}",
                new StringContent(json,
                Encoding.UTF8,
                "application/json"));

            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            else
                return false;
        }
    }
}
