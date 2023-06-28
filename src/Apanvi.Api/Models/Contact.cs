namespace Apanvi.Api.Models
{
    public class Contact : Person
    {
        public new Person? Name { get; set; }
        public int Phone { get; set; }
        public string? Email { get; set; }

    }
}
