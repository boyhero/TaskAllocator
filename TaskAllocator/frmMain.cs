using System;
using System.Collections.Generic;
using System.Threading;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
//using System.Math; //引入数学库命名空间

namespace TaskAllocator
{
    public partial class frmMain : Form
    {
        //下面定义Excel应用程序对象,以便嵌入窗口
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static IntPtr SetParent(IntPtr hChild, IntPtr hParent);

        [DllImport("User32.dll")]
        public static extern int GetWindowThreadProcessId(IntPtr hWnd, out int ProcessId);

        static Excel.Application app = new Excel.Application();
        static IntPtr hwnd = (IntPtr)app.Hwnd;

        string strTmpFileName = "";
        //string BestOutComeSolutionFileName = ""; //最佳产出方案文件
        //string BestOutcomeResRatioSolutionFileName = ""; //最佳收益率方案文件
        int MaxSrcPerDay = 30;   //每天最大可投入人日
        int TaskNumber = 0;  //总任务数
        double SolutionNumber = 0;  //总方案数，不能定义为int，因为int的范围可能不能容纳导致溢出
        /*


        */

        List<List<PrjTask>> SolutionList = new List<List<PrjTask>>(); //可行解决方案列表

        List<PrjTask> BestOutComeSolution = new List<PrjTask>(); //最佳产出方案
        List<PrjTask> BestOutcomeResRatioSolution = new List<PrjTask>(); //最佳收益率方案

        static Excel.Application BestOutComeSolutionApp = new Excel.Application();
        static IntPtr BestOutComeSolutionApphwnd = (IntPtr)BestOutComeSolutionApp.Hwnd;

        static Excel.Application BestOutcomeResRatioSolutionApp = new Excel.Application();
        static IntPtr BestOutcomeResRatioSolutionApphwnd = (IntPtr)BestOutcomeResRatioSolutionApp.Hwnd;

        double MaxOutcome = 0; //最大产出
        double MaxOutcomeResRatio = 0; //最大收益率

        private void KillExcel(Microsoft.Office.Interop.Excel.Application theApp)
        {
            int id = 0;
            IntPtr intptr = new IntPtr(theApp.Hwnd);
            //app.Quit();
            //IntPtr intptr = frmMain.hwnd;
            System.Diagnostics.Process p = null;
            try
            {
                GetWindowThreadProcessId(intptr, out id);
                p = System.Diagnostics.Process.GetProcessById(id);
                if (p != null)
                {
                    p.Kill();
                    p.Dispose();
                }
            }
            catch (Exception)
            {

            }
        }

        private void KillExcelByPointer(IntPtr intptr)
        {
            int id = 0;
            //IntPtr intptr = new IntPtr(theApp.Hwnd);
            //app.Quit();
            //IntPtr intptr = frmMain.hwnd;
            System.Diagnostics.Process p = null;
            try
            {
                GetWindowThreadProcessId(intptr, out id);
                p = System.Diagnostics.Process.GetProcessById(id);
                if (p != null)
                {
                    p.Kill();
                    p.Dispose();
                }
            }
            catch (Exception)
            {

            }
        }

        public static void ResizeExcelWindow(Microsoft.Office.Interop.Excel.Application excelApp) //调整Excel窗口在它所嵌入的Panel上的填充状态使之充满Panel
        {
            if (excelApp == null)
                return;

            excelApp.WindowState = Excel.XlWindowState.xlMinimized; //先最小化
            //excelApp.WindowState = Excel.XlWindowState.xlMaximized; //再最大化
            excelApp.WindowState = Excel.XlWindowState.xlNormal; //再置为正常

            //excelApp.Width = excelApp.Parent.Width - 1;
            //excelApp.Height = excelApp.Parent.Height - 1;


            excelApp.DisplayFullScreen = true;

            excelApp.WindowState = Excel.XlWindowState.xlMinimized; //先最小化
            //excelApp.WindowState = Excel.XlWindowState.xlMaximized; //再最大化
            excelApp.WindowState = Excel.XlWindowState.xlNormal; //再置为正常




        }

