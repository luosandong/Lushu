using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDal
{
    public class TableAttribute : Attribute
    {
        public string Name { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class KeyAttribute : Attribute
    {
    }

    public class MapIgnoreAttribute : Attribute
    {
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class FieldDefAttribute : Attribute
    {
        public bool MapIgnore { get; set; }
        public bool ReadOnly { get; set; }
        public string ColumnName { get; set; }
    }
    
}
