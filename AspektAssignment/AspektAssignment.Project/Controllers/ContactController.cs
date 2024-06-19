using AspektAssignment.Dtos.ContactDtos;
using AspektAssignment.Services.Interface;
using AspektAssignment.Shared.CustomExceptions;
using Microsoft.AspNetCore.Mvc;

namespace AspektAssignment.Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _contactService.Get());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0) return BadRequest("Invalid Id");

            try
            {
                return Ok(await _contactService.GetById(id));
            }
            catch (ContactNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("ContactDetails")]
        public async Task<IActionResult> ContactDetails()
        {
            try
            {
                return Ok(await _contactService.GetContactsWithCompanyAndCountry());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }

        }

        [HttpGet("Filter")]
        public async Task<IActionResult> Filter(int? countryId, int? companyId)
        {
            try
            {
                return Ok(await _contactService.FilterContacts(countryId, companyId));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }

        }

        [HttpPost("CreateContact")]
        public async Task<IActionResult> CreateContact(CreateContactDto contact)
        {
            try
            {
                return Ok(await _contactService.Create(contact));
            }
            catch (CompanyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (CountryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut("UpdateContact")]
        public async Task<IActionResult> UpdateContact(ContactDto contact)
        {
            try
            {
                return Ok(await _contactService.Update(contact));
            }
            catch (ContactNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (CompanyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (CountryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            if (id <= 0) return BadRequest("Invalid Id");
            try
            {
                await _contactService.Delete(id);
                return Ok("Contact is deleted successfully!");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