        public static double Factorial(int n)  //计算阶乘
        {
            if (n == 0)
                return 1;
            if (n == 1)
                return 1;
            else
                return n * Factorial(n - 1);
        }

        public static double Combination(int m,int n)  //计算组合数,m为样本空间，n为每次取出的样本数
        {
            if (n == 0)
                return 1;
            else
                return Factorial(m)/(Factorial(n) * Factorial(m - n));
        }

        private DateTime GetEarlyStartTime(List<PrjTask> SolutionTask)  //取得方案最早开始时间
        {
            DateTime dt = DateTime.Now;
            for (int i = 0; i < SolutionTask.Count; i++)
            { 
                if (0 == i) //如果是第一个任务
                {
                    dt = SolutionTask[i].ExpectStartDate;                   
                
                }
                    
                else
                {
                    if (dt > SolutionTask[i].ExpectStartDate)
                    {
                        dt = SolutionTask[i].ExpectStartDate;
                    
                    }
                    
                        
                }
                
            
            }
            return dt;
        }

        private DateTime GetLatestFinishTime(List<PrjTask> SolutionTask)  //取得方案最晚完成时间
        {
            DateTime dt = DateTime.Now;
            for (int i = 0; i < SolutionTask.Count; i++)
            {
                if (0 == i) //如果是第一个任务
                {
                    dt = SolutionTask[i].ExpectFinishDate;

                }

                else
                {
                    if (dt < SolutionTask[i].ExpectFinishDate)
                    {
                        dt = SolutionTask[i].ExpectFinishDate;

                    }


                }


            }
            return dt;
        }

        private double GetSolutionDayRes(List<PrjTask> SolutionTask,DateTime Day)  //取得方案在指定日期的工作量投入
        {
            double DayRes = 0;
            for (int i = 0; i < SolutionTask.Count; i++)
            {
                DayRes += SolutionTask[i].GetTaskDayRes(Day);

            }
            return DayRes;
            
        }

        private double GetTotalSolutionRes(List<PrjTask> SolutionTask)  //取得方案总工作量投入
        {
            double Res = 0;
            for (int i = 0; i < SolutionTask.Count; i++)
            {
                Res += SolutionTask[i].TotalResNeeded;

            }
            return Res;

        }

        private double GetTotalSolutionOutcome(List<PrjTask> SolutionTask)  //取得方案总产出
        {
            double Outcome = 0;
            for (int i = 0; i < SolutionTask.Count; i++)
            {
                Outcome += SolutionTask[i].Outcome;

            }
            return Outcome;

        }

        private double GetSolutionOutcomeResRatio(List<PrjTask> SolutionTask)  //取得方案收益率
        {
            try
            {
                return GetTotalSolutionOutcome(SolutionTask) / GetTotalSolutionRes(SolutionTask);

            }
            catch (Exception)
            {

                MessageBox.Show("计算方案收益率出错，请检查是否该方案的总投入为零或数据有误！");
                return 0;
            }
            

        }

