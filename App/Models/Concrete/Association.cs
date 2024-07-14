using dotnet_webapi_erp.App.Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet_webapi_erp.App.Models.Concrete
{
    public class Association : BaseEntity
    {
        [Required]
        [ForeignKey("User")] 
        public Guid User {  get; set; }

        [Required]
        [ForeignKey("Company")]
        public Guid Company { get; set; }
        [Required]
        [MaxLength(50)]
        public string Office { get; set; }

        public Association(Guid user, Guid company, string office) : base() 
        {
            User = user;
            Company = company;
            Office = office;
        }

        #pragma warning disable CS8618
        protected Association() { }
    }
}
