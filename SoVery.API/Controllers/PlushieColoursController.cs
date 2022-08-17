using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SoVery.API.Models;

namespace SoVery.API.Controllers
{
    [Route("api/plushies/{plushieId}/plushiecolours")]
    [ApiController]
    public class PlushieColoursController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<PlushieColourDto>> GetPlushieColours(int plushieId)
        {
            var plushie = PlushiesDataStore.Current.Plushies.FirstOrDefault(p => p.Id == plushieId);

            if (plushie == null)
            {
                return NotFound();
            }

            return Ok(plushie.Colours);

        }

        [HttpGet("{id}",Name="GetPlushieColour")]
        public ActionResult<PlushieColourDto> GetPlushieColour(int plushieId,int id)
        {
            var plushie = PlushiesDataStore.Current.Plushies.FirstOrDefault(p => p.Id == plushieId);

            if (plushie == null)
            {
                return NotFound();
            }

            var plushieColour = plushie.Colours.FirstOrDefault(c => c.Id == id);

            if (plushieColour == null)
            {
                return NotFound();
            }

            return Ok(plushieColour);

        }

        [HttpPost]
        public ActionResult<PlushieColourDto> CreatePlushieColour(int plushieId, [FromBody] PlushieColourForCreateDto plushieColour)
        {
           
            var plushie = PlushiesDataStore.Current.Plushies.FirstOrDefault(p => p.Id == plushieId);

            if(plushie == null)
            {
                return NotFound();
            }

            var maxPlushieColourId = PlushiesDataStore.Current.Plushies.SelectMany(p => p.Colours).Max(c => c.Id);

            var finalPlushieColour = new PlushieColourDto()
            {
                Id = ++maxPlushieColourId,
                Name = plushieColour.Name,
                ColourType = plushieColour.ColourType
            };

            plushie.Colours.Add(finalPlushieColour);

            return CreatedAtRoute("GetPlushieColour",
                new
                {
                    plushieId,
                    plushieColourId = finalPlushieColour.Id
                },
                finalPlushieColour);

            }

        
        [HttpPut("{plushiecolourid}")]
        public ActionResult UpdatePlushieColour(int plushieId, int plushieColourId,PlushieColourForUpdateDto plushieColour)
        {
            var plushie = PlushiesDataStore.Current.Plushies.FirstOrDefault(p => p.Id == plushieId);

            if (plushie==null)
            {
                return NotFound();
            }

            var colour = plushie.Colours.FirstOrDefault(c => c.Id == plushieColourId);

            if (colour==null)
            {
                return NotFound();
            }

            colour.Name = plushieColour.Name;
            colour.ColourType = plushieColour.ColourType;

            return NoContent();

        }

        [HttpPatch("{plushiecolourid}")]
        public ActionResult PartialUpdatePlushieColour(int plushieId, int plushieColourId, JsonPatchDocument<PlushieColourForUpdateDto> patchDocument)
        {
            var plushie = PlushiesDataStore.Current.Plushies.FirstOrDefault(p => p.Id == plushieId);

            if (plushie == null)
            {
                return NotFound();
            }

            var colour = plushie.Colours.FirstOrDefault(c => c.Id == plushieColourId);

            if (colour == null)
            {
                return NotFound();
            }

            var plushieColourToPatch = new PlushieColourForUpdateDto()
            {
                Name = colour.Name,
                ColourType = colour.ColourType
            };

            patchDocument.ApplyTo(plushieColourToPatch, ModelState);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(plushieColourToPatch))
            {
                return BadRequest(ModelState);
            }

            colour.Name = plushieColourToPatch.Name;
            colour.ColourType = plushieColourToPatch.ColourType;

            return NoContent();

        }

        [HttpDelete("{plushiecolourid}")]
        public ActionResult DeletePointOfInterest (int plushieId, int plushieColourId)
        {
            var plushie = PlushiesDataStore.Current.Plushies.FirstOrDefault(p => p.Id == plushieId);

            if (plushie == null)
            {
                return NotFound();
            }

            var colour = plushie.Colours.FirstOrDefault(c => c.Id == plushieColourId);

            if (colour == null)
            {
                return NotFound();
            }

            plushie.Colours.Remove(colour);

            return NoContent();


        }

    }       
}