        /////////////////////////////////////////////////////////////////////////////////////
        ///创建给定方案的Excel文件
        private string CreateSlnExcelFile(List<PrjTask> SolutionTask, string TexcelFilePath) //TexcelFilePath为解决方案的Excel模板文件路径
        {
            Excel.Application app = new Excel.Application();
            Excel.Sheets sheets;
            Excel.Workbook workbook = null;
            object oMissiong = System.Reflection.Missing.Value;
            

            

            try
            {
                if (app == null)
                {
                    return null;
                }
                string SolutionFileName = Application.StartupPath + @"\TaskFiles\" + "Solution" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx";
                File.Copy(TexcelFilePath, @SolutionFileName, true); //免于资源争用
                workbook = app.Workbooks.Open(@SolutionFileName, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong);

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

                
                Excel.Range range;

                
                for (int i = 0; i < SolutionTask.Count; i++)
                {
                    range = (Excel.Range)worksheet.Cells[i+2, 1];
                    range.Value = SolutionTask[i].ProjectName;

                    range = (Excel.Range)worksheet.Cells[i + 2, 2];
                    range.Value = SolutionTask[i].ExpectStartDate;

                    range = (Excel.Range)worksheet.Cells[i + 2, 3];
                    range.Value = SolutionTask[i].ExpectFinishDate;

                    range = (Excel.Range)worksheet.Cells[i + 2, 4];
                    range.Value = SolutionTask[i].TotalResNeeded;

                    range = (Excel.Range)worksheet.Cells[i + 2, 5];
                    range.Value = SolutionTask[i].Outcome;

                    

                    /*
                    (Excel.Range)worksheet.Cells[i, 1].Value = SolutionTask[i].ProjectName;
                    (Excel.Range)worksheet.Cells[i, 2].Value = SolutionTask[i].ExpectStartDate;
                    (Excel.Range)worksheet.Cells[i, 3].Value = SolutionTask[i].ExpectFinishDate;
                    (Excel.Range)worksheet.Cells[i, 4].Value = SolutionTask[i].TotalResNeeded;
                    (Excel.Range)worksheet.Cells[i, 5].Value = SolutionTask[i].Outcome;
                     */

                }


                //SolutionFileName = Application.StartupPath + @"\TaskFiles\" + "Solution" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx"; //根据最新时间生成一个新的文件名，以免提示覆盖
                //workbook.Save(@SolutionFileName, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, Excel.XlSaveAsAccessMode.xlNoChange, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong);
                workbook.Save(); //保存结果
                return SolutionFileName;

                
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
        ///创建给定方案的Excel文件end
        /////////////////////////////////////////////////////////////////////////////////////


        public frmMain()
        {
            InitializeComponent();
        }

        private void btnBrouse_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtTaskFile.Text = this.openFileDialog1.FileName;

            }
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            if (cbMaxSrcPerDay.Text.Trim().Length < 1)
            {
                MessageBox.Show("每日最大可投人天不能为空");

                return;
            }            

            try
            {
                MaxSrcPerDay = int.Parse(cbMaxSrcPerDay.Text.Trim());
            }
            catch (Exception)
            {

                MessageBox.Show("每日最大可投人天格式不对，应为合法整数，请重新输入");
                
                return;
            }

            if (txtTaskFile.Text.Trim().Length < 1)
            {
                MessageBox.Show("任务文件不能为空");

                return;
            }

            //重置界面元素
            label6.Text = "最早开始时间：";
            label5.Text = "最早结束时间：";
            label13.Text = "最晚结束时间：";
            label10.Text = "最具性价比任务：";
            label8.Text = "总任务数vs总工作量：";
            label7.Text = "平均每个任务的收益：";
            toolStripStatusLabel1.Text = "总计方案数：（1，n）C（N，i）=";
            label1.Text = "本方案绝对收益为：";
            label2.Text = "本方案收益率为：";
            label4.Text = "本方案绝对收益为：";
            label3.Text = "本方案收益率为：";
            label15.Text = "本方案开始时间为：";
            label14.Text = "本方案结束时间为：";
            label17.Text = "本方案开始时间为：";
            label16.Text = "本方案结束时间为：";
            //重置全局结果
            SolutionNumber = 0;  //总方案数
            TaskNumber = 0;  //总任务数
            MaxOutcome = 0; //最大产出
            MaxOutcomeResRatio = 0; //最大收益率
            //先清理后台资源
            frmMain_FormClosing(sender, null);

            //先load文件
            if (!Directory.Exists(Application.StartupPath + @"\TaskFiles"))
            {
                Directory.CreateDirectory(Application.StartupPath + @"\TaskFiles");
            }
            //首先copy待上传文件到临时文件夹，以免资源争用
            strTmpFileName = Application.StartupPath + @"\TaskFiles\" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx";
            File.Copy(txtTaskFile.Text.Trim(), @strTmpFileName, true);

            if (app == null)
            {
                app = new Excel.Application();
                hwnd = (IntPtr)app.Hwnd;
            }
            
            dynamic workBook = app.Workbooks.Open(@strTmpFileName);            
            workBook.Activate();
            app.Visible = true;
            SetParent(hwnd, splitContainerTask.Panel2.Handle);            
            ResizeExcelWindow(app);

            //解析任务文件
            TaskFile tskFile = new TaskFile(@strTmpFileName);

            //创建任务对象数组（其每一个元素是一个任务对象）
            List<PrjTask> PrjTaskList = new List<PrjTask>();

            //定义任务的一系列基本信息
            DateTime EarlyExpectStartDate = DateTime.Now; //最早开始时间
            DateTime EarlyExpectFinishDate = DateTime.Now; //最早结束时间
            DateTime LatestExpectFinishDate = DateTime.Now; //最晚结束时间
            double BestOutcomeResRatio = 0; //最佳收益率
            double AllTaskTotalResNeeded = 0; //所有任务总计工作量
            double AllTaskTotalOutcome = 0; //所有任务总收益
            double AvgOutcomeResRatio = 0; //平均收益率
            string BestORRprjName = ""; //最佳收益率项目名称
            //根据任务文件所含任务数初始化任务对象
            for (int i = 0; i < tskFile.dataTable.Rows.Count; i++) //按行循环，注意解析时已自动去掉了第一行（第一行不是数据而是标头）
            {
                string ProjectName = System.Text.RegularExpressions.Regex.Replace(tskFile.dataTable.Rows[i][tskFile.dataTable.Columns[0]].ToString().Trim(), "[(,)]", "");
                string sExpectStartDate = System.Text.RegularExpressions.Regex.Replace(tskFile.dataTable.Rows[i][tskFile.dataTable.Columns[1]].ToString().Trim(), "[(,)]", "");
                if (ProjectName.Length < 1 || sExpectStartDate.Length < 1) //遇到无效数据
                    break;
                DateTime ExpectStartDate = DateTime.Parse(sExpectStartDate);
                string sExpectFinishDate = System.Text.RegularExpressions.Regex.Replace(tskFile.dataTable.Rows[i][tskFile.dataTable.Columns[2]].ToString().Trim(), "[(,)]", "");
                DateTime ExpectFinishDate = DateTime.Parse(sExpectFinishDate);

                double TotalResNeeded = (double.Parse(System.Text.RegularExpressions.Regex.Replace(tskFile.dataTable.Rows[i][tskFile.dataTable.Columns[3]].ToString().Trim(), "[(,)]", "")));
                double Outcome = (double.Parse(System.Text.RegularExpressions.Regex.Replace(tskFile.dataTable.Rows[i][tskFile.dataTable.Columns[4]].ToString().Trim(), "[(,)]", "")));

                PrjTask aPrjTask = new PrjTask(ProjectName, ExpectStartDate, ExpectFinishDate, TotalResNeeded, Outcome);             
                PrjTaskList.Add(aPrjTask);

                if (0 == i) //如果是第一个任务
                {
                    EarlyExpectStartDate = ExpectStartDate; //先给初始值
                    EarlyExpectFinishDate = ExpectFinishDate; //先给初始值
                    LatestExpectFinishDate = ExpectFinishDate; //先给初始值
                    BestOutcomeResRatio = aPrjTask.OutcomeResRatio;
                    BestORRprjName = aPrjTask.ProjectName;
                
                }
                    
                else
                {
                    if (ExpectStartDate < EarlyExpectStartDate)
                        EarlyExpectStartDate = ExpectStartDate;

                    if (ExpectFinishDate < EarlyExpectFinishDate)
                        EarlyExpectFinishDate = ExpectFinishDate;
                    else
                        LatestExpectFinishDate = ExpectFinishDate;

                    if (aPrjTask.OutcomeResRatio > BestOutcomeResRatio)
                    {
                        BestORRprjName = aPrjTask.ProjectName;
                        BestOutcomeResRatio = aPrjTask.OutcomeResRatio;
                    
                    }
                        
                }

                AllTaskTotalResNeeded += TotalResNeeded;
                AllTaskTotalOutcome += Outcome;
                
                


            
            }

            //PrjTaskList.Sort();

            //MessageBox.Show("第一个项目的项目名称是：" + PrjTaskList[0].ProjectName);
            //计算每个任务的平均收益
            try
            {
                AvgOutcomeResRatio = AllTaskTotalOutcome / PrjTaskList.Count;

            }
            catch (Exception ep)
            {

                MessageBox.Show("计算每个任务的平均收益出错：" + ep.ToString());
            }

            TaskNumber = PrjTaskList.Count;

            //在界面显示基本信息
            label6.Text += EarlyExpectStartDate.ToShortDateString();
            label5.Text += EarlyExpectFinishDate.ToShortDateString();
            label13.Text += LatestExpectFinishDate.ToShortDateString();
            label10.Text += BestORRprjName+":"+BestOutcomeResRatio.ToString();
            label8.Text += TaskNumber.ToString() + ":" + AllTaskTotalResNeeded.ToString();
            label7.Text += AvgOutcomeResRatio.ToString();
            
            //MessageBox.Show(Factorial(13).ToString());

            //计算理论上的总解决方案数
            for (int i = 1; i <= TaskNumber; i++)
            {
                //MessageBox.Show(Combination(TaskNumber, i).ToString());
                SolutionNumber += Combination(TaskNumber, i);
            }
            toolStripStatusLabel1.Text += SolutionNumber.ToString();

            //MessageBox.Show("最长周期天数：" + (LatestExpectFinishDate - EarlyExpectStartDate).Days);
            //MessageBox.Show("6取3个任务的解决方案数：" + Combination(6,3));
            //总计的方案数应为：（1，n）C（N，i），即从任务中分别选取1,2，...，N个任务的组合之和
            //因此分别计算不同方案，形成解决方案的组合列表
            
            
            
            List<List<PrjTask>> OriginalSolutionList = new List<List<PrjTask>>(); //初始的解决方案列表，形成一个二维的数组组合，每一个SolutionList的元素是一个SolutionTask，表示一个解决方案

            //以下依次构建包含任务数从1到N的解决方案
            for (int i = 1; i <= TaskNumber; i++) //i表示方案包含的任务数，故让其从1开始
            {
                for (int j = 0; j < PrjTaskList.Count; j++) //从j开始取
                {
                    for (int k = 0; k < i; k++ ) //循环i次
                    {
                        //定义解决方案的列表，每个解决方案SolutionTask实际上是一个PrjTaskList，而每个PrjTaskList包含数目不等的任务
                        List<PrjTask> SolutionTask = new List<PrjTask>();
                        for (int h = 0; h < i; h++)
                        {
                            if(j+h<TaskNumber) //确保下标不越界
                            SolutionTask.Add(PrjTaskList[j+h]);

                        }
                        OriginalSolutionList.Add(SolutionTask);


                    }
                     

                    
                    
                }

                //MessageBox.Show("取"+i.ToString()+"个任务的方案总数：" + SolutionList.Count.ToString());   
                           
            }

            //MessageBox.Show("目前取到的方案总数：" + SolutionList.Count.ToString());

            //过滤那些不满足约束条件（每日最大仅可投入人日）的方案，形成基本合法方案
            //从该方案最早开始日期到最晚完成日期，逐一检查每日所需投入工作量是否超标，超标则该方案被废弃
            SolutionList.Clear();//先清除最终解决方案的元素
            for (int i = 0; i < OriginalSolutionList.Count; i++)
            {
                DateTime EarlyStartTime = GetEarlyStartTime(OriginalSolutionList[i]);
                DateTime LatestFinishTime = GetLatestFinishTime(OriginalSolutionList[i]);
                for (DateTime dt = EarlyStartTime; dt <= LatestFinishTime; dt=dt.Date.AddDays(1))
                {
                    if (GetSolutionDayRes(OriginalSolutionList[i], dt) > MaxSrcPerDay) //超标了
                        break;  //已经确定超标，跳出该轮循环(后面的不用判断了)，不用加入最终列表
                    if(dt > LatestFinishTime.Date.AddDays(-1)) //直到最后一天还没有超标
                    {
                        SolutionList.Add(OriginalSolutionList[i]);                       

                    }
                    
                        


                }
            }

            if(SolutionList.Count<1)
                MessageBox.Show("根据所给任务的资源约束条件，每日最大允许投入" + MaxSrcPerDay.ToString()+"人天，无法找到任何合乎条件的方案！");
            //对每一个方案，计算其绝对收益和收益率，找出最大
            for (int i = 0; i < SolutionList.Count; i++)
            {
                
                if (0 == i) //如果是第一个方案
                {
                    BestOutComeSolution = SolutionList[i]; //先给初始值
                    MaxOutcome = GetTotalSolutionOutcome(BestOutComeSolution);
                    BestOutcomeResRatioSolution = SolutionList[i]; //先给初始值
                    MaxOutcomeResRatio = GetSolutionOutcomeResRatio(BestOutComeSolution);

                }

                else
                {
                    double CurrentOutcome = GetTotalSolutionOutcome(SolutionList[i]);
                    if (CurrentOutcome > MaxOutcome)
                    {
                        MaxOutcome = CurrentOutcome;
                        BestOutComeSolution = SolutionList[i];
                    }

                    double CurrentOutcomeResRatio = GetSolutionOutcomeResRatio(SolutionList[i]);
                    if (CurrentOutcomeResRatio > MaxOutcomeResRatio)
                    {
                        MaxOutcomeResRatio = CurrentOutcomeResRatio;
                        BestOutcomeResRatioSolution = SolutionList[i];
                    
                    }
                        
                    

                }

                

                
            }

            //以下创建解决方案的excel文件并在窗体上显示

            //显示最大收益方案
            if (BestOutComeSolutionApp == null)
            {
                BestOutComeSolutionApp = new Excel.Application();
                BestOutComeSolutionApphwnd = (IntPtr)BestOutComeSolutionApp.Hwnd;
            }
            string slnFile = CreateSlnExcelFile(BestOutComeSolution, Application.StartupPath + @"\Solution.xlsx");
            dynamic BestOutComeworkBook = BestOutComeSolutionApp.Workbooks.Open(@slnFile);
            BestOutComeworkBook.Activate();
            BestOutComeSolutionApp.Visible = true;
            SetParent(BestOutComeSolutionApphwnd, splitContainer21.Panel2.Handle);
            ResizeExcelWindow(BestOutComeSolutionApp);

            label1.Text += MaxOutcome.ToString(); //显示最大绝对收益
            label2.Text += GetSolutionOutcomeResRatio(BestOutComeSolution).ToString(); //显示最大绝对收益方案的收益率
            label15.Text += GetEarlyStartTime(BestOutComeSolution).ToShortDateString(); //显示最早开始时间
            label14.Text += GetLatestFinishTime(BestOutComeSolution).ToShortDateString(); //显示最早开始时间
            //显示最佳收益率方案
            if (BestOutcomeResRatioSolutionApp == null)
            {
                BestOutcomeResRatioSolutionApp = new Excel.Application();
                BestOutcomeResRatioSolutionApphwnd = (IntPtr)BestOutcomeResRatioSolutionApp.Hwnd;
            }

            dynamic BestOutcomeResRatioworkBook = BestOutcomeResRatioSolutionApp.Workbooks.Open(@CreateSlnExcelFile(BestOutcomeResRatioSolution, Application.StartupPath + @"\Solution.xlsx"));
            BestOutcomeResRatioworkBook.Activate();
            BestOutcomeResRatioSolutionApp.Visible = true;
            SetParent(BestOutcomeResRatioSolutionApphwnd, splitContainer22.Panel2.Handle);
            ResizeExcelWindow(BestOutcomeResRatioSolutionApp);

            label3.Text += MaxOutcomeResRatio.ToString(); //显示最大收益率
            label4.Text += GetTotalSolutionOutcome(BestOutcomeResRatioSolution).ToString(); //显示最大收益率方案的收益
            label17.Text += GetEarlyStartTime(BestOutcomeResRatioSolution).ToShortDateString(); //显示最早开始时间
            label16.Text += GetLatestFinishTime(BestOutcomeResRatioSolution).ToShortDateString(); //显示最早开始时间


            

        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill(); //彻底退出程序
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (app == null)
            {
                //删除临时文件
                if (File.Exists(@strTmpFileName))
                {
                    //
                    try
                    {
                        File.Delete(@strTmpFileName);
                    }
                    catch (Exception)
                    {
                        //Thread.Sleep(2000); //等待2秒，让后台的Excel进程有机会彻底退出
                        //File.Delete(@strTmpFileName);
                        //throw;
                    }

                }
                //return;
            }

            //把动态创建的后台Excel进程Kill掉
            //System.Runtime.InteropServices.Marshal.ReleaseComObject(app);

            KillExcel((Excel.Application)app);

            app = null;


            //////////////
            //清理最大收益的excel进程
            if (BestOutComeSolutionApp == null)
            {
                //删除临时文件
                if (File.Exists(@strTmpFileName))
                {
                    //
                    try
                    {
                        File.Delete(@strTmpFileName);
                    }
                    catch (Exception)
                    {
                        //Thread.Sleep(2000); //等待2秒，让后台的Excel进程有机会彻底退出
                        //File.Delete(@strTmpFileName);
                        //throw;
                    }

                }
                //return;
            }

            //把动态创建的后台Excel进程Kill掉
            //System.Runtime.InteropServices.Marshal.ReleaseComObject(BestOutComeSolutionApp);

            KillExcel((Excel.Application)BestOutComeSolutionApp);
            //KillExcelByPointer(new IntPtr(BestOutComeSolutionApp.Hwnd));

            BestOutComeSolutionApp = null;

            ////////////////////////////////////////////////////////////

            //////////////
            //清理最大收益率的excel进程
            if (BestOutcomeResRatioSolutionApp == null)
            {
                //删除临时文件
                if (File.Exists(@strTmpFileName))
                {
                    //
                    try
                    {
                        File.Delete(@strTmpFileName);
                    }
                    catch (Exception)
                    {
                        //Thread.Sleep(2000); //等待2秒，让后台的Excel进程有机会彻底退出
                        //File.Delete(@strTmpFileName);
                        //throw;
                    }

                }
                //return;
            }

            //把动态创建的后台Excel进程Kill掉
            //System.Runtime.InteropServices.Marshal.ReleaseComObject(BestOutcomeResRatioSolutionApp);

            KillExcel((Excel.Application)BestOutcomeResRatioSolutionApp);

            BestOutcomeResRatioSolutionApp = null;

            ////////////////////////////////////////////////////////////


            //删除临时文件
            if (File.Exists(@strTmpFileName))
            {
                //
                try
                {
                    File.Delete(@strTmpFileName);
                }
                catch (Exception)
                {
                    //Thread.Sleep(2000); //等待2秒，让后台的Excel进程有机会彻底退出
                    //File.Delete(@strTmpFileName);
                    //throw;
                }

            }

            try
            {
                //清空临时文件夹
                Directory.Delete(Application.StartupPath + @"\TaskFiles", true);
                Directory.CreateDirectory(Application.StartupPath + @"\TaskFiles");
            }
            catch (Exception)
            {
                if (!Directory.Exists(Application.StartupPath + @"\TaskFiles"))
                {
                    Directory.CreateDirectory(Application.StartupPath + @"\TaskFiles");
                }
                //其他暂时没有办法做什么
            }



            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            //把窗体最大化
            this.WindowState = FormWindowState.Maximized;
        }

        private void splitContainerTask_Panel2_SizeChanged(object sender, EventArgs e)
        {
            if (frmMain.app == null)
                return;
            if (frmMain.app.Visible)
                ResizeExcelWindow(frmMain.app);
        }

        private void splitContainer21_Panel2_SizeChanged(object sender, EventArgs e)
        {
            
            if (BestOutComeSolutionApp == null)
                return;
            if (BestOutComeSolutionApp.Visible)
                ResizeExcelWindow(BestOutComeSolutionApp);
        }

        private void splitContainer22_Panel2_SizeChanged(object sender, EventArgs e)
        {
            if (BestOutcomeResRatioSolutionApp == null)
                return;
            if (BestOutcomeResRatioSolutionApp.Visible)
                ResizeExcelWindow(BestOutcomeResRatioSolutionApp);
        }
    }
}
