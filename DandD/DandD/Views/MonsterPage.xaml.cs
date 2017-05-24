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
        private int count = 0;
        private Random rand = new Random();
        private Random r = new Random();
        public MonsterPage ()
		{
            this.Title = "Monster List";

            InitializeComponent();

            reset.Clicked += async (s, e) =>
            {
                App.Database.resetMonster();
                await Navigation.PushAsync(new MonsterPage());
                await Navigation.PopAsync();
            };
        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();
           
            MonsterListView.ItemsSource = await App.Database.RetrieveMonsters();
        }

        async void AddMonster_Clicked(object sender, System.EventArgs e)
        {
            Monster m = new Monster();

            m.Name = PopulateAndReturnNames();
            System.Threading.Thread.Sleep(10);
            m.Str = Randomize();
			System.Threading.Thread.Sleep(10);
            m.Dex = Randomize();
			System.Threading.Thread.Sleep(10);
            m.Speed = Randomize();
            System.Threading.Thread.Sleep(10);
            m.Health = 100;
            m.Level = 1;
            m.Xp = Randomize();
            System.Threading.Thread.Sleep(10);
            m.Image = GetRandomImage();


			//Uncomment if you want to add another monster into db
			await App.Database.InsertMonster(m);
            await Navigation.PushAsync(new MonsterPage());
            await Navigation.PopAsync();
        }
        async void Monster_MonsterSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new MonsterDetail { BindingContext = e.SelectedItem as Monster });
            }
        }

        private int Random1TO4()
        {
            Random r = new Random();
            return r.Next(1, 4);
        }

		private int Randomize()
		{
			Random rand = new Random();
			return rand.Next(1, 10);
		}

		private string PopulateAndReturnNames()
		{

            var words = new[] { "Leroy Jenkins", "Warlock", "Qui-gone-drank-the-gin","The_Chosen_One", "Anakin", "Snake", "Jake from Statefarm", "Flo", "Donald Drumpf",
            "Fur Rat", "Barrack Yo-Momma The 3rd", "Carl","Slime" };
            return words[rand.Next(0, words.Length)];
		}

        private string GetRandomImage()
        {
           
            var images = new[] { "http://i.imgur.com/5oy8rWy.png", "http://i.imgur.com/23o2LKv.png", "http://i.imgur.com/zJ0Y8oa.png", "http://i.imgur.com/GghhfF7.png" };
            if (count < images.Count())
            {
                count++;
                return images[count - 1];
            }
            else
            {
                count = 0;
                return images[count];
            }
        }
    }
}
