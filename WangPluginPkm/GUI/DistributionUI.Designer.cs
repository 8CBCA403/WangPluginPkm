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
        private Button Clone_BTN;
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
        private GroupBox groupBox5;
        private CheckBox Random_Name_Box;
        private CheckBox RandEC_Box;
        private CheckBox RandPID_Box;
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DistributionUI));
            OpenFile_Dialog = new OpenFileDialog();
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
            groupBox5 = new GroupBox();
            DitributiontabControl = new TabControl();
            Quickeditor = new TabPage();
            label1 = new Label();
            Quick_Write_BTN = new Button();
            Quick_EV_BTN = new Button();
            End_NUM = new NumericUpDown();
            RunFilter_CLB = new CheckedListBox();
            Start_NUM = new NumericUpDown();
            Start_BTN = new Button();
            End_LB = new Label();
            Tera_CB = new ComboBox();
            Start_LB = new Label();
            Tera_LAB = new Label();
            EndBox_NUM = new NumericUpDown();
            SNA_CB = new ComboBox();
            StartBox_NUM = new NumericUpDown();
            EndBox = new Label();
            SNL = new Label();
            StartBox_LB = new Label();
            Level_NUM = new NumericUpDown();
            Current_Level_LB = new Label();
            ABN_NU = new NumericUpDown();
            ABNL = new Label();
            FO_NU = new NumericUpDown();
            EV_TB = new TextBox();
            IV_TB = new TextBox();
            BA_CB = new ComboBox();
            LA_CB = new ComboBox();
            AB_CB = new ComboBox();
            IT_CB = new ComboBox();
            NA_CB = new ComboBox();
            EVL = new Label();
            IVL = new Label();
            BAL = new Label();
            LAL = new Label();
            ABL = new Label();
            ITL = new Label();
            FOL = new Label();
            NAL = new Label();
            CopyPage = new TabPage();
            DisGroupBox = new GroupBox();
            DiscomboBox = new ComboBox();
            GenDIs_BTN = new Button();
            EditBoxPage = new TabPage();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox5.SuspendLayout();
            DitributiontabControl.SuspendLayout();
            Quickeditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)End_NUM).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Start_NUM).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EndBox_NUM).BeginInit();
            ((System.ComponentModel.ISupportInitialize)StartBox_NUM).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Level_NUM).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ABN_NU).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FO_NU).BeginInit();
            CopyPage.SuspendLayout();
            DisGroupBox.SuspendLayout();
            EditBoxPage.SuspendLayout();
            SuspendLayout();
            // 
            // OpenFile_Dialog
            // 
            OpenFile_Dialog.Filter = "PokemonHomefile (*.eh1)|*.eh1|All files (*.*)|*.*";
            OpenFile_Dialog.Multiselect = true;
            // 
            // Clone_BTN
            // 
            Clone_BTN.Font = new System.Drawing.Font("黑体", 9F);
            Clone_BTN.Location = new System.Drawing.Point(116, 42);
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
            ShinyBox.Font = new System.Drawing.Font("黑体", 9F);
            ShinyBox.Location = new System.Drawing.Point(7, 20);
            ShinyBox.Name = "ShinyBox";
            ShinyBox.Size = new System.Drawing.Size(61, 19);
            ShinyBox.TabIndex = 28;
            ShinyBox.Text = "闪光";
            ShinyBox.UseVisualStyleBackColor = true;
            // 
            // Gift_BTN
            // 
            Gift_BTN.Font = new System.Drawing.Font("黑体", 9F);
            Gift_BTN.Location = new System.Drawing.Point(222, 42);
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
            SetTrainer_Box.Font = new System.Drawing.Font("黑体", 9F);
            SetTrainer_Box.Location = new System.Drawing.Point(58, 20);
            SetTrainer_Box.Name = "SetTrainer_Box";
            SetTrainer_Box.Size = new System.Drawing.Size(109, 19);
            SetTrainer_Box.TabIndex = 36;
            SetTrainer_Box.Text = "指定训练家";
            SetTrainer_Box.UseVisualStyleBackColor = true;
            // 
            // AllRibbon_BTN
            // 
            AllRibbon_BTN.Font = new System.Drawing.Font("黑体", 9F);
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
            LoadTrainer_BTN.Font = new System.Drawing.Font("黑体", 9F);
            LoadTrainer_BTN.Location = new System.Drawing.Point(118, 20);
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
            BallBox.Location = new System.Drawing.Point(333, 44);
            BallBox.Name = "BallBox";
            BallBox.Size = new System.Drawing.Size(62, 23);
            BallBox.TabIndex = 48;
            // 
            // Trainer_Box
            // 
            Trainer_Box.FormattingEnabled = true;
            Trainer_Box.Location = new System.Drawing.Point(8, 22);
            Trainer_Box.Name = "Trainer_Box";
            Trainer_Box.Size = new System.Drawing.Size(100, 23);
            Trainer_Box.TabIndex = 49;
            // 
            // Use_Trainer_BTN
            // 
            Use_Trainer_BTN.Font = new System.Drawing.Font("黑体", 9F);
            Use_Trainer_BTN.Location = new System.Drawing.Point(330, 20);
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
            RandPID_Box.Font = new System.Drawing.Font("黑体", 9F);
            RandPID_Box.Location = new System.Drawing.Point(332, 20);
            RandPID_Box.Name = "RandPID_Box";
            RandPID_Box.Size = new System.Drawing.Size(85, 19);
            RandPID_Box.TabIndex = 52;
            RandPID_Box.Text = "随机PID";
            RandPID_Box.UseVisualStyleBackColor = true;
            // 
            // IVEVN_BTN
            // 
            IVEVN_BTN.Font = new System.Drawing.Font("黑体", 9F);
            IVEVN_BTN.Location = new System.Drawing.Point(118, 16);
            IVEVN_BTN.Name = "IVEVN_BTN";
            IVEVN_BTN.Size = new System.Drawing.Size(100, 25);
            IVEVN_BTN.TabIndex = 53;
            IVEVN_BTN.Text = "覆盖三维";
            IVEVN_BTN.UseVisualStyleBackColor = true;
            IVEVN_BTN.Click += IVEVN_BTN_Click;
            // 
            // Move_Shop
            // 
            Move_Shop.Font = new System.Drawing.Font("黑体", 9F);
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
            LevelMax_BTN.Font = new System.Drawing.Font("黑体", 9F);
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
            Ball_Box.Font = new System.Drawing.Font("黑体", 9F);
            Ball_Box.Location = new System.Drawing.Point(401, 46);
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
            Edit_EVIVN_Box.Size = new System.Drawing.Size(100, 23);
            Edit_EVIVN_Box.TabIndex = 62;
            // 
            // Clone_Select_Box
            // 
            Clone_Select_Box.FormattingEnabled = true;
            Clone_Select_Box.Location = new System.Drawing.Point(6, 44);
            Clone_Select_Box.Name = "Clone_Select_Box";
            Clone_Select_Box.Size = new System.Drawing.Size(100, 23);
            Clone_Select_Box.TabIndex = 63;
            // 
            // Trainer_Select_Box
            // 
            Trainer_Select_Box.FormattingEnabled = true;
            Trainer_Select_Box.Location = new System.Drawing.Point(224, 22);
            Trainer_Select_Box.Name = "Trainer_Select_Box";
            Trainer_Select_Box.Size = new System.Drawing.Size(100, 23);
            Trainer_Select_Box.TabIndex = 64;
            // 
            // Random_Trainer_Box
            // 
            Random_Trainer_Box.AutoSize = true;
            Random_Trainer_Box.Font = new System.Drawing.Font("黑体", 9F);
            Random_Trainer_Box.Location = new System.Drawing.Point(141, 20);
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
            RandEC_Box.Font = new System.Drawing.Font("黑体", 9F);
            RandEC_Box.Location = new System.Drawing.Point(403, 20);
            RandEC_Box.Name = "RandEC_Box";
            RandEC_Box.Size = new System.Drawing.Size(77, 19);
            RandEC_Box.TabIndex = 69;
            RandEC_Box.Text = "随机EC";
            RandEC_Box.UseVisualStyleBackColor = true;
            // 
            // Random_Name_Box
            // 
            Random_Name_Box.AutoSize = true;
            Random_Name_Box.Font = new System.Drawing.Font("黑体", 9F);
            Random_Name_Box.Location = new System.Drawing.Point(225, 20);
            Random_Name_Box.Name = "Random_Name_Box";
            Random_Name_Box.Size = new System.Drawing.Size(141, 19);
            Random_Name_Box.TabIndex = 68;
            Random_Name_Box.Text = "随机训练家名字";
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
            Random_EggBTN.Font = new System.Drawing.Font("黑体", 9F);
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
            Random_EncBTN.Font = new System.Drawing.Font("黑体", 9F);
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
            ThreeFinder_BTN.Font = new System.Drawing.Font("黑体", 9F);
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
            MINSize_BTN.Font = new System.Drawing.Font("黑体", 9F);
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
            MAXSize_BTN.Font = new System.Drawing.Font("黑体", 9F);
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
            RandEC_BTN.Font = new System.Drawing.Font("黑体", 9F);
            RandEC_BTN.Location = new System.Drawing.Point(122, 57);
            RandEC_BTN.Name = "RandEC_BTN";
            RandEC_BTN.Size = new System.Drawing.Size(100, 25);
            RandEC_BTN.TabIndex = 60;
            RandEC_BTN.Text = "随机EC";
            RandEC_BTN.UseVisualStyleBackColor = true;
            RandEC_BTN.Click += RandEC_BTN_Click;
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
            DitributiontabControl.Controls.Add(Quickeditor);
            DitributiontabControl.Controls.Add(CopyPage);
            DitributiontabControl.Controls.Add(EditBoxPage);
            DitributiontabControl.Location = new System.Drawing.Point(12, 12);
            DitributiontabControl.Name = "DitributiontabControl";
            DitributiontabControl.SelectedIndex = 0;
            DitributiontabControl.Size = new System.Drawing.Size(501, 257);
            DitributiontabControl.TabIndex = 72;
            // 
            // Quickeditor
            // 
            Quickeditor.Controls.Add(label1);
            Quickeditor.Controls.Add(Quick_Write_BTN);
            Quickeditor.Controls.Add(Quick_EV_BTN);
            Quickeditor.Controls.Add(End_NUM);
            Quickeditor.Controls.Add(RunFilter_CLB);
            Quickeditor.Controls.Add(Start_NUM);
            Quickeditor.Controls.Add(Start_BTN);
            Quickeditor.Controls.Add(End_LB);
            Quickeditor.Controls.Add(Tera_CB);
            Quickeditor.Controls.Add(Start_LB);
            Quickeditor.Controls.Add(Tera_LAB);
            Quickeditor.Controls.Add(EndBox_NUM);
            Quickeditor.Controls.Add(SNA_CB);
            Quickeditor.Controls.Add(StartBox_NUM);
            Quickeditor.Controls.Add(EndBox);
            Quickeditor.Controls.Add(SNL);
            Quickeditor.Controls.Add(StartBox_LB);
            Quickeditor.Controls.Add(Level_NUM);
            Quickeditor.Controls.Add(Current_Level_LB);
            Quickeditor.Controls.Add(ABN_NU);
            Quickeditor.Controls.Add(ABNL);
            Quickeditor.Controls.Add(FO_NU);
            Quickeditor.Controls.Add(EV_TB);
            Quickeditor.Controls.Add(IV_TB);
            Quickeditor.Controls.Add(BA_CB);
            Quickeditor.Controls.Add(LA_CB);
            Quickeditor.Controls.Add(AB_CB);
            Quickeditor.Controls.Add(IT_CB);
            Quickeditor.Controls.Add(NA_CB);
            Quickeditor.Controls.Add(EVL);
            Quickeditor.Controls.Add(IVL);
            Quickeditor.Controls.Add(BAL);
            Quickeditor.Controls.Add(LAL);
            Quickeditor.Controls.Add(ABL);
            Quickeditor.Controls.Add(ITL);
            Quickeditor.Controls.Add(FOL);
            Quickeditor.Controls.Add(NAL);
            Quickeditor.Location = new System.Drawing.Point(4, 25);
            Quickeditor.Name = "Quickeditor";
            Quickeditor.Padding = new Padding(3);
            Quickeditor.Size = new System.Drawing.Size(493, 228);
            Quickeditor.TabIndex = 2;
            Quickeditor.Text = "速配器";
            Quickeditor.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(314, 120);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(87, 15);
            label1.TabIndex = 107;
            label1.Text = "速配过滤器";
            // 
            // Quick_Write_BTN
            // 
            Quick_Write_BTN.Location = new System.Drawing.Point(215, 125);
            Quick_Write_BTN.Name = "Quick_Write_BTN";
            Quick_Write_BTN.Size = new System.Drawing.Size(93, 23);
            Quick_Write_BTN.TabIndex = 106;
            Quick_Write_BTN.Text = "刷新当前箱子";
            Quick_Write_BTN.UseVisualStyleBackColor = true;
            Quick_Write_BTN.Click += Quick_Write_BTN_Click;
            // 
            // Quick_EV_BTN
            // 
            Quick_EV_BTN.Location = new System.Drawing.Point(215, 98);
            Quick_EV_BTN.Name = "Quick_EV_BTN";
            Quick_EV_BTN.Size = new System.Drawing.Size(93, 23);
            Quick_EV_BTN.TabIndex = 105;
            Quick_EV_BTN.Text = "速配努力值";
            Quick_EV_BTN.UseVisualStyleBackColor = true;
            Quick_EV_BTN.Click += Quick_EV_BTN_Click;
            // 
            // End_NUM
            // 
            End_NUM.Location = new System.Drawing.Point(174, 189);
            End_NUM.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            End_NUM.Name = "End_NUM";
            End_NUM.Size = new System.Drawing.Size(35, 25);
            End_NUM.TabIndex = 80;
            End_NUM.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // RunFilter_CLB
            // 
            RunFilter_CLB.FormattingEnabled = true;
            RunFilter_CLB.HorizontalScrollbar = true;
            RunFilter_CLB.Location = new System.Drawing.Point(314, 135);
            RunFilter_CLB.Name = "RunFilter_CLB";
            RunFilter_CLB.Size = new System.Drawing.Size(154, 84);
            RunFilter_CLB.TabIndex = 104;
            // 
            // Start_NUM
            // 
            Start_NUM.Location = new System.Drawing.Point(174, 158);
            Start_NUM.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            Start_NUM.Name = "Start_NUM";
            Start_NUM.Size = new System.Drawing.Size(35, 25);
            Start_NUM.TabIndex = 79;
            Start_NUM.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // Start_BTN
            // 
            Start_BTN.Location = new System.Drawing.Point(215, 154);
            Start_BTN.Name = "Start_BTN";
            Start_BTN.Size = new System.Drawing.Size(93, 23);
            Start_BTN.TabIndex = 103;
            Start_BTN.Text = "开始速配";
            Start_BTN.UseVisualStyleBackColor = true;
            Start_BTN.Click += Start_BTN_Click;
            // 
            // End_LB
            // 
            End_LB.AutoSize = true;
            End_LB.Location = new System.Drawing.Point(112, 191);
            End_LB.Name = "End_LB";
            End_LB.Size = new System.Drawing.Size(71, 15);
            End_LB.TabIndex = 78;
            End_LB.Text = "结束槽位";
            // 
            // Tera_CB
            // 
            Tera_CB.AutoCompleteMode = AutoCompleteMode.Append;
            Tera_CB.AutoCompleteSource = AutoCompleteSource.CustomSource;
            Tera_CB.FormattingEnabled = true;
            Tera_CB.Location = new System.Drawing.Point(238, 66);
            Tera_CB.Name = "Tera_CB";
            Tera_CB.Size = new System.Drawing.Size(57, 23);
            Tera_CB.TabIndex = 94;
            // 
            // Start_LB
            // 
            Start_LB.AutoSize = true;
            Start_LB.Location = new System.Drawing.Point(112, 161);
            Start_LB.Name = "Start_LB";
            Start_LB.Size = new System.Drawing.Size(71, 15);
            Start_LB.TabIndex = 77;
            Start_LB.Text = "开始槽位";
            // 
            // Tera_LAB
            // 
            Tera_LAB.AutoSize = true;
            Tera_LAB.Location = new System.Drawing.Point(174, 69);
            Tera_LAB.Name = "Tera_LAB";
            Tera_LAB.Size = new System.Drawing.Size(71, 15);
            Tera_LAB.TabIndex = 93;
            Tera_LAB.Text = "钛晶属性";
            // 
            // EndBox_NUM
            // 
            EndBox_NUM.Location = new System.Drawing.Point(71, 189);
            EndBox_NUM.Maximum = new decimal(new int[] { 32, 0, 0, 0 });
            EndBox_NUM.Name = "EndBox_NUM";
            EndBox_NUM.Size = new System.Drawing.Size(35, 25);
            EndBox_NUM.TabIndex = 76;
            EndBox_NUM.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // SNA_CB
            // 
            SNA_CB.AutoCompleteMode = AutoCompleteMode.Append;
            SNA_CB.AutoCompleteSource = AutoCompleteSource.CustomSource;
            SNA_CB.FormattingEnabled = true;
            SNA_CB.Location = new System.Drawing.Point(73, 37);
            SNA_CB.Name = "SNA_CB";
            SNA_CB.Size = new System.Drawing.Size(65, 23);
            SNA_CB.TabIndex = 92;
            // 
            // StartBox_NUM
            // 
            StartBox_NUM.Location = new System.Drawing.Point(71, 158);
            StartBox_NUM.Maximum = new decimal(new int[] { 32, 0, 0, 0 });
            StartBox_NUM.Name = "StartBox_NUM";
            StartBox_NUM.Size = new System.Drawing.Size(35, 25);
            StartBox_NUM.TabIndex = 75;
            StartBox_NUM.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // EndBox
            // 
            EndBox.AutoSize = true;
            EndBox.Location = new System.Drawing.Point(15, 194);
            EndBox.Name = "EndBox";
            EndBox.Size = new System.Drawing.Size(71, 15);
            EndBox.TabIndex = 74;
            EndBox.Text = "结束箱子";
            // 
            // SNL
            // 
            SNL.AutoSize = true;
            SNL.Location = new System.Drawing.Point(11, 40);
            SNL.Name = "SNL";
            SNL.Size = new System.Drawing.Size(71, 15);
            SNL.TabIndex = 91;
            SNL.Text = "薄荷性格";
            // 
            // StartBox_LB
            // 
            StartBox_LB.AutoSize = true;
            StartBox_LB.Location = new System.Drawing.Point(15, 163);
            StartBox_LB.Name = "StartBox_LB";
            StartBox_LB.Size = new System.Drawing.Size(71, 15);
            StartBox_LB.TabIndex = 73;
            StartBox_LB.Text = "开始箱子";
            // 
            // Level_NUM
            // 
            Level_NUM.Location = new System.Drawing.Point(238, 37);
            Level_NUM.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            Level_NUM.Name = "Level_NUM";
            Level_NUM.Size = new System.Drawing.Size(56, 25);
            Level_NUM.TabIndex = 90;
            Level_NUM.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // Current_Level_LB
            // 
            Current_Level_LB.AutoSize = true;
            Current_Level_LB.Location = new System.Drawing.Point(173, 39);
            Current_Level_LB.Name = "Current_Level_LB";
            Current_Level_LB.Size = new System.Drawing.Size(71, 15);
            Current_Level_LB.TabIndex = 89;
            Current_Level_LB.Text = "当前等级";
            // 
            // ABN_NU
            // 
            ABN_NU.Location = new System.Drawing.Point(376, 64);
            ABN_NU.Name = "ABN_NU";
            ABN_NU.Size = new System.Drawing.Size(56, 25);
            ABN_NU.TabIndex = 85;
            // 
            // ABNL
            // 
            ABNL.AutoSize = true;
            ABNL.Location = new System.Drawing.Point(314, 66);
            ABNL.Name = "ABNL";
            ABNL.Size = new System.Drawing.Size(71, 15);
            ABNL.TabIndex = 84;
            ABNL.Text = "特性序号";
            // 
            // FO_NU
            // 
            FO_NU.Location = new System.Drawing.Point(73, 68);
            FO_NU.Name = "FO_NU";
            FO_NU.Size = new System.Drawing.Size(56, 25);
            FO_NU.TabIndex = 83;
            // 
            // EV_TB
            // 
            EV_TB.Location = new System.Drawing.Point(73, 131);
            EV_TB.Name = "EV_TB";
            EV_TB.Size = new System.Drawing.Size(136, 25);
            EV_TB.TabIndex = 82;
            EV_TB.Text = "0/0/0/0/0/0";
            // 
            // IV_TB
            // 
            IV_TB.Location = new System.Drawing.Point(73, 98);
            IV_TB.Name = "IV_TB";
            IV_TB.Size = new System.Drawing.Size(136, 25);
            IV_TB.TabIndex = 81;
            IV_TB.Text = "0/0/0/0/0/0";
            // 
            // BA_CB
            // 
            BA_CB.AutoCompleteMode = AutoCompleteMode.Append;
            BA_CB.AutoCompleteSource = AutoCompleteSource.CustomSource;
            BA_CB.FormattingEnabled = true;
            BA_CB.Location = new System.Drawing.Point(203, 6);
            BA_CB.Name = "BA_CB";
            BA_CB.Size = new System.Drawing.Size(91, 23);
            BA_CB.TabIndex = 80;
            // 
            // LA_CB
            // 
            LA_CB.FormattingEnabled = true;
            LA_CB.Location = new System.Drawing.Point(376, 93);
            LA_CB.Name = "LA_CB";
            LA_CB.Size = new System.Drawing.Size(92, 23);
            LA_CB.TabIndex = 79;
            // 
            // AB_CB
            // 
            AB_CB.AutoCompleteMode = AutoCompleteMode.Append;
            AB_CB.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AB_CB.FormattingEnabled = true;
            AB_CB.Location = new System.Drawing.Point(376, 36);
            AB_CB.Name = "AB_CB";
            AB_CB.Size = new System.Drawing.Size(91, 23);
            AB_CB.TabIndex = 78;
            // 
            // IT_CB
            // 
            IT_CB.AutoCompleteMode = AutoCompleteMode.Append;
            IT_CB.AutoCompleteSource = AutoCompleteSource.CustomSource;
            IT_CB.FormattingEnabled = true;
            IT_CB.Location = new System.Drawing.Point(376, 5);
            IT_CB.Name = "IT_CB";
            IT_CB.Size = new System.Drawing.Size(91, 23);
            IT_CB.TabIndex = 77;
            // 
            // NA_CB
            // 
            NA_CB.AutoCompleteMode = AutoCompleteMode.Append;
            NA_CB.AutoCompleteSource = AutoCompleteSource.CustomSource;
            NA_CB.FormattingEnabled = true;
            NA_CB.Location = new System.Drawing.Point(72, 6);
            NA_CB.Name = "NA_CB";
            NA_CB.Size = new System.Drawing.Size(65, 23);
            NA_CB.TabIndex = 76;
            // 
            // EVL
            // 
            EVL.AutoSize = true;
            EVL.Location = new System.Drawing.Point(23, 134);
            EVL.Name = "EVL";
            EVL.Size = new System.Drawing.Size(55, 15);
            EVL.TabIndex = 74;
            EVL.Text = "努力值";
            // 
            // IVL
            // 
            IVL.AutoSize = true;
            IVL.Location = new System.Drawing.Point(35, 101);
            IVL.Name = "IVL";
            IVL.Size = new System.Drawing.Size(39, 15);
            IVL.TabIndex = 73;
            IVL.Text = "个体";
            // 
            // BAL
            // 
            BAL.AutoSize = true;
            BAL.Location = new System.Drawing.Point(163, 9);
            BAL.Name = "BAL";
            BAL.Size = new System.Drawing.Size(39, 15);
            BAL.TabIndex = 72;
            BAL.Text = "球种";
            // 
            // LAL
            // 
            LAL.AutoSize = true;
            LAL.Location = new System.Drawing.Point(338, 96);
            LAL.Name = "LAL";
            LAL.Size = new System.Drawing.Size(39, 15);
            LAL.TabIndex = 71;
            LAL.Text = "语言";
            // 
            // ABL
            // 
            ABL.AutoSize = true;
            ABL.Location = new System.Drawing.Point(338, 39);
            ABL.Name = "ABL";
            ABL.Size = new System.Drawing.Size(39, 15);
            ABL.TabIndex = 70;
            ABL.Text = "特性";
            // 
            // ITL
            // 
            ITL.AutoSize = true;
            ITL.Location = new System.Drawing.Point(326, 9);
            ITL.Name = "ITL";
            ITL.Size = new System.Drawing.Size(55, 15);
            ITL.TabIndex = 69;
            ITL.Text = "持有物";
            // 
            // FOL
            // 
            FOL.AutoSize = true;
            FOL.Location = new System.Drawing.Point(34, 70);
            FOL.Name = "FOL";
            FOL.Size = new System.Drawing.Size(39, 15);
            FOL.TabIndex = 68;
            FOL.Text = "形态";
            // 
            // NAL
            // 
            NAL.AutoSize = true;
            NAL.Location = new System.Drawing.Point(10, 9);
            NAL.Name = "NAL";
            NAL.Size = new System.Drawing.Size(71, 15);
            NAL.TabIndex = 67;
            NAL.Text = "原始性格";
            // 
            // CopyPage
            // 
            CopyPage.BackColor = System.Drawing.Color.WhiteSmoke;
            CopyPage.Controls.Add(DisGroupBox);
            CopyPage.Controls.Add(groupBox1);
            CopyPage.Controls.Add(groupBox5);
            CopyPage.Controls.Add(groupBox2);
            CopyPage.Location = new System.Drawing.Point(4, 29);
            CopyPage.Name = "CopyPage";
            CopyPage.Padding = new Padding(3);
            CopyPage.Size = new System.Drawing.Size(493, 224);
            CopyPage.TabIndex = 0;
            CopyPage.Text = "派送器";
            // 
            // DisGroupBox
            // 
            DisGroupBox.Controls.Add(DiscomboBox);
            DisGroupBox.Controls.Add(GenDIs_BTN);
            DisGroupBox.Location = new System.Drawing.Point(250, 163);
            DisGroupBox.Name = "DisGroupBox";
            DisGroupBox.Size = new System.Drawing.Size(228, 53);
            DisGroupBox.TabIndex = 72;
            DisGroupBox.TabStop = false;
            DisGroupBox.Text = "常用派送";
            // 
            // DiscomboBox
            // 
            DiscomboBox.FormattingEnabled = true;
            DiscomboBox.Location = new System.Drawing.Point(8, 18);
            DiscomboBox.Name = "DiscomboBox";
            DiscomboBox.Size = new System.Drawing.Size(100, 23);
            DiscomboBox.TabIndex = 62;
            // 
            // GenDIs_BTN
            // 
            GenDIs_BTN.Font = new System.Drawing.Font("黑体", 9F);
            GenDIs_BTN.Location = new System.Drawing.Point(118, 16);
            GenDIs_BTN.Name = "GenDIs_BTN";
            GenDIs_BTN.Size = new System.Drawing.Size(100, 25);
            GenDIs_BTN.TabIndex = 53;
            GenDIs_BTN.Text = "生成";
            GenDIs_BTN.UseVisualStyleBackColor = true;
            GenDIs_BTN.Click += GenDIs_BTN_Click;
            // 
            // EditBoxPage
            // 
            EditBoxPage.BackColor = System.Drawing.Color.WhiteSmoke;
            EditBoxPage.Controls.Add(groupBox3);
            EditBoxPage.Location = new System.Drawing.Point(4, 29);
            EditBoxPage.Name = "EditBoxPage";
            EditBoxPage.Padding = new Padding(3);
            EditBoxPage.Size = new System.Drawing.Size(493, 224);
            EditBoxPage.TabIndex = 1;
            EditBoxPage.Text = "杂项编辑";
            // 
            // DistributionUI
            // 
            ClientSize = new System.Drawing.Size(529, 280);
            Controls.Add(DitributiontabControl);
            Font = new System.Drawing.Font("黑体", 9F);
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
            groupBox5.ResumeLayout(false);
            DitributiontabControl.ResumeLayout(false);
            Quickeditor.ResumeLayout(false);
            Quickeditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)End_NUM).EndInit();
            ((System.ComponentModel.ISupportInitialize)Start_NUM).EndInit();
            ((System.ComponentModel.ISupportInitialize)EndBox_NUM).EndInit();
            ((System.ComponentModel.ISupportInitialize)StartBox_NUM).EndInit();
            ((System.ComponentModel.ISupportInitialize)Level_NUM).EndInit();
            ((System.ComponentModel.ISupportInitialize)ABN_NU).EndInit();
            ((System.ComponentModel.ISupportInitialize)FO_NU).EndInit();
            CopyPage.ResumeLayout(false);
            DisGroupBox.ResumeLayout(false);
            EditBoxPage.ResumeLayout(false);
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
        private GroupBox DisGroupBox;
        private ComboBox DiscomboBox;
        private Button GenDIs_BTN;
        private TabPage Quickeditor;
        private ComboBox Tera_CB;
        private Label Tera_LAB;
        private ComboBox SNA_CB;
        private Label SNL;
        private NumericUpDown Level_NUM;
        private Label Current_Level_LB;
        private NumericUpDown ABN_NU;
        private Label ABNL;
        private NumericUpDown FO_NU;
        private TextBox EV_TB;
        private TextBox IV_TB;
        private ComboBox BA_CB;
        private ComboBox LA_CB;
        private ComboBox AB_CB;
        private ComboBox IT_CB;
        private ComboBox NA_CB;
        private Label EVL;
        private Label IVL;
        private Label BAL;
        private Label LAL;
        private Label ABL;
        private Label ITL;
        private Label FOL;
        private Label NAL;
        private Button Start_BTN;
        private CheckedListBox RunFilter_CLB;
        private NumericUpDown End_NUM;
        private NumericUpDown Start_NUM;
        private Label End_LB;
        private Label Start_LB;
        private NumericUpDown EndBox_NUM;
        private NumericUpDown StartBox_NUM;
        private Label EndBox;
        private Label StartBox_LB;
        private Button Quick_Write_BTN;
        private Button Quick_EV_BTN;
        private Label label1;
    }
}
