namespace SoVery.API.Models
{
    public class PlushieDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public ICollection<PlushieColourDto> Colours { get; set; } = new List<PlushieColourDto>();
    }
}
