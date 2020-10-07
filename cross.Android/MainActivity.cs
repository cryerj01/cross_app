
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Firebase;
using System.Collections.Generic;
using Firebase.Auth;
using Android.Support.V4.Content;
using Android;
using Android.Support.V4.App;
using System;
using Android.Support.Design.Widget;

namespace cross.Droid
{
    [Activity(Label = "cross", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private FirebaseApp app;
        FirebaseAuth auth;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
           
            base.OnCreate(savedInstanceState);

            Xamarin.FormsMaps.Init(this, savedInstanceState);
            
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            InitFriebase();



           
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void InitFriebase()
        {
            var options = new Firebase.FirebaseOptions.Builder()
                .SetApiKey("AIzaSyAvDZA3xwVepEniUr0Jr3-vcGuIWs4MV64")
                .SetApplicationId("project-706ea")
                .Build();

            bool hasBeenInitialised = false;
            IList <FirebaseApp> firebaseApps = FirebaseApp.GetApps(this);
            FirebaseApp.GetApps(this);
            foreach (FirebaseApp tempapp in firebaseApps)
            {
                if (tempapp.Name.Equals(FirebaseApp.DefaultAppName))
                {
                    hasBeenInitialised = true;
                    app = tempapp;
                }
            }

            if (!hasBeenInitialised)
            {

                app = FirebaseApp.InitializeApp(this, options);
            }
            auth = FirebaseAuth.GetInstance(app);
        }



        

    }
}