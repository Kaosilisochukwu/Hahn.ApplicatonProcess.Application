using Hahn.ApplicatonProcess.December2020.Domain.Interface;
using Hahn.ApplicatonProcess.December2020.Data;
using Hahn.ApplicatonProcess.December2020.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicatonProcess.December2020.Domain.Repository
{
    public class ApplicantRepository : IApplicantRepository
    {
        private readonly ApplicantDbContext _context;

        public ApplicantRepository(ApplicantDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddApplicant(Applicant applicant)
        {
            _context.Applicants.Add(applicant);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteApplicant(int Id)
        {
            var applicant = _context.Applicants.FirstOrDefault(applicant => applicant.ID == Id);
            if(applicant != null)
                _context.Applicants.Remove(applicant);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Applicant>> GetAllApplicants()
        {
            return await _context.Applicants.ToListAsync();
        }

        public async Task<Applicant> GetApplicantById(int Id)
        {
            return await _context.Applicants.FirstOrDefaultAsync(applicant => applicant.ID == Id);
        }

        public async Task<int> UpdateApplicant(Applicant applicant)
        {
            _context.Applicants.Update(applicant);
            return await _context.SaveChangesAsync();
        }
    }
}
