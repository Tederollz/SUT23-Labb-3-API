using System.ComponentModel.DataAnnotations;

namespace PersonInterestAPI.Models
{
    public class Interest
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<PersonInterest> PersonInterests { get; set; }
        public List<Link> Links { get; set; }
    }
}
