using dotnet_webapi_erp.App.Models.Abstract;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace dotnet_webapi_erp.App.Models.Concrete
{
    public class Sale : BaseEntity
    {
        [Required]
        [ForeignKey("Client")]
        public Guid GuidClient { get; set; }

        [Required]
        [ForeignKey("User")]
        public Guid GuidEmployee { get; set; }

        [Required]
        public int OrderNumber { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(50)]
        public string Method { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Status { get; set; }

        public Sale(Guid guidClient, Guid guidEmployee, int orderNumber, decimal price, string method, string status) : base() 
        { 
            GuidClient = guidClient;
            GuidEmployee = guidEmployee;
            OrderNumber = orderNumber;
            Price = price;
            Method = method;
            Status = status;
        }
        #pragma warning disable CS8618
        protected Sale() { }
    }
}
