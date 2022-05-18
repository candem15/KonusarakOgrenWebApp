using CoreBusiness.Entities;

namespace UseCases
{
    public interface IViewBrandsUseCase
    {
        public IEnumerable<Brand> Execute();
    }
}