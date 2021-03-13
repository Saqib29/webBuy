using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webBuy.Models;

namespace webBuy.Repositories
{
    public class ShopRepository : Repository<Shop>
    {
        public Shop GetShop(string email)
        {
            return this.context.Shops.Where(e => e.email == email).FirstOrDefault();
        }
    }
}