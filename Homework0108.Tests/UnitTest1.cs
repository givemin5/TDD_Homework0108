using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Homework0108.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Products使用測試資料三筆一組取Cost總和應為6_15_24_21()
        {
            var products = GetTestProduct();

            int[] expected = new int[] { 6, 15, 24, 21 };

            int[] actual = products.GroupSum(x => x.Cost, 3);

            CollectionAssert.AreEqual(expected, actual);
        }

        public List<Product> GetTestProduct()
        {
            return new List<Product> {
                new Product{Id=1   ,Cost=1   ,Revenue=11, SellPrice=21 },
                new Product{Id=2   ,Cost=2   ,Revenue=12, SellPrice=22 },
                new Product{Id=3   ,Cost=3   ,Revenue=13, SellPrice=23 },
                new Product{Id=4   ,Cost=4   ,Revenue=14, SellPrice=24 },
                new Product{Id=5   ,Cost=5   ,Revenue=15, SellPrice=25 },
                new Product{Id=6   ,Cost=6   ,Revenue=16, SellPrice=26 },
                new Product{Id=7   ,Cost=7   ,Revenue=17, SellPrice=27 },
                new Product{Id=8   ,Cost=8   ,Revenue=18, SellPrice=28 },
                new Product{Id=9   ,Cost=9   ,Revenue=19, SellPrice=29 },
                new Product{Id=10  ,Cost=10  ,Revenue=20, SellPrice=30 },
                new Product{Id=11  ,Cost=11  ,Revenue=21, SellPrice=31 }

            };
        }
    }



    public class Product
    {
        public int Id { get; set; }
        public int Cost { get; set; }
        public int Revenue { get; set; }
        public int SellPrice { get; set; }
    }

    public static class ListExtension
    {
        public static int[] GroupSum(this List<Product> products, Func<Product, int> selector, int group)
        {
            var tmp = products.Select(selector)
                .Select((value, index) => new
                {
                    Value = value,
                    GroupId = index / group
                });

            var result = tmp
                .GroupBy(x => x.GroupId)
                .Select(x => x.Sum(y => y.Value)).ToArray();

            return result;
        }
    }
}
