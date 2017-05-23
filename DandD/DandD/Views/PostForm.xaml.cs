using DandD.Models.Game_Files;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DandD.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostForm : ContentPage
    {
        public PostForm()
        {
            InitializeComponent();


            postButton.Clicked += async (s, e) =>
            {
                var randomText = randomItemOption.Text;
                var characterClass = superItemOption.Text;
                await PostRequest(randomText, characterClass);

            };

        }


        public async Task<string> PostRequest(string val1, string val2)
        {
            App.Database.reset();
            string URL = "https://gamehackathon.azurewebsites.net/api/GetItemsList";
            var client = new System.Net.Http.HttpClient();
            var formContent = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("randomItemOption", val1),
                new KeyValuePair<string, string>("superItemOption", val2),
               
            });


            var response = await client.PostAsync(URL, formContent);

            var json = response.Content.ReadAsStringAsync().Result;

            dynamic results = JsonConvert.DeserializeObject<dynamic>(json);


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
                api.FilePath = results.data[i].FilePath;
                api.Attribute = results.data[i].Attribute;
                api.Value = results.data[i].Value;
                api.Description = results[i].Description;
                api.BodyPart = results[i].BodyPart;
                api.Useage = results[i].Useage;
                api.Creator = results[i].Creator;

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