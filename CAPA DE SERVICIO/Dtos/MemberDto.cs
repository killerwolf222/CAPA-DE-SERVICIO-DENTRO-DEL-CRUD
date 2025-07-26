using System.ComponentModel.DataAnnotations;

namespace MICRUDGABRIEL.Dtos
{
    public class MemberDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Número inválido")]
        public string Phone { get; set; } = string.Empty;
    }
}

