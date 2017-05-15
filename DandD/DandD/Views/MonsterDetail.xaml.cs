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
	public partial class MonsterDetail : ContentPage
	{
		public MonsterDetail ()
		{
			InitializeComponent ();
		}

        async void Update_Clicked(object sender, System.EventArgs e)
        {
            var Mon = (Monster)BindingContext;
            await App.Database.InsertMonster(Mon);
            await Navigation.PopAsync();
        }

        async void Delete_Clicked(object sender, System.EventArgs e)
        {
            var Mon = (Monster)BindingContext;
            await App.Database.deleteMonster(Mon);
            await Navigation.PopAsync();
        }
    }
}
