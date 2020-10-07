using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;


namespace cross
{
    public interface DB
    {
       
        Task<List<User>> GetAllUsers();
        Task AddUserData(string fname,string sname);
        Task<User> GetUser(Guid uID);
        Task<User> GetUser(string fname);
        Task EditUser(string fname, string sname);
        Task RemoveUser(Guid uID);

    }



    public class User
    {

        public Guid userID { get; set; }

        public string fname { get; set; }
        public string sname { get; set; }





    }
}
