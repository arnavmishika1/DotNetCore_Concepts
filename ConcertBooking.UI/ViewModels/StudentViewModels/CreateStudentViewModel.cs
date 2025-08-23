using ConcertBooking.Entities;

namespace ConcertBooking.UI.ViewModels.StudentViewModels
{
    public class CreateStudentViewModel
    {
        public string Name { get; set; }
        public Address PhysicalAddress { get; set; }
        public List<CheckBoxTable> SkillList { get; set; } = new List<CheckBoxTable>();

    }
    public class CheckBoxTable
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; } = "Default";
        public bool IsChecked { get; set; }
    }
}
