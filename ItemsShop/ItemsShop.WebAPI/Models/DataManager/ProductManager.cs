using ItemsShop.WebAPI.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemsShop.WebAPI.Models.DataManager
{
    public class ProductManager : IDataRepository<Product, long>
    {
        public ProductManager(ApplicationContext c)
        {
            ctx = c;
        }

        private ApplicationContext ctx;

        public async Task<long> Add(Product entity)
        {
            ctx.Products.Add(entity);
            long productId = await ctx.SaveChangesAsync();
            return productId;
        }

        public async Task<long> Delete(long id)
        {
            int productId = 0;
            Product product = ctx.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                ctx.Products.Remove(product);
                productId = await ctx.SaveChangesAsync();
            }
            return productId;
        }

        public Product Get(long id)
        {
            Product product = ctx.Products.FirstOrDefault(p => p.Id == id);
            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            List<Product> products = ctx.Products.ToList();
            return products;
        }

        public async Task<long> Update(long id, Product entity)
        {
            int productId = 0;
            Product product = ctx.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                product.Name = entity.Name;
                product.Description = entity.Description;
                product.Price = entity.Price;
                product.Image = entity.Image;
                productId = await ctx.SaveChangesAsync();
            }
            return productId;
        }
    }
}
