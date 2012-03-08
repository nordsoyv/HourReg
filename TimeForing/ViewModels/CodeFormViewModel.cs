using System.Collections.Generic;
using TimeForing.Common;
using TimeForing.Models;
using System.Web.Mvc;

namespace TimeForing.ViewModels
{
    public class CodeFormViewModel
    {
        public Code Code { get; private set; }
        //public SelectList ProjectCodes { get; private set; }
        public IEnumerable<SelectListItem> ProjectCodes { get; private set; }

        public CodeFormViewModel(Code code)
        {
            TimeforingRepository repo = new TimeforingRepository ();
            Code = code;
            ProjectCodes = SelectListMaker.Projects();
        }
    }
}