﻿using dotnet_webapi_erp.App.Models.Abstract;
using dotnet_webapi_erp.Data.DTOs;
using System.ComponentModel.DataAnnotations;

namespace dotnet_webapi_erp.App.Models.Concrete.User
{
    public class User : Person
    {
        [Required]
        [MaxLength(32)]
        public string Password { get; set; }

        [Required]
        public DateOnly DataNascimento { get; set; }

        public User(string name, string lastname, string email, string cpf, string phoneNumber, string password, DateOnly dataNascimento) : base(name, lastname, email, cpf, phoneNumber)
        {
            Password = password;
            DataNascimento = dataNascimento;
        }
        public void Update(UpdateUserDTO user)
        {
            this.Name = user.Name;
            this.Lastname = user.Lastname;
            this.PhoneNumber = user.PhoneNumber;
            this.DataNascimento = user.DataNascimento;
            this.Updated = DateTime.UtcNow;
        }

        #pragma warning disable CS8618
        protected User() { }
    }
}
