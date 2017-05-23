using Android.App;
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
                var randomText = randomEntry.Text;
                var characterClass = characterType.Text;
                var level = levelEntry.Text;

                if (randomText != "1")
                    randomText = "0";

                if (characterClass == "Fighter" || characterClass == "Cleric" || characterClass == "Thief")
                {
                    if (int.Parse(level) < 0)
                    {
                        await DisplayAlert("Invalid input", "Please make level greater than 0", "Ok");
                        return;
                    }
                    await PostRequest(randomText, characterClass, level);

                }
                else
                {
                    await DisplayAlert("Invalid input", "Only Fighter,Cleric or Thief class", "Ok");
                    return;
                }

            };

        }


        public async Task<string> PostRequest(string rand, string character, string _level)
        {
            App.Database.reset();
            string URL = "http://thursdayhomeworkpost.azurewebsites.net/api/GetItems";
            var client = new System.Net.Http.HttpClient();
            var formContent = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("random", rand),
                new KeyValuePair<string, string>("charactertype", character),
                new KeyValuePair<string, string>("characterlevel", _level),
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