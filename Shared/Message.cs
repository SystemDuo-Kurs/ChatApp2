﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp2.Shared
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Sent { get; set; }
        public User User { get; set; }
    }
}
