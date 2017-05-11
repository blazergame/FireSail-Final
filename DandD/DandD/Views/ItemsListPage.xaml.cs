using System;
using System.Collections.Generic;
using DandD.Models.Game_Files;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json.Linq;
using static DandD.Models.GameFiles.Holder;

namespace DandD.Views
{
    public partial class ItemsListPage : ContentPage
    {
        public ItemsListPage()
        {
            InitializeComponent();

            this.Title = "Items List";
            Button b = new Button { Text = "Items" };
            b.Clicked += async (sender, e) =>
             {
                 var webCall = new ItemsWebAPI();
                 var objects = await webCall.MakeGetRequest("http://thursdayhomework.azurewebsites.net/API/GetItemList/1");
                 RootObject r = JsonConvert.DeserializeObject<RootObject>(objects);
                 for (int i = 0; i < r.data.Count; i++)
                 {

                     var newItem = new Items(r.data[i].Name, r.data[i].Attribute, r.data[i].Value);
                     await App.Database.InsertItem(newItem);

                 }
             };
            Button c = new Button { Text = "View Items" };
            c.Clicked += (sender, e) =>
            {
               Navigation.PushAsync(new ViewItems());
           };

			Button z = new Button { Text = "Reset" };
            {
                
            };

			Button b2 = new Button { Text = "Items Option 2" };
			b2.Clicked += async (sender, e) =>
			 {
				 var webCall = new ItemsWebAPI();
				 var objects = await webCall.MakeGetRequest("http://thursdayhomework.azurewebsites.net/API/GetItemList/2");
				 RootObject r = JsonConvert.DeserializeObject<RootObject>(objects);
				 for (int i = 0; i < r.data.Count; i++)
				 {

					 var newItem = new Items(r.data[i].Name, r.data[i].Attribute, r.data[i].Value);
					 await App.Database.InsertItem(newItem);

				 }
			 };

			Button b3 = new Button { Text = "Items Option 3" };
			b3.Clicked += async (sender, e) =>
            {
				 var webCall = new ItemsWebAPI();
				 var objects = await webCall.MakeGetRequest("http://thursdayhomework.azurewebsites.net/API/GetItemList/3");
				 RootObject r = JsonConvert.DeserializeObject<RootObject>(objects);
				 for (int i = 0; i < r.data.Count; i++)
				 {

					 var newItem = new Items(r.data[i].Name, r.data[i].Attribute, r.data[i].Value);
					 await App.Database.InsertItem(newItem);

				 }
			 };

            z.Clicked += (sender, e) =>
             {
                App.Database.reset();
             };
            this.Content = new StackLayout
            {
                Children =
                 {
                    b,b2,b3,c,z
                 }
            };
        }
    }
}
