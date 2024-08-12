using dotnet_webapi_erp.App.Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet_webapi_erp.App.Models.Concrete.Company
{
    public class Company : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        [ForeignKey("User")]
        public Guid Owner { get; init; }

        [Required]
        public int NumberEmployees { get; set; }

        [Required]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O CNPJ deve ter exatamente 14 caracteres.")]
        public string CNPJ { get; init; }

        public Company(string name, string description, Guid owner, int numberEmployees, string cnpj) : base()
        {
            Name = name;
            Description = description;
            Owner = owner;
            NumberEmployees = numberEmployees;
            CNPJ = cnpj;
        }
        public void Update(Company company)
        {
            Name = company.Name;
            Description = company.Description;
            NumberEmployees = company.NumberEmployees;
        }

#pragma warning disable CS8618
        protected Company() { }
    }
}
