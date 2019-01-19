using DatingApp.API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Data
{
    public class Seed
    {

        public DataContext _dataContext { get; }
        public Seed(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void SeedUser()
        {
            var userJson = File.ReadAllText("Data/UserSeedData.json");
            var users = JsonConvert.DeserializeObject<List<User>>(userJson);
            foreach (var user in users)
            {
                byte[] passwordHash; byte[] passwordSalt;
                CreatePasswordHash("password", out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.Username = user.Username.ToLower();
                _dataContext.Add(user);
            }
            _dataContext.SaveChanges();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hashkey = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hashkey.Key;
                passwordHash = hashkey.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

    }
}
