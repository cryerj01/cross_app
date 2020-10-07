using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace cross
{
    public partial class firstpage : ContentPage
    {

        private Task<PermissionStatus> location;

        public firstpage()
        {
            InitializeComponent();
            location = CheckAndRequestLocationPermission();
        }

        void onSignupPage(System.Object sender, System.EventArgs e)
        {
            
            Application.Current.MainPage = new SignUpPage();
        }

        void onloginPage(System.Object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new LoginPage();
        }

        void onMapPage(System.Object sender, System.EventArgs e)
            
        {
            Application.Current.MainPage = new mappage();
        }



        public async Task<PermissionStatus> CheckAndRequestLocationPermission()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            }

        

            return status;
        }

    }
}
