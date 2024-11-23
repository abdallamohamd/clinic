using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace emp_system.Models
{
    public class appuser : IdentityUser
    {
        public string? address {  get; set; }
    }
}
