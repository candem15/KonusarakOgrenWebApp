using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreBusiness.Entities;
using DataStore.SQL;

namespace UseCases
{
    public class ViewProductsUseCase : IViewProductsUseCase
    {
        private readonly IProductRepo productRepo;

        public ViewProductsUseCase(IProductRepo productRepo)
        {
            this.productRepo = productRepo;
        }
        public IEnumerable<Product> Execute()
        {
            return productRepo.GetProducts();
        }
    }

}