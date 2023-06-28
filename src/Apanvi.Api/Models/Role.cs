namespace Apanvi.Api.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
    }
}
