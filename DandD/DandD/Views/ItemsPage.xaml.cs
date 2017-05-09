using System;

using DandD.Models;
using DandD.ViewModels;

using Xamarin.Forms;

namespace DandD.Views
{
	public partial class ItemsPage : ContentPage
	{
		ItemsViewModel viewModel;

		public ItemsPage()
		{
			InitializeComponent();

			BindingContext = viewModel = new ItemsViewModel();
		}

		async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
			var item = args.SelectedItem as Item;
			if (item == null)
				return;

			await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

			// Manually deselect item
			//ItemsListView.SelectedItem = null;
		}

		async void AddItem_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NewItemPage());
		}

		//protected override void OnAppearingAsync()
		//{
		//	base.OnAppearing();

		//	if (viewModel.Items.Count == 0)
		//		viewModel.LoadItemsCommand.Execute(null);
		//}
	}
}
