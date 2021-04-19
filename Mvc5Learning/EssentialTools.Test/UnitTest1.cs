using System;
using EssentialTools.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EssentialTools.Test
{
    [TestClass]
    public class UnitTest1
    {
        private IDiscountHelper getTestObject()
        {
            return new MinimumDiscountHelper();
        }

        [TestMethod]
        public void Discount_Above_100()
        {
            IDiscountHelper target = getTestObject();
            decimal total = 200;
            var discountedTotal = target.ApplyDiscount(total);
            Assert.AreEqual(total * 0.9m, discountedTotal);
        }
    }
}
