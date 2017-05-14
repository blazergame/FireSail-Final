using System;
using System.Collections.Generic;
using DandD.Models.Game_Files;

using Xamarin.Forms;

namespace DandD.Views
{
    public partial class MonsterDetail : ContentPage
    {
		public MonsterDetail()
		{
			InitializeComponent();
		}

		async void Save_Clicked(object sender, System.EventArgs e)
		{
			var Mon = (Monster)BindingContext;
            await App.Database.InsertMonster(Mon);
			await Navigation.PopAsync();
		}

		async void Cancel_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PopAsync();
		}

	}
}
