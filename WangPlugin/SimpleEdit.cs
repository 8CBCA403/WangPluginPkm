using System;
using PKHeX.Core;
using PKHeX.Core.AutoMod;
using System.Windows.Forms;
namespace WangPlugin
{
    internal class SimpleEdit : Form
    {
        private IPKMView Editor { get; }
        private Button AllRibbon;
        private Button ClearRecord;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleEdit));
            this.AllRibbon = new System.Windows.Forms.Button();
            this.ClearRecord = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AllRibbon
            // 
            this.AllRibbon.Location = new System.Drawing.Point(25, 26);
            this.AllRibbon.Name = "AllRibbon";
            this.AllRibbon.Size = new System.Drawing.Size(110, 30);
            this.AllRibbon.TabIndex = 0;
            this.AllRibbon.Text = "AllRibbon";
            this.AllRibbon.UseVisualStyleBackColor = true;
            this.AllRibbon.Click += new System.EventHandler(this.AllRibbon_Click);
            // 
            // ClearRecord
            // 
            this.ClearRecord.Location = new System.Drawing.Point(156, 26);
            this.ClearRecord.Name = "ClearRecord";
            this.ClearRecord.Size = new System.Drawing.Size(110, 30);
            this.ClearRecord.TabIndex = 1;
            this.ClearRecord.Text = "ClearRecord";
            this.ClearRecord.UseVisualStyleBackColor = true;
            this.ClearRecord.Click += new System.EventHandler(this.ClearRecord_Click);
            // 
            // SimpleEdit
            // 
            this.ClientSize = new System.Drawing.Size(287, 79);
            this.Controls.Add(this.ClearRecord);
            this.Controls.Add(this.AllRibbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SimpleEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Wang";
            this.ResumeLayout(false);

        }
        public SimpleEdit(ISaveFileProvider sav, IPKMView editor)
        {
            Editor = editor;
            InitializeComponent();
        }
        private void AllRibbon_Click(object sender, EventArgs e)
        {
            RibbonApplicator.SetAllValidRibbons(Editor.Data);

        }

        private void ClearRecord_Click(object sender, EventArgs e)
        {
            ITechRecord8 techRecord = Editor.Data as ITechRecord8;
            TechnicalRecordApplicator.SetRecordFlags(techRecord, false, 112);
        }
    }
}
