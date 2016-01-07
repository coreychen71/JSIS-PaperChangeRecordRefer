namespace 傑偲單據修改紀錄查詢
{
    partial class MainProgram
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainProgram));
            this.lblPaperSystem = new System.Windows.Forms.Label();
            this.rdoSPO = new System.Windows.Forms.RadioButton();
            this.rdoFOS = new System.Windows.Forms.RadioButton();
            this.lblPaperId = new System.Windows.Forms.Label();
            this.cboPaperId = new System.Windows.Forms.ComboBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.lblUserId = new System.Windows.Forms.Label();
            this.lblUserIdNull = new System.Windows.Forms.Label();
            this.btnRefer = new System.Windows.Forms.Button();
            this.dgvDataShow = new System.Windows.Forms.DataGridView();
            this.lblPaperNum = new System.Windows.Forms.Label();
            this.txtPaperNum = new System.Windows.Forms.TextBox();
            this.lbl00 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataShow)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPaperSystem
            // 
            this.lblPaperSystem.AutoSize = true;
            this.lblPaperSystem.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblPaperSystem.Location = new System.Drawing.Point(12, 9);
            this.lblPaperSystem.Name = "lblPaperSystem";
            this.lblPaperSystem.Size = new System.Drawing.Size(89, 20);
            this.lblPaperSystem.TabIndex = 0;
            this.lblPaperSystem.Text = "查詢模組：";
            // 
            // rdoSPO
            // 
            this.rdoSPO.AutoSize = true;
            this.rdoSPO.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rdoSPO.Location = new System.Drawing.Point(107, 7);
            this.rdoSPO.Name = "rdoSPO";
            this.rdoSPO.Size = new System.Drawing.Size(123, 24);
            this.rdoSPO.TabIndex = 1;
            this.rdoSPO.TabStop = true;
            this.rdoSPO.Text = "銷售管理系統";
            this.rdoSPO.UseVisualStyleBackColor = true;
            this.rdoSPO.CheckedChanged += new System.EventHandler(this.rdoSPO_CheckedChanged);
            // 
            // rdoFOS
            // 
            this.rdoFOS.AutoSize = true;
            this.rdoFOS.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rdoFOS.Location = new System.Drawing.Point(236, 7);
            this.rdoFOS.Name = "rdoFOS";
            this.rdoFOS.Size = new System.Drawing.Size(155, 24);
            this.rdoFOS.TabIndex = 2;
            this.rdoFOS.TabStop = true;
            this.rdoFOS.Text = "製程委外管理系統";
            this.rdoFOS.UseVisualStyleBackColor = true;
            this.rdoFOS.CheckedChanged += new System.EventHandler(this.rdoFOS_CheckedChanged);
            // 
            // lblPaperId
            // 
            this.lblPaperId.AutoSize = true;
            this.lblPaperId.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblPaperId.Location = new System.Drawing.Point(397, 9);
            this.lblPaperId.Name = "lblPaperId";
            this.lblPaperId.Size = new System.Drawing.Size(57, 20);
            this.lblPaperId.TabIndex = 3;
            this.lblPaperId.Text = "單據：";
            // 
            // cboPaperId
            // 
            this.cboPaperId.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cboPaperId.FormattingEnabled = true;
            this.cboPaperId.Location = new System.Drawing.Point(460, 6);
            this.cboPaperId.Name = "cboPaperId";
            this.cboPaperId.Size = new System.Drawing.Size(135, 28);
            this.cboPaperId.TabIndex = 4;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CalendarFont = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dtpStartDate.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dtpStartDate.Location = new System.Drawing.Point(107, 42);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 29);
            this.dtpStartDate.TabIndex = 5;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblDate.Location = new System.Drawing.Point(12, 48);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(89, 20);
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "日期區間：";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CalendarFont = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dtpEndDate.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dtpEndDate.Location = new System.Drawing.Point(344, 42);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 29);
            this.dtpEndDate.TabIndex = 7;
            // 
            // txtUserId
            // 
            this.txtUserId.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtUserId.Location = new System.Drawing.Point(353, 80);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(135, 29);
            this.txtUserId.TabIndex = 8;
            this.txtUserId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextOnlyEN);
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblUserId.Location = new System.Drawing.Point(257, 83);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(90, 20);
            this.lblUserId.TabIndex = 9;
            this.lblUserId.Text = "使用者ID：";
            // 
            // lblUserIdNull
            // 
            this.lblUserIdNull.AutoSize = true;
            this.lblUserIdNull.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblUserIdNull.Location = new System.Drawing.Point(347, 290);
            this.lblUserIdNull.Name = "lblUserIdNull";
            this.lblUserIdNull.Size = new System.Drawing.Size(0, 20);
            this.lblUserIdNull.TabIndex = 10;
            // 
            // btnRefer
            // 
            this.btnRefer.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnRefer.Location = new System.Drawing.Point(550, 78);
            this.btnRefer.Name = "btnRefer";
            this.btnRefer.Size = new System.Drawing.Size(75, 35);
            this.btnRefer.TabIndex = 11;
            this.btnRefer.Text = "查詢";
            this.btnRefer.UseVisualStyleBackColor = true;
            this.btnRefer.Click += new System.EventHandler(this.btnRefer_Click);
            // 
            // dgvDataShow
            // 
            this.dgvDataShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataShow.Location = new System.Drawing.Point(12, 119);
            this.dgvDataShow.Name = "dgvDataShow";
            this.dgvDataShow.RowTemplate.Height = 24;
            this.dgvDataShow.Size = new System.Drawing.Size(760, 470);
            this.dgvDataShow.TabIndex = 12;
            // 
            // lblPaperNum
            // 
            this.lblPaperNum.AutoSize = true;
            this.lblPaperNum.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblPaperNum.Location = new System.Drawing.Point(12, 83);
            this.lblPaperNum.Name = "lblPaperNum";
            this.lblPaperNum.Size = new System.Drawing.Size(89, 20);
            this.lblPaperNum.TabIndex = 17;
            this.lblPaperNum.Text = "單據編號：";
            // 
            // txtPaperNum
            // 
            this.txtPaperNum.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtPaperNum.Location = new System.Drawing.Point(107, 80);
            this.txtPaperNum.Name = "txtPaperNum";
            this.txtPaperNum.Size = new System.Drawing.Size(135, 29);
            this.txtPaperNum.TabIndex = 18;
            // 
            // lbl00
            // 
            this.lbl00.AutoSize = true;
            this.lbl00.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbl00.Location = new System.Drawing.Point(313, 48);
            this.lbl00.Name = "lbl00";
            this.lbl00.Size = new System.Drawing.Size(25, 20);
            this.lbl00.TabIndex = 19;
            this.lbl00.Text = "～";
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClear.Location = new System.Drawing.Point(494, 82);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(50, 25);
            this.btnClear.TabIndex = 20;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnReport
            // 
            this.btnReport.Image = ((System.Drawing.Image)(resources.GetObject("btnReport.Image")));
            this.btnReport.Location = new System.Drawing.Point(626, 6);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(72, 71);
            this.btnReport.TabIndex = 21;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.Location = new System.Drawing.Point(705, 6);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(72, 71);
            this.btnExcel.TabIndex = 22;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // MainProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(784, 601);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lbl00);
            this.Controls.Add(this.txtPaperNum);
            this.Controls.Add(this.lblPaperNum);
            this.Controls.Add(this.btnRefer);
            this.Controls.Add(this.lblUserIdNull);
            this.Controls.Add(this.lblUserId);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.cboPaperId);
            this.Controls.Add(this.lblPaperId);
            this.Controls.Add(this.rdoFOS);
            this.Controls.Add(this.rdoSPO);
            this.Controls.Add(this.lblPaperSystem);
            this.Controls.Add(this.dgvDataShow);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainProgram";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "傑偲資訊-單據修改查詢";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPaperSystem;
        private System.Windows.Forms.RadioButton rdoSPO;
        private System.Windows.Forms.RadioButton rdoFOS;
        private System.Windows.Forms.Label lblPaperId;
        private System.Windows.Forms.ComboBox cboPaperId;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Label lblUserIdNull;
        private System.Windows.Forms.Button btnRefer;
        private System.Windows.Forms.DataGridView dgvDataShow;
        private System.Windows.Forms.Label lblPaperNum;
        private System.Windows.Forms.TextBox txtPaperNum;
        private System.Windows.Forms.Label lbl00;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnExcel;
    }
}

