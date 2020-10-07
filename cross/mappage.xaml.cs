using System;
using System.Collections.Generic;
using Xamarin.Forms.Maps;
using Xamarin.Forms;
using Plugin.Geolocator;
using System.Threading.Tasks;

namespace cross
{
    public partial class mappage : ContentPage
    {
        private IAuth auth;
        private bool loggedin = new bool();

        Map map = new Map();
        public mappage()
        {
            InitializeComponent();


            auth = DependencyService.Get<IAuth>();
            Logincheck();
            _ = mapstuffAsync();


        }

        public void Logincheck()
        {
            loggedin = false;
            loggedin = auth.isLoggedin();

            if (loggedin == false)
            {
                Application.Current.MainPage = new firstpage();
            }

        }

        public async Task mapstuffAsync()
        {
            map = mAp;
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();
            map.MoveToRegion(MapSpan.FromCenterAndRadius(
                new Position(position.Latitude,
                position.Longitude),
                             Distance.FromMiles(1)));

        }

        void logout(System.Object sender, System.EventArgs e)
        {

            auth.SignOut();
            Application.Current.MainPage = new firstpage();

        }





    }
}
