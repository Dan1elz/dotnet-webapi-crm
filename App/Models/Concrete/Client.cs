using dotnet_webapi_erp.App.Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet_webapi_erp.App.Models.Concrete
{
    public class Client : Person
    {
        [Required]
        [ForeignKey("Company")]
        public Guid GuidCompany { get; set; }

        [Required]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "O CEP deve ter exatamente 9 caracteres.")]
        public string CEP {  get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        public Client(Guid guidCompany, string cep, string address, string name, string lastname, string email, string cpf, string phoneNumber) : base(name, lastname, email, cpf, phoneNumber)
        {
            GuidCompany = guidCompany;
            CEP = cep;
            Address = address;
        }

        #pragma warning disable CS8618
        protected Client() { }
    }
}
