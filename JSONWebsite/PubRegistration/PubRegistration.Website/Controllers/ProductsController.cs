using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PubRegistration.Website.Models;
using PubRegistration.Website.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PubRegistration.Website.Controllers
{
 //   [Route("api/[controller]")]
    [Route("[controller]")]
    [ApiController]
    //   public class ProductsController : Controller
    public class ProductsController : ControllerBase
    {


        public ProductsController(JsonFileProductService productService)
        {
            this.ProductService = productService;
        }

        public JsonFileProductService ProductService { get; }


        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        }



/// <summary>
/// ////////////////////////////////////////////////////////
/// </summary>
/// <returns></returns>

        // GET: api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
