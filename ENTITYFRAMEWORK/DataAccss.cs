using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoKartModels;

namespace DemoKartEF
{
   public  class DemoKartDataAccess
    {
        public List<DemoKartModels.Product> GetProducts()
        {
           
                using (var ctx = new OnlineShoppingContext()) {
                var products = (from prod in ctx.Products where prod.CategoryID ==1 select prod).ToList();
                List<DemoKartModels.Product> lsproducts = new List<DemoKartModels.Product>();
                foreach (var item in products)
                {
                    var obj = new DemoKartModels.Product
                    {
                        ProdName = item.ProductName,
                        Unitprice = Convert.ToDouble(item.Price)
                    };
                    lsproducts.Add(obj);
                }
                return lsproducts;
            }
        }
        public int AddProducts(DemoKartModels.InsertValues iobj)
        {
            try
            {
                using (var ctx = new OnlineShoppingContext())
                {
                    Product prObj = new Product()
                    {
                        ProductName = iobj.ProdName,
                        Price = Convert.ToDecimal(iobj.price),
                        ProductID = "P1008",
                        CategoryID = 2,
                        ProductStatus = true
                    };
                    ctx.Products.Add(prObj);
                    ctx.SaveChanges();
                    return 1;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return 0;
            }
        }
        public int UpdateProduct(Product proObj)
        {
            return 1;
        }
     }
}
