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
            AllRibbon = new Button();
            ClearRecord = new Button();
            LegalizeReport = new Button();
            Master = new Button();
            SuspendLayout();
            // 
            // AllRibbon
            // 
            AllRibbon.Location = new System.Drawing.Point(24, 12);
            AllRibbon.Name = "AllRibbon";
            AllRibbon.Size = new System.Drawing.Size(110, 30);
            AllRibbon.TabIndex = 0;
            AllRibbon.Text = "AllRibbon";
            AllRibbon.UseVisualStyleBackColor = true;
            AllRibbon.Click += AllRibbon_Click;
            // 
            // ClearRecord
            // 
            ClearRecord.Location = new System.Drawing.Point(155, 12);
            ClearRecord.Name = "ClearRecord";
            ClearRecord.Size = new System.Drawing.Size(110, 30);
            ClearRecord.TabIndex = 1;
            ClearRecord.Text = "ClearRecord";
            ClearRecord.UseVisualStyleBackColor = true;
            ClearRecord.Click += ClearRecord_Click;
            // 
            // LegalizeReport
            // 
            LegalizeReport.Location = new System.Drawing.Point(23, 48);
            LegalizeReport.Name = "LegalizeReport";
            LegalizeReport.Size = new System.Drawing.Size(110, 28);
            LegalizeReport.TabIndex = 2;
            LegalizeReport.Text = "Report";
            LegalizeReport.UseVisualStyleBackColor = true;
            LegalizeReport.Click += LegalizeReport_Click;
            // 
            // Master
            // 
            Master.Location = new System.Drawing.Point(155, 48);
            Master.Name = "Master";
            Master.Size = new System.Drawing.Size(108, 28);
            Master.TabIndex = 3;
            Master.Text = "Master";
            Master.UseVisualStyleBackColor = true;
            Master.Click += Master_Click;
            // 
            // SimpleEditor
            // 
            ClientSize = new System.Drawing.Size(282, 87);
            Controls.Add(Master);
            Controls.Add(LegalizeReport);
            Controls.Add(ClearRecord);
            Controls.Add(AllRibbon);
            Font = new System.Drawing.Font("Arial", 9F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "SimpleEditor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Super Wang";
            ResumeLayout(false);
        }
    }
}
