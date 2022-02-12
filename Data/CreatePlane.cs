using System.ComponentModel.DataAnnotations;
namespace Conference.Data
{
    public class CreatePlane
    {
        [StringLength(255)]
        [Required]
        public string? Model {get; set; }
        [StringLength(255)]
        [Required]
        public string? Company { set; get; }

        [Required]
        public int Capacity {set; get;}
    }
}

