using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Models
{
    /// <summary>
    /// Properties needed to register an applicant
    /// </summary>
    public class ApplicantToAddDTO
    {
        /// <summary>
        /// Name of the applicant
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Applicant's Family name
        /// </summary>
        [Required]
        [MinLength(5)]        
        public string FamilyName { get; set; }
        /// <summary>
        /// Applicant's Address
        /// </summary>
        [Required]
        [MinLength(10)]
        public string Address { get; set; }
        /// <summary>
        /// Applicant's country of origin
        /// </summary>
        [Required]
        public string CountryOfOrigin { get; set; }
        /// <summary>
        /// Applicant's email address
        /// </summary>
        [DataType(DataType.EmailAddress)]
        [Required]
        public string EmailAddress { get; set; }
        /// <summary>
        /// Applicants Age
        /// </summary>
        [Required]
        [Range(20, 60)]
        public int Age { get; set; }
        /// <summary>
        /// Applicants hired status
        /// </summary>
        [Required]
        public bool Hired { get; set; } = false;
    }
}
