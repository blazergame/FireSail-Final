﻿using DandD.Models.Game_Files;
using DandD.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DandD
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage : ContentPage
	{
		public MenuPage ()
		{
			InitializeComponent();
            this.Title = "Dungeons and Copyright Issues";
		}

        async void Character_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new CharacterPage() { BindingContext = new Character() });
        }

        async void CharacterRead_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new CharacterListPage());
        }

        async void Monster_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new MonsterPage());
        }
        async void Items_Clicked(object sender, System.EventArgs e)
        {
           await Navigation.PushAsync(new ItemsPage());
        }
        async void PlayGame_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new BattlefieldPage());
        }

        async void PlayGameManuel_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new BattlefiedPageManual());
        }

        async void HighScore_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new HighScorePage());
        }
        async void APIPost_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new PostForm());
        }
        async void BattleEffect_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BattlefieldEffectsOptions());
        }
    }
}
