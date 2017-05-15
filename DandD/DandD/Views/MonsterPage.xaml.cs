using DandD.Models.Game_Files;
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
        int monster_count = 1;

        public MonsterPage ()
		{
            this.Title = "Monster List";

            InitializeComponent();
		}


        protected async override void OnAppearing()
        {
            base.OnAppearing();
           
            MonsterListView.ItemsSource = await App.Database.RetrieveMonsters();
        }

        async void AddMonster_Clicked(object sender, System.EventArgs e)
        {
            Monster m = new Monster();
            m.Name = "Monster" + monster_count;
            m.Str = 5;
            m.Dex = 5;
            m.Speed = 10;
            m.Health = 100;
            m.Level = 1;

            monster_count = monster_count + 1;
            System.Diagnostics.Debug.WriteLine(monster_count);
            //Uncomment if you want to add another monster into db
            await App.Database.InsertMonster(m);
        }
        async void Monster_MonsterSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new MonsterDetail { BindingContext = e.SelectedItem as Monster });
            }
        }
    }
}
