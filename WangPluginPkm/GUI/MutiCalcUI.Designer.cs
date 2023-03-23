using System.Windows.Forms;

namespace WangPluginPkm.GUI
{
    partial class MutiCalcUI
    {
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MutiCalcUI));
            tabPage2 = new TabPage();
            tabPage1 = new TabPage();
            PIDHex = new TextBox();
            UnownFormBox = new TextBox();
            Nature = new TextBox();
            UnownPidTextBox = new TextBox();
            Hex1 = new TextBox();
            Dec1 = new TextBox();
            Dec2 = new TextBox();
            Hex2 = new TextBox();
            SID16Result = new TextBox();
            TID16Result = new TextBox();
            TID16 = new TextBox();
            SID16 = new TextBox();
            IDsCheck = new CheckBox();
            IDCheck = new CheckBox();
            FormCalc = new Button();
            CalcNature = new Button();
            UnownLabel = new Label();
            PID = new Label();
            CloseBTN = new Button();
            SID16Label = new Label();
            TID16Label = new Label();
            CalcHTD = new Button();
            CalcDTH = new Button();
            CTH = new Label();
            HTC = new Label();
            CalcID = new Button();
            tabControl = new TabControl();
            tabPage1.SuspendLayout();
            tabControl.SuspendLayout();
            SuspendLayout();
            // 
            // tabPage2
            // 
            tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            tabPage2.Location = new System.Drawing.Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new System.Drawing.Size(616, 341);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            // 
            // tabPage1
            // 
            tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            tabPage1.Controls.Add(PIDHex);
            tabPage1.Controls.Add(UnownFormBox);
            tabPage1.Controls.Add(Nature);
            tabPage1.Controls.Add(UnownPidTextBox);
            tabPage1.Controls.Add(Hex1);
            tabPage1.Controls.Add(Dec1);
            tabPage1.Controls.Add(Dec2);
            tabPage1.Controls.Add(Hex2);
            tabPage1.Controls.Add(SID16Result);
            tabPage1.Controls.Add(TID16Result);
            tabPage1.Controls.Add(TID16);
            tabPage1.Controls.Add(SID16);
            tabPage1.Controls.Add(IDsCheck);
            tabPage1.Controls.Add(IDCheck);
            tabPage1.Controls.Add(FormCalc);
            tabPage1.Controls.Add(CalcNature);
            tabPage1.Controls.Add(UnownLabel);
            tabPage1.Controls.Add(PID);
            tabPage1.Controls.Add(CloseBTN);
            tabPage1.Controls.Add(SID16Label);
            tabPage1.Controls.Add(TID16Label);
            tabPage1.Controls.Add(CalcHTD);
            tabPage1.Controls.Add(CalcDTH);
            tabPage1.Controls.Add(CTH);
            tabPage1.Controls.Add(HTC);
            tabPage1.Controls.Add(CalcID);
            tabPage1.Location = new System.Drawing.Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new System.Drawing.Size(616, 341);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "通用计算器";
            // 
            // PIDHex
            // 
            PIDHex.Location = new System.Drawing.Point(135, 26);
            PIDHex.Name = "PIDHex";
            PIDHex.Size = new System.Drawing.Size(130, 21);
            PIDHex.TabIndex = 2;
            // 
            // UnownFormBox
            // 
            UnownFormBox.Location = new System.Drawing.Point(299, 278);
            UnownFormBox.Name = "UnownFormBox";
            UnownFormBox.Size = new System.Drawing.Size(130, 21);
            UnownFormBox.TabIndex = 34;
            // 
            // Nature
            // 
            Nature.Enabled = false;
            Nature.Location = new System.Drawing.Point(299, 26);
            Nature.Name = "Nature";
            Nature.Size = new System.Drawing.Size(130, 21);
            Nature.TabIndex = 4;
            // 
            // UnownPidTextBox
            // 
            UnownPidTextBox.Location = new System.Drawing.Point(135, 279);
            UnownPidTextBox.Name = "UnownPidTextBox";
            UnownPidTextBox.Size = new System.Drawing.Size(130, 21);
            UnownPidTextBox.TabIndex = 33;
            // 
            // Hex1
            // 
            Hex1.Location = new System.Drawing.Point(135, 69);
            Hex1.Name = "Hex1";
            Hex1.Size = new System.Drawing.Size(130, 21);
            Hex1.TabIndex = 6;
            // 
            // Dec1
            // 
            Dec1.Enabled = false;
            Dec1.Location = new System.Drawing.Point(299, 69);
            Dec1.Name = "Dec1";
            Dec1.Size = new System.Drawing.Size(130, 21);
            Dec1.TabIndex = 7;
            // 
            // Dec2
            // 
            Dec2.Location = new System.Drawing.Point(135, 112);
            Dec2.Name = "Dec2";
            Dec2.Size = new System.Drawing.Size(130, 21);
            Dec2.TabIndex = 8;
            // 
            // Hex2
            // 
            Hex2.Enabled = false;
            Hex2.Location = new System.Drawing.Point(299, 112);
            Hex2.Name = "Hex2";
            Hex2.Size = new System.Drawing.Size(130, 21);
            Hex2.TabIndex = 9;
            // 
            // SID16Result
            // 
            SID16Result.Enabled = false;
            SID16Result.Location = new System.Drawing.Point(299, 199);
            SID16Result.Name = "SID16Result";
            SID16Result.Size = new System.Drawing.Size(130, 21);
            SID16Result.TabIndex = 18;
            // 
            // TID16Result
            // 
            TID16Result.Enabled = false;
            TID16Result.Location = new System.Drawing.Point(299, 156);
            TID16Result.Name = "TID16Result";
            TID16Result.Size = new System.Drawing.Size(130, 21);
            TID16Result.TabIndex = 17;
            // 
            // TID16
            // 
            TID16.Location = new System.Drawing.Point(135, 156);
            TID16.Name = "TID16";
            TID16.Size = new System.Drawing.Size(130, 21);
            TID16.TabIndex = 12;
            // 
            // SID16
            // 
            SID16.Location = new System.Drawing.Point(135, 199);
            SID16.Name = "SID16";
            SID16.Size = new System.Drawing.Size(130, 21);
            SID16.TabIndex = 13;
            // 
            // IDsCheck
            // 
            IDsCheck.AutoSize = true;
            IDsCheck.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            IDsCheck.Location = new System.Drawing.Point(299, 242);
            IDsCheck.Name = "IDsCheck";
            IDsCheck.Size = new System.Drawing.Size(96, 16);
            IDsCheck.TabIndex = 20;
            IDsCheck.Text = "7位ID转5位ID";
            IDsCheck.UseVisualStyleBackColor = true;
            // 
            // IDCheck
            // 
            IDCheck.AutoSize = true;
            IDCheck.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            IDCheck.Location = new System.Drawing.Point(135, 242);
            IDCheck.Name = "IDCheck";
            IDCheck.Size = new System.Drawing.Size(96, 16);
            IDCheck.TabIndex = 19;
            IDCheck.Text = "5位ID转7位ID";
            IDCheck.UseVisualStyleBackColor = true;
            // 
            // FormCalc
            // 
            FormCalc.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            FormCalc.Location = new System.Drawing.Point(435, 277);
            FormCalc.Name = "FormCalc";
            FormCalc.Size = new System.Drawing.Size(100, 25);
            FormCalc.TabIndex = 36;
            FormCalc.Text = "计算";
            FormCalc.UseVisualStyleBackColor = true;
            FormCalc.Click += FormCalc_Click;
            // 
            // CalcNature
            // 
            CalcNature.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            CalcNature.Location = new System.Drawing.Point(435, 25);
            CalcNature.Name = "CalcNature";
            CalcNature.Size = new System.Drawing.Size(100, 25);
            CalcNature.TabIndex = 0;
            CalcNature.Text = "计算";
            CalcNature.UseVisualStyleBackColor = true;
            CalcNature.Click += CalcStart_Click;
            // 
            // UnownLabel
            // 
            UnownLabel.AutoSize = true;
            UnownLabel.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            UnownLabel.Location = new System.Drawing.Point(24, 283);
            UnownLabel.Name = "UnownLabel";
            UnownLabel.Size = new System.Drawing.Size(101, 12);
            UnownLabel.TabIndex = 35;
            UnownLabel.Text = "Gen3未知图腾形态";
            // 
            // PID
            // 
            PID.AutoSize = true;
            PID.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            PID.Location = new System.Drawing.Point(44, 30);
            PID.Name = "PID";
            PID.Size = new System.Drawing.Size(83, 12);
            PID.TabIndex = 3;
            PID.Text = "通过PID算性格";
            // 
            // CloseBTN
            // 
            CloseBTN.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            CloseBTN.Location = new System.Drawing.Point(435, 199);
            CloseBTN.Name = "CloseBTN";
            CloseBTN.Size = new System.Drawing.Size(100, 25);
            CloseBTN.TabIndex = 5;
            CloseBTN.Text = "关闭";
            CloseBTN.UseVisualStyleBackColor = true;
            CloseBTN.Click += CloseBTN_Click;
            // 
            // SID16Label
            // 
            SID16Label.AutoSize = true;
            SID16Label.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            SID16Label.Location = new System.Drawing.Point(98, 205);
            SID16Label.Name = "SID16Label";
            SID16Label.Size = new System.Drawing.Size(29, 12);
            SID16Label.TabIndex = 32;
            SID16Label.Text = "里ID";
            // 
            // TID16Label
            // 
            TID16Label.AutoSize = true;
            TID16Label.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            TID16Label.Location = new System.Drawing.Point(98, 160);
            TID16Label.Name = "TID16Label";
            TID16Label.Size = new System.Drawing.Size(29, 12);
            TID16Label.TabIndex = 31;
            TID16Label.Text = "表ID";
            // 
            // CalcHTD
            // 
            CalcHTD.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            CalcHTD.Location = new System.Drawing.Point(435, 68);
            CalcHTD.Name = "CalcHTD";
            CalcHTD.Size = new System.Drawing.Size(100, 25);
            CalcHTD.TabIndex = 10;
            CalcHTD.Text = "计算";
            CalcHTD.UseVisualStyleBackColor = true;
            CalcHTD.Click += CalcHTD_Click;
            // 
            // CalcDTH
            // 
            CalcDTH.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            CalcDTH.Location = new System.Drawing.Point(435, 110);
            CalcDTH.Name = "CalcDTH";
            CalcDTH.Size = new System.Drawing.Size(100, 26);
            CalcDTH.TabIndex = 11;
            CalcDTH.Text = "计算";
            CalcDTH.UseVisualStyleBackColor = true;
            CalcDTH.Click += CalcDTH_Click;
            // 
            // CTH
            // 
            CTH.AutoSize = true;
            CTH.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            CTH.Location = new System.Drawing.Point(38, 114);
            CTH.Name = "CTH";
            CTH.Size = new System.Drawing.Size(89, 12);
            CTH.TabIndex = 16;
            CTH.Text = "10进制转16进制";
            // 
            // HTC
            // 
            HTC.AutoSize = true;
            HTC.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            HTC.Location = new System.Drawing.Point(38, 70);
            HTC.Name = "HTC";
            HTC.Size = new System.Drawing.Size(89, 12);
            HTC.TabIndex = 15;
            HTC.Text = "16进制转10进制";
            // 
            // CalcID
            // 
            CalcID.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            CalcID.Location = new System.Drawing.Point(435, 154);
            CalcID.Name = "CalcID";
            CalcID.Size = new System.Drawing.Size(100, 26);
            CalcID.TabIndex = 14;
            CalcID.Text = "转换";
            CalcID.UseVisualStyleBackColor = true;
            CalcID.Click += CalcID_Click;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPage1);
            tabControl.Controls.Add(tabPage2);
            tabControl.Location = new System.Drawing.Point(12, 12);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new System.Drawing.Size(624, 369);
            tabControl.TabIndex = 37;
            // 
            // MutiCalcUI
            // 
            ClientSize = new System.Drawing.Size(651, 389);
            Controls.Add(tabControl);
            Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MutiCalcUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Super Wang";
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabControl.ResumeLayout(false);
            ResumeLayout(false);
        }

        private TabPage tabPage2;
        private TabPage tabPage1;
        private TextBox PIDHex;
        private TextBox UnownFormBox;
        private TextBox Nature;
        private TextBox UnownPidTextBox;
        private TextBox Hex1;
        private TextBox Dec1;
        private TextBox Dec2;
        private TextBox Hex2;
        private TextBox SID16Result;
        private TextBox TID16Result;
        private TextBox TID16;
        private TextBox SID16;
        private CheckBox IDsCheck;
        private CheckBox IDCheck;
        private Button FormCalc;
        private Button CalcNature;
        private Label UnownLabel;
        private Label PID;
        private Button CloseBTN;
        private Label SID16Label;
        private Label TID16Label;
        private Button CalcHTD;
        private Button CalcDTH;
        private Label CTH;
        private Label HTC;
        private Button CalcID;
        private TabControl tabControl;
    }
}
