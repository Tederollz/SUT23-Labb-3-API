﻿using System.ComponentModel.DataAnnotations;

namespace PersonInterestAPI.Models
{
    public class PersonInterest
    {
        [Key]
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int InterestId { get; set; }
        public Interest Interest { get; set; }

        public ICollection<Link> Links { get; set; }
    }
}
