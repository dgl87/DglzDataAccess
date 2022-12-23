using BlogApp.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Repositories
{
    public class UserRepository
    {
        private readonly SqlConnection _connection;

        public UserRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public User Get(int id)
            => _connection.Get<User>(id);

        public IEnumerable<User> GetAll() 
        {
            return _connection.GetAll<User>();
        }
        public void Create(User user)
        {
            _connection.Insert<User>(user);
        }
        public void Update(User user)
        {
            _connection.Update<User>(user);
        }
        public void Delete(User user)
        {
            _connection.Delete<User>(user);
        }
        public void Delete(int id)
        {
            var user = _connection.Get<User>(id);
            _connection.Delete<User>(user);
        }
    }
}
