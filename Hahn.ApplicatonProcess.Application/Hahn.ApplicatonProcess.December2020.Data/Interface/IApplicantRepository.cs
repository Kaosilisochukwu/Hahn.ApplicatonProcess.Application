using Hahn.ApplicatonProcess.December2020.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Interface
{
    public interface IApplicantRepository
    {
        Task<int> AddApplicant(Applicant applicant);
        Task<IEnumerable<Applicant>> GetAllApplicants();
        Task<Applicant> GetApplicantById(int Id);
        Task<int> UpdateApplicant(Applicant applicant);
        Task<int> DeleteApplicant(int Id);
    }
}
