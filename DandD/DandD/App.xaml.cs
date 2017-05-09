﻿using DandD.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DandD
{
	public partial class App : Application
	{
        public App()
		{
			InitializeComponent();

			SetMainPage();
		}

		public static void SetMainPage()
		{
            Current.MainPage = new TabbedPage
            {
                Children =
                {
                    new NavigationPage(new AboutPage())
                    {
                        Title = "About",
                        Icon = Device.OnPlatform<string>("tab_about.png",null,null)
                    },
                    new NavigationPage(new ItemsPage())
                    {
                        Title = "Item",
                        Icon = Device.OnPlatform<string>("tab_feed.png",null,null)
                    },
                    //new NavigationPage(new CharacterPage())
                    //{
                    //    Title = "Character",
                    //    Icon = Device.OnPlatform<string>("tab_about.png",null,null)
                    //},
                    //new NavigationPage(new MonsterPage())
                    //{
                    //    Title = "Monsters",
                    //    Icon = Device.OnPlatform<string>("tab_about.png",null,null)
                    //},
                    // new NavigationPage(new BattlefieldPage())
                    //{
                    //    Title = "Battlefield",
                    //    Icon = Device.OnPlatform<string>("tab_about.png",null,null)
                    //},
                }
            };
        }
	}
}
