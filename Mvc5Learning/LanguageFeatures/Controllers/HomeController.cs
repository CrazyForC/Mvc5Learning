using LanguageFeatures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "Navigate to a URL to show an example";
        }

        public ViewResult AutoProperty()
        {
            Product myProduct = new Product();
            myProduct.Name = "HelloWorld";
            string productName = myProduct.Name;
            return View("Result", (object)string.Format("The product's name is {0}", productName));
        }

        public ViewResult CreateProduct()
        {
            Product myProdect = new Product()
            {
                ProdectId = 10010,
                Name = "HEY",
                Description = "HEY HEY CHECK IT NOW!",
                Catefory = "BM-350",
                Price = 1780,
            };

            return View("Result", (object)string.Format("The product's catefory is {0}.", myProdect.Catefory));
        }

        public ViewResult UseExtension()
        {
            ShoppingCart cart = new ShoppingCart();
            cart.Products = new List<Product>()
            {
                new Product(){ ProdectId=1201, Name="AA", Price = 120},
                new Product(){ ProdectId=1201, Name="BB", Price = 150},
                new Product(){ ProdectId=1201, Name="CC", Price = 121},
                new Product(){ ProdectId=1201, Name="DD", Price = 180},
            };
            decimal totalValue = cart.TotalPrices();
            return View("Result", (object)string.Format("The tatal value of ShoppingCart is {0}.", totalValue));
        }

        public ViewResult UseExtensionEnumerable()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product(){ ProdectId=1201, Name="AA", Price = 120},
                    new Product(){ ProdectId=1201, Name="BB", Price = 150},
                    new Product(){ ProdectId=1201, Name="CC", Price = 121},
                    new Product(){ ProdectId=1201, Name="DD", Price = 180},
                }
            };
            Product[] productArray = {
                new Product(){ ProdectId=1201, Name="AA", Price = 120},
                new Product(){ ProdectId=1201, Name="BB", Price = 150},
                new Product(){ ProdectId=1201, Name="CC", Price = 121},
                new Product(){ ProdectId=1201, Name="DD", Price = 180},
            };
            decimal carTotal = products.TotalPrices();
            decimal arrayTotal = productArray.TotalPrices();
            return View("Result", (object)string.Format("CarTotal: {0}--ArrayTotal: {1}", carTotal, arrayTotal));
        }

        public ViewResult UseFilterExtensionMethod()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product(){ ProdectId=1201, Name="AA", Price = 120, Catefory = "Hello" },
                    new Product(){ ProdectId=1201, Name="BB", Price = 150, Catefory = "World"},
                    new Product(){ ProdectId=1201, Name="CC", Price = 121, Catefory = "Hello"},
                    new Product(){ ProdectId=1201, Name="DD", Price = 180, Catefory = "World"},
                }
            };
            decimal total = 0;
            foreach (Product prod in products.FilterByCategory("World"))
            {
                total += prod.Price;
            }
            return View("Result", (object)string.Format("Catefory World Total -- {0}", total));
        }

        public ViewResult UseFilterExtensionMetnod()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product(){ ProdectId=1201, Name="AA", Price = 120, Catefory = "Hello" },
                    new Product(){ ProdectId=1201, Name="BB", Price = 150, Catefory = "World"},
                    new Product(){ ProdectId=1201, Name="CC", Price = 121, Catefory = "Hello"},
                    new Product(){ ProdectId=1201, Name="DD", Price = 180, Catefory = "World"},
                }
            };
            /// 用lambda表达式就可以不声明过滤器了
            Func<Product, bool> filter = delegate (Product prod)
            {
                return prod.Catefory == "Hello";
            };
            /// 当然这种方式书写也可以
            Func<Product, bool> filter1 = prod => prod.Catefory == "World";
            decimal total = 0;
            /// 感觉直接用的方式最方便
            foreach (Product prod in products.Filter(o => o.Catefory == "Hello" || o.Price > 100))
            {
                total += prod.Price;
            }
            return View("Result", (object)string.Format("Catefory Hello Total -- {0}", total));
        }

        public ViewResult UseAnonymousTypes()
        {
            var anonymousType = new { Name = "Kaka", Age = 23, Addr = "Guangzhou" };
            return View("Result", (object)string.Format("AnonymousType.Name -- {0}", anonymousType.Name));
        }

        public ViewResult UseAnonymousTypesArray()
        {
            var anonArray = new[] {
                new { Name="aa" },
                new { Name="bb" },
                new { Name="cc" }
            };
            StringBuilder sb = new StringBuilder();
            foreach (var item in anonArray)
            {
                sb.Append(item.Name);
                sb.Append("-");
            }
            sb.Remove(sb.Length - 1, 1);
            return View("Result", (object)string.Format("anonArray.Names -- {0}", sb.ToString()));
        }

        public ViewResult UseLinq()
        {
            Product[] productArray = {
                new Product(){ ProdectId=1201, Name="AA", Price = 120, Catefory = "Hello" },
                new Product(){ ProdectId=1201, Name="BB", Price = 150, Catefory = "World" },
                new Product(){ ProdectId=1201, Name="CC", Price = 121, Catefory = "Hello" },
                new Product(){ ProdectId=1201, Name="DD", Price = 180, Catefory = "Fly" },
            };
            //Array.Sort(productArray, )
            var prodects = productArray.OrderByDescending(o => o.Price)
                           .Take(3)
                           .Select(o => new { o.Name, o.Price });
            decimal sum = 0;
            foreach (var item in prodects)
            {
                sum += item.Price;
            }
            return View("Result", (object)string.Format("Total Price of top 3 -- {0}", sum));
        }
    }
}