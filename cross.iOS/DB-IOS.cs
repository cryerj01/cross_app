using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;

namespace cross.iOS
{
    public class DB_IOS : DB
    {

         FirebaseClient firebase = new FirebaseClient("https://project-706ea.firebaseio.com/users");
        private readonly string ChildName = "Users";


        public async Task AddUserData(string Fname, string Sname)
        {
            await firebase
                .Child(ChildName)
                .PostAsync(new User() { userID = Guid.NewGuid(), fname = Fname, sname = Sname });
                    
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
