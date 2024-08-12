using dotnet_webapi_erp.App.Models.Concrete.Invite;
using dotnet_webapi_erp.App.Models.Concrete.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using dotnet_webapi_erp.App.Models.Concrete.Association;

namespace dotnet_webapi_erp.Data.Repositories
{
    public class IniviteRepository(AppDbContext context) : IInviteRepository
    {
        private readonly AppDbContext _context = context;

        public List<Invite> ListAll(Guid user)
        {
            var currentDate = DateTime.Now;

            return  _context.Invites
            .Where(u => u.User == user && u.Expiration > currentDate)
            .ToList();

        }

        public async Task<object> ListByValue(string value, Guid user, CancellationToken ct)
        {
            var currentDate = DateTime.Now;

            var invite = await _context.Invites
                .SingleOrDefaultAsync(u => u.Value == value && u.User == user && u.Expiration > currentDate, ct);

            return Confirm(invite!.Id, ct);
        }


        public async Task<bool> Confirm(Guid Inivit, CancellationToken ct)
        {
            
          var invite = await _context.Invites.FindAsync(Inivit, ct);

        if (invite == null) return false;

            var association = new Association(invite.User, invite.Company, invite.Office);
            _context.
        //remover o invite no final 

        //criar associação 



    }
    }
}
