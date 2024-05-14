using PersonInterestAPI.Models;

namespace SUT23_Labb_3_API.Services.Interface
{
    public interface IInterest
    {
        Task<IEnumerable<Interest>> GetAll();
    }
}
