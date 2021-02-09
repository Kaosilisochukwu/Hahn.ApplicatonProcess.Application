using AutoMapper;
using FluentValidation;
using Hahn.ApplicatonProcess.December2020.Domain;
using Hahn.ApplicatonProcess.December2020.Domain.Interface;
using Hahn.ApplicatonProcess.December2020.Domain.Models;
using Hahn.ApplicatonProcess.December2020.Web.SwaggerObjectSamples;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantController : ControllerBase
    {
        private readonly ILogger<ApplicantController> _logger;
        private readonly IApplicantRepository _appRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<Applicant> _applicantValidator;
        private readonly IValidator<ApplicantToAddDTO> _applicantInfoValidator;

       
        public ApplicantController(ILogger<ApplicantController> logger, IApplicantRepository appRepository,  IMapper mapper, IValidator<Applicant> applicantValidator, IValidator<ApplicantToAddDTO> applicantInfoValidator)
        {
            _logger = logger;
            _appRepository = appRepository;
            _mapper = mapper;
            _applicantValidator = applicantValidator;
            _applicantInfoValidator = applicantInfoValidator;
        }

        /// <summary>
        /// Adds an Applicant 
        /// </summary>
        /// <param name="applicant"></param>
        [HttpPost(Name = "add" )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddApplicant([FromBody] ApplicantToAddDTO applicant)
         {
            _logger.LogInformation("\t\n\n=========================================================================\n\nAccessing the Endpoint for adding an Applicant");
            try
            {
                var validationResult = _applicantInfoValidator.Validate(applicant);
                if (!validationResult.IsValid)
                {
                    _logger.LogInformation("Register Endpoint called with invalid parameters");
                    return BadRequest(new ResponseModel(400, "Object contain one or more validation Errors", validationResult.Errors));
                }
                var applicatToRegister = _mapper.Map<Applicant>(applicant);
                var applicationStatus = await _appRepository.AddApplicant(applicatToRegister);
                if(applicationStatus > 0)
                {
                    _logger.LogInformation("Successful Registration call was made");
                    return Created("add", new ResponseModel(201, "Success", applicatToRegister));
                }
                _logger.LogInformation("Add applicant call was not successful");
                return BadRequest(new ResponseModel(400, "Failed", applicatToRegister));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("An Error occured in the Register endpoint", ex);
                return BadRequest(new ResponseModel(400, "Some Error occuredl!!! Please Try again", null));
            }
        }

        /// <summary>
        /// Gets a specific Applicant by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetApplicant(int Id)
        {
            _logger.LogInformation("\t\n\n=========================================================================\n\nAccessing the Endpoint for getting an applicant");
            try
            {

                var applicant = await _appRepository.GetApplicantById(Id);
                if (applicant != null)
                {
                    _logger.LogInformation("Successful Get call was made");
                    return Ok(new ResponseModel(200, "Success", applicant));
                }
                _logger.LogInformation("Get call was not successful");
                return NotFound(new ResponseModel(404, "Applicant does not exist", null));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("An Error occured in the Get applicant endpoint", ex);
                return BadRequest(new ResponseModel(400, "Some Error occuredl!!! Please Try again", null));
            }
        }

        /// <summary>
        /// Deletes a specific applicant
        /// </summary>
        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteApplicant(int Id)
        {
            _logger.LogInformation("\t\n\n=========================================================================\n\nAccessing the Endpoint for Deleting an Applicant");

            try
            {
                var deletionResult = await _appRepository.DeleteApplicant(Id);
                if (deletionResult > 0)
                {
                    _logger.LogInformation("Successful Delete call was made");
                    return Ok(new ResponseModel(200, "Success", null));
                }
                _logger.LogInformation("Delete call was not successful");
                return NotFound(new ResponseModel(404, "Applicant does not exist", null));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("An Error occured in the Delete endpoint", ex);
                return BadRequest(new ResponseModel(400, "Some Error occuredl!!! Please Try again", null));
            }
        }

        /// <summary>
        /// Get all applicants
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetApplicants()
        {
            _logger.LogInformation("\t\n\n=========================================================================\n\nAccessing the Endpoint for Getting all Applicant");

            try
            {
                var applicants = await _appRepository.GetAllApplicants();
                if (applicants != null)
                {
                    _logger.LogInformation("Successful Get call was made");
                    return Ok(new ResponseModel(200, "Success", applicants));
                }
                _logger.LogInformation("Failed");
                return NotFound(new ResponseModel(404, "Applicant does not exist", null));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("An Error occured in the GetAllApplicants endpoint", ex);
                return BadRequest(new ResponseModel(400, "Some Error occuredl!!! Please Try again", null));
            }
        }

        /// <summary>
        /// Updates a specifc applicant
        /// </summary>
        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerRequestExample(typeof(Applicant), typeof(ApplicantModelExample))]
        public async Task<IActionResult> UpdateApplicant([FromBody] Applicant applicant)
        {
            _logger.LogInformation("\t\n\n=========================================================================\n\nAccessing the Endpoint for Updating an Applicant");
            try
            {
                var validationResult = _applicantValidator.Validate(applicant);
                if (!validationResult.IsValid)
                {
                    _logger.LogInformation("Update Endpoint called with invalid parameters");
                    return BadRequest(new ResponseModel(400, "object has one or more validation Errors", validationResult.Errors));
                }
                var updateResult = await _appRepository.UpdateApplicant(applicant);
                if (updateResult > 0)
                {
                    _logger.LogInformation("Successful Update call was made");
                    return Ok(new ResponseModel(200, "Applicant updated", applicant));
                }
                _logger.LogInformation("Update call was not successful");
                return BadRequest(new ResponseModel(400, "Failed", applicant));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("An Error occured in the Update endpoint", ex);
                return BadRequest(new ResponseModel(400, "Some Error occuredl!!! Please Try again", null));
            }
        }
    }
}
