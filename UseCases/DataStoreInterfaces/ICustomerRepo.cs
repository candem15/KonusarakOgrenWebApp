using CoreBusiness.Entities;

namespace DataStore.SQL
{
    public interface ICustomerRepo
    {
        public IEnumerable<Customer> GetCustomers();
    }
}