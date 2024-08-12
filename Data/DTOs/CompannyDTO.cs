using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace dotnet_webapi_erp.Data.DTOs
{
   public record CompannyDTO(string Name, string Description, int NumberEmployees, string CNPJ);
}
