using Microsoft.AspNetCore.Mvc;


public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class ProductsController : ControllerBase
{
    static List<Product> products = new List<Product>()
    {
        new Product {Id = 1, Name = "Iphone 12"},
        new Product {Id = 2, Name = "Iphone 15"},
        new Product {Id = 3, Name = "Iphone 14"}
    };
    /// <summary>
    /// Obtenir la liste des produits enregistrés.
    /// </summary>
    /// <returns>The list of registered products.</returns>
    /// <response code="200">Returns the list of registered products</response>
    [HttpGet]
    public ActionResult<IEnumerable<Product>> Get()
    {
        return Ok(products); // 'products' est supposé être une liste d'objets Product
    }

    /// <summary>
    /// Obtenir les détails d'un produit à partir de son ID.
    /// </summary>
    /// <param name="id">ID du produit à récupérer.</param>
    /// <returns>Les détails du produit spécifié.</returns>
    /// <response code="200">Retourne les détails du produit.</response>
    /// <response code="404">Si le produit avec l'ID spécifié n'est pas trouvé.</response>
    [HttpGet("{id}")]
    public ActionResult<Product> GetById(int id)
    {
        var product = products.Find(x => x.Id == id);
        return product == null ? NotFound() : Ok(product);
    }



    /// <summary>
    /// supprime un produit a partir de son Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
  
    public IActionResult Delete(long id)
    {
        var product = products.Find(x => x.Id == id);
        if (product == null)
        {
            return NotFound("Produit non trouvé avec l'ID fourni.");
        }

        // Ajoutez ici la logique pour supprimer le produit de votre liste ou de votre base de données

        return Ok("Produit supprimé avec succès.");
    }


    /// <summary>
    /// Permet d'ajouter un produit.
    /// </summary>
    /// <param name="item"></param>
    /// <returns>A newly created TodoItem</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Todo
    ///     {
    ///        "id": 1,
    ///        "name": "Item #1",
    ///        "isComplete": true
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
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

