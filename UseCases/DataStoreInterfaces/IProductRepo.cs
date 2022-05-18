using CoreBusiness.Entities;

namespace DataStore.SQL
{
    public interface IProductRepo
    {
        public IEnumerable<Product> GetProducts();
    }
}