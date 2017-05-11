using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DandD.Views
{
    public partial class ViewItems : ContentPage
    {
        public ViewItems()
        {
            InitializeComponent();
            this.Title = "View list of Items";
        }


		protected async override void OnAppearing()
		{
			base.OnAppearing();
			ItemsListView.ItemsSource = await App.Database.RetrieveItems();
		}

		

	}
}
