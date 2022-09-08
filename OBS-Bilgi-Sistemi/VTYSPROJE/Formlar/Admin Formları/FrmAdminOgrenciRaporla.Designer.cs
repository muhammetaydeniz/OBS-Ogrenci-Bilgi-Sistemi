namespace VTYSPROJE
{
    partial class FrmAdminOgrenciRaporla
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdminOgrenciRaporla));
            this.TBLNOTLARBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OGRSISTEMIDataSet = new VTYSPROJE.OGRSISTEMIDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.TBLNOTLARTableAdapter = new VTYSPROJE.OGRSISTEMIDataSetTableAdapters.TBLNOTLARTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.TBLNOTLARBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OGRSISTEMIDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // TBLNOTLARBindingSource
            // 
            this.TBLNOTLARBindingSource.DataMember = "TBLNOTLAR";
            this.TBLNOTLARBindingSource.DataSource = this.OGRSISTEMIDataSet;
            // 
            // OGRSISTEMIDataSet
            // 
            this.OGRSISTEMIDataSet.DataSetName = "OGRSISTEMIDataSet";
            this.OGRSISTEMIDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.TBLNOTLARBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "VTYSPROJE.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(934, 761);
            this.reportViewer1.TabIndex = 0;
            // 
            // TBLNOTLARTableAdapter
            // 
            this.TBLNOTLARTableAdapter.ClearBeforeFill = true;
            // 
            // FrmAdminOgrenciRaporla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 761);
            this.Controls.Add(this.reportViewer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAdminOgrenciRaporla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RAPOR";
            this.Load += new System.EventHandler(this.FrmAdminOgrenciRaporla_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TBLNOTLARBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OGRSISTEMIDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource TBLNOTLARBindingSource;
        private OGRSISTEMIDataSet OGRSISTEMIDataSet;
        private OGRSISTEMIDataSetTableAdapters.TBLNOTLARTableAdapter TBLNOTLARTableAdapter;
    }
}