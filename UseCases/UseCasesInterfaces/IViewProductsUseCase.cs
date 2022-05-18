using CoreBusiness.Entities;

namespace UseCases
{
    public interface IViewProductsUseCase
    {
        IEnumerable<Product> Execute();
    }
}