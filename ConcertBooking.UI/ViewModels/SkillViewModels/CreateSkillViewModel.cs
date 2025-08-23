using ConcertBooking.UI.Validations;

namespace ConcertBooking.UI.ViewModels.SkillViewModels
{
    public class CreateSkillViewModel
    {
        [Uppercase]
        //[Uppercase("Error message")] // can also use
        public string Title { get; set; }
    }
}
