using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator.Tasks
{
    public class EmailName
    {
        public EmailName(string name, string email)
        {
            Name = name;
            Email = email;
        }
        public EmailName() { }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
