using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DependencyInjectionConsoleApp.Model;
using DependencyInjectionConsoleApp.Repositories;
using DependencyInjectionConsoleApp.Tasks;
using Microsoft.Office.Interop.Excel;

namespace DependencyInjectionConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProcessHappinessText processor = new ProcessHappinessText();
            //processor.WriteToConsole();

            //ProcessHappinessExcel processor = new ProcessHappinessExcel();
            //processor.WriteToConsole();

            ProcessHappiness processor = new ProcessHappiness();
            processor.WriteToConsole();
        }
    }

    //class ProcessHappinessText
    //{
    //    HappinessLevelTasks happyTasks = new HappinessLevelTasks(new TextRepository());

    //    public List<ConvertedHappinessLevel> HappyDayList
    //    {
    //        get { return happyTasks.GetConvertedHappinessList(); }
    //    }

    //    public void WriteToConsole()
    //    {
    //        foreach (var entry in HappyDayList)
    //        {
    //            Console.WriteLine(string.Format("Alex was {0} on {1} at {2}", entry.Happiness, entry.Day, entry.Time));
    //        }

    //        Console.Read();
    //    }
    //}

    //class ProcessHappinessExcel
    //{
    //    HappinessLevelTasksExcel happyTasks = new HappinessLevelTasksExcel(new ExcelRepository());

    //    public List<ConvertedHappinessLevel> HappyDayList
    //    {
    //        get { return happyTasks.GetConvertedHappinessList(); }
    //    }

    //    public void WriteToConsole()
    //    {
    //        foreach (var entry in HappyDayList)
    //        {
    //            Console.WriteLine(string.Format("Alex was {0} on {1} at {2}", entry.Happiness, entry.Day, entry.Time));
    //        }

    //        Console.Read();
    //    }
    //}

    class ProcessHappiness
    {
        HappinessLevelTasks happyTasks = new HappinessLevelTasks(new ExcelRepository());

        public List<ConvertedHappinessLevel> HappyDayList
        {
            get { return happyTasks.GetConvertedHappinessList(); }
        }

        public void WriteToConsole()
        {
            foreach (var entry in HappyDayList)
            {
                Console.WriteLine(string.Format("Alex was {0} on {1} at {2}", entry.Happiness, entry.Day, entry.Time));
            }

            Console.Read();
        }
    }
}
