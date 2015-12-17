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
    public partial class Login : Form
    {
        private string SQLCon = Properties.Settings.Default["OpenSQL"].ToString();
        private string SQLComm = "";
        public string UserID = "";
        public Login()
        {
            InitializeComponent();
        }

        private void LoginForm_FormClosing(object sender,FormClosingEventArgs e)
        {
            if (UserID == "")
            {
                Application.Exit();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUserName.Text=="" | txtPassword.Text=="")
            {
                MessageBox.Show("帳號和密碼不可為空白！", "提示訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SQLComm = "select UserId from CURdUsers where UserId='" + txtUserName.Text + "' and UserPassword " +
                    "collate Chinese_Taiwan_Stroke_CS_AS='" + txtPassword.Text + "'";
                using (SqlConnection sqlcon = new SqlConnection(SQLCon))
                {
                    sqlcon.Open();
                    using (SqlCommand sqlcomm = new SqlCommand(SQLComm, sqlcon))
                    {
                        SqlDataReader reader = sqlcomm.ExecuteReader();
                        if(reader.HasRows)
                        {
                            DialogResult = DialogResult.OK;
                            reader.Read();
                            UserID = reader.GetValue(0).ToString();
                        }
                        else
                        {
                            MessageBox.Show("帳號或密碼錯誤！", "提示訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
