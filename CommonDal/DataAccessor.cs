using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using Dapper;

namespace CommonDal
{

    public sealed class DataAccessor
    {
        private readonly IDbAccessorConfiguration _dbConfiguration;
        private IDbConnection _connection;

        public DataAccessor(IDbAccessorConfiguration dbConfiguration)
        {
            _dbConfiguration = dbConfiguration;
        }

       
        public void Insert<T>(T model)
        {
            using (_connection = _dbConfiguration.CreateDbConnection())
            {
                var sql = _dbConfiguration.SqlGenerator.Insert(model);
                _connection.Execute(sql, model);
                _connection.Close();
                _connection.Dispose();
            }
        }

        public void Update<T>(T model)
        {
            using (_connection = _dbConfiguration.CreateDbConnection())
            {
                var sql = _dbConfiguration.SqlGenerator.Update(model);
                _connection.Execute(sql, model);
                _connection.Close();
                _connection.Dispose();
            }

        }
        public void Delete<T>(T model)
        {
            using (_connection = _dbConfiguration.CreateDbConnection())
            {
                var sql = _dbConfiguration.SqlGenerator.Delete(model);
                _connection.Execute(sql, model);
                _connection.Close();
                _connection.Dispose();
            }

        }
        public T Get<T>(Dictionary<string, object> parameters)
        {
            using (_connection = _dbConfiguration.CreateDbConnection())
            {
                var sql = _dbConfiguration.SqlGenerator.Get(typeof(T));
                _connection.Close();
                _connection.Dispose();
                return _connection.Query<T>(sql, parameters).FirstOrDefault();

            }
        }

        public IEnumerable<T> GetAll<T>(Dictionary<string, object> parameters = null)
        {
            try
            {
                using (_connection = _dbConfiguration.CreateDbConnection())
                {
                    _connection.Open();
                    string sql = _dbConfiguration.SqlGenerator.Get(typeof(T));
                    var results = _connection.Query<T>(sql, parameters);
                    _connection.Close();
                    return results;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                _connection.Close();
                _connection.Dispose();
            }


        }

        public IEnumerable<T> GetBySql<T>(string sql, Dictionary<string, object> parameters = null)
        {
            try
            {
                using (_connection = _dbConfiguration.CreateDbConnection())
                {
                    _connection.Open();
                    var results = _connection.Query<T>(sql, parameters);
                    _connection.Close();
                    return results;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                _connection.Close();
                _connection.Dispose();
            }
        }

       

    }
}
