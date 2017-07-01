using Datastore.Abstractions;
using System.Threading.Tasks;
using System.Web.Http;
using apox.owin.webapi.selfhost.ErrorHandling;
using Apox.Models;

namespace apox.owing.webapi.selfhost.Controllers
{

    [RoutePrefix("api")]
    [ApiExceptionFilter]
    public class ProductsController : ApiController
    {

        private readonly IProductsRepository _repo;
        public ProductsController(IProductsRepository productsRepository)
        {
            _repo = productsRepository;
        }

        // GET api/products
        [Route("products")]
        public async Task<IHttpActionResult> GetProducts()
        {
            var products = await _repo.GetProducts();
            return Ok(products);
        }

        // GET api/products/5
        [Route("products/{Id}")]
        public async Task<IHttpActionResult> GetProduct(int Id)
        {
            var product = await _repo.GetProduct(Id);
            return Ok(product);
        }

        // POST api/products
        [Route("products")]
        [HttpPost]
        public async Task<IHttpActionResult> AddProduct([FromBody] Product product)
        {
            var Id= await _repo.AddProduct(product);
            return Ok(Id);
        }

        // PUT api/products/5
        [Route("products/{Id}")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateProduct(int Id, [FromBody] Product product)
        {
            await _repo.UpdateProduct(Id, product);
            return Ok();
        }

        // DELETE api/products/5
        [Route("products/{Id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteProduct(int Id)
        {
            await _repo.DeleteProduct(Id);
            return Ok();
        }


    }

}
