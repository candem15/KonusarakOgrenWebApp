using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreBusiness.Entities;
using DataStore.SQL;

namespace UseCases
{
    public class ViewBrandsUseCase : IViewBrandsUseCase
    {
        private readonly IBrandRepo brandRepo;

        public ViewBrandsUseCase(IBrandRepo brandRepo)
        {
            this.brandRepo = brandRepo;
        }
        public IEnumerable<Brand> Execute()
        {
            return brandRepo.GetBrands();
        }
    }
}