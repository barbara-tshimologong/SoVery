using Microsoft.AspNetCore.Mvc;
using SoVery.API.Models;

namespace SoVery.API.Controllers
{
    [ApiController]
    [Route("api/plushies")]
    public class PlushiesController : ControllerBase
    {

        public PlushiesController()
        {
            int test = 1;
        }

        [HttpGet]
        public  ActionResult<IEnumerable<PlushieDto>> GetPlushies()
        {

            return Ok(PlushiesDataStore.Current);
        }

        [HttpGet("{id}")]
        public ActionResult<PlushieDto> GetPlushie(int id)
        {
            var plushie = PlushiesDataStore.Current.Plushies.FirstOrDefault(p => p.Id == id);

            if (plushie == null)
            {

                return NotFound();
                
            }

            return Ok(plushie);
        }
    }
}
