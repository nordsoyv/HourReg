using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeForing.Models
{
    public partial  class Project
    {
        public bool IsValid
        {
            get { return (GetRuleViolations().Count() == 0); }
        }

        public IEnumerable<RuleViolation> GetRuleViolations()
        {
           
            if (String.IsNullOrEmpty(this.Name))
                yield return new RuleViolation("Navn påkrevd", "Name");
            if (Name.Length > 50)
                yield return new RuleViolation("Navn kan maks være 50 tegn", "Name");
            yield break;

        }

        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if (!IsValid )
            {
                throw new ApplicationException ("Rule violations prevent saving");    
            }
            
        }
    }
}
