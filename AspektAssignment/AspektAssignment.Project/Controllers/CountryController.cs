using AspektAssignment.Dtos.CountryDtos;
using AspektAssignment.Services.Interface;
using AspektAssignment.Shared.CustomExceptions;
using Microsoft.AspNetCore.Mvc;

namespace AspektAssignment.Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _countryService.Get());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0) return BadRequest("Invalid Id!");

            try
            {
                return Ok(await _countryService.GetById(id));
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

        [HttpGet("CompanyStatistics/{id}")]
        public async Task<IActionResult> GetCompanyStatisticsByCountryId(int id)
        {
            if (id <= 0) return BadRequest("Invalid Id");

            try
            {
                return Ok(await _countryService.GetCompanyStatisticsByCountryId(id));
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

        [HttpPost("CreateCountry")]
        public async Task<IActionResult> CreateCountry(CreateCountryDto country)
        {
            try
            {
                return Ok(await _countryService.Create(country));
            }
            catch (InvalidNameException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut("UpdateCountry")]
        public async Task<IActionResult> UpdateCountry(CountryDto country)
        {
            try
            {
                return Ok(await _countryService.Update(country));
            }
            catch (CountryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidNameException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            if (id <= 0) return BadRequest("Invalid Id");
            try
            {
                await _countryService.Delete(id);
                return Ok("Country is deleted successfully!");
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
