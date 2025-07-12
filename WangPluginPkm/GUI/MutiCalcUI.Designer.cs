using System.Windows.Forms;

namespace WangPluginPkm.GUI
{
    partial class MutiCalcUI
    {
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MutiCalcUI));
            tabPage1 = new TabPage();
            PIDHex = new TextBox();
            Nature = new TextBox();
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
            CalcNature = new Button();
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
            tabPage2 = new TabPage();
            label4 = new Label();
            XorN = new NumericUpDown();
            SToNS_BTN = new Button();
            label3 = new Label();
            label2 = new Label();
            SID_TB = new TextBox();
            TID_TB = new TextBox();
            ReadEditorBTN = new Button();
            ShinyPID_TB = new TextBox();
            NSToS_BTN = new Button();
            NonShinyPID_TB = new TextBox();
            label1 = new Label();
            UnownFormBox = new TextBox();
            UnownPidTextBox = new TextBox();
            FormCalc = new Button();
            UnownLabel = new Label();
            tabPage1.SuspendLayout();
            tabControl.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)XorN).BeginInit();
            SuspendLayout();
            // 
            // tabPage1
            // 
            tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            tabPage1.Controls.Add(PIDHex);
            tabPage1.Controls.Add(Nature);
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
            tabPage1.Controls.Add(CalcNature);
            tabPage1.Controls.Add(PID);
            tabPage1.Controls.Add(CloseBTN);
            tabPage1.Controls.Add(SID16Label);
            tabPage1.Controls.Add(TID16Label);
            tabPage1.Controls.Add(CalcHTD);
            tabPage1.Controls.Add(CalcDTH);
            tabPage1.Controls.Add(CTH);
            tabPage1.Controls.Add(HTC);
            tabPage1.Controls.Add(CalcID);
            tabPage1.Location = new System.Drawing.Point(4, 26);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new System.Drawing.Size(616, 283);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "通用计算器";
            // 
            // PIDHex
            // 
            PIDHex.Location = new System.Drawing.Point(156, 25);
            PIDHex.Name = "PIDHex";
            PIDHex.Size = new System.Drawing.Size(130, 25);
            PIDHex.TabIndex = 2;
            // 
            // Nature
            // 
            Nature.Enabled = false;
            Nature.Location = new System.Drawing.Point(320, 25);
            Nature.Name = "Nature";
            Nature.Size = new System.Drawing.Size(130, 25);
            Nature.TabIndex = 4;
            // 
            // Hex1
            // 
            Hex1.Location = new System.Drawing.Point(156, 68);
            Hex1.Name = "Hex1";
            Hex1.Size = new System.Drawing.Size(130, 25);
            Hex1.TabIndex = 6;
            // 
            // Dec1
            // 
            Dec1.Enabled = false;
            Dec1.Location = new System.Drawing.Point(320, 68);
            Dec1.Name = "Dec1";
            Dec1.Size = new System.Drawing.Size(130, 25);
            Dec1.TabIndex = 7;
            // 
            // Dec2
            // 
            Dec2.Location = new System.Drawing.Point(156, 111);
            Dec2.Name = "Dec2";
            Dec2.Size = new System.Drawing.Size(130, 25);
            Dec2.TabIndex = 8;
            // 
            // Hex2
            // 
            Hex2.Enabled = false;
            Hex2.Location = new System.Drawing.Point(320, 111);
            Hex2.Name = "Hex2";
            Hex2.Size = new System.Drawing.Size(130, 25);
            Hex2.TabIndex = 9;
            // 
            // SID16Result
            // 
            SID16Result.Enabled = false;
            SID16Result.Location = new System.Drawing.Point(320, 198);
            SID16Result.Name = "SID16Result";
            SID16Result.Size = new System.Drawing.Size(130, 25);
            SID16Result.TabIndex = 18;
            // 
            // TID16Result
            // 
            TID16Result.Enabled = false;
            TID16Result.Location = new System.Drawing.Point(320, 155);
            TID16Result.Name = "TID16Result";
            TID16Result.Size = new System.Drawing.Size(130, 25);
            TID16Result.TabIndex = 17;
            // 
            // TID16
            // 
            TID16.Location = new System.Drawing.Point(156, 155);
            TID16.Name = "TID16";
            TID16.Size = new System.Drawing.Size(130, 25);
            TID16.TabIndex = 12;
            // 
            // SID16
            // 
            SID16.Location = new System.Drawing.Point(156, 198);
            SID16.Name = "SID16";
            SID16.Size = new System.Drawing.Size(130, 25);
            SID16.TabIndex = 13;
            // 
            // IDsCheck
            // 
            IDsCheck.AutoSize = true;
            IDsCheck.Font = new System.Drawing.Font("黑体", 9F);
            IDsCheck.Location = new System.Drawing.Point(320, 241);
            IDsCheck.Name = "IDsCheck";
            IDsCheck.Size = new System.Drawing.Size(125, 19);
            IDsCheck.TabIndex = 20;
            IDsCheck.Text = "7位ID转5位ID";
            IDsCheck.UseVisualStyleBackColor = true;
            // 
            // IDCheck
            // 
            IDCheck.AutoSize = true;
            IDCheck.Font = new System.Drawing.Font("黑体", 9F);
            IDCheck.Location = new System.Drawing.Point(156, 241);
            IDCheck.Name = "IDCheck";
            IDCheck.Size = new System.Drawing.Size(125, 19);
            IDCheck.TabIndex = 19;
            IDCheck.Text = "5位ID转7位ID";
            IDCheck.UseVisualStyleBackColor = true;
            // 
            // CalcNature
            // 
            CalcNature.Font = new System.Drawing.Font("黑体", 9F);
            CalcNature.Location = new System.Drawing.Point(456, 24);
            CalcNature.Name = "CalcNature";
            CalcNature.Size = new System.Drawing.Size(100, 25);
            CalcNature.TabIndex = 0;
            CalcNature.Text = "计算";
            CalcNature.UseVisualStyleBackColor = true;
            CalcNature.Click += CalcStart_Click;
            // 
            // PID
            // 
            PID.AutoSize = true;
            PID.Font = new System.Drawing.Font("黑体", 9F);
            PID.Location = new System.Drawing.Point(39, 29);
            PID.Name = "PID";
            PID.Size = new System.Drawing.Size(111, 15);
            PID.TabIndex = 3;
            PID.Text = "通过PID算性格";
            // 
            // CloseBTN
            // 
            CloseBTN.Font = new System.Drawing.Font("黑体", 9F);
            CloseBTN.Location = new System.Drawing.Point(456, 198);
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
            SID16Label.Font = new System.Drawing.Font("黑体", 9F);
            SID16Label.Location = new System.Drawing.Point(111, 203);
            SID16Label.Name = "SID16Label";
            SID16Label.Size = new System.Drawing.Size(39, 15);
            SID16Label.TabIndex = 32;
            SID16Label.Text = "里ID";
            // 
            // TID16Label
            // 
            TID16Label.AutoSize = true;
            TID16Label.Font = new System.Drawing.Font("黑体", 9F);
            TID16Label.Location = new System.Drawing.Point(111, 159);
            TID16Label.Name = "TID16Label";
            TID16Label.Size = new System.Drawing.Size(39, 15);
            TID16Label.TabIndex = 31;
            TID16Label.Text = "表ID";
            // 
            // CalcHTD
            // 
            CalcHTD.Font = new System.Drawing.Font("黑体", 9F);
            CalcHTD.Location = new System.Drawing.Point(456, 67);
            CalcHTD.Name = "CalcHTD";
            CalcHTD.Size = new System.Drawing.Size(100, 25);
            CalcHTD.TabIndex = 10;
            CalcHTD.Text = "计算";
            CalcHTD.UseVisualStyleBackColor = true;
            CalcHTD.Click += CalcHTD_Click;
            // 
            // CalcDTH
            // 
            CalcDTH.Font = new System.Drawing.Font("黑体", 9F);
            CalcDTH.Location = new System.Drawing.Point(456, 109);
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
            CTH.Font = new System.Drawing.Font("黑体", 9F);
            CTH.Location = new System.Drawing.Point(31, 115);
            CTH.Name = "CTH";
            CTH.Size = new System.Drawing.Size(119, 15);
            CTH.TabIndex = 16;
            CTH.Text = "10进制转16进制";
            // 
            // HTC
            // 
            HTC.AutoSize = true;
            HTC.Font = new System.Drawing.Font("黑体", 9F);
            HTC.Location = new System.Drawing.Point(31, 72);
            HTC.Name = "HTC";
            HTC.Size = new System.Drawing.Size(119, 15);
            HTC.TabIndex = 15;
            HTC.Text = "16进制转10进制";
            // 
            // CalcID
            // 
            CalcID.Font = new System.Drawing.Font("黑体", 9F);
            CalcID.Location = new System.Drawing.Point(456, 153);
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
            tabControl.Size = new System.Drawing.Size(624, 313);
            tabControl.TabIndex = 37;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(XorN);
            tabPage2.Controls.Add(SToNS_BTN);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(SID_TB);
            tabPage2.Controls.Add(TID_TB);
            tabPage2.Controls.Add(ReadEditorBTN);
            tabPage2.Controls.Add(ShinyPID_TB);
            tabPage2.Controls.Add(NSToS_BTN);
            tabPage2.Controls.Add(NonShinyPID_TB);
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(UnownFormBox);
            tabPage2.Controls.Add(UnownPidTextBox);
            tabPage2.Controls.Add(FormCalc);
            tabPage2.Controls.Add(UnownLabel);
            tabPage2.Location = new System.Drawing.Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new System.Drawing.Size(616, 280);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "特殊计算";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("黑体", 9F);
            label4.Location = new System.Drawing.Point(328, 158);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(47, 15);
            label4.TabIndex = 52;
            label4.Text = "XOR值";
            // 
            // XorN
            // 
            XorN.Location = new System.Drawing.Point(381, 155);
            XorN.Maximum = new decimal(new int[] { 15, 0, 0, 0 });
            XorN.Name = "XorN";
            XorN.Size = new System.Drawing.Size(51, 25);
            XorN.TabIndex = 51;
            // 
            // SToNS_BTN
            // 
            SToNS_BTN.Font = new System.Drawing.Font("黑体", 9F);
            SToNS_BTN.Location = new System.Drawing.Point(300, 104);
            SToNS_BTN.Name = "SToNS_BTN";
            SToNS_BTN.Size = new System.Drawing.Size(37, 25);
            SToNS_BTN.TabIndex = 50;
            SToNS_BTN.Text = "<";
            SToNS_BTN.UseVisualStyleBackColor = true;
            SToNS_BTN.Click += SToNS_BTN_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("黑体", 9F);
            label3.Location = new System.Drawing.Point(136, 175);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(47, 15);
            label3.TabIndex = 49;
            label3.Text = "SID16";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("黑体", 9F);
            label2.Location = new System.Drawing.Point(136, 144);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(47, 15);
            label2.TabIndex = 48;
            label2.Text = "TID16";
            // 
            // SID_TB
            // 
            SID_TB.Location = new System.Drawing.Point(189, 171);
            SID_TB.Name = "SID_TB";
            SID_TB.Size = new System.Drawing.Size(130, 25);
            SID_TB.TabIndex = 47;
            // 
            // TID_TB
            // 
            TID_TB.Location = new System.Drawing.Point(189, 140);
            TID_TB.Name = "TID_TB";
            TID_TB.Size = new System.Drawing.Size(130, 25);
            TID_TB.TabIndex = 46;
            // 
            // ReadEditorBTN
            // 
            ReadEditorBTN.Font = new System.Drawing.Font("黑体", 9F);
            ReadEditorBTN.Location = new System.Drawing.Point(479, 83);
            ReadEditorBTN.Name = "ReadEditorBTN";
            ReadEditorBTN.Size = new System.Drawing.Size(100, 25);
            ReadEditorBTN.TabIndex = 45;
            ReadEditorBTN.Text = "读面板";
            ReadEditorBTN.UseVisualStyleBackColor = true;
            ReadEditorBTN.Click += ReadEditorBTN_Click;
            // 
            // ShinyPID_TB
            // 
            ShinyPID_TB.Location = new System.Drawing.Point(343, 83);
            ShinyPID_TB.Name = "ShinyPID_TB";
            ShinyPID_TB.Size = new System.Drawing.Size(130, 25);
            ShinyPID_TB.TabIndex = 44;
            // 
            // NSToS_BTN
            // 
            NSToS_BTN.Font = new System.Drawing.Font("黑体", 9F);
            NSToS_BTN.Location = new System.Drawing.Point(300, 73);
            NSToS_BTN.Name = "NSToS_BTN";
            NSToS_BTN.Size = new System.Drawing.Size(37, 25);
            NSToS_BTN.TabIndex = 43;
            NSToS_BTN.Text = ">";
            NSToS_BTN.UseVisualStyleBackColor = true;
            NSToS_BTN.Click += NSToS_BTN_Click;
            // 
            // NonShinyPID_TB
            // 
            NonShinyPID_TB.Location = new System.Drawing.Point(164, 83);
            NonShinyPID_TB.Name = "NonShinyPID_TB";
            NonShinyPID_TB.Size = new System.Drawing.Size(130, 25);
            NonShinyPID_TB.TabIndex = 42;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("黑体", 9F);
            label1.Location = new System.Drawing.Point(39, 88);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(119, 15);
            label1.TabIndex = 41;
            label1.Text = "Xor闪光PID计算";
            // 
            // UnownFormBox
            // 
            UnownFormBox.Location = new System.Drawing.Point(328, 26);
            UnownFormBox.Name = "UnownFormBox";
            UnownFormBox.Size = new System.Drawing.Size(130, 25);
            UnownFormBox.TabIndex = 38;
            // 
            // UnownPidTextBox
            // 
            UnownPidTextBox.Location = new System.Drawing.Point(164, 26);
            UnownPidTextBox.Name = "UnownPidTextBox";
            UnownPidTextBox.Size = new System.Drawing.Size(130, 25);
            UnownPidTextBox.TabIndex = 37;
            // 
            // FormCalc
            // 
            FormCalc.Font = new System.Drawing.Font("黑体", 9F);
            FormCalc.Location = new System.Drawing.Point(464, 25);
            FormCalc.Name = "FormCalc";
            FormCalc.Size = new System.Drawing.Size(100, 25);
            FormCalc.TabIndex = 40;
            FormCalc.Text = "计算";
            FormCalc.UseVisualStyleBackColor = true;
            // 
            // UnownLabel
            // 
            UnownLabel.AutoSize = true;
            UnownLabel.Font = new System.Drawing.Font("黑体", 9F);
            UnownLabel.Location = new System.Drawing.Point(23, 30);
            UnownLabel.Name = "UnownLabel";
            UnownLabel.Size = new System.Drawing.Size(135, 15);
            UnownLabel.TabIndex = 39;
            UnownLabel.Text = "Gen3未知图腾形态";
            // 
            // MutiCalcUI
            // 
            ClientSize = new System.Drawing.Size(651, 341);
            Controls.Add(tabControl);
            Font = new System.Drawing.Font("Arial", 9F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MutiCalcUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Super Wang";
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabControl.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)XorN).EndInit();
            ResumeLayout(false);
        }

        private TabPage tabPage1;
        private TextBox PIDHex;
        private TextBox Nature;
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
        private Button CalcNature;
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
        private TabPage tabPage2;
        private TextBox UnownFormBox;
        private TextBox UnownPidTextBox;
        private Button FormCalc;
        private Label UnownLabel;
        private TextBox ShinyPID_TB;
        private Button NSToS_BTN;
        private TextBox NonShinyPID_TB;
        private Label label1;
        private Label label3;
        private Label label2;
        private TextBox SID_TB;
        private TextBox TID_TB;
        private Button ReadEditorBTN;
        private Button SToNS_BTN;
        private NumericUpDown XorN;
        private Label label4;
    }
}
