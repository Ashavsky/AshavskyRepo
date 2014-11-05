using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionConsoleApp.Model
{
    public class HappinessLevel
    {
        public int Day { get; set; }
        public int Time { get; set; }
        public int Happiness { get; set; }
    }

    public class ConvertedHappinessLevel
    {
        public string Day { get; set; }
        public string Time { get; set; }
        public string Happiness { get; set; }
    }
}
