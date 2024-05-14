using System.ComponentModel.DataAnnotations;

namespace PersonInterestAPI.Models
{
    public class Link
    {
        [Key]
        public int Id { get; set; }
        public string URL { get; set; }
        public int PersonInterestId { get; set; }
        public PersonInterest PersonInterest { get; set; }
    }
}
