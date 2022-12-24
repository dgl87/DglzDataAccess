using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace DesafioApp.Repositories
{
    public class Repository<T> where T : class
    {
        private readonly SqlConnection _connection;
        public Repository(SqlConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<T> GetAll()
        {
            return _connection.GetAll<T>();
        }
        public void Create(T model)
        {
            _connection.Insert<T>(model);
        }
        public void Update(T model)
        {
            _connection.Update<T>(model);
        }
        public void Delete(T model)
        {
            _connection.Delete<T>(model);
        }
        public void Delete(int id)
        {
            var item = _connection.Get<T>(id);
            _connection.Delete<T>(item);
        }
    }
}
