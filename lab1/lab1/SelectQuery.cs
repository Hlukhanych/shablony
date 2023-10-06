using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    internal class SelectQuery
    {
        public string TableName;
        public List<string> Fields = new List<string>();
        public string Condition;
        public string OrderByField;

        public SelectQuery SetTableName(string tableName)
        {
            TableName = tableName;
            return this;
        }

        public SelectQuery AddField(string field)
        {
            Fields.Add(field);
            return this;
        }

        public SelectQuery SetCondition(string condition)
        {
            Condition = condition;
            return this;
        }

        public SelectQuery SetOrderBy(string field)
        {
            OrderByField = field;
            return this;
        }

        public override string ToString()
        {
            StringBuilder sql = new StringBuilder($"SELECT ");

            if (Fields.Count == 0)
            {
                sql.Append("*");
            }
            else
            {
                sql.Append(string.Join(", ", Fields));
            }

            sql.Append($" FROM {TableName}");

            if (!string.IsNullOrEmpty(Condition))
            {
                sql.Append($" WHERE {Condition}");
            }

            if (!string.IsNullOrEmpty(OrderByField))
            {
                sql.Append($" ORDER BY {OrderByField}");
            }

            return sql.ToString();
        }
    }
}
