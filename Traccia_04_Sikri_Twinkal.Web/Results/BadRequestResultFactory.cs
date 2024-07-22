using Microsoft.AspNetCore.Mvc;
using Traccia_04_Sikri_Twinkal.App.Models.Responses;


namespace Traccia_04_Sikri_Twinkal.Web.Results
{
    public class BadRequestResultFactory : BadRequestObjectResult
    {
        public BadRequestResultFactory(ActionContext context) : base(new BadResponse())
        {
            var retErrors = new List<string>();
            foreach (var key in context.ModelState)
            {
                var errors = key.Value.Errors;
                for (var i = 0; i < errors.Count(); i++)
                {
                    retErrors.Add(errors[0].ErrorMessage);
                }
            }

            var response = (BadResponse)Value;
            response.Errors = retErrors;
        }
    }
}