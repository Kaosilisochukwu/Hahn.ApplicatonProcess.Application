using Hahn.ApplicatonProcess.December2020.Domain;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Web.SwaggerObjectSamples
{
    public class ApplicantModelExample : IExamplesProvider<Applicant>
    {
        public Applicant GetExamples()
        {
            return new Applicant
            {
                ID = 1,
                Name = "Johnny",
                FamilyName = "Morgan",
                Address = "12 Freeman ave",
                CountryOfOrigin = "Canada",
                EmailAddress = "johm@morgan.com",
                Age = 45,
                Hired = false
            };
        }
    }
}
