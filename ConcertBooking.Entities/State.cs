using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertBooking.Entities
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Default State";
        public int CountryId { get; set; } // Foreign Key
        //Navigation property
        public Country? Country { get; set; }
        // Also a navigation property
        public ICollection<City> Cities { get; set; } = new HashSet<City>();
    }
}
