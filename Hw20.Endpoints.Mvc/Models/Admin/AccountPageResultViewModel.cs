using App.Domain.Core.Hw20.Result;
using Microsoft.AspNetCore.Identity;

namespace Hw20.Endpoints.Mvc.Models.Admin
{
    public class AccountPageResultViewModel
    {
        public AccountViewModel loginViewModel { get; set; }
        public string? LoginMessage { get; set; }
        public IdentityResult? SignUpResult { get; set; }
    }
}
