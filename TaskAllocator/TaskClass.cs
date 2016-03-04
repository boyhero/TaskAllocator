using System;
using System.Collections.Generic;
using System.Threading;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace TaskAllocator
{
    class TaskFile
    {
        
        public string TaskFileName;
        public DataTable dataTable = null; //由于任务表同一个表含有多条纪录，解析的数据放在此虚拟表对象中，待后续使用

        public TaskFile()
        {

        }



        public TaskFile(string TaskFileName)
        {
            this.TaskFileName = TaskFileName;
            //开始解析文件
            dataTable = GetExcelData(@TaskFileName);
            if (dataTable == null)
            {
                MessageBox.Show("文件内容无法按规则解析，请确保任务文件合乎格式及数据完整性要求！");
                return;
            }

        }

        /////////////////////////////////////////////////////////////////////////////////////
        ///解析Excel文件的方法
        private System.Data.DataTable GetExcelData(string excelFilePath)
        {
            Excel.Application app = new Excel.Application();
            Excel.Sheets sheets;
            Excel.Workbook workbook = null;
            object oMissiong = System.Reflection.Missing.Value;
            System.Data.DataTable dt = new System.Data.DataTable();

            //wath.Start();

            try
            {
                if (app == null)
                {
                    return null;
                }

                workbook = app.Workbooks.Open(excelFilePath, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong);

                if (workbook == null)
                {
                    MessageBox.Show("Can't create Excel COM Object, please check to see if you have already installed Microsoft Excel 2010 or higher.");
                    return null;


                }
                //将数据读入到DataTable中——Start   

                sheets = workbook.Worksheets;
                Excel.Worksheet worksheet = (Excel.Worksheet)sheets.get_Item(1);//读取第一张表
                if (worksheet == null)
                    return null;

                string cellContent;
                int iRowCount = worksheet.UsedRange.Rows.Count;
                int iColCount = worksheet.UsedRange.Columns.Count;
                Excel.Range range;

                //负责列头Start
                DataColumn dc;
                int ColumnID = 1;
                range = (Excel.Range)worksheet.Cells[1, 1];
                while (range.Text.ToString().Trim() != "")
                {
                    dc = new DataColumn();
                    dc.DataType = System.Type.GetType("System.String");
                    dc.ColumnName = range.Text.ToString().Trim();
                    dt.Columns.Add(dc);

                    range = (Excel.Range)worksheet.Cells[1, ++ColumnID];
                }
                //End

                for (int iRow = 2; iRow <= iRowCount; iRow++)
                {
                    DataRow dr = dt.NewRow();

                    for (int iCol = 1; iCol <= iColCount; iCol++)
                    {
                        range = (Excel.Range)worksheet.Cells[iRow, iCol];

                        cellContent = (range.Value2 == null) ? "" : range.Text.ToString();

                        //if (iRow == 1)
                        //{
                        //    dt.Columns.Add(cellContent);
                        //}
                        //else
                        //{
                        dr[iCol - 1] = cellContent;
                        //}
                    }

                    //if (iRow != 1)
                    dt.Rows.Add(dr);
                }

                //wath.Stop();
                //TimeSpan ts = wath.Elapsed;

                //将数据读入到DataTable中——End
                return dt;
            }
            catch
            {

                return null;
            }
            finally
            {
                if (workbook == null)
                {
                    MessageBox.Show("Can't create Excel COM Object, please check to see if you have already installed Microsoft Excel 2010 or higher.");

                }
                else
                {
                    workbook.Close(false, oMissiong, oMissiong);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                    workbook = null;
                }

                app.Workbooks.Close();
                app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                app = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
        ///解析Excel文件的方法end
        /////////////////////////////////////////////////////////////////////////////////////


    }  

    class TaskBase
    {
        public string ProjectName;
        public DateTime ExpectStartDate;
        public DateTime ExpectFinishDate;
        public double TotalResNeeded;
        public double Outcome;
        public int DurationDays; //任务持续天数（基于一旦开始就不中断的假设,最后一日算可用天数）
        public double AvgResPerDay; //平均每日投入工作量（基于一旦开始就不中断的假设）
        //public string TaskFileName;
        






        public TaskBase()
        {

        }



        public TaskBase(string ProjectName, DateTime ExpectStartDate, DateTime ExpectFinishDate, double TotalResNeeded, double Outcome)
        {
            this.ProjectName = ProjectName;
            this.ExpectStartDate = ExpectStartDate;
            this.ExpectFinishDate = ExpectFinishDate;
            this.TotalResNeeded = TotalResNeeded;
            this.Outcome = Outcome;
            this.DurationDays = (ExpectFinishDate - ExpectStartDate).Days+1; //完成当天也算可用工作日，故加1
            this.AvgResPerDay = TotalResNeeded / DurationDays;          
            
        }

        public double GetTaskDayRes(DateTime theDay)
        {
            if (theDay < ExpectStartDate || theDay > ExpectFinishDate)
                return 0;
            else
                return this.AvgResPerDay;

        }

        

        
    }



    class PrjTask : TaskBase
    {

        
        public double OutcomeResRatio = 0; //任务自身的收益率（性价比）

        public PrjTask(string ProjectName, DateTime ExpectStartDate, DateTime ExpectFinishDate, double TotalResNeeded, double Outcome)
            : base(ProjectName, ExpectStartDate, ExpectFinishDate, TotalResNeeded, Outcome)
        {
            try
            {
                this.OutcomeResRatio = Outcome / TotalResNeeded;  

            }
            catch (Exception)
            {

                MessageBox.Show("请检查数据，确保所需工作量及产出数据合法！");
                return;
            }
                   
    
        }



    }

    

}
