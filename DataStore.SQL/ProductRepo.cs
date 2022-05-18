using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreBusiness.Entities;

namespace DataStore.SQL
{
    public class ProductRepo : IProductRepo
    {
        private readonly AppDbContext dbContext;

        public ProductRepo(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<Product> GetProducts()
        {
            return dbContext.Products.ToList();
        }
    }
}