using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UR_Login.View;

//[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace UR_Login
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new UR_LoginPage());
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
