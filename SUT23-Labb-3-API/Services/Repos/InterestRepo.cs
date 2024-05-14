using Microsoft.EntityFrameworkCore;
using PersonInterestAPI.Data;
using PersonInterestAPI.Models;
using SUT23_Labb_3_API.Services.Interface;
using System;

namespace SUT23_Labb_3_API.Services.Repos
{
    public class InterestRepo : IInterest
    {
        private readonly PersonDbContext _context;

        public InterestRepo(PersonDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Interest>> GetAll()
        {
            return await _context.Interests.ToListAsync();
        }
    }
}
