using System.ComponentModel.DataAnnotations;

namespace AzureAPI.Application.ViewModel
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage ="O nome não pode ser nulo ou vazio")]
        [MinLength(3, ErrorMessage ="O nome deve ter pelo menos 3 caracteres")]
        [MaxLength(80, ErrorMessage ="O nome deve ter no máximo 80 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O email não pode ser nulo ou vazio")]
        [MinLength(3, ErrorMessage = "O email deve ter pelo menos 3 caracteres")]
        [MaxLength(80, ErrorMessage = "O email deve ter no máximo 80 caracteres")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage ="O email não é válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha não pode ser nulo ou vazio")]
        [MinLength(3, ErrorMessage = "A senha deve ter pelo menos 3 caracteres")]
        [MaxLength(80, ErrorMessage = "A senha deve ter no máximo 80 caracteres")]
        public string Password { get; set; }
    }
}
