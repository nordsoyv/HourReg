using TimeForing.Models;

namespace TimeForing.ViewModels
{
    public class StoriesViewModel
    {
        public Story Story { get; private set; }

        public StoriesViewModel(Story s)
        {
            Story = s;

        }
    }
}
