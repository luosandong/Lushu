    using System;
using System.Collections.Generic;
    using System.Data;
    using System.Text;
    using MySql.Data.MySqlClient;

    namespace CommonDal
{
    public interface IDbAccessorConfiguration
    {
        DatabaseType DbType { get; }
        string ConnectionString { get; }
        ISqlGenerator SqlGenerator { get; }
        IDbConnection CreateDbConnection();
    }

    public class DbAccessorConfiguration : IDbAccessorConfiguration
    {
        
        private string _connectionString;
        private DatabaseType _dbType;
        private ISqlGenerator _sqlGenerator;
        public DbAccessorConfiguration(string connectionString, DatabaseType dbType)
        {
            _connectionString = connectionString;
            _dbType = dbType;
        }

        public DatabaseType DbType => _dbType;

        public string ConnectionString => _connectionString;

        public ISqlGenerator SqlGenerator => _sqlGenerator;

        public IDbConnection CreateDbConnection()
        {
            IDbConnection connection=null;
            switch (DbType)
            {
                case DatabaseType.MySql:
                    connection = new MySqlConnection(ConnectionString);
                    _sqlGenerator = new MySqlSqlGenerator();
                    break;
            }

            return connection;
        }
    }
}
