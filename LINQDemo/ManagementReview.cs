using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            foreach (var productReview in recordedData)
            {
                Console.WriteLine("Product Id :" + productReview.ProductID + "\t" + "User Id :" + productReview.UserID + "\t" + "Rating ;" + productReview.Rating + "\t" + "Review :" + productReview.Review + "\t" + "Is Like :" + productReview.isLike);
            }
        }
        // UC3 Retrieves the records with rating greater than three.
        public void RetrieveRecordsWithGreaterThanThreeRating(List<ProductReview> listProductReview)
        {
            var recordedData = from productReview in listProductReview
                               where (productReview.ProductID == 1 || productReview.ProductID == 4 || productReview.ProductID == 9)
                               && productReview.Rating > 3
                               select productReview;
            foreach (var productReview in recordedData)
            {
                Console.WriteLine("Product Id :" + productReview.ProductID + "\t" + "User Id :" + productReview.UserID + "\t" + "Rating ;" + productReview.Rating + "\t" + "Review :" + productReview.Review + "\t" + "Is Like :" + productReview.isLike);
            }
        }
        // UC4 Retrieves the count of reviews for each productID.
        public void RetrieveCountOfReviewForEachProductId(List<ProductReview> listProductReview)
        {
            var recordedData = listProductReview.GroupBy(x => x.ProductID).Select(x => new { ProductID = x.Key, Count = x.Count() });
            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ProductID + " " + list.Count);
            }

        }
    }
}

