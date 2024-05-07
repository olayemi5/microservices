namespace Catalog.Api.Models
{
    public class ProblemDetails
    {
        public string Title { get; set; } = default!;
        public int Status { get; set; } 
        public string Detail { get; set; } = default!;
    }
}
