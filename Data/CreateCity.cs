using System.ComponentModel.DataAnnotations;

namespace Conference.Data

{
    public class CreateCity
    {
        [Required]
        public string? Destination { get; set; }

    }
}
