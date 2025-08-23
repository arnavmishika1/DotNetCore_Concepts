using ConcertBooking.Entities;

namespace ConcertBooking.UI.ViewModels.StudentViewModels
{
    public class EditStudentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address PhysicalAddress { get; set; }
        public List<CheckBoxTable> SkillList { get; set; } = new List<CheckBoxTable>();
    }
}
