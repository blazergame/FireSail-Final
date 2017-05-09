﻿using DandD.Models.Game_Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DandD.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MonsterPage : ContentPage
	{
		public MonsterPage ()
		{
            this.Title = "Monster List";

            InitializeComponent();
		}


        protected async override void OnAppearing()
        {
            base.OnAppearing();
            Monster m = new Monster();
            m.Name = "Warlord";
            m.Str = 5;
            m.Dex = 5;
            m.Speed = 10;
            m.Health = 100;
            m.Level = 34;

            //Uncomment if you want to add another monster into db
           // await App.Database.InsertMonster(m);
            MonsterListView.ItemsSource = await App.Database.RetrieveMonsters();
        }
    }
}
