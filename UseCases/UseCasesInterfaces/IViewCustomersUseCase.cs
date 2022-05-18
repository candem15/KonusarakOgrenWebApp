using CoreBusiness.Entities;

namespace UseCases
{
    public interface IViewCustomersUseCase
    {
        IEnumerable<Customer> Execute();
    }
}