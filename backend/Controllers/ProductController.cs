using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase{
        private IMemoryCache cache;
        public ProductsController(IMemoryCache cache){
            this.cache = cache;
        }
        public class Product{
            [Required]
            public string name;
            public string description;
            public int quantity;
            public decimal price;
        }
        // GET api/value
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            List<Product> cacheEntry;
            if (!cache.TryGetValue("products", out cacheEntry)){
                cacheEntry = new List<Product>();
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromDays(10));
                cache.Set("products", cacheEntry, cacheOptions);
            }
            return cacheEntry;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product value)
        {
            List<Product> cacheEntry;
            if (!cache.TryGetValue("products", out cacheEntry)){
                cacheEntry = new List<Product>();
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromDays(10));
                cache.Set("products", cacheEntry, cacheOptions);
            }
            if(cacheEntry.Any(x => x.name == value.name)){
                var error = new {error="Duplicate product names prohibited"};
                return BadRequest(error);
            }
            cacheEntry.Add(value);
            return value;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

}