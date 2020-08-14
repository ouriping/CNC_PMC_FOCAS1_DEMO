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
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(18, 162);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(59, 22);
            this.textBox2.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(18, 127);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(116, 22);
            this.textBox1.TabIndex = 6;
            // 
            // butGetAlmNo
            // 
            this.butGetAlmNo.Location = new System.Drawing.Point(18, 70);
            this.butGetAlmNo.Margin = new System.Windows.Forms.Padding(2);
            this.butGetAlmNo.Name = "butGetAlmNo";
            this.butGetAlmNo.Size = new System.Drawing.Size(85, 31);
            this.butGetAlmNo.TabIndex = 5;
            this.butGetAlmNo.Text = "GetAlmNo";
            this.butGetAlmNo.UseVisualStyleBackColor = true;
            this.butGetAlmNo.Click += new System.EventHandler(this.butGetAlmNo_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(18, 18);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(2);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(85, 31);
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
            this.textBox3.Location = new System.Drawing.Point(80, 162);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(205, 22);
            this.textBox3.TabIndex = 8;
            // 
            // btnSetParam
            // 
            this.btnSetParam.Location = new System.Drawing.Point(18, 207);
            this.btnSetParam.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetParam.Name = "btnSetParam";
            this.btnSetParam.Size = new System.Drawing.Size(85, 31);
            this.btnSetParam.TabIndex = 9;
            this.btnSetParam.Text = "SetParam20";
            this.btnSetParam.UseVisualStyleBackColor = true;
            this.btnSetParam.Click += new System.EventHandler(this.btnSetParam_Click);
            // 
            // rdpara
            // 
            this.rdpara.Enabled = false;
            this.rdpara.Location = new System.Drawing.Point(303, 26);
            this.rdpara.Name = "rdpara";
            this.rdpara.Size = new System.Drawing.Size(75, 23);
            this.rdpara.TabIndex = 10;
            this.rdpara.Text = "下載參數";
            this.rdpara.UseVisualStyleBackColor = true;
            this.rdpara.Click += new System.EventHandler(this.rdpara_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(303, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "IP";
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(325, 59);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(146, 22);
            this.textBox_IP.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 273);
            this.Controls.Add(this.textBox_IP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdpara);
            this.Controls.Add(this.btnSetParam);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.butGetAlmNo);
            this.Controls.Add(this.btnConnect);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
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
    }
}

