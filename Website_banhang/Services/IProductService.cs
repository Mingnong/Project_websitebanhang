using Website_banhang.Models;

namespace Website_banhang.Services
{
    public interface IProductService
    {
        public List<Product> GetAllProduct(int _skip, int _take);
        public List<Product> GetProductBycategory(int? CategoryId);
    }
}
