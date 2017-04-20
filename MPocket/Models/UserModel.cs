using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MPocket.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Login is required")]
        public string Login { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
    }
}