using System.ComponentModel.DataAnnotations;
namespace Conference.Data
{
    public class SearchInfo
    {
        [Required]
        public int from { get; set; }

        [Required]
        public int to { get; set; }

        [Required]
        public DateTime time { get; set; }

        public SearchInfo() 
        {
            (from, to, time) = (0,1, DateTime.MinValue);
        }

        
    }
}