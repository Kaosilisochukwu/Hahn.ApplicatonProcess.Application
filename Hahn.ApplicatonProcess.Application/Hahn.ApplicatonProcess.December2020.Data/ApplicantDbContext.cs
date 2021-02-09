using Hahn.ApplicatonProcess.December2020.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Data
{
    public class ApplicantDbContext : DbContext
    {
        public ApplicantDbContext(DbContextOptions<ApplicantDbContext> options) : base (options) { }

        public DbSet<Applicant> Applicants { get; set; }
    }
}
