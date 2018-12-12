using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItemsShop.WebAPI.Models;
using ItemsShop.WebAPI.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ItemsShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductController(IDataRepository<Product, long> repo)
        {
            _repository = repo;
        }

        private IDataRepository<Product, long> _repository;

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        // GET: api/Product
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _repository.GetAll(); ;
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public Product Get(int id)
        {
            return _repository.Get(id);
        }

        // POST: api/Product
        [HttpPost]
        public void Post([FromBody] Product value)
        {
            _repository.Add(value);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product value)
        {
            _repository.Update(id, value);
        }
    }
}
