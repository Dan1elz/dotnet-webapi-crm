using System.ComponentModel.DataAnnotations;

namespace dotnet_webapi_erp.App.Models.Abstract
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; init; }
        public DateTime Created { get; init; }
        public DateTime Updated { get; set; }

        public BaseEntity()
        {
            Guid id = Guid.NewGuid();
            Created = DateTime.Now;
            Updated = DateTime.Now;
        }
    }
}
