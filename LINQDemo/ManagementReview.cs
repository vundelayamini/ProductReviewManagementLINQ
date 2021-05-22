using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LINQDemo
{
    class ManagementReview
    {
        public readonly DataTable dataTable = new DataTable();
        //UC2-Retrive top three records from the list 
        public void TopRecords(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReview in listProductReview
                                orderby productReview.Rating descending
                                select productReview).Take(3);
            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ToString());
            }
        }
    }
}

