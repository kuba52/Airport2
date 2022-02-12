using System.ComponentModel.DataAnnotations;
namespace Conference.Data

{
    public class CreateFlight
    {
        
        [Required]
        public DateTime startTime { get; set; }

        [Required]
        public DateTime arrivalTime { get; set; }

        [Required]
        public int? planeId { get; set; }

        [Required]
        public int destination { get; set; }

        public int start { get; set;}

    }
}
