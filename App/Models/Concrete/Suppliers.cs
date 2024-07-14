using dotnet_webapi_erp.App.Models.Abstract;
using System.ComponentModel.DataAnnotations;

namespace dotnet_webapi_erp.App.Models.Concrete
{
    public class Suppliers : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "O CEP deve ter exatamente 9 caracteres.")]
        public string  CEP { get; set; }
        
        [Required]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O CNPJ deve ter exatamente 14 caracteres.")]
        
        public string CNPJ { get; set; }
        [Required]
        [StringLength(14, MinimumLength = 14, ErrorMessage ="O Telefone deve ter exatamente 14 caracteres.")]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        public Suppliers(string name, string address, string cep, string cnpj, string phoneNumber, string email) : base() 
        {
            Name = name;
            Address = address;
            CEP = cep;
            CNPJ = cnpj;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        #pragma warning disable CS8618
        protected Suppliers() { }
    }
}
