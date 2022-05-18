using CoreBusiness.Entities;

namespace DataStore.SQL
{
    public interface IBrandRepo
    {
        public IEnumerable<Brand> GetBrands();
    }
}