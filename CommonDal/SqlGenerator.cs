using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommonDal
{
    public interface ISqlGenerator
    {
        string Insert<T>(T model);
        string Update<T>(T model);
        string Get(Type type);
        string Delete<T>(T model);
        string GetCondition(Dictionary<string, object> QueryParams);
    }

    public class SqlGenerator
    {
        public virtual char ParameterPrefix => '@';
        public virtual char OpenQuote => '[';

        public virtual char CloseQuote => ']';
        protected string GetTableName(Type type)
        {
            TableAttribute attr = type.GetCustomAttribute(typeof(TableAttribute)) as TableAttribute;
            return attr.Name;
        }

        public virtual string Delete<T>(T model)
        {
            string sql = $"DELETE  FROM {GetTableName(typeof(T))} WHERE 1=1 ";
            var key = model.GetType().GetProperties().FirstOrDefault(property => (property.GetCustomAttribute(typeof(KeyAttribute))) != null);
            if (key != null)
            {
                sql += $"AND {key.Name}={ParameterPrefix}{key.Name}";
            }
            return sql;
        }

        protected virtual string BuildUpdate(List<PropertyInfo> properties)
        {
            List<string> fields = new List<string>();
            foreach (var property in properties)
            {
                if ((property.GetCustomAttribute(typeof(MapIgnoreAttribute)) as MapIgnoreAttribute) != null) continue;
                var fieldDef =
                    property.GetCustomAttribute(typeof(FieldDefAttribute)) as FieldDefAttribute;
                if (fieldDef != null)
                {
                    fields.Add($"{this.OpenQuote}{fieldDef.ColumnName}{this.CloseQuote}={ParameterPrefix}{property.Name}");
                }
                else
                {
                    fields.Add($"{this.OpenQuote}{property.Name}{this.CloseQuote}={ParameterPrefix}{property.Name}");
                }
                
            }
            return string.Join(",", fields.ToArray());
        }

        protected Tuple<string,string>  BuildField(List<PropertyInfo> properties)
        {
            List<string> fields = new List<string>();
            List<string> fieldParameter = new List<string>();
            foreach (var property in properties)
            {
                if ((property.GetCustomAttribute(typeof(MapIgnoreAttribute)) as MapIgnoreAttribute) != null) continue;
                var fieldDef =
                    property.GetCustomAttribute(typeof(FieldDefAttribute)) as FieldDefAttribute;
                if (fieldDef != null)
                {
                    fields.Add($"`{fieldDef.ColumnName}`");
                }
                else
                {
                    fields.Add($"`{property.Name}`");
                }
                fieldParameter.Add($"{ParameterPrefix}{property.Name}");
            }

            return new Tuple<string, string>(string.Join(",", fields.ToArray()), string.Join(",", fieldParameter.ToArray()));
           
        }

        protected string BuidFieldParameter(List<PropertyInfo> properties)
        {
            List<string> fields = new List<string>();
            foreach (var property in properties)
            {
                fields.Add($"@{property.Name}");
            }

            return string.Join(",", fields.ToArray());
        }

        protected List<PropertyInfo> GetProperties(Type type)
        {
            return (from property in type.GetProperties() let ignore = property.GetCustomAttribute(typeof(MapIgnoreAttribute)) != null where !ignore select property).ToList();
        }

        public string Update<T>(T model)
        {
            var properties = GetProperties(model.GetType());
            var tableName = GetTableName(typeof(T));
            StringBuilder sb = new StringBuilder($"UPDATE  {OpenQuote}{tableName}{CloseQuote}  SET {BuildUpdate(properties)} WHERE Id=@Id ");
            string sql = sb.ToString();
            return sql;
        }
    }

    public class MySqlSqlGenerator : SqlGenerator, ISqlGenerator
    {
        public override char OpenQuote => '`';

        public override char CloseQuote => '`';

       
        public string Get(Type type)
        {
            string sql = $"SELECT {BuildField(GetProperties(type)).Item1} FROM {GetTableName(type)}";
            return sql;
        }

        public string GetCondition(Dictionary<string, object> QueryParams)
        {
            string condition = " WHERE 1=1 ";
            foreach (var kv in QueryParams)
            {
                condition += $" AND {OpenQuote}{kv.Key}{CloseQuote}={ParameterPrefix}{kv.Key} ";
            }

            return condition;
        }
        public string Insert<T>(T model)
        {
            string sql = $"insert into {GetTableName(model.GetType())} ({BuildField(GetProperties(model.GetType())).Item1}) values ({BuildField(GetProperties(model.GetType())).Item2});";
            return sql;
        }

       

     
    }

    public class SqlServerSqlGenerator: SqlGenerator,ISqlGenerator
    {
        public List<PropertyInfo> Properties { get; set; }
        public string Insert<T>(T model)
        {
            var properties = GetProperties(model.GetType());
            var tableName = GetTableName(typeof(T));
            StringBuilder sb = new StringBuilder($"INSERT INTO [{tableName}] ({BuidField(properties)}) VALUES({BuidFieldParameter(properties)})");
            string sql = sb.ToString();
            return sql;
        }

       

        public string Get(Type type)
        {
            string sql = $"SELECT {BuidField(GetProperties(type))} FROM {GetTableName(type)}";
            return sql;
        }

        public string Delete<T>(T model)
        {
            string sql = $"DELETE  FROM {GetTableName(model.GetType())}";
            return sql;
        }

        private string BuildUpdate(List<PropertyInfo> properties)
        {
            List<string> fields = new List<string>();
            foreach (var property in properties)
            {
                fields.Add($"[{property.Name}]=@{property.Name}");
            }
            return string.Join(",", fields.ToArray());
        }

        private string BuidField(List<PropertyInfo> properties)
        {
            List<string> fields = new List<string>();
            foreach (var property in properties)
            {
                fields.Add($"[{property.Name}]");
            }
            return string.Join(",", fields.ToArray());
        }
        private string BuidFieldParameter(List<PropertyInfo> properties)
        {
            List<string> fields = new List<string>();
            foreach (var property in properties)
            {
                fields.Add($"@{property.Name}");
            }

            return string.Join(",", fields.ToArray());
        }

        public string GetCondition(Dictionary<string, object> QueryParams)
        {
            throw new NotImplementedException();
        }
    }
}
