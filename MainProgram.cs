using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace 傑偲單據修改紀錄查詢
{
    public partial class MainProgram : Form
    {
        string SQLCon = Properties.Settings.Default["OpenSQL"].ToString();
        string SQLComm = "";
        string[] SPO_ID = { "SPOdDebitMain", "SPOdInvoiceMain","SPOdOrderMain","SPOdOutMain","SPOdRejectMain",
            "SPOdServiceMain" };
        string[] SPO_Name = { "折讓單", "發票作業", "備料單", "出貨單", "退貨單", "服務單" };
        string[] FOS_ID = { "FOSdDebitMain", "FOSdInvoiceMain", "FOSdOrderMain", "FOSdReceiveMain",
            "FOSdRwkPenaltyMain", "FOSdScrapMain" };
        string[] FOS_Name = { "折讓單", "對帳單", "加工單", "進貨單", "重工扣款單", "報廢扣款單" };
        DataSet Read = new DataSet();
        DataTable result = new DataTable();

        /// <summary>
        /// 限制TextBox只能輸入英文和數字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextOnlyEN(object sender, KeyPressEventArgs e)
        {
            int keyChar = (int)e.KeyChar;
            int bk = (int)Keys.Back;
            int aChar = (int)'a';//97
            int zChar = (int)'z';//122
            int AChar = (int)'A';//65
            int ZChar = (int)'Z';//90
            int zero = (int)'0';//48
            int night = (int)'9';//57
            if ((keyChar >= aChar && keyChar <= zChar) || (keyChar >= AChar && keyChar <= ZChar) ||
                (keyChar >= zero && keyChar <= night) ||
                keyChar == bk)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 以設立的條件下去查詢，並傳回帶有查詢結果的DataTable
        /// </summary>
        /// <param name="DateStart">起始日期</param>
        /// <param name="DateEnd">結束日期</param>
        /// <param name="PaperId">單據ID</param>
        /// <param name="UserId">使用者ID</param>
        /// <returns></returns>
        private DataTable SelectToDB(string DateStart,string DateEnd,string PaperId,string PaperNum,string UserId)
        {
            if (UserId == "" & PaperNum == "")
            {
                SQLComm = "select PaperNum,SerialNum,UserId,UpdateTime,Difference from CURdPaperLog where " +
                    "PaperId = '" + PaperId + "' and UpdateTime between '" + DateStart + "' and '" + DateEnd + "' " +
                    "order by PaperNum,SerialNum asc";
            }
            else if (UserId != "" & PaperNum == "")
            {
                SQLComm = "select PaperNum,SerialNum,UserId,UpdateTime,Difference from CURdPaperLog where " +
                    "PaperId = '" + PaperId + "' and UpdateTime between '" + DateStart + "' and '" + DateEnd + "' " +
                    "and UserId='" + UserId + "' order by PaperNum,SerialNum asc";
            }
            else if(UserId=="" & PaperNum!="")
            {
                SQLComm = "select PaperNum,SerialNum,UserId,UpdateTime,Difference from CURdPaperLog where " +
                    "PaperNum='" + PaperNum + "' order by PaperNum,SerialNum asc";
            }
            else
            {
                SQLComm = "select PaperNum,SerialNum,UserId,UpdateTime,Difference from CURdPaperLog where " +
                    "UserId='" + UserId + "' and PaperNum='" + PaperNum + "' order by PaperNum,SerialNum asc";
            }
            //重新載入資料前，先將Table清空
            result.Clear();
            using (SqlConnection sqlcon = new SqlConnection(SQLCon))
            {
                using (SqlDataAdapter Load = new SqlDataAdapter(SQLComm, sqlcon))
                {
                    Load.Fill(Read, "Result");
                }
            }
            return Read.Tables["Result"];
        }

        /// <summary>
        /// DataGridView Data Output to Excel
        /// </summary>
        private void OutputToExcel()
        {
            //DataGridView沒有資料就不執行
            if (dgvDataShow.Rows.Count <= 1)
            {
                MessageBox.Show("沒有可滙出的資料！", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else
            {
                //建一個excel物件
                Excel._Application excel = new Excel.Application();
                //建一個excel物件下的工作簿
                Excel._Workbook workbook = excel.Workbooks.Add();
                //建二個excel物件下的工作表
                Excel._Worksheet worksheet1 = excel.Worksheets.Add();
                try
                {
                    string Date = DateTime.Now.ToString("yyyy-MM-dd");
                    string UserDesktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                    string SaveFilePath = UserDesktop + @"\" + Date + ".xls";//檔案儲存的路徑
                    //Set Excel Sheet Name
                    worksheet1.Name = cboPaperId.Text + "_修改查詢";

                    //Call ProgressBar Window and Set Default Values
                    PGB pgb = new PGB();
                    pgb.progressBar1.Minimum = 0;
                    pgb.progressBar1.Maximum = dgvDataShow.Columns.Count + (dgvDataShow.Rows.Count - 1);
                    pgb.progressBar1.Step = 1;
                    pgb.progressBar1.Value = 0;
                    pgb.progressBar1.Style = ProgressBarStyle.Continuous;
                    pgb.Show();

                    //填入dgvWPRshow欄位名稱至worksheet1
                    for (int i = 0; i < dgvDataShow.Columns.Count; i++)
                    {
                        worksheet1.Cells[1, i + 1] = dgvDataShow.Columns[i].HeaderText;
                        pgb.progressBar1.Value++;
                        Application.DoEvents();
                    }
                    //填入dgvWPRshow資料至worksheet1
                    for (int i = 0; i < dgvDataShow.Rows.Count - 1; i++)
                    {
                        pgb.progressBar1.Value++;
                        Application.DoEvents();
                        for (int j = 0; j < dgvDataShow.Columns.Count; j++)
                        {
                            if (dgvDataShow[j, i].ValueType == typeof(string))
                            {
                                worksheet1.Cells[i + 2, j + 1] = "'" + dgvDataShow[j, i].Value.ToString();
                            }
                            else
                            {
                                worksheet1.Cells[i + 2, j + 1] = dgvDataShow[j, i].Value.ToString();
                            }
                        }
                    }
                    
                    //設定滙出後，欄位寛度自動配合資料調整
                    worksheet1.Cells.EntireRow.AutoFit();
                    //自動調整列高
                    worksheet1.Cells.EntireColumn.AutoFit();
                                                           
                    //設置禁止彈出覆蓋或儲存的彈跳視窗
                    excel.DisplayAlerts = false;
                    excel.AlertBeforeOverwriting = false;
                    //將檔案儲存到SaveFile指定的位置，儲存前先判斷系統上的Office版本號
                    if (excel.Application.Version == "11.0")//Office 2003
                    {
                        excel.ActiveWorkbook.SaveAs(SaveFilePath);
                    }
                    else
                    {
                        //Office 2003 Up，FileFormat: Excel.XlFileFormat.xlExcel8=>指定Excel 2003 xls格式
                        excel.ActiveWorkbook.SaveAs(SaveFilePath, FileFormat: Excel.XlFileFormat.xlExcel8);
                    }
                    pgb.Close();
                    MessageBox.Show("已將資料滙出並存放置" + SaveFilePath, "訊息", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    //關閉工作簿和結束Excel程式
                    workbook.Close();
                    excel.Quit();
                    //釋放資源
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                    excel = null;
                    workbook = null;
                    worksheet1 = null;
                    GC.Collect();
                }
            }
        }

        /// <summary>
        /// Converts the DataGridView to DataTable
        /// </summary>
        /// <param name="dgv">DataGridView Name</param>
        /// <param name="tblName"></param>
        /// <param name="minRow"></param>
        /// <returns></returns>
        private DataTable DataGridViewToDataTable(DataGridView dgv, String tblName = "", int minRow = 0)
        {
            DataTable dt = new DataTable();
            PGB pgb = new PGB();
            pgb.progressBar1.Minimum = 0;
            pgb.progressBar1.Maximum = dgvDataShow.Columns.Count + dgvDataShow.Rows.Count;
            pgb.progressBar1.Step = 1;
            pgb.progressBar1.Value = 0;
            pgb.progressBar1.Style = ProgressBarStyle.Continuous;
            pgb.Show();
            // Header columns  
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                pgb.progressBar1.Value++;
                Application.DoEvents();
                DataColumn dc = new DataColumn(column.HeaderText.ToString());
                dt.Columns.Add(dc);
            }
            // Data cells  
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                pgb.progressBar1.Value++;
                Application.DoEvents();
                DataGridViewRow row = dgv.Rows[i];
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    dr[j] = (row.Cells[j].Value == null) ? "" : row.Cells[j].Value.ToString();
                }
                dt.Rows.Add(dr);
            }
            // Related to the bug arround min size when using ExcelLibrary for export  
            for (int i = dgv.Rows.Count; i < minRow; i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    dr[j] = " ";
                }
                dt.Rows.Add(dr);
            }
            pgb.Close();
            return dt;
        }

        public MainProgram()
        {
            InitializeComponent();
            this.Hide();
            Login log = new Login();
            if(log.ShowDialog()==DialogResult.OK)
            {
                this.Show();
                log.Dispose();
            }
            dgvDataShow.ReadOnly = true;
        }

        private void rdoSPO_CheckedChanged(object sender, EventArgs e)
        {
            cboPaperId.DataSource = SPO_Name;
            cboPaperId.DisplayMember = SPO_Name[0];
            cboPaperId.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void rdoFOS_CheckedChanged(object sender, EventArgs e)
        {
            cboPaperId.DataSource = FOS_Name;
            cboPaperId.DisplayMember = FOS_Name[0];
            cboPaperId.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnRefer_Click(object sender, EventArgs e)
        {
            string paper = "";
            if (rdoSPO.Checked == true)
            {
                for (int i = 0; i < SPO_Name.Count(); i++)
                {
                    if (cboPaperId.Text == SPO_Name[i])
                    {
                        paper = SPO_ID[i];
                    }
                }
            }
            else if (rdoFOS.Checked == true)
            {
                for (int i = 0; i < FOS_Name.Count(); i++)
                {
                    if (cboPaperId.Text == FOS_Name[i])
                    {
                        paper = FOS_ID[i];
                    }
                }
            }
            result = SelectToDB(dtpStartDate.Value.ToString("yyyy-MM-dd 00:00:00"), dtpEndDate.Value.ToString
                ("yyyy-MM-dd 23:59:59"), paper, txtPaperNum.Text.Trim(), txtUserId.Text.Trim());
            dgvDataShow.DataSource = result;
            dgvDataShow.Columns["PaperNum"].HeaderText = "單據號碼";
            dgvDataShow.Columns["SerialNum"].HeaderText = "順序";
            dgvDataShow.Columns["UserId"].HeaderText = "人員";
            dgvDataShow.Columns["UpdateTime"].HeaderText = "修改時間";
            dgvDataShow.Columns["Difference"].HeaderText = "修改內容";
            dgvDataShow.Columns[0].Width = 80;
            dgvDataShow.Columns[1].Width = 60;
            dgvDataShow.Columns[2].Width = 60;
            dgvDataShow.Columns[3].Width = 130;
            dgvDataShow.Columns[4].Width = 800;
            for(int i=0;i<=3;i++)
            {
                dgvDataShow.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvDataShow.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (i < 3)
                {
                    dgvDataShow.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else
                {
                    dgvDataShow.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUserId.Text = "";
            txtPaperNum.Text = "";
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (dgvDataShow.Rows.Count <= 1)
            {
                MessageBox.Show("沒有可滙出的資料！", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else
            {
                DataSet ds = new DataSet();
                DataTable rpt = new DataTable();
                rpt = DataGridViewToDataTable(dgvDataShow);
                ds.Tables.Add(rpt);
                ds.WriteXmlSchema("rpt.xml");
                try
                {
                    CrystalReport1 cr = new CrystalReport1();
                    cr.SetDataSource(ds);
                    Report rp = new Report();
                    rp.crystalReportViewer1.ReportSource = cr;
                    rp.Show();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            OutputToExcel();
        }
    }
}
