using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace cross
{

    public partial class SignUpPage : ContentPage
    {
        IAuth auth;
      //  DB dbstuff;
        bool signedup;
        string Token;

        public SignUpPage()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();
        //  dbstuff = DependencyService.Get<DB>();
        }

        public async void SignupClicked(object sender, EventArgs e)
        {
            try
            {
                signedup = await auth.SignUpWithEmailPassword(EmailIn.Text, Pass1In.Text, Pass2In.Text);

                if (signedup != false)
                {
                    //    makeuser();
                    Login();

                }
                else
                {
                    ShowError();
                }
            }
            catch (Exception error)
            {
                //Console.WriteLine("***********************************************");
                //Console.WriteLine("Error " + error);
                //Console.WriteLine("***********************************************");
                //Console.WriteLine("email " + EmailIn.Text + " Password 1-" + Pass1In.Text + " Password 2-" + Pass2In.Text);
                //Console.WriteLine("***********************************************");
                //Console.WriteLine("auth " + auth);
                //Console.WriteLine("***********************************************");
                //Console.WriteLine("signup" + signedup);
                //Console.WriteLine("***********************************************");

            }

            async void ShowError()
            {
                await DisplayAlert("Authentication Failed", "", "OK");
            }



        }


        public async void Login()
        {

            try
            {
                Token = await auth.LoginWithEmailPassword(EmailIn.Text, Pass1In.Text);
                if (Token != "")
                {
                    Application.Current.MainPage = new mappage();
                }

            }
            catch (Exception error)
            {
                Console.WriteLine(error);

            }
        }


        //public async void makeuser()
        //{

        //    try
        //    {



        //        await dbstuff.AddUserData(fname.Text, sname.Text);

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("*****************?????????????????????");
        //        Console.WriteLine(ex);
        //        Console.WriteLine("*****************?????????????????????");

        //    }
        //}

        void loginpage(System.Object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new LoginPage();
        }






    }
}
