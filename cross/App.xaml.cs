using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace cross
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            MainPage = new firstpage();


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
