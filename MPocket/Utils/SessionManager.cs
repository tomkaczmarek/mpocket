using MPocketCommon.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace MPocket.Utils
{
    internal class SessionManager
    {
        private readonly HttpSessionState _session;

        internal SessionManager()
        {
            _session = HttpContext.Current.Session;              
        }

        internal void Add<T>(T value, string name)
        {
            _session.Add(name, value);
        }

        internal T Get<T>(string name)
        {
            return (T)_session[name];
        }
        
        internal void Replace<T>(T value, string name)
        {
            _session[name] = value;
        }
    }
}