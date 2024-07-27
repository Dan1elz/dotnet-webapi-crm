using System.ComponentModel.DataAnnotations;

namespace dotnet_webapi_erp.Data.DTOs
{
    public record CreateUserDTO(string Name, string Lastname, string Email, string CPF, string PhoneNumber, DateOnly DataNascimento );
    public record UserDTO(Guid Id, string Name, string Lastname, string Email, string CPF, string PhoneNumber, DateTime Created, DateTime Updated);
}