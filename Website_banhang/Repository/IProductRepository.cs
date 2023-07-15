using Website_banhang.Models;

namespace Website_banhang.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAllProduct(int _skip, int _take);
        Product GetProductById(int id);
        List<Product> GetProductByCategory(int? CategoryId);

        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);

    }
}
