using Hahn.ApplicatonProcess.December2020.Domain.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Hahn.ApplicatonProcess.December2020.Web.SwaggerObjectSamples
{
    public class ApplicantToAddExample : IExamplesProvider<ApplicantToAddDTO>
    {
        public ApplicantToAddDTO GetExamples()
        {
            return new ApplicantToAddDTO
            {
                Name = "Johnson",
                FamilyName = "Morgans",
                Address = "12 Freeman avenue",
                CountryOfOrigin = "Canada",
                EmailAddress = "johm@morgan.com",
                Age = 46,
                Hired = false
            };
        }
    }
}
