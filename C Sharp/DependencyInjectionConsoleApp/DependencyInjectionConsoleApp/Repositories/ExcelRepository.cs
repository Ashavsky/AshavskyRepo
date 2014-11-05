using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjectionConsoleApp.Model;
using Katz.ExcelUtilities;

namespace DependencyInjectionConsoleApp.Repositories
{
    public class ExcelRepository : IHappinessLevelRepository
    //public class ExcelRepository
    {
        private int[] excelNumbers = new int[] {1,2,3,4,5,6,7,8,9,10}; 

        List<HappinessLevel> happyList = new List<HappinessLevel>(); 

        public List<HappinessLevel> GetList()
        {
            using (ExcelManager em = new ExcelManager())
            {
                em.Open(@"C:\Temp\Happiness.xlsx");

                foreach (var rowNumber in excelNumbers)
                {
                    var day = em.GetNumericValue("A" + rowNumber);
                    var time = em.GetNumericValue("B" + rowNumber);
                    var happiness = em.GetNumericValue("C" + rowNumber);

                    happyList.Add(ProcessLine(day, time, happiness));
                }
            }
            return happyList;
        }


        //Helper Methods
        HappinessLevel ProcessLine(double? day, double? time, double? happiness)
        {
            return new HappinessLevel()
            {
                Day = Convert.ToInt32(day),
                Time = Convert.ToInt32(time),
                Happiness = Convert.ToInt32(happiness)
            };   
        }

    }
}
