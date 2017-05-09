using DandD.Views;

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

			SetMainPage();
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

        public static void SetMainPage()
		{
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
