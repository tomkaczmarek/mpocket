﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPocket.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public bool IsConstant { get; set; }
    }
}