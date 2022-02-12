using System.ComponentModel.DataAnnotations;
namespace Conference.Data
{
    public class CityInfo
    {
        [Required]
        public int cityId { get; set; }

        public CityInfo()
        {
            cityId = 0;
        }

    }
}