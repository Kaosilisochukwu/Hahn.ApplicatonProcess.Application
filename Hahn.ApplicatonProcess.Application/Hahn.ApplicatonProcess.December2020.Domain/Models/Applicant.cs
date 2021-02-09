using System;
using System.ComponentModel.DataAnnotations;

namespace Hahn.ApplicatonProcess.December2020.Domain
{
    /// <summary>
    /// Properties of an applicant
    /// </summary>
    public class Applicant
    {

        /// <summary>
        /// Applicants Id
        /// </summary>
        /// <example>1</example>
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// Name of the applicant
        /// </summary>
        /// <example>Johnny</example>
        public string Name { get; set; }

        /// <summary>
        /// Applicant's Family name
        /// </summary>
        /// <example>Morgan</example>
        [Required]
        [MinLength(5)]
        public string FamilyName { get; set; }
        /// <summary>
        /// Applicant's Address
        /// </summary>
        /// <example>16 Reality ave</example>
        [Required]
        [MinLength(10)]
        public string Address { get; set; }
        /// <summary>
        /// Applicant's country of origin
        /// </summary>
        /// <example>Canada</example>
        [Required]
        public string CountryOfOrigin { get; set; }
        /// <summary>
        /// Applicant's email address
        /// </summary>
        /// <example>Jon@morg.com</example>
        [DataType(DataType.EmailAddress)]
        [Required]
        public string EmailAddress { get; set; }
        /// <summary>
        /// Applicants Age
        /// </summary>
        /// <example>70</example>
        [Required]
        [Range(20, 60)]
        public int Age { get; set; }
        /// <summary>
        /// Applicants hired status
        /// </summary>
        /// <example>false</example>
        [Required]
        public bool Hired { get; set; } = false;
    }
}
