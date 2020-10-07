using System;
using System.Threading.Tasks;
using cross;
using cross.iOS;
using Xamarin.Forms;
using Firebase.Auth;
using Foundation;

[assembly: Dependency(typeof(AuthIOS))]

namespace cross.iOS
{
    public class AuthIOS : IAuth
    {
        public bool isLoggedin()
        {
            var user = Auth.DefaultInstance.CurrentUser;
            return user != null;
        }

        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            try
            {
                var user = await Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
                return await user.User.GetIdTokenAsync();
            }
            catch (Exception e)
            {
                return "Error" + e;
            }
        }


        public async Task<bool> SignUpWithEmailPassword(string email, string password1, string password2)
        {
            string checkedpass;
            bool signedup;
            
                if (password1 == password2)
                {
                    checkedpass = password1;
                    var user = await Auth.DefaultInstance.CreateUserAsync(email, checkedpass);
                    signedup = true;
                }
            else
            {
                signedup = false;
            }
                return signedup;
            
            
        }

        bool IAuth.SignOut()
        {
            try
            {
                Auth.DefaultInstance.SignOut(out NSError nSError);
                return nSError == null;
            }
            catch
            {
                return false;
            }


        }
    }
}
