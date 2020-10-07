using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;

namespace cross.Droid
{
    public class DBa : DB
    {

        readonly FirebaseClient firebase = new FirebaseClient("https://project-706ea.firebaseio.com/");
        private readonly string ChildName = "Users";

        public async Task AddUserData(string fname, string sname)
        {
          await firebase
                .Child(ChildName)
                .PostAsync(new User() { userID = Guid.NewGuid(), fname = fname, sname = sname });
        }





        public Task EditUser(string fname, string sname)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUser(Guid uID)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUser(string fname)
        {
            throw new NotImplementedException();
        }

        public Task RemoveUser(Guid uID)
        {
            throw new NotImplementedException();
        }
    }
}
