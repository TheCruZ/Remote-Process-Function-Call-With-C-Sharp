namespace RemoteProcessFunctionCall
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.bCall = new System.Windows.Forms.Button();
            this.textFunctionAddr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textEAX = new System.Windows.Forms.TextBox();
            this.cEAX = new System.Windows.Forms.CheckBox();
            this.cEBX = new System.Windows.Forms.CheckBox();
            this.textEBX = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cECX = new System.Windows.Forms.CheckBox();
            this.textECX = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cEDX = new System.Windows.Forms.CheckBox();
            this.textEDX = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cESI = new System.Windows.Forms.CheckBox();
            this.textESI = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textProcessFilter = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.listProcess = new System.Windows.Forms.ComboBox();
            this.groupParams = new System.Windows.Forms.GroupBox();
            this.labelNone = new System.Windows.Forms.Label();
            this.bAddParam = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupParams.SuspendLayout();
            this.SuspendLayout();
            // 
            // bCall
            // 
            this.bCall.Location = new System.Drawing.Point(149, 376);
            this.bCall.Name = "bCall";
            this.bCall.Size = new System.Drawing.Size(75, 28);
            this.bCall.TabIndex = 0;
            this.bCall.Text = "Call NOW!";
            this.bCall.UseVisualStyleBackColor = true;
            this.bCall.Click += new System.EventHandler(this.button1_Click);
            // 
            // textFunctionAddr
            // 
            this.textFunctionAddr.Location = new System.Drawing.Point(94, 102);
            this.textFunctionAddr.Name = "textFunctionAddr";
            this.textFunctionAddr.Size = new System.Drawing.Size(130, 20);
            this.textFunctionAddr.TabIndex = 1;
            this.textFunctionAddr.Tag = "ex: FEDCBA98 (HEX)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Function Addr:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "EAX";
            // 
            // textEAX
            // 
            this.textEAX.Location = new System.Drawing.Point(40, 28);
            this.textEAX.Name = "textEAX";
            this.textEAX.Size = new System.Drawing.Size(138, 20);
            this.textEAX.TabIndex = 6;
            this.textEAX.Tag = "ex: FEDCBA98 (HEX)";
            // 
            // cEAX
            // 
            this.cEAX.AutoSize = true;
            this.cEAX.Location = new System.Drawing.Point(184, 30);
            this.cEAX.Name = "cEAX";
            this.cEAX.Size = new System.Drawing.Size(15, 14);
            this.cEAX.TabIndex = 7;
            this.cEAX.UseVisualStyleBackColor = true;
            // 
            // cEBX
            // 
            this.cEBX.AutoSize = true;
            this.cEBX.Location = new System.Drawing.Point(184, 59);
            this.cEBX.Name = "cEBX";
            this.cEBX.Size = new System.Drawing.Size(15, 14);
            this.cEBX.TabIndex = 11;
            this.cEBX.UseVisualStyleBackColor = true;
            // 
            // textEBX
            // 
            this.textEBX.Location = new System.Drawing.Point(40, 57);
            this.textEBX.Name = "textEBX";
            this.textEBX.Size = new System.Drawing.Size(138, 20);
            this.textEBX.TabIndex = 10;
            this.textEBX.Tag = "ex: FEDCBA98 (HEX)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "EBX";
            // 
            // cECX
            // 
            this.cECX.AutoSize = true;
            this.cECX.Location = new System.Drawing.Point(184, 85);
            this.cECX.Name = "cECX";
            this.cECX.Size = new System.Drawing.Size(15, 14);
            this.cECX.TabIndex = 14;
            this.cECX.UseVisualStyleBackColor = true;
            // 
            // textECX
            // 
            this.textECX.Location = new System.Drawing.Point(40, 83);
            this.textECX.Name = "textECX";
            this.textECX.Size = new System.Drawing.Size(138, 20);
            this.textECX.TabIndex = 13;
            this.textECX.Tag = "ex: FEDCBA98 (HEX)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "ECX";
            // 
            // cEDX
            // 
            this.cEDX.AutoSize = true;
            this.cEDX.Location = new System.Drawing.Point(184, 111);
            this.cEDX.Name = "cEDX";
            this.cEDX.Size = new System.Drawing.Size(15, 14);
            this.cEDX.TabIndex = 17;
            this.cEDX.UseVisualStyleBackColor = true;
            // 
            // textEDX
            // 
            this.textEDX.Location = new System.Drawing.Point(40, 109);
            this.textEDX.Name = "textEDX";
            this.textEDX.Size = new System.Drawing.Size(138, 20);
            this.textEDX.TabIndex = 16;
            this.textEDX.Tag = "ex: FEDCBA98 (HEX)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "EDX";
            // 
            // cESI
            // 
            this.cESI.AutoSize = true;
            this.cESI.Location = new System.Drawing.Point(184, 137);
            this.cESI.Name = "cESI";
            this.cESI.Size = new System.Drawing.Size(15, 14);
            this.cESI.TabIndex = 20;
            this.cESI.UseVisualStyleBackColor = true;
            // 
            // textESI
            // 
            this.textESI.Location = new System.Drawing.Point(40, 135);
            this.textESI.Name = "textESI";
            this.textESI.Size = new System.Drawing.Size(138, 20);
            this.textESI.TabIndex = 19;
            this.textESI.Tag = "ex: FEDCBA98 (HEX)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "ESI";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textEAX);
            this.groupBox1.Controls.Add(this.cEAX);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textEBX);
            this.groupBox1.Controls.Add(this.cESI);
            this.groupBox1.Controls.Add(this.cEBX);
            this.groupBox1.Controls.Add(this.textESI);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textECX);
            this.groupBox1.Controls.Add(this.cEDX);
            this.groupBox1.Controls.Add(this.cECX);
            this.groupBox1.Controls.Add(this.textEDX);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(12, 194);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 176);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registers Before Call:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textProcessFilter);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.listProcess);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(212, 81);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Process";
            // 
            // textProcessFilter
            // 
            this.textProcessFilter.Location = new System.Drawing.Point(64, 46);
            this.textProcessFilter.Name = "textProcessFilter";
            this.textProcessFilter.Size = new System.Drawing.Size(138, 20);
            this.textProcessFilter.TabIndex = 28;
            this.textProcessFilter.Tag = "Process name, ex: chrome";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Filter:";
            // 
            // listProcess
            // 
            this.listProcess.FormattingEnabled = true;
            this.listProcess.Location = new System.Drawing.Point(6, 19);
            this.listProcess.Name = "listProcess";
            this.listProcess.Size = new System.Drawing.Size(196, 21);
            this.listProcess.TabIndex = 26;
            this.listProcess.SelectedIndexChanged += new System.EventHandler(this.listProcess_SelectedIndexChanged);
            this.listProcess.MouseDown += new System.Windows.Forms.MouseEventHandler(this.loadProcessList);
            // 
            // groupParams
            // 
            this.groupParams.Controls.Add(this.labelNone);
            this.groupParams.Controls.Add(this.bAddParam);
            this.groupParams.Location = new System.Drawing.Point(12, 129);
            this.groupParams.Name = "groupParams";
            this.groupParams.Size = new System.Drawing.Size(211, 59);
            this.groupParams.TabIndex = 28;
            this.groupParams.TabStop = false;
            this.groupParams.Text = "Params";
            // 
            // labelNone
            // 
            this.labelNone.AutoSize = true;
            this.labelNone.Location = new System.Drawing.Point(9, 24);
            this.labelNone.Name = "labelNone";
            this.labelNone.Size = new System.Drawing.Size(33, 13);
            this.labelNone.TabIndex = 24;
            this.labelNone.Text = "None";
            // 
            // bAddParam
            // 
            this.bAddParam.Location = new System.Drawing.Point(182, 19);
            this.bAddParam.Name = "bAddParam";
            this.bAddParam.Size = new System.Drawing.Size(23, 23);
            this.bAddParam.TabIndex = 22;
            this.bAddParam.Text = "+";
            this.bAddParam.UseVisualStyleBackColor = true;
            this.bAddParam.Click += new System.EventHandler(this.bAddParam_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 416);
            this.Controls.Add(this.groupParams);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textFunctionAddr);
            this.Controls.Add(this.bCall);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Remote Process Function Call";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupParams.ResumeLayout(false);
            this.groupParams.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bCall;
        private System.Windows.Forms.TextBox textFunctionAddr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textEAX;
        private System.Windows.Forms.CheckBox cEAX;
        private System.Windows.Forms.CheckBox cEBX;
        private System.Windows.Forms.TextBox textEBX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cECX;
        private System.Windows.Forms.TextBox textECX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cEDX;
        private System.Windows.Forms.TextBox textEDX;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cESI;
        private System.Windows.Forms.TextBox textESI;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textProcessFilter;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox listProcess;
        private System.Windows.Forms.GroupBox groupParams;
        private System.Windows.Forms.Label labelNone;
        private System.Windows.Forms.Button bAddParam;
    }
}

