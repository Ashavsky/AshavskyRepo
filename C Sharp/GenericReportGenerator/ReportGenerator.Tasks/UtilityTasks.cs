using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator.Tasks
{
    public class UtilityTasks
    {
        public string ReportFolder { get; set; }
        public string ReportName { get; set; }
        public int ArchiveOlderThanDays { get; set; }

        public FileInfo ReportFileExcel { get; set; }

        public UtilityTasks()
        {
            ReportFolder = ConfigurationManager.AppSettings["ReportFolder"];
            ReportName = ConfigurationManager.AppSettings["ReportName"];
            ArchiveOlderThanDays = int.Parse(ConfigurationManager.AppSettings["ArchiveIfOlderThanThisManyDays"]);

            FolderCreate(ReportFolder);
            TruncateFolder(ReportFolder, ArchiveOlderThanDays);

            ReportFileExcel = CreateFileInfo(ReportName, ReportFolder);
        }

        private void FolderCreate(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private void TruncateFolder(string folderName, int daysToKeep)
        {
            string[] files = Directory.GetFiles(folderName);

            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                if (fi.CreationTime < DateTime.Now.AddDays(daysToKeep * -1))
                {
                    fi.Delete();
                }
            }
        }

        private FileInfo CreateFileInfo(string reportName, string path)
        {
            var fileName = CreateFileName(reportName);
            return new FileInfo(path + fileName);
        }

        private string CreateFileName(string reportName)
        {
            DateTime Today = DateTime.Now;

            string numberDay = Today.Day.ToString().PadLeft(2, '0');
            string numberMonth = Today.Month.ToString().PadLeft(2, '0');
            string numberYear = Today.Year.ToString();

            return reportName + "_" + numberYear + numberMonth + numberDay + ".xls";
        }
    }
}
