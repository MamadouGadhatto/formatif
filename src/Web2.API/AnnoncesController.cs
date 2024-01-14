using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web2.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnoncesController : ControllerBase
    {
        // GET: api/<AnnoncesController>
        [HttpGet]
        public ActionResult<List<Annonce>> Get()
        {
            var annonces = Repository.GetAnnonces();
            return Ok(annonces);
        }

        // GET api/<AnnoncesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AnnoncesController>
        [HttpPost]
        public ActionResult Create([FromBody] Annonce annonce)
        {
            Repository.CreateAnnonce(annonce);
            return CreatedAtAction(nameof(Get), new { id = annonce.Id }, annonce);
        }

        // PUT api/<AnnoncesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AnnoncesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
