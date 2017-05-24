using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DandD.Models.Game_Files;
using DandD.Models.GameFiles;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace DandD.Views
{
    public partial class BattleEffects : ContentPage
    {
        public BattleEffects()
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
			string URL = "https://gamehackathon.azurewebsites.net/api/GetBattleEffects";
			var client = new System.Net.Http.HttpClient();
			var formContent = new FormUrlEncodedContent(new[] {
				new KeyValuePair<string, string>("randomItemOption", val1),
				new KeyValuePair<string, string>("superItemOption", val2),

			});


			var response = await client.PostAsync(URL, formContent);

			var json = response.Content.ReadAsStringAsync().Result;

			UndoneBE results = JsonConvert.DeserializeObject<UndoneBE>(json);

			var temp = string.Empty;
			for (var i = 0; i < results.data.Count; i++)
			{

				Items api = new Items();

				api.Name = results.data[i].Name;
				api.Description = results.data[i].Description;
				api.Tier = results.data[i].Tier;
				api.AttribMod = results.data[i].AttribMod;
                api.Target = results.data[i].Target;
				


				await App.Database.InsertItem(api);
			}

			return temp;
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();
			//ApiListView.ItemsSource = await App.Database.RetrieveItems();
		}
    }
}
