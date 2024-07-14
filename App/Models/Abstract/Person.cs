using System.ComponentModel.DataAnnotations;

namespace dotnet_webapi_erp.App.Models.Abstract
{
    public abstract class Person
    {
        [Key]
        public Guid Id { get; init; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        [MaxLength(25)]
        public string Lastname { get; set; }

        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(14)]
        public string CPF { get; init; }

        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        public DateTime Created { get; init; }
        public DateTime Updated { get; set; }

        #pragma warning disable CS8618
        protected Person() { }
        protected Person(string _name, string _lastname, string _email, string _CPF, string _phoneNumber)
        {
            Id = Guid.NewGuid();
            Name = _name;
            Lastname = _lastname;
            Email = _email;
            CPF = _CPF;
            PhoneNumber = _phoneNumber;
            Created = DateTime.UtcNow;
            Updated = DateTime.UtcNow;
        }
    }
}
