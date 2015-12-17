using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

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
        int TotalPage = 0;
        int CurrentPageIndex = 1;
        int PageSize = 20;

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
            DataSet Read = new DataSet();
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
            using (SqlConnection sqlcon = new SqlConnection(SQLCon))
            {
                using (SqlDataAdapter Load = new SqlDataAdapter(SQLComm, sqlcon))
                {
                    Load.Fill(Read, "Result");
                }
            }
            return Read.Tables["Result"];
        }


        private void CalcuateTotalPages(DataTable dt)
        {
            int rowCount = dt.Rows.Count;
            TotalPage = rowCount / PageSize;
            if (rowCount % PageSize > 0)
            {
                TotalPage += 1;
            }
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
            DataTable result = SelectToDB(dtpStartDate.Value.ToString("yyyy-MM-dd 00:00:00"), dtpEndDate.Value.ToString
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
            CalcuateTotalPages(result);
            lblPageNumShow.Text = "第 0 頁／共 " + TotalPage.ToString() + " 頁";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUserId.Text = "";
            txtPaperNum.Text = "";
        }
    }
}
