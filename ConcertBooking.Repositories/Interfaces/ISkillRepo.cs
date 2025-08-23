using ConcertBooking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertBooking.Repositories.Interfaces
{
    public interface ISkillRepo
    {
        Task<IEnumerable<Skill>> GetAll();
        Task<Skill> GetById(int id);
        Task Save(Skill skill);
        Task Edit(Skill skill);
        Task RemoveData(Skill skill);
    }
}
