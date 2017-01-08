using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Homework0108.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Products使用測試資料三筆一組取Cost總和應為6_15_24_21()
        {
            var products = new List<Product>();

            int[] expected = new int[] { 6, 15, 24, 21 };

            int[] actual = products.GroupSum(x => x.Cost, 3);

            Assert.AreEqual(expected, actual);
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public int Cost { get; set; }
        public int Revenne { get; set; }
        public int SellPrice { get; set; }
    }

    public static class ListExtension
    {
        public static int[] GroupSum(this List<Product> products, Func<Product, int> selector, int group) {
            return new int[1];
        }
    }
}
