using System.ComponentModel.DataAnnotations;

namespace senai_eventPlus_webApi_codeFirst_jwt.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Informe o e-mail do usuário!")]
        public string email { get; set; }


        [Required(ErrorMessage = "Informe a senha do usuário!")]
        public string senha { get; set; }
    }
}
