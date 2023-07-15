using Website_banhang.Models;
using Website_banhang.Repository;

namespace Website_banhang.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _ProductRepository;
        public ProductService(IProductRepository productRepository)
        {
            _ProductRepository = productRepository;
        }

        public List<Product> GetAllProduct(int _skip, int _take)
        {
            var products = _ProductRepository.GetAllProduct(_skip, _take);
            return products;
        }

        public List<Product> GetProductBycategory(int? CategoryId)
        {
            var product = _ProductRepository.GetProductByCategory(CategoryId);
            return product;
        }
    }
}
