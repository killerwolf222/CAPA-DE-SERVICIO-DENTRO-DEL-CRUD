using System;
using System.ComponentModel.DataAnnotations;

namespace MICRUDGABRIEL.Models
{
    public class Member
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public required string Name { get; set; }

        [Phone(ErrorMessage = "Número inválido")]
        public string? Phone { get; set; }

        public DateTime RegistrationDate { get; set; }
    }
}
