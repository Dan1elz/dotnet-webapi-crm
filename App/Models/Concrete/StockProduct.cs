using dotnet_webapi_erp.App.Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet_webapi_erp.App.Models.Concrete
{
    public class StockProduct : BaseEntity
    {
        [Required]
        [ForeignKey("Company")]
        public Guid GuidCompany { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        public StockProduct(Guid guidCompany, string name, string description, int quantity, decimal price) : base() 
        {
            GuidCompany = guidCompany;
            Name = name;
            Description = description;
            Quantity = quantity;
            Price = price;
        }
        #pragma warning disable CS8618
        protected StockProduct() { }
    }
}
