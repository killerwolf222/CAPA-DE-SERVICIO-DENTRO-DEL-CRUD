using System;
using System.ComponentModel.DataAnnotations;

namespace MICRUDGABRIEL.Models
{
    public class Trainer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public required string FullName { get; set; }

        [EmailAddress(ErrorMessage = "Correo electrónico inválido")]
        public required string Email { get; set; }

        [Phone(ErrorMessage = "Número de teléfono inválido")]
        public required string PhoneNumber { get; set; }

        public DateTime HireDate { get; set; }
    }
}
