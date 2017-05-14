using System;
using System.Collections.Generic;
using DandD.Models.Game_Files;
using Xamarin.Forms;

namespace DandD.Views
{
    public partial class CharacterDetail : ContentPage
    {
        public CharacterDetail()
        {
            InitializeComponent();
        }

		async void Save_Clicked(object sender, System.EventArgs e)
		{
			var Char = (Character)BindingContext;
            await App.Database.InsertCharacter(Char);
			await Navigation.PopAsync();
		}

		async void Cancel_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PopAsync();
		}

	}
}
