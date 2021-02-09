using FluentValidation;
using Hahn.ApplicatonProcess.December2020.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain
{
    public class ApplicantInfoValidator : AbstractValidator<ApplicantToAddDTO>
    {
        public ApplicantInfoValidator()
        {
            RuleFor(applicant => applicant.Name).NotNull().MinimumLength(5);
            RuleFor(applicant => applicant.FamilyName).NotNull().MinimumLength(5);
            RuleFor(applicant => applicant.Address).NotNull().MinimumLength(10);
            RuleFor(applicant => applicant.CountryOfOrigin).MustAsync(async (country, cancellation) =>
            {
                var client = new HttpClient();
                var url = $"https://restcountries.eu/rest/v2/name/{country}?fullText=true";
                var requestResult = await client.GetAsync(url);
                return requestResult.IsSuccessStatusCode;
            }).WithMessage("Must be a valid country");
            RuleFor(applicant => applicant.EmailAddress).Matches(@"^[a-z]+[\w]*@[\w]+.(com|net|edu|gov|int|org)");
            RuleFor(applicant => applicant.Age).GreaterThanOrEqualTo(20).LessThanOrEqualTo(60);
            RuleFor(applicant => applicant.Hired).NotNull();
        }
    }
}
