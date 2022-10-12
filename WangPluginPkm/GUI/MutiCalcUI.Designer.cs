using System.Windows.Forms;

namespace WangPluginPkm.GUI
{
    partial class MutiCalcUI
    {
        private Button CalcNature;
        private Label PID;
        private TextBox Nature;
        private Button CloseBTN;
        private TextBox Hex1;
        private TextBox Dec1;
        private TextBox Dec2;
        private TextBox Hex2;
        private Button CalcHTD;
        private Button CalcDTH;
        private TextBox TID;
        private TextBox SID;
        private Button CalcID;
        private Label HTC;
        private Label CTH;
        private TextBox TIDResult;
        private TextBox SIDResult;
        private CheckBox IDCheck;
        private CheckBox IDsCheck;
        private TextBox PIDHex;
        private Label TIDLabel;
        private Label SIDLabel;
        private TextBox UnownPidTextBox;
        private TextBox UnownFormBox;
        private Label UnownLabel;
        private Button FormCalc;
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MutiCalcUI));
            this.CalcNature = new System.Windows.Forms.Button();
            this.PIDHex = new System.Windows.Forms.TextBox();
            this.PID = new System.Windows.Forms.Label();
            this.Nature = new System.Windows.Forms.TextBox();
            this.CloseBTN = new System.Windows.Forms.Button();
            this.Hex1 = new System.Windows.Forms.TextBox();
            this.Dec1 = new System.Windows.Forms.TextBox();
            this.Dec2 = new System.Windows.Forms.TextBox();
            this.Hex2 = new System.Windows.Forms.TextBox();
            this.CalcHTD = new System.Windows.Forms.Button();
            this.CalcDTH = new System.Windows.Forms.Button();
            this.TID = new System.Windows.Forms.TextBox();
            this.SID = new System.Windows.Forms.TextBox();
            this.CalcID = new System.Windows.Forms.Button();
            this.HTC = new System.Windows.Forms.Label();
            this.CTH = new System.Windows.Forms.Label();
            this.TIDResult = new System.Windows.Forms.TextBox();
            this.SIDResult = new System.Windows.Forms.TextBox();
            this.IDCheck = new System.Windows.Forms.CheckBox();
            this.IDsCheck = new System.Windows.Forms.CheckBox();
            this.TIDLabel = new System.Windows.Forms.Label();
            this.SIDLabel = new System.Windows.Forms.Label();
            this.UnownPidTextBox = new System.Windows.Forms.TextBox();
            this.UnownFormBox = new System.Windows.Forms.TextBox();
            this.UnownLabel = new System.Windows.Forms.Label();
            this.FormCalc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CalcNature
            // 
            this.CalcNature.Font = new System.Drawing.Font("黑体", 9F);
            this.CalcNature.Location = new System.Drawing.Point(315, 23);
            this.CalcNature.Name = "CalcNature";
            this.CalcNature.Size = new System.Drawing.Size(100, 25);
            this.CalcNature.TabIndex = 0;
            this.CalcNature.Text = "计算";
            this.CalcNature.UseVisualStyleBackColor = true;
            this.CalcNature.Click += new System.EventHandler(this.CalcStart_Click);
            // 
            // PIDHex
            // 
            this.PIDHex.Location = new System.Drawing.Point(103, 23);
            this.PIDHex.Name = "PIDHex";
            this.PIDHex.Size = new System.Drawing.Size(100, 25);
            this.PIDHex.TabIndex = 2;
            // 
            // PID
            // 
            this.PID.AutoSize = true;
            this.PID.Font = new System.Drawing.Font("黑体", 9F);
            this.PID.Location = new System.Drawing.Point(12, 27);
            this.PID.Name = "PID";
            this.PID.Size = new System.Drawing.Size(111, 15);
            this.PID.TabIndex = 3;
            this.PID.Text = "通过PID算性格";
            // 
            // Nature
            // 
            this.Nature.Enabled = false;
            this.Nature.Location = new System.Drawing.Point(209, 23);
            this.Nature.Name = "Nature";
            this.Nature.Size = new System.Drawing.Size(100, 25);
            this.Nature.TabIndex = 4;
            // 
            // CloseBTN
            // 
            this.CloseBTN.Font = new System.Drawing.Font("黑体", 9F);
            this.CloseBTN.Location = new System.Drawing.Point(315, 147);
            this.CloseBTN.Name = "CloseBTN";
            this.CloseBTN.Size = new System.Drawing.Size(100, 25);
            this.CloseBTN.TabIndex = 5;
            this.CloseBTN.Text = "关闭";
            this.CloseBTN.UseVisualStyleBackColor = true;
            this.CloseBTN.Click += new System.EventHandler(this.CloseBTN_Click);
            // 
            // Hex1
            // 
            this.Hex1.Location = new System.Drawing.Point(103, 54);
            this.Hex1.Name = "Hex1";
            this.Hex1.Size = new System.Drawing.Size(100, 25);
            this.Hex1.TabIndex = 6;
            // 
            // Dec1
            // 
            this.Dec1.Enabled = false;
            this.Dec1.Location = new System.Drawing.Point(209, 54);
            this.Dec1.Name = "Dec1";
            this.Dec1.Size = new System.Drawing.Size(100, 25);
            this.Dec1.TabIndex = 7;
            // 
            // Dec2
            // 
            this.Dec2.Location = new System.Drawing.Point(103, 85);
            this.Dec2.Name = "Dec2";
            this.Dec2.Size = new System.Drawing.Size(100, 25);
            this.Dec2.TabIndex = 8;
            // 
            // Hex2
            // 
            this.Hex2.Enabled = false;
            this.Hex2.Location = new System.Drawing.Point(209, 85);
            this.Hex2.Name = "Hex2";
            this.Hex2.Size = new System.Drawing.Size(100, 25);
            this.Hex2.TabIndex = 9;
            // 
            // CalcHTD
            // 
            this.CalcHTD.Font = new System.Drawing.Font("黑体", 9F);
            this.CalcHTD.Location = new System.Drawing.Point(315, 53);
            this.CalcHTD.Name = "CalcHTD";
            this.CalcHTD.Size = new System.Drawing.Size(100, 25);
            this.CalcHTD.TabIndex = 10;
            this.CalcHTD.Text = "计算";
            this.CalcHTD.UseVisualStyleBackColor = true;
            this.CalcHTD.Click += new System.EventHandler(this.CalcHTD_Click);
            // 
            // CalcDTH
            // 
            this.CalcDTH.Font = new System.Drawing.Font("黑体", 9F);
            this.CalcDTH.Location = new System.Drawing.Point(315, 85);
            this.CalcDTH.Name = "CalcDTH";
            this.CalcDTH.Size = new System.Drawing.Size(100, 26);
            this.CalcDTH.TabIndex = 11;
            this.CalcDTH.Text = "计算";
            this.CalcDTH.UseVisualStyleBackColor = true;
            this.CalcDTH.Click += new System.EventHandler(this.CalcDTH_Click);
            // 
            // TID
            // 
            this.TID.Location = new System.Drawing.Point(103, 116);
            this.TID.Name = "TID";
            this.TID.Size = new System.Drawing.Size(100, 25);
            this.TID.TabIndex = 12;
            // 
            // SID
            // 
            this.SID.Location = new System.Drawing.Point(103, 147);
            this.SID.Name = "SID";
            this.SID.Size = new System.Drawing.Size(100, 25);
            this.SID.TabIndex = 13;
            // 
            // CalcID
            // 
            this.CalcID.Font = new System.Drawing.Font("黑体", 9F);
            this.CalcID.Location = new System.Drawing.Point(315, 116);
            this.CalcID.Name = "CalcID";
            this.CalcID.Size = new System.Drawing.Size(100, 26);
            this.CalcID.TabIndex = 14;
            this.CalcID.Text = "转换";
            this.CalcID.UseVisualStyleBackColor = true;
            this.CalcID.Click += new System.EventHandler(this.CalcID_Click);
            // 
            // HTC
            // 
            this.HTC.AutoSize = true;
            this.HTC.Font = new System.Drawing.Font("黑体", 9F);
            this.HTC.Location = new System.Drawing.Point(6, 57);
            this.HTC.Name = "HTC";
            this.HTC.Size = new System.Drawing.Size(119, 15);
            this.HTC.TabIndex = 15;
            this.HTC.Text = "16进制转10进制";
            // 
            // CTH
            // 
            this.CTH.AutoSize = true;
            this.CTH.Font = new System.Drawing.Font("黑体", 9F);
            this.CTH.Location = new System.Drawing.Point(6, 88);
            this.CTH.Name = "CTH";
            this.CTH.Size = new System.Drawing.Size(119, 15);
            this.CTH.TabIndex = 16;
            this.CTH.Text = "10进制转16进制";
            // 
            // TIDResult
            // 
            this.TIDResult.Enabled = false;
            this.TIDResult.Location = new System.Drawing.Point(209, 116);
            this.TIDResult.Name = "TIDResult";
            this.TIDResult.Size = new System.Drawing.Size(100, 25);
            this.TIDResult.TabIndex = 17;
            // 
            // SIDResult
            // 
            this.SIDResult.Enabled = false;
            this.SIDResult.Location = new System.Drawing.Point(209, 147);
            this.SIDResult.Name = "SIDResult";
            this.SIDResult.Size = new System.Drawing.Size(100, 25);
            this.SIDResult.TabIndex = 18;
            // 
            // IDCheck
            // 
            this.IDCheck.AutoSize = true;
            this.IDCheck.Font = new System.Drawing.Font("黑体", 9F);
            this.IDCheck.Location = new System.Drawing.Point(78, 214);
            this.IDCheck.Name = "IDCheck";
            this.IDCheck.Size = new System.Drawing.Size(125, 19);
            this.IDCheck.TabIndex = 19;
            this.IDCheck.Text = "5位ID转7位ID";
            this.IDCheck.UseVisualStyleBackColor = true;
            // 
            // IDsCheck
            // 
            this.IDsCheck.AutoSize = true;
            this.IDsCheck.Font = new System.Drawing.Font("黑体", 9F);
            this.IDsCheck.Location = new System.Drawing.Point(209, 214);
            this.IDsCheck.Name = "IDsCheck";
            this.IDsCheck.Size = new System.Drawing.Size(125, 19);
            this.IDsCheck.TabIndex = 20;
            this.IDsCheck.Text = "7位ID转5位ID";
            this.IDsCheck.UseVisualStyleBackColor = true;
            // 
            // TIDLabel
            // 
            this.TIDLabel.AutoSize = true;
            this.TIDLabel.Font = new System.Drawing.Font("黑体", 9F);
            this.TIDLabel.Location = new System.Drawing.Point(66, 118);
            this.TIDLabel.Name = "TIDLabel";
            this.TIDLabel.Size = new System.Drawing.Size(39, 15);
            this.TIDLabel.TabIndex = 31;
            this.TIDLabel.Text = "表ID";
            // 
            // SIDLabel
            // 
            this.SIDLabel.AutoSize = true;
            this.SIDLabel.Font = new System.Drawing.Font("黑体", 9F);
            this.SIDLabel.Location = new System.Drawing.Point(66, 151);
            this.SIDLabel.Name = "SIDLabel";
            this.SIDLabel.Size = new System.Drawing.Size(39, 15);
            this.SIDLabel.TabIndex = 32;
            this.SIDLabel.Text = "里ID";
            // 
            // UnownPidTextBox
            // 
            this.UnownPidTextBox.Location = new System.Drawing.Point(123, 178);
            this.UnownPidTextBox.Name = "UnownPidTextBox";
            this.UnownPidTextBox.Size = new System.Drawing.Size(129, 25);
            this.UnownPidTextBox.TabIndex = 33;
            // 
            // UnownFormBox
            // 
            this.UnownFormBox.Location = new System.Drawing.Point(258, 178);
            this.UnownFormBox.Name = "UnownFormBox";
            this.UnownFormBox.Size = new System.Drawing.Size(51, 25);
            this.UnownFormBox.TabIndex = 34;
            // 
            // UnownLabel
            // 
            this.UnownLabel.AutoSize = true;
            this.UnownLabel.Font = new System.Drawing.Font("黑体", 9F);
            this.UnownLabel.Location = new System.Drawing.Point(12, 182);
            this.UnownLabel.Name = "UnownLabel";
            this.UnownLabel.Size = new System.Drawing.Size(135, 15);
            this.UnownLabel.TabIndex = 35;
            this.UnownLabel.Text = "Gen3未知图腾形态";
            // 
            // FormCalc
            // 
            this.FormCalc.Font = new System.Drawing.Font("黑体", 9F);
            this.FormCalc.Location = new System.Drawing.Point(315, 178);
            this.FormCalc.Name = "FormCalc";
            this.FormCalc.Size = new System.Drawing.Size(100, 25);
            this.FormCalc.TabIndex = 36;
            this.FormCalc.Text = "计算";
            this.FormCalc.UseVisualStyleBackColor = true;
            this.FormCalc.Click += new System.EventHandler(this.FormCalc_Click);
            // 
            // MutiCalcUI
            // 
            this.ClientSize = new System.Drawing.Size(424, 245);
            this.Controls.Add(this.FormCalc);
            this.Controls.Add(this.UnownLabel);
            this.Controls.Add(this.UnownFormBox);
            this.Controls.Add(this.UnownPidTextBox);
            this.Controls.Add(this.SIDLabel);
            this.Controls.Add(this.TIDLabel);
            this.Controls.Add(this.IDsCheck);
            this.Controls.Add(this.IDCheck);
            this.Controls.Add(this.SIDResult);
            this.Controls.Add(this.TIDResult);
            this.Controls.Add(this.CTH);
            this.Controls.Add(this.HTC);
            this.Controls.Add(this.CalcID);
            this.Controls.Add(this.SID);
            this.Controls.Add(this.TID);
            this.Controls.Add(this.CalcDTH);
            this.Controls.Add(this.CalcHTD);
            this.Controls.Add(this.Hex2);
            this.Controls.Add(this.Dec2);
            this.Controls.Add(this.Dec1);
            this.Controls.Add(this.Hex1);
            this.Controls.Add(this.CloseBTN);
            this.Controls.Add(this.Nature);
            this.Controls.Add(this.PID);
            this.Controls.Add(this.PIDHex);
            this.Controls.Add(this.CalcNature);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MutiCalcUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Wang";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
