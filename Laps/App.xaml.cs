using System;
using Laps.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Laps
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TimerPage();
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
