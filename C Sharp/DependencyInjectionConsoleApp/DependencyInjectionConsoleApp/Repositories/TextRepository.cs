using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjectionConsoleApp.Model;

namespace DependencyInjectionConsoleApp.Repositories
{
    public class TextRepository : IHappinessLevelRepository
    //public class TextRepository
    {
        public List<HappinessLevel> GetList()
        {
            return File.ReadAllLines(@"C:\Temp\happiness.txt").Select(ProcessLine).ToList();
        }


        //Helper Methods
        HappinessLevel ProcessLine(string line)
        {
            var delimittedArray = SliceLine(line);
             return new HappinessLevel()
             {
                 Day = Convert.ToInt32(delimittedArray[0]),
                 Time = Convert.ToInt32(delimittedArray[1]),
                 Happiness = Convert.ToInt32(delimittedArray[2])
             };   
        }

        public string[] SliceLine(string line)
        {
            var delimittedArray = line.Split(new char[] {'|', '|'});
            return delimittedArray;
        }
    }
}
