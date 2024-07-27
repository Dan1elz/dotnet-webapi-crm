using dotnet_webapi_erp.App.Models.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet_webapi_erp.App.Models.Concrete.Token
{
    public class Token : BaseEntity
    {
        [ForeignKey("User")]
        public Guid UserId { get; init; }

        public string Value {  get; init; }

        public Token (Guid userId, string value) : base()
        {
            UserId = userId;
            Value = value;
        }
    }
}
