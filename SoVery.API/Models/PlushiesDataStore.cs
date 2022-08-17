using Microsoft.AspNetCore.Mvc;

namespace SoVery.API.Models
{
    public class PlushiesDataStore
    {

        public PlushiesDataStore()
        {
            Plushies = new List<PlushieDto>()
            {
                new PlushieDto()
                {
                    Id = 1,
                    Name = "Oceana",
                    Colours = new List <PlushieColourDto>()
                    {
                        new PlushieColourDto()
                        {
                            Id = 1,
                            Name = "Purple",
                            ColourType = ColourType.Primary
                        },
                        new PlushieColourDto()
                        {
                            Id = 2,
                            Name = "White",
                            ColourType = ColourType.Accent
                        }
                    }
                },

                new PlushieDto()
                {
                        Id = 2,
                        Name = "Calli",
                        Colours = new List<PlushieColourDto>()
                        {
                            new PlushieColourDto()
                            {
                                Id = 1,
                                Name = "White",
                                ColourType = ColourType.Primary
                            },
                            new PlushieColourDto()
                            {
                                Id = 2,
                                Name = "Pink",
                                ColourType = ColourType.Accent
                            }
                        }
                }
            };
        }

        public List<PlushieDto> Plushies { get; set; }

        public static PlushiesDataStore Current { get; } = new PlushiesDataStore();

    }
}


