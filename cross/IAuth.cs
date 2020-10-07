using System;
using System.Threading.Tasks;

namespace cross
{
    public interface IAuth
    {
       
        Task<string> LoginWithEmailPassword(string email, string password);
        Task<bool> SignUpWithEmailPassword(string email, string password1, string password2);
        bool SignOut();
        bool isLoggedin();
        
    }
}
