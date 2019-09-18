using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;

namespace LsdDal
{
    public interface IDalBuilder
    {

    }
    public class DalBuilder: IDalBuilder
    {
        public IEnumerable<T> GetAll<T>()
        {

            using (MySqlConnection connection = new MySqlConnection("server=127.0.0.1;port=3306;uid=root;pwd=P@ssW0rd;database=lushu;"))
            {
                return connection.Query<T>("Select * from book_category;");
            }
        }

        public void Insert<T>(T model)
        {
            using (MySqlConnection connection = new MySqlConnection("server=127.0.0.1;port=3306;uid=root;pwd=P@ssW0rd;database=lushu;"))
            {
                connection.ExecuteAsync("Insert Into book_category value (@id,@Name,@ParentId,@Layer,@Sequence)",
                    model);
            }
        }
    }
}
