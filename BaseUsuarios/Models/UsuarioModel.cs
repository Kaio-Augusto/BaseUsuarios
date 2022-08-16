using BaseUsuarios.Enums;
using BaseUsuarios.Helper;
using System;
using System.ComponentModel.DataAnnotations;

namespace BaseUsuarios.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuário.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o email do usuário.")]
        [EmailAddress(ErrorMessage = "O email informado não é válido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o senha do usuário.")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Digite o login do usuário.")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o número de telefone do usúario.")]
        [Phone(ErrorMessage = "O número informado não é válido!")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "Digite o CPF do usuário.")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "Digite o nome da mãe do usuário.")]
        public string NomeDaMae { get; set; }
        [Required(ErrorMessage = "Insira seu perfil.")]
        public DateTime DataDeCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
        [Required(ErrorMessage = "Insira sua data de nascimento.")]        
        public string DataDeNascimento { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }
        
        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }

        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            Senha = novaSenha.GerarHash();
            return novaSenha;
        }
    }
}
