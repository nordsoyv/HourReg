using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeForing.Models;

namespace TimeForing.Common
{
    public static class SelectListMaker
    {
        private static readonly TimeForing.Models.TimeforingRepository _repo = new TimeforingRepository();

        #region "Prosjects"

        public static List<SelectListItem> Projects()
        {

            var items = from p in _repo.FindAllProjects()
                        select p;
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in items)
            {
                SelectListItem i;
                i = new SelectListItem { Value = item.ProjectID.ToString(), Text = item.ProjectID + "/" + item.Name, Selected = false };
                list.Add(i);
            }
            return list;

        }

        #endregion

        #region "Stories"


        public static List<SelectListItem> Stories()
        {
            var items = from s in _repo.FindAllStories()
                        select s;
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in items)
            {
                SelectListItem i;
                i = new SelectListItem { Value = item.StoryID.ToString(), Text = item.Name, Selected = false };
                list.Add(i);
            }
            return list;
        }


        public static List<SelectListItem> StoriesWithSelected(Task task)
        {
            var items = from s in _repo.FindAllStories()
                        select s;
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in items)
            {
                SelectListItem i;

                i = new SelectListItem { Value = item.StoryID.ToString(), Text = item.Name, Selected = task.StoryID == item.StoryID };

                list.Add(i);
            }
            return list;
        }

        public static List<SelectListItem> StoriesWithSelected(Story s)
        {

            var items = _repo.FindAllStories();

            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in items)
            {
                SelectListItem i;
                i = new SelectListItem { Value = item.StoryID.ToString(), Text = item.Name, Selected = s.StoryID == item.StoryID };

                list.Add(i);
            }
            return list;
        }

        #endregion

        #region "Sprints"

        public static List<SelectListItem> Sprints()
        {
            var items = _repo.FindAllSprints().Where(s=> s.Archived != true).Select( s=>s);

            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in items)
            {
                SelectListItem i = new SelectListItem { Value = item.SprintID.ToString(), Text = item.Name };
                list.Add(i);
            }
            return list;
        }

        public static List<SelectListItem> SprintsWithSelected(Task t)
        {
            var items = _repo.FindAllSprints().Where(s => s.Archived != true).Select(s => s); ;

            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in items)
            {
                SelectListItem i = new SelectListItem { Value = item.SprintID.ToString(), Text = item.Name, Selected = t.SprintID == item.SprintID };
                list.Add(i);
            }
            return list;
        }


        public static List<SelectListItem> SprintsWithSelected(Sprint sprint)
        {
            var items = _repo.FindAllSprints().Where(s => s.Archived != true).Select(s => s); ;

            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in items)
            {
                SelectListItem i;
                i = new SelectListItem { Value = item.SprintID.ToString(), Text = item.Name, Selected = sprint.SprintID == item.SprintID };

                list.Add(i);
            }
            return list;
        }

        #endregion

        #region "User"

        public static List<SelectListItem> Users()
        {
            var items = _repo.FindAllUsers();

            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in items)
            {
                SelectListItem i;
                i = new SelectListItem { Value = item.UserID.ToString(), Text = item.Name };
                list.Add(i);
            }
            return list;
        }
        public static List<SelectListItem> UsersWithSelected(Task t)
        {
            var items = _repo.FindAllUsers();


            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in items)
            {
                SelectListItem i;
                i = new SelectListItem { Value = item.UserID.ToString(), Text = item.Name, Selected = t.UserID == item.UserID };
                list.Add(i);
            }
            return list;
        }

        public static List<SelectListItem> UsersWithSelected(User u)
        {
            var items = _repo.FindAllUsers();

            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in items)
            {
                SelectListItem i;
                i = new SelectListItem { Value = item.UserID.ToString(), Text = item.Name, Selected = u.UserID == item.UserID };

                list.Add(i);
            }
            return list;
        }

        #endregion

        #region "Code"
        public static List<SelectListItem> CodesWithSelected(Task t)
        {
            var items = _repo.FindAllCodes();

            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in items)
            {
                SelectListItem i = new SelectListItem
                {
                    Value = item.CodeID.ToString(),
                    Text = item.ProjectID + "/" + item.CodeNumber + " - " + item.Name,
                    Selected = t.CodeID == item.CodeID
                };
                list.Add(i);
            }
            return list;

        }

        public static List<SelectListItem> CodesWithSelected(Code c)
        {
            var items = _repo.FindAllCodes();

            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in items)
            {
                SelectListItem i;
                i = new SelectListItem { Value = item.CodeID.ToString(), Text = item.Name, Selected = c.CodeID == item.CodeID };

                list.Add(i);
            }
            return list;
        }

        #endregion

    }
}
