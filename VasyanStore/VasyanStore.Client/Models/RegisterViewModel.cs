﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VasyanStore.Client.Models
{
    public class RegisterViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Confirm { get; set; }
        public bool IsAgree { get; set; }
    }
}