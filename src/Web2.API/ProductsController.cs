using Microsoft.AspNetCore.Mvc;


public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

[Route("api/[controller]")]
[Produces("application/json")]
[ApiController]
public class ProductsController : ControllerBase
{
    static List<Product> products = new List<Product>()
    {
        new Product {Id = 1, Name = "Iphone 12"},
        new Product {Id = 2, Name = "Iphone 15"},
        new Product {Id = 3, Name = "Iphone 14"}
    };

    [HttpGet]
    public ActionResult<IEnumerable<Product>> Get()
    {
        return Ok(products);
    }

    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Product>> GetById(int id)
    {
         var product = products.Find(x => x.Id == id);
        return product == null? NotFound() :Ok(products);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
       var product = products.Find(x => x.Id==id);
        if(product == null)
        {
            return NotFound();
        }

        return NotFound();
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Post([FromBody] Product product)
    {
        var newProduct = new Product
        {
            Id = products.Select(x => x.Id).Max() +1,
            Name = product.Name,
            Description = product.Description
        };


        return NoContent();
    }
}

