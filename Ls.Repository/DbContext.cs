using CommonDal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Ls.Repository
{
    public interface IDbContext
    {
        T Get<T>(dynamic id, int? commandTimeout = null) where T : class;
        void Insert<T>(T model, int? commandTimeout = null) where T : class;
        void Update<T>(T entity, int? commandTimeout = null) where T : class;
        void Delete<T>(T entity, int? commandTimeout = null) where T : class;
        IList<T> GetBySql<T>(string sql, Dictionary<string, object> parameters = null) where T : class;
        IList<T> GetList<T>(Dictionary<string, object> parameters = null) where T : class;
        int ExecuteSql(string sql ,Dictionary<string, object> parameters = null);
    }
    public class DbContext : IDbContext
    {
        private readonly DataAccessor _dataAccessor;
        private readonly DbAccessorConfiguration _dbConfiguration;
        public DbContext(DbAccessorConfiguration dbConfiguration)
        {
            _dbConfiguration = dbConfiguration;
            _dataAccessor = new DataAccessor(dbConfiguration);
        }
        public void Delete<T>(T entity, int? commandTimeout = null) where T : class
        {
             _dataAccessor.Delete(entity);
        }

        public int ExecuteSql(string sql ,Dictionary<string, object> parameters = null)
        {
           return _dataAccessor.ExecuteSql(sql, parameters);
        }

        public T Get<T>(dynamic id, int? commandTimeout = null) where T : class
        {
            var par = new Dictionary<string, object>
            {
                { "id", id }
            };
            return _dataAccessor.Get<T>(par);
        }

        public IList<T> GetBySql<T>(string sql, Dictionary<string, object> parameters = null) where T : class
        {
            return _dataAccessor.GetBySql<T>(sql, parameters)?.ToList();
        }

        public IList<T> GetList<T>(Dictionary<string, object> parameters = null) where T : class
        {
            return _dataAccessor.GetAll<T>(parameters)?.ToList();
        }

        public void Insert<T>(T model, int? commandTimeout = null) where T : class
        {
            _dataAccessor.Insert(model);
        }

        public void Update<T>(T entity, int? commandTimeout = null) where T : class
        {
            _dataAccessor.Update(entity);
        }
    }
}
