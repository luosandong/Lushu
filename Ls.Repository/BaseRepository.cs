using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CommonDal;
using Ls.Common.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Ls.Repository
{
    public interface IBaseRepository<T> where T : class, new()
    {
        #region CURD
        T Get(object id);
        /// <summary>
        /// 返回所有记录
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();
        /// <summary>
        /// 根据条件返回
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns></returns>
        IEnumerable<T> GetAll(Dictionary<string, object> predicate);
        /// <summary>
        /// 根据搜索组合条件查询
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>

        void Insert(T model);
        void Update(T model);
        bool Delete(T model);
        #endregion

        IEnumerable<T> GetBySql(string sql, Dictionary<string, object> parameters = null);

       
        int Count(string sql, Dictionary<string, object> parameters = null);

        int ExecuteSql(string sql, Dictionary<string, object> parameters = null);

    }

    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        protected IDbContext DbContext;

        public BaseRepository( )
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("databaseconfig.json", optional: true);
            var config = configBuilder.Build();
            DbAccessorConfiguration configuration = new DbAccessorConfiguration(
                config["ConnectionString"], (DatabaseType)int.Parse(config["DatabaseType"]));
            DbContext = new DbContext(configuration);

        }
        public bool Delete(T model)
        {
            try
            {
                DbContext.Delete(model);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T Get(object id)
        {
            try
            {
                return DbContext.Get<T>(id.ToString());
                //return DbContext.Get<T>(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return DbContext.GetList<T>();
                //return DbContext.GetList<T>();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<T> GetAll(Dictionary<string, object> predicate)
        {
            try
            {
                return DbContext.GetList<T>(predicate);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void Insert(T model)
        {
            DbContext.Insert(model);
            //DbContext.Insert(model);
        }

        public void Update(T model)
        {
            DbContext.Update(model);
        }



        public int Count(string sql, Dictionary<string, object> parameters = null)
        {
            return 0;
            //  return DbContext.Use(db => db.Count(sql, parameters));
        }

      

        public IEnumerable<T> GetBySql(string sql, Dictionary<string, object> parameters = null)
        {
            return DbContext.GetBySql<T>(sql, parameters);
        }

        public int ExecuteSql(string sql, Dictionary<string, object> parameters = null)
        {
            return DbContext.ExecuteSql(sql, parameters);
        }
    }
}
