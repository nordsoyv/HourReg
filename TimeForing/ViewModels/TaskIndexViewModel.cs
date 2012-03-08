using System.Collections.Generic;
using System.Linq;
using TimeForing.Models;

namespace TimeForing.ViewModels
{
    public class TaskIndexViewModel
    {
        public List<Story> Stories { get; private set; }
        public bool ShowDoneTasks { get; private set; }

        public TaskIndexViewModel(bool showAll)
        {
            TimeforingRepository repo = new TimeforingRepository();
            if (showAll)
                Stories = (repo.FindAllStories()
                    .Where(s => s.Tasks.Count > 0))
                    .OrderBy( s => s.Name )
                    .ToList();
            else
                Stories = (repo.FindAllStories()
                     .Where(s => s.Tasks.Count > 0))
                     .Where( s => s.Tasks.Select(t=>t.TimeLeft ).Sum() > 0)
                     .OrderBy(s => s.Name)
                     .ToList();
            
            ShowDoneTasks = showAll;
        }

    }
}
