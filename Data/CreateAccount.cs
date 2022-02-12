using System.ComponentModel.DataAnnotations;

namespace Conference.Data{

public class CreateAccount{
    [Required]
    public string? Name {get; set;}

    [Required]
    public string? Surname {get; set;}

    [Required]
    public bool isStaff {get; set;}
    }
}
