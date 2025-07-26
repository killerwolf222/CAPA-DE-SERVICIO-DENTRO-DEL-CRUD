using System.ComponentModel.DataAnnotations;

namespace MICRUDGABRIEL.Dtos
{
    public class TrainerDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}


