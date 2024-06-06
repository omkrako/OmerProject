using System.ComponentModel.DataAnnotations;

namespace OmerProject.Models
{
    public class EditUserViewModel
    {
        public required string Id { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }
    }
}
