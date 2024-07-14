using dotnet_webapi_erp.App.Models.Abstract;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace dotnet_webapi_erp.App.Models.Concrete
{
    public class Order : BaseEntity
    {
        [Required]
        [ForeignKey("Company")]
        public Guid GuidCompany { get; set; }

        [Required]
        [ForeignKey("StockProduct")]
        public Guid GuidProduct { get; set; }

        [Required]
        [ForeignKey("Client")]
        public Guid GuidClient { get; set; }

        [Required]
        public int OrderNumber { get; set; }


        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(50)]
        public string Status { get; set; }

        public Order(Guid guidCompany, Guid guidProduct, Guid guidClient, int orderNumber, decimal price, string status) : base() 
        {
            GuidCompany = guidCompany;
            GuidProduct = guidProduct;
            GuidClient = guidClient;
            OrderNumber = orderNumber;
            Price = price;
            Status = status;
        }

        #pragma warning disable CS8618
        protected Order() { }
    }
}
