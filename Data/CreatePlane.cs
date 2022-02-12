using System.ComponentModel.DataAnnotations;
namespace Conference.Data
{
    public class CreatePlane
    {
        [Required]
        public string? Company { set; get; }

        [Required]
        public int Capacity {set; get;}
    }
}

