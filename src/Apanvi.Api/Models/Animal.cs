namespace Apanvi.Api.Models
{
    public class Animal
    {
        public string Name { get; set; } = string.Empty;

        public Species Species { get; set; }

        public Genres Genre { get; set; }

        public Sizes Size { get; set; }

        public string? Description { get; set; }

        public Uri? Image { get; set; } 

    }
}
