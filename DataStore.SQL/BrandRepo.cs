using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreBusiness.Entities;

namespace DataStore.SQL
{
    public class BrandRepo:IBrandRepo
    {
        private readonly AppDbContext _context;

        public BrandRepo(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Brand> GetBrands()
        {
            return _context.Brands.ToList();
        }
    }
}