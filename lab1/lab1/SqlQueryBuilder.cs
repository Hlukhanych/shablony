using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    internal class SqlQueryBuilder
    {
        public static string GetAllFieldsFromTable(string tableName)
        {
            return new SelectQuery()
                .SetTableName(tableName)
                .ToString();
        }

        public static string GetIdAndFieldOrdered(string tableName, string fieldName)
        {
            return new SelectQuery()
                .SetTableName(tableName)
                .AddField("ID")
                .AddField(fieldName)
                .SetOrderBy(fieldName)
                .ToString();
        }
    }
}
