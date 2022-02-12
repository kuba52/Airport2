using System.ComponentModel.DataAnnotations;
namespace Conference.Data
{
    public class CreateSearch
    {
    
        [Required]
        public int destination { get; set; }

        [Required]
        public int from { get; set;}

    }
}
