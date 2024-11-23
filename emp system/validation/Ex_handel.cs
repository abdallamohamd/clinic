using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace emp_system.validation
{
    public class Ex_handelAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            ViewResult result =new ViewResult();
            result.ViewName = "ex_handel";
            context.Result = result;
        }
    }
}
