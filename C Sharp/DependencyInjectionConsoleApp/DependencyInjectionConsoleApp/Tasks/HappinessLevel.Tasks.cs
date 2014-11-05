using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using DependencyInjectionConsoleApp.Model;
using DependencyInjectionConsoleApp.Repositories;

namespace DependencyInjectionConsoleApp.Tasks
{
    //public class HappinessLevelTasks
    //{
    //    private TextRepository _repo;
    //    private Dictionary<int, string> happinessMap = new Dictionary<int, string>()
    //    {
    //        {1, "Miserable"},
    //        {2, "Not Happy"},
    //        {3, "Feeling Good"},
    //        {4, "Very Happy"},
    //    };
    //    private Dictionary<int, string> timeMap = new Dictionary<int, string>()
    //    {
    //        {9, "9:00 AM"},
    //        {15, "3:00 PM"},
    //    };
    //    private Dictionary<int, string> dayMap = new Dictionary<int, string>()
    //    {
    //        {1, "Monday"},
    //        {2, "Tuesday"},
    //        {3, "Wednesday"},
    //        {4, "Thursday"},
    //        {5, "Friday"},
    //    };


    //    //What if we want to switch to an excel repository?
    //    public HappinessLevelTasks(TextRepository repo)
    //    {
    //        _repo = repo;
    //    }

    //    public List<ConvertedHappinessLevel> GetConvertedHappinessList()
    //    {
    //        var convertedList = new List<ConvertedHappinessLevel>();
    //        foreach (var item in GetHappinessList())
    //        {
    //            convertedList.Add(ApplyHappinessMap(item));
    //        }
    //        return convertedList;
    //    }

    //    public List<HappinessLevel> GetHappinessList()
    //    {
    //        return _repo.GetList();
    //    }

    //    public ConvertedHappinessLevel ApplyHappinessMap(HappinessLevel rawItem)
    //    {
    //        return new ConvertedHappinessLevel()
    //        {
    //            Day = dayMap[rawItem.Day],
    //            Happiness = happinessMap[rawItem.Happiness],
    //            Time = timeMap[rawItem.Time]
    //        };
    //    }
    //}

    //public class HappinessLevelTasksExcel
    //{
    //    private ExcelRepository _repo;
    //    private Dictionary<int, string> happinessMap = new Dictionary<int, string>()
    //    {
    //        {1, "Miserable"},
    //        {2, "Not Happy"},
    //        {3, "Feeling Good"},
    //        {4, "Very Happy"},
    //    };
    //    private Dictionary<int, string> timeMap = new Dictionary<int, string>()
    //    {
    //        {9, "9:00 AM"},
    //        {15, "3:00 PM"},
    //    };
    //    private Dictionary<int, string> dayMap = new Dictionary<int, string>()
    //    {
    //        {1, "Monday"},
    //        {2, "Tuesday"},
    //        {3, "Wednesday"},
    //        {4, "Thursday"},
    //        {5, "Friday"},
    //    };

    //    public HappinessLevelTasksExcel(ExcelRepository repo)
    //    {
    //        _repo = repo;
    //    }

    //    public List<ConvertedHappinessLevel> GetConvertedHappinessList()
    //    {
    //        var convertedList = new List<ConvertedHappinessLevel>();
    //        foreach (var item in GetHappinessList())
    //        {
    //            convertedList.Add(ApplyHappinessMap(item));
    //        }
    //        return convertedList;
    //    }

    //    public List<HappinessLevel> GetHappinessList()
    //    {
    //        return _repo.GetList();
    //    }

    //    public ConvertedHappinessLevel ApplyHappinessMap(HappinessLevel rawItem)
    //    {
    //        return new ConvertedHappinessLevel()
    //        {
    //            Day = dayMap[rawItem.Day],
    //            Happiness = happinessMap[rawItem.Happiness],
    //            Time = timeMap[rawItem.Time]
    //        };
    //    }
    //}

    public class HappinessLevelTasks
    {
        private IHappinessLevelRepository _repo;
        private Dictionary<int, string> happinessMap = new Dictionary<int, string>()
        {
            {1, "Miserable"},
            {2, "Not Happy"},
            {3, "Feeling Good"},
            {4, "Very Happy"},
        };
        private Dictionary<int, string> timeMap = new Dictionary<int, string>()
        {
            {9, "9:00 AM"},
            {15, "3:00 PM"},
        };
        private Dictionary<int, string> dayMap = new Dictionary<int, string>()
        {
            {1, "Monday"},
            {2, "Tuesday"},
            {3, "Wednesday"},
            {4, "Thursday"},
            {5, "Friday"},
        };

        public HappinessLevelTasks(IHappinessLevelRepository repo)
        {
            _repo = repo;
        }

        public List<ConvertedHappinessLevel> GetConvertedHappinessList()
        {
            var convertedList = new List<ConvertedHappinessLevel>();
            foreach (var item in GetHappinessList())
            {
                convertedList.Add(ApplyHappinessMap(item));
            }
            return convertedList;
        }

        public List<HappinessLevel> GetHappinessList()
        {
            return _repo.GetList();
        }

        public ConvertedHappinessLevel ApplyHappinessMap(HappinessLevel rawItem)
        {
            return new ConvertedHappinessLevel()
            {
                Day = dayMap[rawItem.Day],
                Happiness = happinessMap[rawItem.Happiness],
                Time = timeMap[rawItem.Time]
            };
        }
    }
}
