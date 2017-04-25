using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPocket.Models
{
    public class FirstLaunchModel
    {
        public BudgetModel Budget { get; set; } 
        public SettingsModel Settings { get; set; }
    }
}