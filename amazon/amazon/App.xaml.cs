using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using amazon.Themes;

namespace amazon
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjYxNDkwM0AzMjMyMmUzMDJlMzBHNTd1Zzd3S1dXdDk3L2dGb3pRZisrL1o4emx5SHhHRUprNVg0dDRVcVNZPQ==");

            InitializeComponent();

            MainPage = new NavigationPage( new  Views.MainPage());
        }
        public static void ChangeTheme(int option)
        {
            App.Current.Resources.MergedDictionaries.Clear();
            if (option == 1)
                App.Current.Resources.MergedDictionaries.Add(new Themes.Light());
            else
                App.Current.Resources.MergedDictionaries.Add(new Themes.Dark());

            App.Current.Resources.MergedDictionaries.Add(new Themes.GeneralStyle());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
