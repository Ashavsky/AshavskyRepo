using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportGenerator.Tasks;

namespace GenericReportGenerator
{
    public class ReportProcessor
    {
        private UtilityTasks ut;
        private DatabaseTasks db;
        private ExcelTasks et;
        private EmailTasks mail;

        private FileInfo excelFile;
        private DataSet dataResultSet;

        public ReportProcessor()
        {   
            ut = new UtilityTasks();
            db = new DatabaseTasks();
            et = new ExcelTasks();
            mail = new EmailTasks();
        }

        public void GenerateDataset()
        {
            try
            {
                dataResultSet = db.SqlResultSet;
            }
            catch (Exception ex)
            {
                mail.SendErrorEmails("Generating Dataset", ex.ToString());
            }
        }

        public void GenerateExcel()
        {
            try
            {
                excelFile = et.GetXLS(dataResultSet.Tables[0], ut.ReportFileExcel);
            }
            catch (Exception ex)
            {
                mail.SendErrorEmails("Generating Dataset", ex.ToString());
            }
        }

        public void EmailExcel()
        {
            try
            {
                mail.EmailAttachmentToEmailList(excelFile);
            }
            catch (Exception ex)
            {
                mail.SendErrorEmails("Emailing Attachment", ex.ToString());
            }
        }
    }
}
