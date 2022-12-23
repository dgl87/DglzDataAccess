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
    public class RoleRepository
    {
        private readonly SqlConnection _connection;
        public RoleRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Role> GetAll()
        {
            return _connection.GetAll<Role>();
        }
        public Role Get(int id)
        {
            return _connection.Get<Role>(id);
        }
        public void Create(Role role)
        {
            _connection.Insert<Role>(role);
        }
        public void Update(Role role)
        {
            _connection.Update(role);
        }
        public void Delete(Role role)
        {
            _connection.Delete<Role>(role);
        }
        public void Delete(int id)
        {
            var user = _connection.Get<User>(id);
            _connection.Delete(user);
        }
    }
}
