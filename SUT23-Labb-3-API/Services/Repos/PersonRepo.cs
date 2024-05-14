using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonInterestAPI.Data;
using PersonInterestAPI.Models;

namespace PersonInterestAPI.Repositories
{
    public class PersonRepo : IPerson
    {
        private readonly PersonDbContext _context;

        public PersonRepo(PersonDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<IEnumerable<Interest>> GetInterestById(int personId)
        {
            return await _context.PersonInterests
                .Where(pi => pi.PersonId == personId)
                .Select(pi => pi.Interest)
                .ToListAsync();
        }

        public async Task<IEnumerable<Link>> GetLinksById(int id)
        {
            return await _context.PersonInterests
                .Where(pi => pi.PersonId == id)
                .Include(pi => pi.Links)
                .SelectMany(pi => pi.Links)
                .ToListAsync();
        }

        public async Task<PersonInterest> AddNewPersonInterest(int personId, int interestId)
        {
            var existingUser = await _context.PersonInterests.FirstOrDefaultAsync(
                pi => pi.PersonId == personId && pi.InterestId == interestId);

            if (existingUser != null)
            {
                return null;
            }

            var newInterest = new PersonInterest
            {
                PersonId = personId,
                InterestId = interestId
            };

            _context.PersonInterests.Add(newInterest);
            await _context.SaveChangesAsync();
            return newInterest;
        }

        public async Task<Link> AddLink(int personId, int interestId, string url)
        {
            var result = await _context.PersonInterests
                .FirstOrDefaultAsync(pi => pi.PersonId == personId && pi.InterestId == interestId);

            if (result == null)
            {
                return null;
            }

            var newLink = new Link
            {
                URL = url,
                PersonInterestId = result.Id
            };

            _context.Links.Add(newLink);
            await _context.SaveChangesAsync();

            return newLink;
        }
    }
}
