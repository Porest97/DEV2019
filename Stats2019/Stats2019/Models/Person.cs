using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Stats2019.Models
{
    public class Person
    {
        public int Id { get; set; }        
        public Name Name { get; set; }
        public string Email { get; set; }

        // navigation reference???        
        public Address Address { get; set; }

        // navigation collection???
        //[NotMapped]
        public string PhoneNumber { get; set; }

        //Navigation collection
        public Matches Matches { get; set; }             
    }

    [Owned]
    public class Address
    {
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string County { get; set; }
        public string City { get; set; }

    }
    [Owned]
    public class Name
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Matches
    {
        public int Id { get; set; }
        public DateTime MatchDate { get; set; }
        public DayOfWeek Day { get; set; }
        public Series Series { get; set; }
        public Arena Arena { get; set; }
        public Team TeamHome { get; set; }
        public string TeamAway { get; set; }
        public int ScoreTeamHome { get; set; }
        public int ScoreTeamAway { get; set; }
        [NotMapped]
        public Person Ref1 { get; set; }
        [NotMapped]
        public Person Ref2 { get; set; }
        [NotMapped]
        public Person Ref3 { get; set; }
        [NotMapped]
        public Person Ref4 { get; set; }
        public int PersonId { get; set; }
        public int SeriesId { get; set; }
        public int ArenaId { get; set; }
        public int TeamId { get; set; }
    }
    public class Arena
    {
        public int Id { get; set; }
        public string ArenaName { get; set; }
        public Address Address { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class Series
    {
        public int Id { get; set; }
        public string SeriesName { get; set; }
        public string MatchLength { get; set; }
        public int RefFee { get; set; }
        public int LMFee { get; set; }
    }
    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public Arena Arena { get; set; }
    }
}
