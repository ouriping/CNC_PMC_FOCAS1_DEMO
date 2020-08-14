namespace GetAlmMsg
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該公開 Managed 資源則為 true，否則為 false。</param>
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
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.butGetAlmNo = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.AlmTimer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.btnSetParam = new System.Windows.Forms.Button();
            this.rdpara = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.opdCNC = new System.Windows.Forms.OpenFileDialog();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnFileDown = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnSetMain = new System.Windows.Forms.Button();
            this.btnToolRead = new System.Windows.Forms.Button();
            this.btnToolWrite = new System.Windows.Forms.Button();
            this.btnRunStatus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(24, 202);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(77, 25);
            this.textBox2.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(24, 159);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(153, 25);
            this.textBox1.TabIndex = 6;
            // 
            // butGetAlmNo
            // 
            this.butGetAlmNo.Location = new System.Drawing.Point(24, 88);
            this.butGetAlmNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.butGetAlmNo.Name = "butGetAlmNo";
            this.butGetAlmNo.Size = new System.Drawing.Size(113, 39);
            this.butGetAlmNo.TabIndex = 5;
            this.butGetAlmNo.Text = "GetAlmNo";
            this.butGetAlmNo.UseVisualStyleBackColor = true;
            this.butGetAlmNo.Click += new System.EventHandler(this.butGetAlmNo_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(24, 22);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(113, 39);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // AlmTimer1
            // 
            this.AlmTimer1.Enabled = true;
            this.AlmTimer1.Interval = 1000;
            this.AlmTimer1.Tick += new System.EventHandler(this.AlmTimer1_Tick);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(107, 202);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(272, 25);
            this.textBox3.TabIndex = 8;
            // 
            // btnSetParam
            // 
            this.btnSetParam.Location = new System.Drawing.Point(24, 259);
            this.btnSetParam.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSetParam.Name = "btnSetParam";
            this.btnSetParam.Size = new System.Drawing.Size(113, 39);
            this.btnSetParam.TabIndex = 9;
            this.btnSetParam.Text = "SetParam20";
            this.btnSetParam.UseVisualStyleBackColor = true;
            this.btnSetParam.Click += new System.EventHandler(this.btnSetParam_Click);
            // 
            // rdpara
            // 
            this.rdpara.Enabled = false;
            this.rdpara.Location = new System.Drawing.Point(404, 32);
            this.rdpara.Margin = new System.Windows.Forms.Padding(4);
            this.rdpara.Name = "rdpara";
            this.rdpara.Size = new System.Drawing.Size(100, 29);
            this.rdpara.TabIndex = 10;
            this.rdpara.Text = "下載參數";
            this.rdpara.UseVisualStyleBackColor = true;
            this.rdpara.Click += new System.EventHandler(this.rdpara_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(404, 88);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "IP";
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(433, 74);
            this.textBox_IP.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(193, 25);
            this.textBox_IP.TabIndex = 12;
            // 
            // opdCNC
            // 
            this.opdCNC.FileName = "openFileDialog1";
            this.opdCNC.Filter = "NC 文件|*.nc|所有文件|*.*";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(407, 141);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(153, 25);
            this.txtFilePath.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(566, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "浏览...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnFileDown
            // 
            this.btnFileDown.Enabled = false;
            this.btnFileDown.Location = new System.Drawing.Point(407, 182);
            this.btnFileDown.Margin = new System.Windows.Forms.Padding(4);
            this.btnFileDown.Name = "btnFileDown";
            this.btnFileDown.Size = new System.Drawing.Size(100, 29);
            this.btnFileDown.TabIndex = 10;
            this.btnFileDown.Text = "下載文件";
            this.btnFileDown.UseVisualStyleBackColor = true;
            this.btnFileDown.Click += new System.EventHandler(this.btnFileDown_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Enabled = false;
            this.btnUpload.Location = new System.Drawing.Point(407, 244);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(100, 29);
            this.btnUpload.TabIndex = 10;
            this.btnUpload.Text = "上載文件";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnSetMain
            // 
            this.btnSetMain.Location = new System.Drawing.Point(404, 291);
            this.btnSetMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSetMain.Name = "btnSetMain";
            this.btnSetMain.Size = new System.Drawing.Size(113, 39);
            this.btnSetMain.TabIndex = 4;
            this.btnSetMain.Text = "设置主程序";
            this.btnSetMain.UseVisualStyleBackColor = true;
            this.btnSetMain.Click += new System.EventHandler(this.btnSetMain_Click);
            // 
            // btnToolRead
            // 
            this.btnToolRead.Location = new System.Drawing.Point(528, 291);
            this.btnToolRead.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnToolRead.Name = "btnToolRead";
            this.btnToolRead.Size = new System.Drawing.Size(113, 39);
            this.btnToolRead.TabIndex = 4;
            this.btnToolRead.Text = "读取刀具寿命";
            this.btnToolRead.UseVisualStyleBackColor = true;
            this.btnToolRead.Click += new System.EventHandler(this.btnToolRead_Click);
            // 
            // btnToolWrite
            // 
            this.btnToolWrite.Location = new System.Drawing.Point(528, 239);
            this.btnToolWrite.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnToolWrite.Name = "btnToolWrite";
            this.btnToolWrite.Size = new System.Drawing.Size(113, 39);
            this.btnToolWrite.TabIndex = 4;
            this.btnToolWrite.Text = "写入刀具补偿";
            this.btnToolWrite.UseVisualStyleBackColor = true;
            this.btnToolWrite.Click += new System.EventHandler(this.btnToolWrite_Click);
            // 
            // btnRunStatus
            // 
            this.btnRunStatus.Location = new System.Drawing.Point(528, 193);
            this.btnRunStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRunStatus.Name = "btnRunStatus";
            this.btnRunStatus.Size = new System.Drawing.Size(113, 39);
            this.btnRunStatus.TabIndex = 4;
            this.btnRunStatus.Text = "运行状态";
            this.btnRunStatus.UseVisualStyleBackColor = true;
            this.btnRunStatus.Click += new System.EventHandler(this.btnRunStatus_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 341);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.textBox_IP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnFileDown);
            this.Controls.Add(this.rdpara);
            this.Controls.Add(this.btnSetParam);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.butGetAlmNo);
            this.Controls.Add(this.btnRunStatus);
            this.Controls.Add(this.btnToolWrite);
            this.Controls.Add(this.btnToolRead);
            this.Controls.Add(this.btnSetMain);
            this.Controls.Add(this.btnConnect);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button butGetAlmNo;
        private System.Windows.Forms.Button btnConnect;
       private System.Windows.Forms.Timer AlmTimer1;
       private System.Windows.Forms.TextBox textBox3;
       private System.Windows.Forms.Button btnSetParam;
        private System.Windows.Forms.Button rdpara;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.OpenFileDialog opdCNC;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnFileDown;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnSetMain;
        private System.Windows.Forms.Button btnToolRead;
        private System.Windows.Forms.Button btnToolWrite;
        private System.Windows.Forms.Button btnRunStatus;
    }
}

