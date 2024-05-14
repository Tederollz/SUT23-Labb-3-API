using Microsoft.EntityFrameworkCore;
using PersonInterestAPI.Data;
using PersonInterestAPI.Models;
using SUT23_Labb_3_API.Services.Interface;

namespace SUT23_Labb_3_API.Services.Repos
{
    public class LinkRepo : ILink
    {
        private readonly PersonDbContext _context;

        public LinkRepo(PersonDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Link>> GetAll()
        {
            return await _context.Links.ToListAsync();
        }
    }
}
