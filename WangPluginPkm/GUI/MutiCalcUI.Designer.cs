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
        private TextBox TID16;
        private TextBox SID16;
        private Button CalcID;
        private Label HTC;
        private Label CTH;
        private TextBox TID16Result;
        private TextBox SID16Result;
        private CheckBox IDCheck;
        private CheckBox IDsCheck;
        private TextBox PIDHex;
        private Label TID16Label;
        private Label SID16Label;
        private TextBox UnownPidTextBox;
        private TextBox UnownFormBox;
        private Label UnownLabel;
        private Button FormCalc;
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MutiCalcUI));
            CalcNature = new Button();
            PIDHex = new TextBox();
            PID = new Label();
            Nature = new TextBox();
            CloseBTN = new Button();
            Hex1 = new TextBox();
            Dec1 = new TextBox();
            Dec2 = new TextBox();
            Hex2 = new TextBox();
            CalcHTD = new Button();
            CalcDTH = new Button();
            TID16 = new TextBox();
            SID16 = new TextBox();
            CalcID = new Button();
            HTC = new Label();
            CTH = new Label();
            TID16Result = new TextBox();
            SID16Result = new TextBox();
            IDCheck = new CheckBox();
            IDsCheck = new CheckBox();
            TID16Label = new Label();
            SID16Label = new Label();
            UnownPidTextBox = new TextBox();
            UnownFormBox = new TextBox();
            UnownLabel = new Label();
            FormCalc = new Button();
            SuspendLayout();
            // 
            // CalcNature
            // 
            CalcNature.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            CalcNature.Location = new System.Drawing.Point(315, 23);
            CalcNature.Name = "CalcNature";
            CalcNature.Size = new System.Drawing.Size(100, 25);
            CalcNature.TabIndex = 0;
            CalcNature.Text = "计算";
            CalcNature.UseVisualStyleBackColor = true;
            CalcNature.Click += CalcStart_Click;
            // 
            // PIDHex
            // 
            PIDHex.Location = new System.Drawing.Point(103, 23);
            PIDHex.Name = "PIDHex";
            PIDHex.Size = new System.Drawing.Size(100, 25);
            PIDHex.TabIndex = 2;
            // 
            // PID
            // 
            PID.AutoSize = true;
            PID.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            PID.Location = new System.Drawing.Point(12, 27);
            PID.Name = "PID";
            PID.Size = new System.Drawing.Size(111, 15);
            PID.TabIndex = 3;
            PID.Text = "通过PID算性格";
            // 
            // Nature
            // 
            Nature.Enabled = false;
            Nature.Location = new System.Drawing.Point(209, 23);
            Nature.Name = "Nature";
            Nature.Size = new System.Drawing.Size(100, 25);
            Nature.TabIndex = 4;
            // 
            // CloseBTN
            // 
            CloseBTN.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            CloseBTN.Location = new System.Drawing.Point(315, 147);
            CloseBTN.Name = "CloseBTN";
            CloseBTN.Size = new System.Drawing.Size(100, 25);
            CloseBTN.TabIndex = 5;
            CloseBTN.Text = "关闭";
            CloseBTN.UseVisualStyleBackColor = true;
            CloseBTN.Click += CloseBTN_Click;
            // 
            // Hex1
            // 
            Hex1.Location = new System.Drawing.Point(103, 54);
            Hex1.Name = "Hex1";
            Hex1.Size = new System.Drawing.Size(100, 25);
            Hex1.TabIndex = 6;
            // 
            // Dec1
            // 
            Dec1.Enabled = false;
            Dec1.Location = new System.Drawing.Point(209, 54);
            Dec1.Name = "Dec1";
            Dec1.Size = new System.Drawing.Size(100, 25);
            Dec1.TabIndex = 7;
            // 
            // Dec2
            // 
            Dec2.Location = new System.Drawing.Point(103, 85);
            Dec2.Name = "Dec2";
            Dec2.Size = new System.Drawing.Size(100, 25);
            Dec2.TabIndex = 8;
            // 
            // Hex2
            // 
            Hex2.Enabled = false;
            Hex2.Location = new System.Drawing.Point(209, 85);
            Hex2.Name = "Hex2";
            Hex2.Size = new System.Drawing.Size(100, 25);
            Hex2.TabIndex = 9;
            // 
            // CalcHTD
            // 
            CalcHTD.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            CalcHTD.Location = new System.Drawing.Point(315, 53);
            CalcHTD.Name = "CalcHTD";
            CalcHTD.Size = new System.Drawing.Size(100, 25);
            CalcHTD.TabIndex = 10;
            CalcHTD.Text = "计算";
            CalcHTD.UseVisualStyleBackColor = true;
            CalcHTD.Click += CalcHTD_Click;
            // 
            // CalcDTH
            // 
            CalcDTH.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            CalcDTH.Location = new System.Drawing.Point(315, 85);
            CalcDTH.Name = "CalcDTH";
            CalcDTH.Size = new System.Drawing.Size(100, 26);
            CalcDTH.TabIndex = 11;
            CalcDTH.Text = "计算";
            CalcDTH.UseVisualStyleBackColor = true;
            CalcDTH.Click += CalcDTH_Click;
            // 
            // TID16
            // 
            TID16.Location = new System.Drawing.Point(103, 116);
            TID16.Name = "TID16";
            TID16.Size = new System.Drawing.Size(100, 25);
            TID16.TabIndex = 12;
            // 
            // SID16
            // 
            SID16.Location = new System.Drawing.Point(103, 147);
            SID16.Name = "SID16";
            SID16.Size = new System.Drawing.Size(100, 25);
            SID16.TabIndex = 13;
            // 
            // CalcID
            // 
            CalcID.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            CalcID.Location = new System.Drawing.Point(315, 116);
            CalcID.Name = "CalcID";
            CalcID.Size = new System.Drawing.Size(100, 26);
            CalcID.TabIndex = 14;
            CalcID.Text = "转换";
            CalcID.UseVisualStyleBackColor = true;
            CalcID.Click += CalcID_Click;
            // 
            // HTC
            // 
            HTC.AutoSize = true;
            HTC.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            HTC.Location = new System.Drawing.Point(6, 57);
            HTC.Name = "HTC";
            HTC.Size = new System.Drawing.Size(119, 15);
            HTC.TabIndex = 15;
            HTC.Text = "16进制转10进制";
            // 
            // CTH
            // 
            CTH.AutoSize = true;
            CTH.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            CTH.Location = new System.Drawing.Point(6, 88);
            CTH.Name = "CTH";
            CTH.Size = new System.Drawing.Size(119, 15);
            CTH.TabIndex = 16;
            CTH.Text = "10进制转16进制";
            // 
            // TID16Result
            // 
            TID16Result.Enabled = false;
            TID16Result.Location = new System.Drawing.Point(209, 116);
            TID16Result.Name = "TID16Result";
            TID16Result.Size = new System.Drawing.Size(100, 25);
            TID16Result.TabIndex = 17;
            // 
            // SID16Result
            // 
            SID16Result.Enabled = false;
            SID16Result.Location = new System.Drawing.Point(209, 147);
            SID16Result.Name = "SID16Result";
            SID16Result.Size = new System.Drawing.Size(100, 25);
            SID16Result.TabIndex = 18;
            // 
            // IDCheck
            // 
            IDCheck.AutoSize = true;
            IDCheck.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            IDCheck.Location = new System.Drawing.Point(78, 214);
            IDCheck.Name = "IDCheck";
            IDCheck.Size = new System.Drawing.Size(125, 19);
            IDCheck.TabIndex = 19;
            IDCheck.Text = "5位ID转7位ID";
            IDCheck.UseVisualStyleBackColor = true;
            // 
            // IDsCheck
            // 
            IDsCheck.AutoSize = true;
            IDsCheck.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            IDsCheck.Location = new System.Drawing.Point(209, 214);
            IDsCheck.Name = "IDsCheck";
            IDsCheck.Size = new System.Drawing.Size(125, 19);
            IDsCheck.TabIndex = 20;
            IDsCheck.Text = "7位ID转5位ID";
            IDsCheck.UseVisualStyleBackColor = true;
            // 
            // TID16Label
            // 
            TID16Label.AutoSize = true;
            TID16Label.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            TID16Label.Location = new System.Drawing.Point(66, 118);
            TID16Label.Name = "TID16Label";
            TID16Label.Size = new System.Drawing.Size(39, 15);
            TID16Label.TabIndex = 31;
            TID16Label.Text = "表ID";
            // 
            // SID16Label
            // 
            SID16Label.AutoSize = true;
            SID16Label.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            SID16Label.Location = new System.Drawing.Point(66, 151);
            SID16Label.Name = "SID16Label";
            SID16Label.Size = new System.Drawing.Size(39, 15);
            SID16Label.TabIndex = 32;
            SID16Label.Text = "里ID";
            // 
            // UnownPidTextBox
            // 
            UnownPidTextBox.Location = new System.Drawing.Point(123, 178);
            UnownPidTextBox.Name = "UnownPidTextBox";
            UnownPidTextBox.Size = new System.Drawing.Size(129, 25);
            UnownPidTextBox.TabIndex = 33;
            // 
            // UnownFormBox
            // 
            UnownFormBox.Location = new System.Drawing.Point(258, 178);
            UnownFormBox.Name = "UnownFormBox";
            UnownFormBox.Size = new System.Drawing.Size(51, 25);
            UnownFormBox.TabIndex = 34;
            // 
            // UnownLabel
            // 
            UnownLabel.AutoSize = true;
            UnownLabel.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            UnownLabel.Location = new System.Drawing.Point(12, 182);
            UnownLabel.Name = "UnownLabel";
            UnownLabel.Size = new System.Drawing.Size(135, 15);
            UnownLabel.TabIndex = 35;
            UnownLabel.Text = "Gen3未知图腾形态";
            // 
            // FormCalc
            // 
            FormCalc.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            FormCalc.Location = new System.Drawing.Point(315, 178);
            FormCalc.Name = "FormCalc";
            FormCalc.Size = new System.Drawing.Size(100, 25);
            FormCalc.TabIndex = 36;
            FormCalc.Text = "计算";
            FormCalc.UseVisualStyleBackColor = true;
            FormCalc.Click += FormCalc_Click;
            // 
            // MutiCalcUI
            // 
            ClientSize = new System.Drawing.Size(424, 245);
            Controls.Add(FormCalc);
            Controls.Add(UnownLabel);
            Controls.Add(UnownFormBox);
            Controls.Add(UnownPidTextBox);
            Controls.Add(SID16Label);
            Controls.Add(TID16Label);
            Controls.Add(IDsCheck);
            Controls.Add(IDCheck);
            Controls.Add(SID16Result);
            Controls.Add(TID16Result);
            Controls.Add(CTH);
            Controls.Add(HTC);
            Controls.Add(CalcID);
            Controls.Add(SID16);
            Controls.Add(TID16);
            Controls.Add(CalcDTH);
            Controls.Add(CalcHTD);
            Controls.Add(Hex2);
            Controls.Add(Dec2);
            Controls.Add(Dec1);
            Controls.Add(Hex1);
            Controls.Add(CloseBTN);
            Controls.Add(Nature);
            Controls.Add(PID);
            Controls.Add(PIDHex);
            Controls.Add(CalcNature);
            Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MutiCalcUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Super Wang";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
