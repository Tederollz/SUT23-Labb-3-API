using System.Collections.Generic;
using System.Threading.Tasks;
using PersonInterestAPI.Models;

namespace PersonInterestAPI.Repositories
{
    public interface IPerson
    {
        Task<IEnumerable<Person>> GetAll();
        Task<IEnumerable<Interest>> GetInterestById(int id);
        Task<IEnumerable<Link>> GetLinksById(int id);
        Task<PersonInterest> AddNewPersonInterest(int personId, int interestId);
        Task<Link> AddLink(int personId, int interestId, string url);
    }
}
