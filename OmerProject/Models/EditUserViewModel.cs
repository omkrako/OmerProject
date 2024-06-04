using System.ComponentModel.DataAnnotations;

namespace OmerProject.Models
{
    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
