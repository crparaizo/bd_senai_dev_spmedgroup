using System.ComponentModel.DataAnnotations;

namespace Senai.SpMedGroup.WebApi.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o email!!! :(")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "O email deve ter entre 5 e 50 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha!!! :(")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "A senha deve ter entre 5 e 100 caracteres")]
        public string Senha { get; set; }
    }
}