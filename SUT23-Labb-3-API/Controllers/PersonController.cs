using Microsoft.AspNetCore.Mvc;
using PersonInterestAPI.Repositories;
using SUT23_Labb_3_API.Services.Interface;

namespace Labb3_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPerson _personRepository;
        private readonly ILink _linkRepository;
        private readonly IInterest _interestRepository;

        public PersonController(IPerson personRepository, ILink linkRepository, IInterest interestRepository)
        {
            _personRepository = personRepository;
            _linkRepository = linkRepository;
            _interestRepository = interestRepository;
        }

        [HttpGet("GetAllPersons")]
        public async Task<IActionResult> GetAllPersons()
        {
            try
            {
                return Ok(await _personRepository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpGet("GetInterest/{id:int}")]
        public async Task<IActionResult> GetAllInterests(int id)
        {
            try
            {
                return Ok(await _personRepository.GetInterestById(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpGet("GetLinksForPerson/{id:int}")]
        public async Task<IActionResult> GetAllLinksByPerson(int id)
        {
            try
            {
                var result = await _personRepository.GetLinksById(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpPost("AddNewInterestForPerson/{personId:int}/{interestId:int}")]
        public async Task<IActionResult> AddNewInterestToPerson(int personId, int interestId)
        {
            try
            {
                var newPersonInterest = await _personRepository.AddNewPersonInterest(personId, interestId);

                if (newPersonInterest == null)
                {
                    return BadRequest("The relation already exists in the database.");
                }

                return Ok(newPersonInterest);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding new data to the database.");
            }
        }

        [HttpPost("AddNewLinkForPerson/{personId:int}/{interestId:int}")]
        public async Task<IActionResult> AddNewLinkToPerson(int personId, int interestId, [FromBody] string url)
        {
            try
            {
                var newLink = await _personRepository.AddLink(personId, interestId, url);
                if (newLink == null)
                {
                    return NotFound("No relation found.");
                }
                return Ok(newLink);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding new data to the database.");
            }
        }

        [HttpGet("Links")]
        public async Task<IActionResult> GetAllLinks()
        {
            try
            {
                return Ok(await _linkRepository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpGet("Interests")]
        public async Task<IActionResult> GetAllInterests()
        {
            try
            {
                return Ok(await _interestRepository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }
    }
}
