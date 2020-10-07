using System;
using Xamarin.Forms;




namespace cross
{
    public partial class LoginPage : ContentPage
    {
        IAuth auth;
        string Token;
        public LoginPage()
        {

            InitializeComponent();




            auth = DependencyService.Get<IAuth>();

        }

        public async void LoginClicked(object sender, EventArgs e)
        {
            try
            {
                Token = await auth.LoginWithEmailPassword(EmailInput.Text, PasswordInput.Text);
                if (Token != "")
                {
                    Application.Current.MainPage = new mappage();
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
                //Console.WriteLine("email " + EmailInput.Text + " Password " + PasswordInput.Text);
                //Console.WriteLine("***********************************************");
                //Console.WriteLine("auth " + auth);
                //Console.WriteLine("***********************************************");
                //Console.WriteLine("Token" + Token);
                //Console.WriteLine("***********************************************");





            }



            async void ShowError()
            {
                await DisplayAlert("Authentication Failed", "E-mail or password are incorrect. Try again!", "OK");
            }




        }

        void singuppage(System.Object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new SignUpPage();

        }
    }
}