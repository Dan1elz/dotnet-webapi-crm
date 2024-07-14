using dotnet_webapi_erp.App.Models.Abstract;
using System.ComponentModel.DataAnnotations;

namespace dotnet_webapi_erp.App.Models.Concrete
{
    public class User : Person
    {
        [Required]
        [MaxLength(32)]
        public string Password { get; set; }

        [Required]
        public DateOnly DataNascimento { get; set; }

        public User(string name, string lastname, string email, string cpf, string phoneNumber, string password, DateOnly dataNascimento) : base(name, lastname, email, cpf, phoneNumber)
        {
            Password = password;
            DataNascimento = dataNascimento;
        }

        #pragma warning disable CS8618
        protected User() { }
    }
}
