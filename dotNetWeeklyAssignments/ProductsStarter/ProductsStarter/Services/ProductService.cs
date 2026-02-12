using ProductsStarter.DTOs;
using ProductsStarter.Models;
using System.Xml.Linq;
namespace ProductsStarter.Services
{
    public class ProductService : IProductService
    {
        private static List<ProductsModel> products = new(){
            new ProductsModel { Id=1,Name="Smart-Tv-Porto",Price=65700m,Category="Electronics",Description="This is 28 inches tv"},
             new ProductsModel { Id = 2, Name = "OPPO K13", Price = 18700m, Category = "Electronics", Description = "This mobile of oppo has 6000mah battery" },
              new ProductsModel { Id = 3, Name = "Bucket", Price = 400m, Category = "Homeware", Description = "This is heat resistant color:blue" }
            };
        public List<ProductResponseDTO> GetAll()
        {
            return products.Select(product => new ProductResponseDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Category = product.Category,
                CartQuantity = product.CartQuantity,
                Description = product.Description,
                IsAvailable = product.isAvailable

            }).ToList();
        }


        public ProductResponseDTO? GetById(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return null;
            return new ProductResponseDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Category = product.Category,
                CartQuantity = product.CartQuantity,
                Description = product.Description,
                IsAvailable = product.isAvailable

            };

        }

        public ProductResponseDTO Create(ProductCreateDTO dto)
        {
            var product = new ProductsModel
            {
                Id = products.Any() ? products.Max(p => p.Id) + 1 : 1,
                Name = dto.Name,
                Price = dto.Price,
                Category = dto.Category,
                CartQuantity = dto.CartQuantity,
                Description = dto.Description
            };
            products.Add(product);

            return new ProductResponseDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Category = product.Category,
                CartQuantity = product.CartQuantity,
                Description = product.Description
            };
        }

        public bool Update(int id, ProductUpdateDTO dto)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return false;

            product.Name = dto.Name;
            product.Price = dto.Price;
            product.Category = dto.Category;
            product.CartQuantity = dto.CartQuantity;
            product.Description = dto.Description;
            return true;
        }

        public bool UpdateQuantiy(int id, int quantity)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null || quantity < 0) return false;
            product.CartQuantity = quantity;
            return true;

        }

        public bool Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return false;
            products.Remove(product);
            return true;
        }

    }

    }
