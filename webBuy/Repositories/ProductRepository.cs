using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webBuy.Models;

namespace webBuy.Repositories
{
    public class ProductRepository:Repository<Product>
    {
        public List<Product> GetProducts(int shopId)
        {
            return this.context.Products.Where(e => e.shopId == shopId).Where(e => e.productStatus == 1).ToList();
        }
    }
}