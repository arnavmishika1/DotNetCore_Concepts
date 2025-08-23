using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertBooking.Entities
{
    //Student(*) ------------ (*) Skills (Many to many)
    //Student
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address PermanentAddress { get; set; }
        public ICollection<StudentSkill> StudentSkills { get; set; } = new List<StudentSkill>();
    }
}
