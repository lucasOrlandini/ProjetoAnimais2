using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fatec.ProjetoAnimais.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }

        //[Required]
        //[DataType(DataType.Password)]
        //[Display(Name = "Senha")]
        //[StringLength(20, ErrorMessage = "É necessário informar pelo menos 8 caracteres para a Senha.", MinimumLength = 8)]
        //public string Senha { get; set; }
    }
}
