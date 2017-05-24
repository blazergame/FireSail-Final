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
using DandD.Models.GameFiles;

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

            RootObject results = JsonConvert.DeserializeObject<RootObject>(json);


            var temp = string.Empty;
            for (var i = 0; i < results.data.Count; i++)
            {
                
                Items api = new Items();
               
                api.Name = results.data[i].Name;
				api.Description = results.data[i].Description;
                api.Tier = results.data[i].Tier;
				api.BodyPart = results.data[i].BodyPart;
                api.AttribMod = results.data[i].AttribMod;
				api.Creator = results.data[i].Creator;
				api.Image = results.data[i].Image;
                api.Usage = results.data[i].Usage;
               

                await App.Database.InsertItem(api);
            }

            return temp;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            ApiListView.ItemsSource = await App.Database.RetrieveItems();
        }
    }
}