using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertBooking.Entities
{
    // Student(1) ------------ (*) StudentSkills (*) ------------ (1) Skill
    public class StudentSkill
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
