namespace myQQClient
{
    partial class frmRegister
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gpbSetInfo = new System.Windows.Forms.GroupBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtPasswordVerify = new System.Windows.Forms.TextBox();
            this.lblPasswordVerify = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gpbSetInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbSetInfo
            // 
            this.gpbSetInfo.Controls.Add(this.txtPasswordVerify);
            this.gpbSetInfo.Controls.Add(this.lblPasswordVerify);
            this.gpbSetInfo.Controls.Add(this.txtPort);
            this.gpbSetInfo.Controls.Add(this.lblPort);
            this.gpbSetInfo.Controls.Add(this.txtPassword);
            this.gpbSetInfo.Controls.Add(this.lblPassword);
            this.gpbSetInfo.Controls.Add(this.txtUserName);
            this.gpbSetInfo.Controls.Add(this.lblUserName);
            this.gpbSetInfo.Controls.Add(this.txtServer);
            this.gpbSetInfo.Controls.Add(this.lblServer);
            this.gpbSetInfo.Location = new System.Drawing.Point(12, 12);
            this.gpbSetInfo.Name = "gpbSetInfo";
            this.gpbSetInfo.Size = new System.Drawing.Size(300, 213);
            this.gpbSetInfo.TabIndex = 0;
            this.gpbSetInfo.TabStop = false;
            this.gpbSetInfo.Text = "设置信息";
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(21, 32);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(65, 13);
            this.lblServer.TabIndex = 0;
            this.lblServer.Text = "服务器IP：";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(102, 29);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(168, 20);
            this.txtServer.TabIndex = 1;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(102, 107);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(168, 20);
            this.txtUserName.TabIndex = 3;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(21, 110);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(67, 13);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "用  户  名：";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(102, 140);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(168, 20);
            this.txtPassword.TabIndex = 5;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(21, 143);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(67, 13);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "密        码：";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(102, 67);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(168, 20);
            this.txtPort.TabIndex = 7;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(21, 70);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(67, 13);
            this.lblPort.TabIndex = 6;
            this.lblPort.Text = "端  口  号：";
            // 
            // txtPasswordVerify
            // 
            this.txtPasswordVerify.Location = new System.Drawing.Point(102, 175);
            this.txtPasswordVerify.Name = "txtPasswordVerify";
            this.txtPasswordVerify.Size = new System.Drawing.Size(168, 20);
            this.txtPasswordVerify.TabIndex = 9;
            // 
            // lblPasswordVerify
            // 
            this.lblPasswordVerify.AutoSize = true;
            this.lblPasswordVerify.Location = new System.Drawing.Point(21, 178);
            this.lblPasswordVerify.Name = "lblPasswordVerify";
            this.lblPasswordVerify.Size = new System.Drawing.Size(67, 13);
            this.lblPasswordVerify.TabIndex = 8;
            this.lblPasswordVerify.Text = "确认密码：";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(49, 242);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(188, 242);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 284);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gpbSetInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmRegister";
            this.Text = "用户注册";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRegister_FormClosed);
            this.Load += new System.EventHandler(this.frmRegister_Load);
            this.gpbSetInfo.ResumeLayout(false);
            this.gpbSetInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbSetInfo;
        private System.Windows.Forms.TextBox txtPasswordVerify;
        private System.Windows.Forms.Label lblPasswordVerify;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}