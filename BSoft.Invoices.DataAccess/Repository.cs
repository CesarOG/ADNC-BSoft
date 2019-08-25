using Dapper.Contrib.Extensions;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSoft.Invoices.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected string _connectionString;
        public Repository(string connectionString)
        {
            SqlMapperExtensions.TableNameMapper = (type) => { return $"{type.Name}"; };
            _connectionString = connectionString;
        }
        public bool Delete(T entity)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return connection.Delete(entity);
            }
        }

        public T GetById(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return connection.Get<T>(id);
            }
        }

        public IEnumerable<T> GetList()
        {
            IEnumerable<T> response = null;
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                response= connection.GetAll<T>();
                connection.Close();
            }
            return response;
        }

        public int Insert(T entity)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return (int)connection.Insert(entity);
            }
        }

        public bool Update(T entity)
        {
            using (var connection = new NpgsqlConnection(_connectionString)) {
                return connection.Update(entity);
            }
        }
    }
}
