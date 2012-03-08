using System.Collections.Generic;
using TimeForing.Common;
using TimeForing.Models;
using System.Web.Mvc;

namespace TimeForing.ViewModels
{
    public class SelectTasksViewModel
    {
        public List<Task> Tasks { get; private set; }
        public Sprint Sprint { get; private set; }
        public List<List<SelectListItem>> AllUsers { get; private set; }
        public List<List<SelectListItem>> AllSprints { get; private set; }
        TimeforingRepository repo = new TimeforingRepository();
            
        public SelectTasksViewModel(int sprintId)
        {


            Sprint = repo.GetSprint(sprintId);
            Tasks = repo.GetTasksInSprint(sprintId);

            SetUsers(sprintId);
            SetSprints(sprintId);

        }

        private void SetUsers(int id)
        {
            AllUsers = new List<List<SelectListItem> >();
            foreach (var task in Tasks )
            {
                AllUsers.Add(SelectListMaker.UsersWithSelected(task ));
            }
            
        }
        
        private void SetSprints(int id)
        {
            AllSprints = new List<List<SelectListItem>>();
            foreach (var task in Tasks)
            {
                AllSprints.Add( SelectListMaker.SprintsWithSelected(task ));
            }
        }
    }
}