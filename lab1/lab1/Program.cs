using System;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var queryAllFieldsUsers = SqlQueryBuilder.GetAllFieldsFromTable("Users");
            Console.WriteLine(queryAllFieldsUsers);

            var queryIdAndNameOrdered = SqlQueryBuilder.GetIdAndFieldOrdered("Users", "Name");
            Console.WriteLine(queryIdAndNameOrdered);

            var queryAllFieldsOrders = SqlQueryBuilder.GetAllFieldsFromTable("Orders");
            Console.WriteLine(queryAllFieldsOrders);

            var queryIdAndDateOrdered = SqlQueryBuilder.GetIdAndFieldOrdered("Orders", "OrderDate");
            Console.WriteLine(queryIdAndDateOrdered);

            var queryAllFieldsProducts = SqlQueryBuilder.GetAllFieldsFromTable("Products");
            Console.WriteLine(queryAllFieldsProducts);

            var customQuery = new SelectQuery()
                .SetTableName("Products")
                .AddField("ID")
                .AddField("Price")
                .SetOrderBy("Price")
                .ToString();
            Console.WriteLine(customQuery);
        }
    }
}