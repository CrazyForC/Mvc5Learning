using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public class FlexibleDiscountHelper : IDiscountHelper
    {
        public decimal ApplyDiscount(decimal totalParam)
        {
            decimal tmp = totalParam > 100 ? 70m : 25m;
            return (totalParam - (tmp / 100m * totalParam));
        }
    }
}