using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Katz.ExcelUtilities;

namespace ReportGenerator.Tasks
{
    public class ExcelTasks
    {
        public FileInfo GetXLS(DataTable dtReport, FileInfo file)
        {
            using (ExcelManager manager = new ExcelManager())
            {
                manager.Create(file.FullName);
                manager.Open(file.FullName);

                for (int i = 1; i < dtReport.Columns.Count + 1; i++)
                {
                    manager.SetValue(GetColumnName(i - 1) + "1", dtReport.Columns[i - 1].ColumnName);
                }

                int rowCount = 2;
                foreach (DataRow dr in dtReport.Rows)
                {
                    var startCell = GetColumnName(0) + rowCount;
                    var endCell = GetColumnName(dtReport.Columns.Count) + rowCount;
                    manager.SetRangeValues(startCell, endCell, dr.ItemArray.ToList());

                    rowCount += 1;
                }

                manager.Save();
                manager.Close();
            }

            return file;
        }

        private string GetColumnName(int index)
        {
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            var value = "";

            if (index >= letters.Length)
                value += letters[index / letters.Length - 1];

            value += letters[index % letters.Length];

            return value;
        }
    }

}
