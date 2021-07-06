using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPAM.FootballForum.PL.Web.Models
{
    public class SearchUserState
    {
        public bool UserIsFound { get; private set; }

        public void FoundStatus (bool result)
        {
            UserIsFound = result;
        }
    }
}