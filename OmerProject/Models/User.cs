using System.ComponentModel.DataAnnotations;
namespace OmerProject.Models
{
    public class User

    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Username { get; set; }

        [Required]
        [StringLength(100)]
        public required string Password { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

    }

}

