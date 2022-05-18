using CoreBusiness.Entities;

namespace DataStore.SQL
{
    public interface ICategoryRepo
    {
        public IEnumerable<Category> GetCategories();
    }
}