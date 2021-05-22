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
        // UC3-Retrieves the records with rating greater than three.
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
        // UC4-Retrieves the count of reviews for each productID.
        public void RetrieveCountOfReviewForEachProductId(List<ProductReview> listProductReview)
        {
            var recordedData = listProductReview.GroupBy(x => x.ProductID).Select(x => new { ProductID = x.Key, Count = x.Count() });
            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ProductID + " " + list.Count);
            }

        }
        // UC5-Retrieves only the product id and review of all records.
        public void RetrieveProductIDAndReviews(List<ProductReview> listProductReview)
        {
            var recordedData = from productReview in listProductReview
                               select new { productReview.ProductID, productReview.Review };
            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ProductID + " " + list.Review);
            }
        }
        // UC6-Skip top five records from the list 
        public void SkipTop5Records(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReview in listProductReview
                                select productReview).Skip(5);
            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ToString());
            }
        }
        // UC7 Retrieving reviews and productId using the lambda expression 
        public void SelectProductIDAndReviews(List<ProductReview> listProductReview)
        {
            var recordedData = listProductReview.Select(x => new { x.ProductID, x.Review });
            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ProductID + " " + list.Review);
            }
        }

        //UC9-Retrieve all the records from the datatable variable who’s isLike value is true 
        public void RetrieveTrueIsLike()
        {
            var Data = from reviews in dataTable.AsEnumerable()
                       where reviews.Field<bool>("isLike").Equals(true)
                       select reviews;
            foreach (var dataItem in Data)
            {
                Console.WriteLine($"ProductID- {dataItem.ItemArray[0]} UserID- {dataItem.ItemArray[1]} Rating- {dataItem.ItemArray[2]} Review- {dataItem.ItemArray[3]} isLike- {dataItem.ItemArray[4]}");
            }
        }
        //UC10-Find Average rating of the each productId
        public void AverageRatingByProductID()
        {
            var Data = dataTable.AsEnumerable()
                        .GroupBy(x => x.Field<int>("ProductID"))
                        .Select(x => new { ProductID = x.Key, Average = x.Average(p => p.Field<double>("Rating")) });
            foreach (var dataItem in Data)
            {
                Console.WriteLine(dataItem.ProductID + " " + dataItem.Average);
            }
        }
        //UC11-Retreive all records from the list who’s review message contain “nice”
        public void NiceReviews()
        {
            var Data = dataTable.AsEnumerable()
                        .Where(x => x.Field<string>("Review").Contains("Nice", StringComparison.OrdinalIgnoreCase));
            foreach (var dataItem in Data)
            {
                foreach (var item in dataItem.ItemArray)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }

        }
        //UC12-Retreive all records from the list who’s Userid = 10 and order by rating
        public void OrderByRatingOnCondition()
        {
            var Data = dataTable.AsEnumerable()
                        .Where(x => x.Field<int>("UserID") == 10)
                        .OrderBy(x => x.Field<double>("Rating"));
            foreach (var dataItem in Data)
            {
                foreach (var item in dataItem.ItemArray)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
        }

    }
}
    



