using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsStarter.Models;
using ProductsStarter.DTOs;
using ProductsStarter.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ProductsStarter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductsController(IProductService service)
        {
            _service = service;
        }

        // GET 
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        //GET BY ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            var product = _service.GetById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        // POST PRODUCT
        [HttpPost]
        public IActionResult Create(ProductCreateDTO dto)
        {
            var created = _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // UPDATE PUT METHOD

        [HttpPut("{id}")]
        public IActionResult Update(int id,ProductUpdateDTO dto) {
            var updated = _service.Update(id, dto);
            if(!updated) return BadRequest("update couldnt be possible");
            return NoContent(); 
        }

        //PATCH METHOD AS WE ARE GOING TO UPDATE THE QUANTITY ONLY
        [HttpPatch("{id}/quantity")]
        public IActionResult UpdateQuantity(int id, [FromBody] int quantity) { 
             var updated=_service.UpdateQuantiy(id, quantity);
            if (!updated) return BadRequest("update couldnt be possible");

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) { 
           var deleted= _service.Delete(id);
            if(!deleted) return NotFound();
            return Ok(deleted);

        }

    }
}
