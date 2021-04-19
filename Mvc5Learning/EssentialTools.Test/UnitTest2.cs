using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EssentialTools.Models;
using Moq;

namespace EssentialTools.Test
{
    /// <summary>
    /// UnitTest2 的摘要说明
    /// </summary>
    [TestClass]
    public class UnitTest2
    {
        private Product[] products = {
            new Product {Name = "Kayak", Category = "Watersports", Price =275M},
            new Product {Name = "Lifejacket", Category = "Watersports",Price = 48.95M},
            new Product {Name = "Soccer ball", Category = "Soccer", Price= 19.50M},
            new Product {Name = "Corner flag", Category = "Soccer", Price= 34.95M}
        };

        private Product[] createProduct(decimal value)
        {
            return new[] { new Product { Price = value } };
        }

        [TestMethod]
        public void Pass_Through_Variable_Discounts()
        {
            Mock<IDiscountHelper> mock = new Mock<IDiscountHelper>();
            mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>())).Returns<decimal>(total => total);
            mock.Setup(m => m.ApplyDiscount(It.Is<decimal>(v => v > 100))).Returns<decimal>(total => total * 0.9M);
            mock.Setup(m => m.ApplyDiscount(It.IsInRange<decimal>(10, 100, Range.Inclusive))).Returns<decimal>(total => total - 5);
            var target = new LinqValueCalculator(mock.Object);
            decimal OneThousandDiscount = target.ValueProducts(createProduct(5));
            decimal TowHundredDiscount = target.ValueProducts(createProduct(200));
            decimal EightyDiscount = target.ValueProducts(createProduct(80));
            Assert.AreEqual(5, OneThousandDiscount, "$5 fail");
            Assert.AreEqual(180, TowHundredDiscount, "$200 fail");
            Assert.AreEqual(75, EightyDiscount, "$80 fail");
        }
    }
}
