using System;

using DandD.Models;
using DandD.ViewModels;

using Xamarin.Forms;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using DandD.Models.Game_Files;

namespace DandD.Views
{
	public partial class ItemsPage : ContentPage
	{
		ItemsViewModel viewModel;

        public ItemsPage()
        {
            this.Title = "API List";
            InitializeComponent();
            listButton.Clicked += async (s, e) =>
            {
                await getAPI();

            };

            listButton2.Clicked += async (s, e) =>
            {
                await getAPI2();

            };

            listButton3.Clicked += async (s, e) =>
            {
                await getAPI3();

            };

            reset.Clicked += async (s, e) =>
            {
                App.Database.reset();
            };
        }

        public async Task<string> getAPI()
        {
            App.Database.reset();
            var client = new System.Net.Http.HttpClient();
            client.BaseAddress = new Uri("http://thursdayhomework.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            var response = await client.GetAsync("API/GetItemList/1");

            var listJson = response.Content.ReadAsStringAsync().Result;


            dynamic results = JsonConvert.DeserializeObject(listJson);

            var data = string.Empty;


            for (var i = 0; i < results.data.Count; i++)
            {
                data = results.data[i].Name;
                Items api = new Items();
                if (results.msg != "OK" && results.error_code != 0)
                    break;
                api.Error_Code = results.error_code;
                api.Msg = results.msg;
                api.Name = results.data[i].Name;
                api.Attribute = results.data[i].Attribute;
                api.Value = results.data[i].Value;

                await App.Database.InsertItem(api);
            }

            return data;
        }

        public async Task<string> getAPI2()
        {
            App.Database.reset();
            var client = new System.Net.Http.HttpClient();
            client.BaseAddress = new Uri("http://thursdayhomework.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            var response = await client.GetAsync("API/GetItemList/2");

            var listJson = response.Content.ReadAsStringAsync().Result;


            dynamic results = JsonConvert.DeserializeObject(listJson);

            var data = string.Empty;


            for (var i = 0; i < results.data.Count; i++)
            {
                data = results.data[i].Name;
                Items api = new Items();
                if (results.msg != "OK" && results.error_code != 0)
                    break;
                api.Error_Code = results.error_code;
                api.Msg = results.msg;
                api.Name = results.data[i].Name;
                api.Attribute = results.data[i].Attribute;
                api.Value = results.data[i].Value;

                await App.Database.InsertItem(api);
            }

            return data;
        }

        public async Task<string> getAPI3()
        {
            App.Database.reset();
            var client = new System.Net.Http.HttpClient();
            client.BaseAddress = new Uri("http://thursdayhomework.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync("API/GetItemList/3");
            var listJson = response.Content.ReadAsStringAsync().Result;

            dynamic results = JsonConvert.DeserializeObject(listJson);

            var data = string.Empty;


            for (var i = 0; i < results.data.Count; i++)
            {
                data = results.data[i].Name;
                Items api = new Items();
                if (results.msg != "OK" && results.error_code != 0)
                    break;
                api.Error_Code = results.error_code;
                api.Msg = results.msg;
                api.Name = results.data[i].Name;
                api.Attribute = results.data[i].Attribute;
                api.Value = results.data[i].Value;

                await App.Database.InsertItem(api);
            }


            return data;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            ApiListView.ItemsSource = await App.Database.RetrieveItems();
        }
    }
}
