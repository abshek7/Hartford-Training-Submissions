using ProductsStarter.DTOs;
using ProductsStarter.Models;

namespace ProductsStarter.Services
{
    public interface IProductService
    { 
        List<ProductResponseDTO> GetAll();
        ProductResponseDTO? GetById(int id);
        ProductResponseDTO Create(ProductCreateDTO dto);
        bool Update(int id,ProductUpdateDTO dto);
        bool UpdateQuantiy(int id, int quantity);
        bool Delete(int id);



    }
}
