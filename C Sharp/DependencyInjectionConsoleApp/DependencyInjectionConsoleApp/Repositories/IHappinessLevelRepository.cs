using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjectionConsoleApp.Model;

namespace DependencyInjectionConsoleApp.Repositories
{
    public interface IHappinessLevelRepository
    {
        List<HappinessLevel> GetList();
    }
}
