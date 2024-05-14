using PersonInterestAPI.Models;

namespace SUT23_Labb_3_API.Services.Interface
{
    public interface ILink
    {
        Task<IEnumerable<Link>> GetAll();
    }
}
