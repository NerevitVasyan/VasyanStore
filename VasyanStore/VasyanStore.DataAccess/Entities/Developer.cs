﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VasyanStore.DataAccess.Entities
{
    public class Developer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        /* Navigation Props */

        public ICollection<Game> Games { get; set; }
    }
}
