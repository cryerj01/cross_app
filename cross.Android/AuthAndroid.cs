using System;
using System.Threading.Tasks;
using cross;
using cross.Droid;
using Firebase.Auth;
using Firebase;
using Xamarin.Forms;
using System.Collections.Generic;
using Android.Gms.Extensions;

[assembly: Dependency(typeof(AuthAndroid))]
namespace cross.Droid
{
    public class AuthAndroid : IAuth
    {
        public bool isLoggedin()
        {
            var user = FirebaseAuth.Instance.CurrentUser;
            return (user != null);
        }

        
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            try
            {
                var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                var token = await user.User.GetIdTokenAsync(false);
                return token.Token;
            }
            catch (FirebaseAuthInvalidUserException e)
            {
                e.PrintStackTrace();
                return e.ErrorCode;
            }
        }

        public async Task<bool> SignUpWithEmailPassword(string email, string password1, string password2)
        {
            string checkedpass;
            bool signedup =false;
            
            if (password1 == password2)
            {
                checkedpass = password1;
                var user = await FirebaseAuth.Instance.CreateUserWithEmailAndPassword(email, checkedpass);
                
                    signedup = true;
                
            }
            return signedup;
      
        }

        bool IAuth.SignOut()
        {
            Firebase.Auth.FirebaseAuth.Instance.SignOut();
            return true;
        }
    }
}
