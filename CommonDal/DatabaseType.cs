using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDal
{
    public enum DatabaseType
    {
        /// <summary>
        /// SqlServer
        /// </summary>
        SqlServer = 0,

        /// <summary>
        /// Oracle
        /// </summary>
        Oracle = 1,

        /// <summary>
        /// PostgreSql
        /// </summary>
        PostgreSql = 2,
        /// <summary>
        /// SQL CE
        /// </summary>
        SqlCe = 3,
        /// <summary>
        /// Sqlite
        /// </summary>
        Sqlite = 4,
        /// <summary>
        /// MySQL
        /// </summary>
        MySql = 5
    }
}
