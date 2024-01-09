using Microsoft.AspNetCore.Mvc;


public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
}

[Route("api/[controller]")]
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

}

