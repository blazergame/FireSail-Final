using System;
using System.Threading.Tasks;
using DandD.Views;
using DandD;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DandD
{
	public partial class App : Application
	{
        static ItemDatabase database;

        public App()
		{
			InitializeComponent();

			SetMainPageAsync();
		}

        public static ItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ItemDatabase(DependencyService.Get<ILocalFileHelper>().GetLocalFilePath("Item.db3"));
                }
                return database;
            }

        }

        public static async void SetMainPageAsync()
        {
            Current.MainPage = new SplashPage();
            await Task.Delay(TimeSpan.FromSeconds(3));
            Current.MainPage = new TabbedPage
            {
                Children =
                {
                    new NavigationPage(new MenuPage())
                    {
                        Title = "Menu",
                        Icon = Device.OnPlatform<string>("tab_about.png",null,null)
                    },
                    new NavigationPage(new AboutPage())
                    {
                        Title = "About",
                        Icon = Device.OnPlatform<string>("tab_feed.png",null,null)
                    },
                    new NavigationPage(new SettingsPage())
                    {
                        Title = "Settings",
                        Icon = Device.OnPlatform<string>("tab_feed.png",null,null)
                    }
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
