﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VasyanStore.Client.Models
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsRemember { get; set; }
    }
}