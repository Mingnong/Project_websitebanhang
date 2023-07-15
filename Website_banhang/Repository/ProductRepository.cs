using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Collections.Generic;
using Website_banhang.Models;

namespace Website_banhang.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly QlbhContext _context;

        public ProductRepository(QlbhContext context)
        {
            _context = context;
        }
        // GetAllProduct
        public List<Product> GetAllProduct(int _skip, int _take)
        {
            return _context.Products.Where(p => p.IsActive == true).Skip(_skip).Take(_take).ToList();
        }
        // GetProductyId
        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(x => x.ProductId == id);    
        }
        // GetProductByCategory

        public List<Product> GetProductByCategory(int? CategoryId)
        {
           return _context.Products.Where(x => x.CategoryId == CategoryId).ToList();
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = GetProductById(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
