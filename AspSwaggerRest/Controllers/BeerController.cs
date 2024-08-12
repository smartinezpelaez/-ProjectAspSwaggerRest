using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspSwaggerRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        List<Beer> beers = new List<Beer>() 
        {
            new Beer(){ Id= 1, Name = "Corona"},
            new Beer(){ Id= 2, Name = "Delirium"},
            new Beer(){ Id= 3, Name = "Erdinger"},
        };

        [HttpGet]
        public ActionResult<Beer> Get(int id)
        { 
            var beer = beers.Where(d=> d.Id == id).FirstOrDefault();
            if (beer == null) return NotFound();

            return beer;

        }
    }

    public class Beer 
    {
        public int Id { get; set; } 
        public string Name { get; set; }
    }
}
