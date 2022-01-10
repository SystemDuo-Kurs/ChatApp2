using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp2.Shared
{
    public class Status
    {
        public bool Uspesno { get; set; }
        public List<string> Greske { get; set; } = new();
    }
}