
using EntityDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPocketCommon.Helpers
{
    public class SessionManager
    {
        private string _sessionId;

        public SessionManager(string sessionId)
        {
            _sessionId = sessionId;
        }

        public void AddUserToSession(User user)
        {

        }

        public void AddBudgetToSession(Budget budget)
        {

        }
    }
}
