using System.ComponentModel.DataAnnotations;
namespace Conference.Data
{
    public class UserInfo
    {
        [Required]
        public int userId { get; set; }

        [StringLength(255)]
        [Required]
        public string? Name { get; set; }

        [StringLength(255)]
        [Required]
        public string? Surname { get; set; }

        [Required]
        public bool isStaff {get; set; }

        public UserInfo()
        {
            (userId, Name, Surname, isStaff) = (0, "", "", false);
        }
        
    }
}