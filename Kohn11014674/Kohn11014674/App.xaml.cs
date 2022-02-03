using Kohn11014674.Services;
using Kohn11014674.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kohn11014674
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
