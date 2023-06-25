namespace PL
{
    partial class InBaoCao
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
            this.spSINHVIENbaoCaoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLyDangKyHPDataSet = new PL.QuanLyDangKyHPDataSet1();
            this.rpViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sp_SINHVIEN_baoCaoTableAdapter = new PL.QuanLyDangKyHPDataSet1TableAdapters.sp_SINHVIEN_baoCaoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.spSINHVIENbaoCaoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyDangKyHPDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // spSINHVIENbaoCaoBindingSource
            // 
            this.spSINHVIENbaoCaoBindingSource.DataMember = "sp_SINHVIEN_baoCao";
            this.spSINHVIENbaoCaoBindingSource.DataSource = this.quanLyDangKyHPDataSet;
            // 
            // quanLyDangKyHPDataSet
            // 
            this.quanLyDangKyHPDataSet.DataSetName = "QuanLyDangKyHPDataSet1";
            this.quanLyDangKyHPDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rpViewer
            // 
            this.rpViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.spSINHVIENbaoCaoBindingSource;
            this.rpViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.rpViewer.LocalReport.ReportPath = "Report1.rdlc";
            this.rpViewer.Location = new System.Drawing.Point(0, 0);
            this.rpViewer.Margin = new System.Windows.Forms.Padding(2);
            this.rpViewer.Name = "rpViewer";
            this.rpViewer.ServerReport.BearerToken = null;
            this.rpViewer.Size = new System.Drawing.Size(718, 431);
            this.rpViewer.TabIndex = 0;
            // 
            // sp_SINHVIEN_baoCaoTableAdapter
            // 
            this.sp_SINHVIEN_baoCaoTableAdapter.ClearBeforeFill = true;
            // 
            // InBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 431);
            this.Controls.Add(this.rpViewer);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "InBaoCao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InBaoCao";
            this.Load += new System.EventHandler(this.InBaoCao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spSINHVIENbaoCaoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyDangKyHPDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpViewer;
        private System.Windows.Forms.BindingSource spSINHVIENbaoCaoBindingSource;
        private QuanLyDangKyHPDataSet1 quanLyDangKyHPDataSet;
        private QuanLyDangKyHPDataSet1TableAdapters.sp_SINHVIEN_baoCaoTableAdapter sp_SINHVIEN_baoCaoTableAdapter;
    }
}