using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LINQDemo
{
    class AddDataIntoDataTable
    {
        public static DataTable table = new DataTable();
        //UC8-Creating a data table
        public AddDataIntoDataTable()
        {
            //Creating Columns of the DataTable
            table.Columns.Add("ProductID");
            table.Columns.Add("UserID");
            table.Columns.Add("Rating");
            table.Columns.Add("Review");
            table.Columns.Add("isLike");
            //Inserting Data into the Table
            table.Rows.Add(1, 1, 2d, "Good", true);
            table.Rows.Add(2, 1, 4d, "Good", true);
            table.Rows.Add(3, 1, 5d, "Good", true);
            table.Rows.Add(4, 1, 6d, "Good", false);
            table.Rows.Add(5, 1, 2d, "nice", true);
            table.Rows.Add(6, 1, 1d, "bas", true);
            table.Rows.Add(8, 1, 1d, "Good", false);
            table.Rows.Add(8, 1, 9d, "nice", true);
            table.Rows.Add(2, 1, 10d, "nice", true);
            table.Rows.Add(10, 1, 8d, "nice", true);
            table.Rows.Add(11, 1, 3d, "nice", true);
            //Printing data
            Console.WriteLine("\nDataTable contents:");
        }
    }
}
