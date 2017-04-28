using EntityDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPocket.Models
{
    public class HistoryModel
    {
        public Budget Budget { get; set; }
        public bool IsChecked { get; set; }
    }
}