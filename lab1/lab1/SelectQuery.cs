using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    internal class SelectQuery
    {
        private string tableName;
        private List<string> fields = new List<string>();
        private string condition;
        private string orderByField;

        public SelectQuery SetTableName(string tableName)
        {
            tableName = tableName;
            return this;
        }

        public SelectQuery AddField(string field)
        {
            fields.Add(field);
            return this;
        }

        public SelectQuery SetCondition(string condition)
        {
            condition = condition;
            return this;
        }

        public SelectQuery SetOrderBy(string field)
        {
            orderByField = field;
            return this;
        }

        public override string ToString()
        {
            StringBuilder sql = new StringBuilder($"SELECT ");

            if (fields.Count == 0)
            {
                sql.Append("*");
            }
            else
            {
                sql.Append(string.Join(", ", fields));
            }

            sql.Append($" FROM {tableName}");

            if (!string.IsNullOrEmpty(condition))
            {
                sql.Append($" WHERE {condition}");
            }

            if (!string.IsNullOrEmpty(orderByField))
            {
                sql.Append($" ORDER BY {orderByField}");
            }

            return sql.ToString();
        }
    }
}
