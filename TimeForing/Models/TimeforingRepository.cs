using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeForing.Common;

namespace TimeForing.Models
{
    public class TimeforingRepository
    {
        private TimeforingDataContext db = new TimeforingDataContext();
        


        #region "Project"

        public IQueryable<Project> FindAllProjects()
        {
            return db.Projects;
        }

      
        public Project GetProject(int id)
        {
            return db.Projects.SingleOrDefault(d => d.ProjectID == id);
        }

        public void AddProject(Project project)
        {
            db.Projects.InsertOnSubmit(project);
        }
        #endregion

        #region "Code"

        public IQueryable<Code> FindAllCodes()
        {
            return db.Codes;
        }

        public Code GetCode(int id)
        {
            return db.Codes.SingleOrDefault(d => d.CodeID == id);
        }


        public void AddCode(Code c)
        {
            db.Codes.InsertOnSubmit(c);
        }

      

        #endregion

        #region "User"

        public IQueryable<User> FindAllUsers()
        {
            return db.Users;
        }

        public User GetUser(int id)
        {
            return db.Users.SingleOrDefault(d => d.UserID == id);
        }


        public void AddUser(User u)
        {
            db.Users.InsertOnSubmit(u);
        }

    

        #endregion

        #region "Sprint"

        public IQueryable<Sprint> FindAllSprints()
        {
            return db.Sprints;
        }

        public IQueryable<Sprint> FindAllActiveSprints()
        {
            return db.Sprints.Where( s=> s.Archived == false).Select( s=>s);
        }


        public Sprint GetSprint(int id)
        {
            return db.Sprints.SingleOrDefault(d => d.SprintID == id);
        }

        public void AddSprint(Sprint s)
        {
            db.Sprints.InsertOnSubmit(s);
        }

      
        public List<Task> GetTasksInSprint(int sprintId)
        {
            var items = from task in db.Tasks
                        where task.SprintID == sprintId
                        select task;
            List<Task> tasks = new List<Task>();
            foreach (var item in items)
            {
                tasks.Add(item);
            }

            return tasks;

        }

        #endregion

        #region "Tasks"

        public IQueryable<Task> FindAllTasks()
        {
            return db.Tasks;
        }

        public Task GetTask(int id)
        {
            return db.Tasks.SingleOrDefault(d => d.TaskID == id);
        }

        public void AddTask(Task t)
        {
            db.Tasks.InsertOnSubmit(t);
        }

        public List<Task> GetUserWorkedOnTasksForWeek(User user, int week, int year)
        {
            DateTime startDate = Util.StartDateInWeek(week, year);
            DateTime endDate = startDate.AddDays(6);

            List<Task> regs = user.HourRegs.Where(h => h.Date >= startDate && h.Date <= endDate).Select(h => h.Task).ToList();
            return regs;
        }


        #endregion

        #region "HourRegs"
        public void AddHourReg(HourReg h)
        {
            db.HourRegs.InsertOnSubmit(h);
        }

        public IQueryable<HourReg> GetHourRegs()
        {
            return db.HourRegs;
        }


        #endregion

        #region "Stories"

        public IQueryable<Story> FindAllStories()
        {
            return db.Stories;
        }

        public Story GetStory(int id)
        {
            return db.Stories.SingleOrDefault(d => d.StoryID == id);
        }

        public void AddStory(Story s)
        {
            db.Stories.InsertOnSubmit(s);
        }

        #endregion


        public void Save()
        {
            db.SubmitChanges();
        }
    }
}
