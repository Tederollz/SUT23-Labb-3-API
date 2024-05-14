using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonInterestAPI.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<PersonInterest> PersonInterests { get; set; }
    }
}
