using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericReportGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            ReportProcessor processor = new ReportProcessor();

            processor.GenerateDataset();
            processor.GenerateExcel();
            processor.EmailExcel();
        }
    }
}
