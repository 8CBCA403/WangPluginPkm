using PKHeX.Core;
using Python.Runtime;
using System;
using System.IO;
using System.Windows.Forms;



namespace WangPluginPkm.GUI
{
    internal class TESTForm : Form
    {
        private Button SetAll_BTN;

        private ISaveFileProvider SAV { get; }
        private IPKMView Editor { get; }
        public TESTForm(ISaveFileProvider sav, IPKMView editor)
        {
            SAV = sav;
            Editor = editor;
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TESTForm));
            SetAll_BTN = new Button();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // SetAll_BTN
            // 
            SetAll_BTN.Location = new System.Drawing.Point(80, 34);
            SetAll_BTN.Name = "SetAll_BTN";
            SetAll_BTN.Size = new System.Drawing.Size(96, 30);
            SetAll_BTN.TabIndex = 0;
            SetAll_BTN.Text = "RandomPID";
            SetAll_BTN.UseVisualStyleBackColor = true;
            SetAll_BTN.Click += SetAll_BTN_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(12, 77);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(234, 174);
            textBox1.TabIndex = 1;
            // 
            // TESTForm
            // 
            ClientSize = new System.Drawing.Size(258, 263);
            Controls.Add(textBox1);
            Controls.Add(SetAll_BTN);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "TESTForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Super Wang";
            ResumeLayout(false);
            PerformLayout();
        }

        private void Wang()
        {
            PythonEngine.Initialize();

            dynamic pickle = Py.Import("pickle");

            using (Py.GIL())
            {
                // 读取pickle文件
                byte[] pickleData = File.ReadAllBytes(@"D:\Desk\encounter_might_paldea.pkl");

                // 反序列化pickle数据
                dynamic unpickledObject = pickle.loads(pickleData);

                // 将动态对象转换为字典
                dynamic dictionary = unpickledObject.ToDictionary();

                // 输出字典内容
                foreach (dynamic kvp in dictionary)
                {
                    textBox1.Text += ($"{kvp.Key}: {kvp.Value}");
                }
            }

            PythonEngine.Shutdown();
        }

        private void SetAll_BTN_Click(object sender, EventArgs e)
        {
            Wang();
        }

        private TextBox textBox1;
    }


}

