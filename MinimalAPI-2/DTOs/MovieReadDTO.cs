using System.ComponentModel.DataAnnotations;

namespace MinimalAPI_2.DTOs
{
    public class MovieReadDTO
    {
        //public int Id { get; set; }

        public string Title { get; set; }

        public string? Synopsis { get; set; }

        public int? Year { get; set; }
    }
}
