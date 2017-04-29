using MPocketCommon.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace MPocket.Utils
{
    public class SessionManager
    {
        private readonly HttpSessionState _session;

        public SessionManager()
        {
            _session = HttpContext.Current.Session;              
        }

        public void Add<T>(T value, string name)
        {
            _session.Add(name, value);
        }

        public T Get<T>(string name)
        {
            return (T)_session[name];
        }

        public void Replace<T>(T value, string name)
        {
            _session[name] = value;
        }

        public void RemoveSession()
        {
            _session.RemoveAll();
        }
    }
}