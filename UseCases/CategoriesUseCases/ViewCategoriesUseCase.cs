using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreBusiness.Entities;
using DataStore.SQL;

namespace UseCases
{
    public class ViewCategoriesUseCase : IViewCategoriesUseCase
    {
        private readonly ICategoryRepo _repository;

        public ViewCategoriesUseCase(ICategoryRepo repository)
        {
            _repository = repository;
        }
        public IEnumerable<Category> Execute()
        {
            return _repository.GetCategories();
        }
    }
}