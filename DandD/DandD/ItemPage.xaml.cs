using DandD.Models.Game_Files;
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
	public partial class ItemPage : ContentPage
	{
		public ItemPage ()
		{
			InitializeComponent();
		}


        async void Save_Clicked(object sender, System.EventArgs e)
        {
            var ItemRow = (Items)BindingContext;
            await App.Database.InsertItem(ItemRow);
            await Navigation.PopAsync();
        }

        async void Cancel_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
