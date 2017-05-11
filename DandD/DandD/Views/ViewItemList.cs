using System;
using Xamarin.Forms;

namespace DandD.Views
{
    public class ViewItemList:ContentPage
    {
        public ViewItemList()
        {
			this.Title = "Item List";
        }

		protected async override void OnAppearing()
		{
            
			base.OnAppearing();
			ViewItemList.ItemsSource = await App.Database.RetrieveCharacters();
		}

	}
}
