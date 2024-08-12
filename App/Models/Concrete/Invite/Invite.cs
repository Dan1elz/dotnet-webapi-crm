using dotnet_webapi_erp.App.Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace dotnet_webapi_erp.App.Models.Concrete.Invite
{
    public class Invite : BaseEntity
    {
        [Required]
        [ForeignKey("User")]
        public Guid User { get; init; }

        [Required]
        [ForeignKey("Company")]
        public Guid Company { get; init; }

        [Required]
        public string Value { get; init; }

        [Required]
        [MaxLength(50)]
        public string Office { get; set; }

        [Required]
        public DateTime Expiration { get; init; }

        public Invite(Guid user, Guid company, string value, DateTime expiration) : base() 
        {
            this.User = user;
            this.Company = company;
            this.Value = value;
            this.Expiration = expiration;
        }
    }
}
