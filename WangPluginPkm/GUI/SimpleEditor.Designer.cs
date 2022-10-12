using System.Windows.Forms;
namespace WangPluginPkm.GUI
{
    partial class SimpleEditor
    {
        private Button AllRibbon;
        private Button LegalizeReport;
        private Button Master;
        private Button ClearRecord;
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleEditor));
            this.AllRibbon = new System.Windows.Forms.Button();
            this.ClearRecord = new System.Windows.Forms.Button();
            this.LegalizeReport = new System.Windows.Forms.Button();
            this.Master = new System.Windows.Forms.Button();
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
            // LegalizeReport
            // 
            this.LegalizeReport.Location = new System.Drawing.Point(25, 71);
            this.LegalizeReport.Name = "LegalizeReport";
            this.LegalizeReport.Size = new System.Drawing.Size(110, 28);
            this.LegalizeReport.TabIndex = 2;
            this.LegalizeReport.Text = "Report";
            this.LegalizeReport.UseVisualStyleBackColor = true;
            this.LegalizeReport.Click += new System.EventHandler(this.LegalizeReport_Click);
            // 
            // Master
            // 
            this.Master.Location = new System.Drawing.Point(157, 71);
            this.Master.Name = "Master";
            this.Master.Size = new System.Drawing.Size(108, 28);
            this.Master.TabIndex = 3;
            this.Master.Text = "Master";
            this.Master.UseVisualStyleBackColor = true;
            this.Master.Click += new System.EventHandler(this.Master_Click);
            // 
            // SimpleEditor
            // 
            this.ClientSize = new System.Drawing.Size(287, 115);
            this.Controls.Add(this.Master);
            this.Controls.Add(this.LegalizeReport);
            this.Controls.Add(this.ClearRecord);
            this.Controls.Add(this.AllRibbon);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SimpleEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Wang";
            this.ResumeLayout(false);

        }
    }
}
