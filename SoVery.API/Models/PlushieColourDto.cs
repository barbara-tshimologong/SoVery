namespace SoVery.API.Models
{
    public class PlushieColourDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public ColourType ColourType { get; set; } = ColourType.Primary;

    }
}
