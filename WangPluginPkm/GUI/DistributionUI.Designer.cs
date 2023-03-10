using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WangPluginPkm.GUI
{
    partial class DistributionUI
    {
        private OpenFileDialog OpenFile_Dialog;
        private TextBox BOX_TextBox;
        private Label BOX_Label;
        private Button Clone_BTN;
        private Button LoadEH1_BTN;
        private CheckBox ShinyBox;
        private Button Gift_BTN;
        private CheckBox SetTrainer_Box;
        private Button AllRibbon_BTN;
        private Button LoadTrainer_BTN;
        private ComboBox BallBox;
        private ComboBox Trainer_Box;
        private Button Use_Trainer_BTN;
        private Button IVEVN_BTN;
        private Button Move_Shop;
        private Button LevelMax_BTN;
        private CheckBox Ball_Box;
        private ComboBox Edit_EVIVN_Box;
        private ComboBox Clone_Select_Box;
        private ComboBox Trainer_Select_Box;
        private CheckBox Random_Trainer_Box;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private CheckBox Random_Name_Box;
        private CheckBox RandEC_Box;
        private CheckBox RandPID_Box;
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DistributionUI));
            LoadEH1_BTN = new Button();
            OpenFile_Dialog = new OpenFileDialog();
            BOX_TextBox = new TextBox();
            BOX_Label = new Label();
            Clone_BTN = new Button();
            ShinyBox = new CheckBox();
            Gift_BTN = new Button();
            SetTrainer_Box = new CheckBox();
            AllRibbon_BTN = new Button();
            LoadTrainer_BTN = new Button();
            BallBox = new ComboBox();
            Trainer_Box = new ComboBox();
            Use_Trainer_BTN = new Button();
            RandPID_Box = new CheckBox();
            IVEVN_BTN = new Button();
            Move_Shop = new Button();
            LevelMax_BTN = new Button();
            Ball_Box = new CheckBox();
            Edit_EVIVN_Box = new ComboBox();
            Clone_Select_Box = new ComboBox();
            Trainer_Select_Box = new ComboBox();
            Random_Trainer_Box = new CheckBox();
            groupBox1 = new GroupBox();
            RandEC_Box = new CheckBox();
            Random_Name_Box = new CheckBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            Random_EggBTN = new Button();
            Random_EncBTN = new Button();
            ThreeFinder_BTN = new Button();
            MINSize_BTN = new Button();
            MAXSize_BTN = new Button();
            RandEC_BTN = new Button();
            groupBox4 = new GroupBox();
            groupBox5 = new GroupBox();
            DitributiontabControl = new TabControl();
            CopyPage = new TabPage();
            EditBoxPage = new TabPage();
            EH1Page = new TabPage();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            DitributiontabControl.SuspendLayout();
            CopyPage.SuspendLayout();
            EditBoxPage.SuspendLayout();
            EH1Page.SuspendLayout();
            SuspendLayout();
            // 
            // LoadEH1_BTN
            // 
            LoadEH1_BTN.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            LoadEH1_BTN.Location = new System.Drawing.Point(115, 16);
            LoadEH1_BTN.Name = "LoadEH1_BTN";
            LoadEH1_BTN.Size = new System.Drawing.Size(100, 25);
            LoadEH1_BTN.TabIndex = 0;
            LoadEH1_BTN.Text = "读取EH1";
            LoadEH1_BTN.UseVisualStyleBackColor = true;
            LoadEH1_BTN.Click += LoadEH1_BTN_Click;
            // 
            // OpenFile_Dialog
            // 
            OpenFile_Dialog.Filter = "PokemonHomefile (*.eh1)|*.eh1|All files (*.*)|*.*";
            OpenFile_Dialog.Multiselect = true;
            // 
            // BOX_TextBox
            // 
            BOX_TextBox.Location = new System.Drawing.Point(44, 17);
            BOX_TextBox.Name = "BOX_TextBox";
            BOX_TextBox.Size = new System.Drawing.Size(65, 27);
            BOX_TextBox.TabIndex = 1;
            BOX_TextBox.Text = "1";
            // 
            // BOX_Label
            // 
            BOX_Label.AutoSize = true;
            BOX_Label.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            BOX_Label.Location = new System.Drawing.Point(6, 21);
            BOX_Label.Name = "BOX_Label";
            BOX_Label.Size = new System.Drawing.Size(39, 15);
            BOX_Label.TabIndex = 2;
            BOX_Label.Text = "箱子";
            // 
            // Clone_BTN
            // 
            Clone_BTN.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Clone_BTN.Location = new System.Drawing.Point(115, 49);
            Clone_BTN.Name = "Clone_BTN";
            Clone_BTN.Size = new System.Drawing.Size(100, 25);
            Clone_BTN.TabIndex = 20;
            Clone_BTN.Text = "开始复制";
            Clone_BTN.UseVisualStyleBackColor = true;
            Clone_BTN.Click += Clone_BTN_Click;
            // 
            // ShinyBox
            // 
            ShinyBox.AutoSize = true;
            ShinyBox.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ShinyBox.Location = new System.Drawing.Point(8, 24);
            ShinyBox.Name = "ShinyBox";
            ShinyBox.Size = new System.Drawing.Size(61, 19);
            ShinyBox.TabIndex = 28;
            ShinyBox.Text = "闪光";
            ShinyBox.UseVisualStyleBackColor = true;
            // 
            // Gift_BTN
            // 
            Gift_BTN.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Gift_BTN.Location = new System.Drawing.Point(221, 49);
            Gift_BTN.Name = "Gift_BTN";
            Gift_BTN.Size = new System.Drawing.Size(100, 25);
            Gift_BTN.TabIndex = 35;
            Gift_BTN.Text = "一箱神兽";
            Gift_BTN.UseVisualStyleBackColor = true;
            Gift_BTN.Click += Gift_BTN_Click;
            // 
            // SetTrainer_Box
            // 
            SetTrainer_Box.AutoSize = true;
            SetTrainer_Box.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            SetTrainer_Box.Location = new System.Drawing.Point(59, 24);
            SetTrainer_Box.Name = "SetTrainer_Box";
            SetTrainer_Box.Size = new System.Drawing.Size(109, 19);
            SetTrainer_Box.TabIndex = 36;
            SetTrainer_Box.Text = "指定训练家";
            SetTrainer_Box.UseVisualStyleBackColor = true;
            // 
            // AllRibbon_BTN
            // 
            AllRibbon_BTN.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            AllRibbon_BTN.Location = new System.Drawing.Point(122, 26);
            AllRibbon_BTN.Name = "AllRibbon_BTN";
            AllRibbon_BTN.Size = new System.Drawing.Size(100, 25);
            AllRibbon_BTN.TabIndex = 37;
            AllRibbon_BTN.Text = "全段带";
            AllRibbon_BTN.UseVisualStyleBackColor = true;
            AllRibbon_BTN.Click += AllRibbon_BTN_Click;
            // 
            // LoadTrainer_BTN
            // 
            LoadTrainer_BTN.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            LoadTrainer_BTN.Location = new System.Drawing.Point(118, 18);
            LoadTrainer_BTN.Name = "LoadTrainer_BTN";
            LoadTrainer_BTN.Size = new System.Drawing.Size(100, 25);
            LoadTrainer_BTN.TabIndex = 39;
            LoadTrainer_BTN.Text = "导入训练家";
            LoadTrainer_BTN.UseVisualStyleBackColor = true;
            LoadTrainer_BTN.Click += LoadTrainer_BTN_Click;
            // 
            // BallBox
            // 
            BallBox.FormattingEnabled = true;
            BallBox.Location = new System.Drawing.Point(332, 49);
            BallBox.Name = "BallBox";
            BallBox.Size = new System.Drawing.Size(62, 28);
            BallBox.TabIndex = 48;
            // 
            // Trainer_Box
            // 
            Trainer_Box.FormattingEnabled = true;
            Trainer_Box.Location = new System.Drawing.Point(8, 17);
            Trainer_Box.Name = "Trainer_Box";
            Trainer_Box.Size = new System.Drawing.Size(100, 28);
            Trainer_Box.TabIndex = 49;
            // 
            // Use_Trainer_BTN
            // 
            Use_Trainer_BTN.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Use_Trainer_BTN.Location = new System.Drawing.Point(330, 17);
            Use_Trainer_BTN.Name = "Use_Trainer_BTN";
            Use_Trainer_BTN.Size = new System.Drawing.Size(100, 25);
            Use_Trainer_BTN.TabIndex = 50;
            Use_Trainer_BTN.Text = "应用训练家";
            Use_Trainer_BTN.UseVisualStyleBackColor = true;
            Use_Trainer_BTN.Click += Use_Trainer_BTN_Click;
            // 
            // RandPID_Box
            // 
            RandPID_Box.AutoSize = true;
            RandPID_Box.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            RandPID_Box.Location = new System.Drawing.Point(298, 24);
            RandPID_Box.Name = "RandPID_Box";
            RandPID_Box.Size = new System.Drawing.Size(85, 19);
            RandPID_Box.TabIndex = 52;
            RandPID_Box.Text = "随机PID";
            RandPID_Box.UseVisualStyleBackColor = true;
            // 
            // IVEVN_BTN
            // 
            IVEVN_BTN.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            IVEVN_BTN.Location = new System.Drawing.Point(118, 19);
            IVEVN_BTN.Name = "IVEVN_BTN";
            IVEVN_BTN.Size = new System.Drawing.Size(100, 25);
            IVEVN_BTN.TabIndex = 53;
            IVEVN_BTN.Text = "覆盖三维";
            IVEVN_BTN.UseVisualStyleBackColor = true;
            IVEVN_BTN.Click += IVEVN_BTN_Click;
            // 
            // Move_Shop
            // 
            Move_Shop.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Move_Shop.Location = new System.Drawing.Point(15, 26);
            Move_Shop.Name = "Move_Shop";
            Move_Shop.Size = new System.Drawing.Size(100, 25);
            Move_Shop.TabIndex = 58;
            Move_Shop.Text = "全部技能";
            Move_Shop.UseVisualStyleBackColor = true;
            Move_Shop.Click += Move_Shop_Click;
            // 
            // LevelMax_BTN
            // 
            LevelMax_BTN.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            LevelMax_BTN.Location = new System.Drawing.Point(15, 57);
            LevelMax_BTN.Name = "LevelMax_BTN";
            LevelMax_BTN.Size = new System.Drawing.Size(100, 25);
            LevelMax_BTN.TabIndex = 59;
            LevelMax_BTN.Text = "等级最大";
            LevelMax_BTN.UseVisualStyleBackColor = true;
            LevelMax_BTN.Click += LevelMax_BTN_Click;
            // 
            // Ball_Box
            // 
            Ball_Box.AutoSize = true;
            Ball_Box.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Ball_Box.Location = new System.Drawing.Point(400, 51);
            Ball_Box.Name = "Ball_Box";
            Ball_Box.Size = new System.Drawing.Size(61, 19);
            Ball_Box.TabIndex = 61;
            Ball_Box.Text = "球种";
            Ball_Box.UseVisualStyleBackColor = true;
            // 
            // Edit_EVIVN_Box
            // 
            Edit_EVIVN_Box.FormattingEnabled = true;
            Edit_EVIVN_Box.Location = new System.Drawing.Point(8, 18);
            Edit_EVIVN_Box.Name = "Edit_EVIVN_Box";
            Edit_EVIVN_Box.Size = new System.Drawing.Size(100, 28);
            Edit_EVIVN_Box.TabIndex = 62;
            // 
            // Clone_Select_Box
            // 
            Clone_Select_Box.FormattingEnabled = true;
            Clone_Select_Box.Location = new System.Drawing.Point(5, 48);
            Clone_Select_Box.Name = "Clone_Select_Box";
            Clone_Select_Box.Size = new System.Drawing.Size(100, 28);
            Clone_Select_Box.TabIndex = 63;
            // 
            // Trainer_Select_Box
            // 
            Trainer_Select_Box.FormattingEnabled = true;
            Trainer_Select_Box.Location = new System.Drawing.Point(224, 17);
            Trainer_Select_Box.Name = "Trainer_Select_Box";
            Trainer_Select_Box.Size = new System.Drawing.Size(100, 28);
            Trainer_Select_Box.TabIndex = 64;
            // 
            // Random_Trainer_Box
            // 
            Random_Trainer_Box.AutoSize = true;
            Random_Trainer_Box.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Random_Trainer_Box.Location = new System.Drawing.Point(142, 24);
            Random_Trainer_Box.Name = "Random_Trainer_Box";
            Random_Trainer_Box.Size = new System.Drawing.Size(109, 19);
            Random_Trainer_Box.TabIndex = 65;
            Random_Trainer_Box.Text = "随机训练家";
            Random_Trainer_Box.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(RandEC_Box);
            groupBox1.Controls.Add(RandPID_Box);
            groupBox1.Controls.Add(Random_Name_Box);
            groupBox1.Controls.Add(Random_Trainer_Box);
            groupBox1.Controls.Add(Clone_Select_Box);
            groupBox1.Controls.Add(Ball_Box);
            groupBox1.Controls.Add(BallBox);
            groupBox1.Controls.Add(SetTrainer_Box);
            groupBox1.Controls.Add(Gift_BTN);
            groupBox1.Controls.Add(ShinyBox);
            groupBox1.Controls.Add(Clone_BTN);
            groupBox1.Location = new System.Drawing.Point(6, 9);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(472, 83);
            groupBox1.TabIndex = 67;
            groupBox1.TabStop = false;
            groupBox1.Text = "复制器（复制面板）";
            // 
            // RandEC_Box
            // 
            RandEC_Box.AutoSize = true;
            RandEC_Box.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            RandEC_Box.Location = new System.Drawing.Point(369, 24);
            RandEC_Box.Name = "RandEC_Box";
            RandEC_Box.Size = new System.Drawing.Size(77, 19);
            RandEC_Box.TabIndex = 69;
            RandEC_Box.Text = "随机EC";
            RandEC_Box.UseVisualStyleBackColor = true;
            // 
            // Random_Name_Box
            // 
            Random_Name_Box.AutoSize = true;
            Random_Name_Box.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Random_Name_Box.Location = new System.Drawing.Point(226, 24);
            Random_Name_Box.Name = "Random_Name_Box";
            Random_Name_Box.Size = new System.Drawing.Size(93, 19);
            Random_Name_Box.TabIndex = 68;
            Random_Name_Box.Text = "随机名字";
            Random_Name_Box.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(Trainer_Select_Box);
            groupBox2.Controls.Add(Use_Trainer_BTN);
            groupBox2.Controls.Add(Trainer_Box);
            groupBox2.Controls.Add(LoadTrainer_BTN);
            groupBox2.Location = new System.Drawing.Point(3, 94);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(475, 63);
            groupBox2.TabIndex = 68;
            groupBox2.TabStop = false;
            groupBox2.Text = "训练家";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(Random_EggBTN);
            groupBox3.Controls.Add(Random_EncBTN);
            groupBox3.Controls.Add(ThreeFinder_BTN);
            groupBox3.Controls.Add(MINSize_BTN);
            groupBox3.Controls.Add(MAXSize_BTN);
            groupBox3.Controls.Add(RandEC_BTN);
            groupBox3.Controls.Add(LevelMax_BTN);
            groupBox3.Controls.Add(Move_Shop);
            groupBox3.Controls.Add(AllRibbon_BTN);
            groupBox3.Location = new System.Drawing.Point(8, 13);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(469, 204);
            groupBox3.TabIndex = 69;
            groupBox3.TabStop = false;
            groupBox3.Text = "编辑当前箱子";
            // 
            // Random_EggBTN
            // 
            Random_EggBTN.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Random_EggBTN.Location = new System.Drawing.Point(334, 57);
            Random_EggBTN.Name = "Random_EggBTN";
            Random_EggBTN.Size = new System.Drawing.Size(100, 25);
            Random_EggBTN.TabIndex = 65;
            Random_EggBTN.Text = "随机孵蛋日";
            Random_EggBTN.UseVisualStyleBackColor = true;
            Random_EggBTN.Click += Random_EggBTN_Click;
            // 
            // Random_EncBTN
            // 
            Random_EncBTN.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Random_EncBTN.Location = new System.Drawing.Point(228, 57);
            Random_EncBTN.Name = "Random_EncBTN";
            Random_EncBTN.Size = new System.Drawing.Size(100, 25);
            Random_EncBTN.TabIndex = 64;
            Random_EncBTN.Text = "随机相遇日";
            Random_EncBTN.UseVisualStyleBackColor = true;
            Random_EncBTN.Click += Random_EncBTN_Click;
            // 
            // ThreeFinder_BTN
            // 
            ThreeFinder_BTN.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ThreeFinder_BTN.Location = new System.Drawing.Point(15, 88);
            ThreeFinder_BTN.Name = "ThreeFinder_BTN";
            ThreeFinder_BTN.Size = new System.Drawing.Size(100, 25);
            ThreeFinder_BTN.TabIndex = 63;
            ThreeFinder_BTN.Text = "土龙一家鼠";
            ThreeFinder_BTN.UseVisualStyleBackColor = true;
            ThreeFinder_BTN.Click += ThreeFinder_BTN_Click;
            // 
            // MINSize_BTN
            // 
            MINSize_BTN.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            MINSize_BTN.Location = new System.Drawing.Point(334, 26);
            MINSize_BTN.Name = "MINSize_BTN";
            MINSize_BTN.Size = new System.Drawing.Size(100, 25);
            MINSize_BTN.TabIndex = 62;
            MINSize_BTN.Text = "一键小不点";
            MINSize_BTN.UseVisualStyleBackColor = true;
            MINSize_BTN.Click += MINSize_BTN_Click;
            // 
            // MAXSize_BTN
            // 
            MAXSize_BTN.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            MAXSize_BTN.Location = new System.Drawing.Point(228, 26);
            MAXSize_BTN.Name = "MAXSize_BTN";
            MAXSize_BTN.Size = new System.Drawing.Size(100, 25);
            MAXSize_BTN.TabIndex = 61;
            MAXSize_BTN.Text = "一键大个子";
            MAXSize_BTN.UseVisualStyleBackColor = true;
            MAXSize_BTN.Click += MAXSize_BTN_Click;
            // 
            // RandEC_BTN
            // 
            RandEC_BTN.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            RandEC_BTN.Location = new System.Drawing.Point(122, 57);
            RandEC_BTN.Name = "RandEC_BTN";
            RandEC_BTN.Size = new System.Drawing.Size(100, 25);
            RandEC_BTN.TabIndex = 60;
            RandEC_BTN.Text = "随机EC";
            RandEC_BTN.UseVisualStyleBackColor = true;
            RandEC_BTN.Click += RandEC_BTN_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(BOX_TextBox);
            groupBox4.Controls.Add(LoadEH1_BTN);
            groupBox4.Controls.Add(BOX_Label);
            groupBox4.Location = new System.Drawing.Point(21, 17);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new System.Drawing.Size(224, 50);
            groupBox4.TabIndex = 70;
            groupBox4.TabStop = false;
            groupBox4.Text = "EH1查看器";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(Edit_EVIVN_Box);
            groupBox5.Controls.Add(IVEVN_BTN);
            groupBox5.Location = new System.Drawing.Point(3, 163);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new System.Drawing.Size(228, 53);
            groupBox5.TabIndex = 71;
            groupBox5.TabStop = false;
            groupBox5.Text = "编辑面板";
            // 
            // DitributiontabControl
            // 
            DitributiontabControl.Controls.Add(CopyPage);
            DitributiontabControl.Controls.Add(EditBoxPage);
            DitributiontabControl.Controls.Add(EH1Page);
            DitributiontabControl.Location = new System.Drawing.Point(12, 12);
            DitributiontabControl.Name = "DitributiontabControl";
            DitributiontabControl.SelectedIndex = 0;
            DitributiontabControl.Size = new System.Drawing.Size(501, 256);
            DitributiontabControl.TabIndex = 72;
            // 
            // CopyPage
            // 
            CopyPage.Controls.Add(groupBox1);
            CopyPage.Controls.Add(groupBox5);
            CopyPage.Controls.Add(groupBox2);
            CopyPage.Location = new System.Drawing.Point(4, 29);
            CopyPage.Name = "CopyPage";
            CopyPage.Padding = new Padding(3);
            CopyPage.Size = new System.Drawing.Size(493, 223);
            CopyPage.TabIndex = 0;
            CopyPage.Text = "复制器";
            CopyPage.UseVisualStyleBackColor = true;
            // 
            // EditBoxPage
            // 
            EditBoxPage.Controls.Add(groupBox3);
            EditBoxPage.Location = new System.Drawing.Point(4, 29);
            EditBoxPage.Name = "EditBoxPage";
            EditBoxPage.Padding = new Padding(3);
            EditBoxPage.Size = new System.Drawing.Size(493, 223);
            EditBoxPage.TabIndex = 1;
            EditBoxPage.Text = "杂项编辑";
            EditBoxPage.UseVisualStyleBackColor = true;
            // 
            // EH1Page
            // 
            EH1Page.Controls.Add(groupBox4);
            EH1Page.Location = new System.Drawing.Point(4, 29);
            EH1Page.Name = "EH1Page";
            EH1Page.Padding = new Padding(3);
            EH1Page.Size = new System.Drawing.Size(493, 223);
            EH1Page.TabIndex = 2;
            EH1Page.Text = "EH1查看器";
            EH1Page.UseVisualStyleBackColor = true;
            // 
            // DistributionUI
            // 
            ClientSize = new System.Drawing.Size(529, 273);
            Controls.Add(DitributiontabControl);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "DistributionUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SuperWang";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            DitributiontabControl.ResumeLayout(false);
            CopyPage.ResumeLayout(false);
            EditBoxPage.ResumeLayout(false);
            EH1Page.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Button RandEC_BTN;
        private Button MINSize_BTN;
        private Button MAXSize_BTN;
        private Button ThreeFinder_BTN;
        private Button Random_EncBTN;
        private Button Random_EggBTN;
        private TabControl DitributiontabControl;
        private TabPage CopyPage;
        private TabPage EditBoxPage;
        private TabPage EH1Page;
    }
}
