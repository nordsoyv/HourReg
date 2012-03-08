using System;
using System.Collections.Generic;
using TimeForing.Common;
using TimeForing.Models;
using System.Web.Mvc;

namespace TimeForing.ViewModels
{
    public class TaskFormViewModel
    {
        public Task Task { get;  set; }
        public List<SelectListItem > Sprint { get; private set; }
        public List<SelectListItem> User { get; private set; }
        public List<SelectListItem> Code { get; private set; }
        public List<SelectListItem> Story { get; private set; }
        

        public TaskFormViewModel(Task task)
        {
            TimeforingRepository repo = new TimeforingRepository();
            Task = task;

            Sprint = SelectListMaker.SprintsWithSelected( Task);
            User = SelectListMaker.UsersWithSelected(Task);
            Code = SelectListMaker.CodesWithSelected(Task);
            Story = SelectListMaker.StoriesWithSelected(Task);

            
            
        }

        public TaskFormViewModel (Task task , Sprint sprint , User user, Code  code, Story story)
        {
            TimeforingRepository repo = new TimeforingRepository();
            Task = task;


            Sprint = SelectListMaker.SprintsWithSelected(Task);
            User = SelectListMaker.UsersWithSelected(Task);
            Code = SelectListMaker.CodesWithSelected(Task);
            Story = SelectListMaker.StoriesWithSelected(Task);

        }
    }
}