using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPocketCommon.Helpers
{
    public class CurrentContext
    {
        private static CurrentContext _currentcontex;
        private static IDictionary<string, SessionBags> _context;
        private static object _lock = new object();

        public static CurrentContext Instance
        {
            get
            {
                lock(_lock)
                {
                    if (_currentcontex == null)
                    {
                        _currentcontex = new CurrentContext();
                        _context = new Dictionary<string, SessionBags>();
                    }
                    return _currentcontex;
                }
            }
        }

        private static IDictionary<string, SessionBags> Context
        {
            get
            {
                lock(_lock)
                {
                    if(_context == null)
                    {
                        _context = new Dictionary<string, SessionBags>();
                    }
                    return _context;
                }
            }
            set
            {
                _context = value;
            }
        }

        public void Add(string sessionId, SessionBags sessionBags)
        {
            Context[sessionId] = sessionBags;
        }

        public SessionBags Get(string sessionId)
        {
            SessionBags sessionBags = new SessionBags();
            Context.TryGetValue(sessionId, out sessionBags);

            return sessionBags == null ? new SessionBags() : sessionBags;
        }
    }

    public class SessionBags
    {
        public int CurrentUserId { get; set; }
        public string CurrentUserName { get; set; }
    }

}
