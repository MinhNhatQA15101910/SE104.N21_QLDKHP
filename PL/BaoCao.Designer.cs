
namespace PL
{
    partial class BaoCao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaoCao));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grbHocKy = new System.Windows.Forms.GroupBox();
            this.cmbHocKy = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.grbNamHoc = new System.Windows.Forms.GroupBox();
            this.txtNamHoc = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.pnlDeMuc = new System.Windows.Forms.Panel();
            this.btnQuayLai = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblBaoCao = new System.Windows.Forms.Label();
            this.dgvDSSV = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.btnThongKe = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnInBaoCao = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.plt1 = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.grbHocKy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHocKy)).BeginInit();
            this.grbNamHoc.SuspendLayout();
            this.pnlDeMuc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSSV)).BeginInit();
            this.SuspendLayout();
            // 
            // grbHocKy
            // 
            this.grbHocKy.Controls.Add(this.cmbHocKy);
            this.grbHocKy.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbHocKy.Location = new System.Drawing.Point(52, 70);
            this.grbHocKy.Margin = new System.Windows.Forms.Padding(2);
            this.grbHocKy.Name = "grbHocKy";
            this.grbHocKy.Padding = new System.Windows.Forms.Padding(2);
            this.grbHocKy.Size = new System.Drawing.Size(170, 64);
            this.grbHocKy.TabIndex = 27;
            this.grbHocKy.TabStop = false;
            this.grbHocKy.Text = "Học Kỳ";
            // 
            // cmbHocKy
            // 
            this.cmbHocKy.DropDownWidth = 221;
            this.cmbHocKy.Location = new System.Drawing.Point(15, 22);
            this.cmbHocKy.Margin = new System.Windows.Forms.Padding(2);
            this.cmbHocKy.Name = "cmbHocKy";
            this.cmbHocKy.Size = new System.Drawing.Size(151, 34);
            this.cmbHocKy.StateActive.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbHocKy.StateActive.ComboBox.Border.Rounding = 15;
            this.cmbHocKy.StateActive.ComboBox.Content.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHocKy.StateActive.ComboBox.Content.Padding = new System.Windows.Forms.Padding(2, -1, -1, -1);
            this.cmbHocKy.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHocKy.TabIndex = 4;
            // 
            // grbNamHoc
            // 
            this.grbNamHoc.Controls.Add(this.txtNamHoc);
            this.grbNamHoc.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbNamHoc.Location = new System.Drawing.Point(243, 70);
            this.grbNamHoc.Margin = new System.Windows.Forms.Padding(2);
            this.grbNamHoc.Name = "grbNamHoc";
            this.grbNamHoc.Padding = new System.Windows.Forms.Padding(2);
            this.grbNamHoc.Size = new System.Drawing.Size(170, 64);
            this.grbNamHoc.TabIndex = 26;
            this.grbNamHoc.TabStop = false;
            this.grbNamHoc.Text = "Năm học";
            // 
            // txtNamHoc
            // 
            this.txtNamHoc.Location = new System.Drawing.Point(15, 24);
            this.txtNamHoc.Margin = new System.Windows.Forms.Padding(2);
            this.txtNamHoc.Name = "txtNamHoc";
            this.txtNamHoc.Size = new System.Drawing.Size(151, 29);
            this.txtNamHoc.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtNamHoc.StateActive.Border.Rounding = 15;
            this.txtNamHoc.StateActive.Content.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNamHoc.StateCommon.Content.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNamHoc.StateCommon.Content.Padding = new System.Windows.Forms.Padding(2, -1, -1, -1);
            this.txtNamHoc.TabIndex = 12;
            // 
            // pnlDeMuc
            // 
            this.pnlDeMuc.Controls.Add(this.btnQuayLai);
            this.pnlDeMuc.Controls.Add(this.lblBaoCao);
            this.pnlDeMuc.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDeMuc.Location = new System.Drawing.Point(0, 0);
            this.pnlDeMuc.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDeMuc.Name = "pnlDeMuc";
            this.pnlDeMuc.Size = new System.Drawing.Size(859, 54);
            this.pnlDeMuc.TabIndex = 52;
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.Location = new System.Drawing.Point(11, 5);
            this.btnQuayLai.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(39, 39);
            this.btnQuayLai.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnQuayLai.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnQuayLai.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnQuayLai.StateCommon.Border.Rounding = 15;
            this.btnQuayLai.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuayLai.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuayLai.TabIndex = 49;
            this.btnQuayLai.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnQuayLai.Values.Image")));
            this.btnQuayLai.Values.Text = " QUAY LẠI";
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // lblBaoCao
            // 
            this.lblBaoCao.AutoEllipsis = true;
            this.lblBaoCao.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaoCao.Location = new System.Drawing.Point(104, 12);
            this.lblBaoCao.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBaoCao.Name = "lblBaoCao";
            this.lblBaoCao.Size = new System.Drawing.Size(716, 32);
            this.lblBaoCao.TabIndex = 0;
            this.lblBaoCao.Text = "DANH SÁCH SINH VIÊN CHƯA HOÀN THÀNH VIỆC ĐÓNG HỌC PHÍ ";
            // 
            // dgvDSSV
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvDSSV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSSV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSSV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvDSSV.Location = new System.Drawing.Point(33, 157);
            this.dgvDSSV.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDSSV.Name = "dgvDSSV";
            this.dgvDSSV.RowHeadersVisible = false;
            this.dgvDSSV.RowHeadersWidth = 51;
            this.dgvDSSV.RowTemplate.Height = 24;
            this.dgvDSSV.Size = new System.Drawing.Size(755, 343);
            this.dgvDSSV.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dgvDSSV.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dgvDSSV.StateCommon.DataCell.Back.Color1 = System.Drawing.Color.White;
            this.dgvDSSV.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(64)))), ((int)(((byte)(77)))));
            this.dgvDSSV.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(64)))), ((int)(((byte)(77)))));
            this.dgvDSSV.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White;
            this.dgvDSSV.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDSSV.StateCommon.HeaderColumn.Content.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.dgvDSSV.TabIndex = 53;
            // 
            // btnThongKe
            // 
            this.btnThongKe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThongKe.Location = new System.Drawing.Point(437, 80);
            this.btnThongKe.Margin = new System.Windows.Forms.Padding(2);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.OverrideDefault.Back.Color1 = System.Drawing.Color.White;
            this.btnThongKe.OverrideDefault.Back.Color2 = System.Drawing.Color.White;
            this.btnThongKe.Size = new System.Drawing.Size(130, 42);
            this.btnThongKe.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnThongKe.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnThongKe.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(64)))), ((int)(((byte)(77)))));
            this.btnThongKe.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.btnThongKe.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnThongKe.StateCommon.Border.Rounding = 15;
            this.btnThongKe.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btnThongKe.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.btnThongKe.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnThongKe.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnThongKe.StateTracking.Back.Color1 = System.Drawing.Color.White;
            this.btnThongKe.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnThongKe.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(64)))), ((int)(((byte)(77)))));
            this.btnThongKe.StateTracking.Border.Color2 = System.Drawing.Color.White;
            this.btnThongKe.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnThongKe.TabIndex = 54;
            this.btnThongKe.Values.Image = global::PL.Properties.Resources.icons8_edit_property_256;
            this.btnThongKe.Values.Text = "THỐNG KÊ";
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnInBaoCao
            // 
            this.btnInBaoCao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInBaoCao.Location = new System.Drawing.Point(582, 80);
            this.btnInBaoCao.Margin = new System.Windows.Forms.Padding(2);
            this.btnInBaoCao.Name = "btnInBaoCao";
            this.btnInBaoCao.OverrideDefault.Back.Color1 = System.Drawing.Color.White;
            this.btnInBaoCao.OverrideDefault.Back.Color2 = System.Drawing.Color.White;
            this.btnInBaoCao.Size = new System.Drawing.Size(130, 42);
            this.btnInBaoCao.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnInBaoCao.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnInBaoCao.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(64)))), ((int)(((byte)(77)))));
            this.btnInBaoCao.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.btnInBaoCao.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnInBaoCao.StateCommon.Border.Rounding = 15;
            this.btnInBaoCao.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInBaoCao.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btnInBaoCao.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.btnInBaoCao.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInBaoCao.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnInBaoCao.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnInBaoCao.StateTracking.Back.Color1 = System.Drawing.Color.White;
            this.btnInBaoCao.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnInBaoCao.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(64)))), ((int)(((byte)(77)))));
            this.btnInBaoCao.StateTracking.Border.Color2 = System.Drawing.Color.White;
            this.btnInBaoCao.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnInBaoCao.TabIndex = 55;
            this.btnInBaoCao.Values.Image = global::PL.Properties.Resources.icons8_edit_property_256;
            this.btnInBaoCao.Values.Text = "IN BÁO CÁO";
            this.btnInBaoCao.Click += new System.EventHandler(this.btnInBaoCao_Click);
            // 
            // plt1
            // 
            this.plt1.ButtonSpecs.FormClose.Image = global::PL.Properties.Resources.icons8_orange_circle_20;
            this.plt1.ButtonSpecs.FormClose.ImageStates.ImageTracking = global::PL.Properties.Resources.icons8_orange_circle_201;
            this.plt1.ButtonSpecs.FormMax.Image = global::PL.Properties.Resources.icons8_yellow_circle_20;
            this.plt1.ButtonSpecs.FormMax.ImageStates.ImageTracking = global::PL.Properties.Resources.icons8_yellow_circle_20;
            this.plt1.ButtonSpecs.FormMin.Image = global::PL.Properties.Resources.icons8_green_circle_20;
            this.plt1.ButtonSpecs.FormMin.ImageStates.ImageTracking = global::PL.Properties.Resources.icons8_green_circle_20;
            this.plt1.FormStyles.FormMain.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.plt1.FormStyles.FormMain.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.plt1.FormStyles.FormMain.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.plt1.FormStyles.FormMain.StateCommon.Border.Rounding = 20;
            this.plt1.HeaderStyles.HeaderCommon.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.plt1.HeaderStyles.HeaderCommon.StateCommon.Back.Color2 = System.Drawing.Color.White;
            // 
            // BaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 538);
            this.Controls.Add(this.btnInBaoCao);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.dgvDSSV);
            this.Controls.Add(this.pnlDeMuc);
            this.Controls.Add(this.grbHocKy);
            this.Controls.Add(this.grbNamHoc);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BaoCao";
            this.Palette = this.plt1;
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BaoCao_FormClosing);
            this.Load += new System.EventHandler(this.BaoCao_Load);
            this.grbHocKy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbHocKy)).EndInit();
            this.grbNamHoc.ResumeLayout(false);
            this.grbNamHoc.PerformLayout();
            this.pnlDeMuc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSSV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grbHocKy;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbHocKy;
        private System.Windows.Forms.GroupBox grbNamHoc;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtNamHoc;
        private System.Windows.Forms.Panel pnlDeMuc;
        private System.Windows.Forms.Label lblBaoCao;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvDSSV;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnThongKe;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnInBaoCao;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnQuayLai;
        private ComponentFactory.Krypton.Toolkit.KryptonPalette plt1;
    }
}