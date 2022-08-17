using System.ComponentModel.DataAnnotations;

namespace SoVery.API.Models
{
    public class PlushieColourForUpdateDto
    {
        [Required(ErrorMessage = "The Plushie Colour requires a name.")]
        public string Name { get; set; } = string.Empty;

        [EnumDataType(typeof(ColourType))]
        public ColourType ColourType { get; set; } = ColourType.Primary;
    }
}
