using dotnet_webapi_erp.App.Models.Abstract;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace dotnet_webapi_erp.App.Models.Concrete
{
    public class StockMovement : BaseEntity
    {
        [Required]
        [ForeignKey("StockProduct")]
        public Guid GuidProduct { get; set; }

        [Required]
        [MaxLength(50)]
        public string TypeMovement { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal CurrentPrice { get; set; }


        public StockMovement(Guid guidProduct, string typeMovement, decimal currentPrice) : base() 
        {
            GuidProduct = guidProduct;
            TypeMovement = typeMovement;
            CurrentPrice = currentPrice;
        }

        #pragma warning disable CS8618
        protected StockMovement() { }
    }
}
