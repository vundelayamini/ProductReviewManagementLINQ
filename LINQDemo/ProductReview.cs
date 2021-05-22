﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LINQDemo
{
    class ProductReview
    {
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public double Rating { get; set; }
        public string Review { get; set; }
        public bool isLike { get; set; }
        public override string ToString()
        {
            return $"ProductID: - {ProductID}  UserID: - { UserID} Rating:- {Rating} Review:- { Review}  isLike:- { isLike}";
        }
    }
}

