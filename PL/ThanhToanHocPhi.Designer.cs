
namespace PL
{
    partial class ThanhToanHocPhi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThanhToanHocPhi));
            this.lblDSPhieuDKHPChuaTT = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.grbDSPhieuDKHP = new System.Windows.Forms.GroupBox();
            this.dgvDSHPChuaThanhToan = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.pnlDeMuc = new System.Windows.Forms.Panel();
            this.btnQuayLai = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblThanhToanHocPhi = new System.Windows.Forms.Label();
            this.txtTongTien = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.plt1 = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.grbDSPhieuDKHP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSHPChuaThanhToan)).BeginInit();
            this.pnlDeMuc.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDSPhieuDKHPChuaTT
            // 
            this.lblDSPhieuDKHPChuaTT.AutoSize = true;
            this.lblDSPhieuDKHPChuaTT.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDSPhieuDKHPChuaTT.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDSPhieuDKHPChuaTT.Location = new System.Drawing.Point(31, 69);
            this.lblDSPhieuDKHPChuaTT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDSPhieuDKHPChuaTT.Name = "lblDSPhieuDKHPChuaTT";
            this.lblDSPhieuDKHPChuaTT.Size = new System.Drawing.Size(235, 16);
            this.lblDSPhieuDKHPChuaTT.TabIndex = 1;
            this.lblDSPhieuDKHPChuaTT.Text = "Danh sách phiếu ĐKHP chưa thanh toán";
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.ForeColor = System.Drawing.Color.Black;
            this.lblTongTien.Location = new System.Drawing.Point(397, 388);
            this.lblTongTien.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(64, 16);
            this.lblTongTien.TabIndex = 3;
            this.lblTongTien.Text = "Tổng tiền:";
            // 
            // grbDSPhieuDKHP
            // 
            this.grbDSPhieuDKHP.Controls.Add(this.dgvDSHPChuaThanhToan);
            this.grbDSPhieuDKHP.Location = new System.Drawing.Point(20, 84);
            this.grbDSPhieuDKHP.Margin = new System.Windows.Forms.Padding(2);
            this.grbDSPhieuDKHP.Name = "grbDSPhieuDKHP";
            this.grbDSPhieuDKHP.Padding = new System.Windows.Forms.Padding(2);
            this.grbDSPhieuDKHP.Size = new System.Drawing.Size(625, 285);
            this.grbDSPhieuDKHP.TabIndex = 69;
            this.grbDSPhieuDKHP.TabStop = false;
            // 
            // dgvDSHPChuaThanhToan
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvDSHPChuaThanhToan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSHPChuaThanhToan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSHPChuaThanhToan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDSHPChuaThanhToan.Location = new System.Drawing.Point(2, 15);
            this.dgvDSHPChuaThanhToan.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDSHPChuaThanhToan.Name = "dgvDSHPChuaThanhToan";
            this.dgvDSHPChuaThanhToan.RowHeadersVisible = false;
            this.dgvDSHPChuaThanhToan.RowHeadersWidth = 51;
            this.dgvDSHPChuaThanhToan.RowTemplate.Height = 24;
            this.dgvDSHPChuaThanhToan.Size = new System.Drawing.Size(621, 268);
            this.dgvDSHPChuaThanhToan.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dgvDSHPChuaThanhToan.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dgvDSHPChuaThanhToan.StateCommon.DataCell.Back.Color1 = System.Drawing.Color.White;
            this.dgvDSHPChuaThanhToan.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(64)))), ((int)(((byte)(77)))));
            this.dgvDSHPChuaThanhToan.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(64)))), ((int)(((byte)(77)))));
            this.dgvDSHPChuaThanhToan.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White;
            this.dgvDSHPChuaThanhToan.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDSHPChuaThanhToan.StateCommon.HeaderColumn.Content.Padding = new System.Windows.Forms.Padding(2, -1, -1, -1);
            this.dgvDSHPChuaThanhToan.StateCommon.HeaderColumn.Content.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.dgvDSHPChuaThanhToan.TabIndex = 1;
            this.dgvDSHPChuaThanhToan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSHPChuaThanhToan_CellClick);
            // 
            // pnlDeMuc
            // 
            this.pnlDeMuc.Controls.Add(this.btnQuayLai);
            this.pnlDeMuc.Controls.Add(this.lblThanhToanHocPhi);
            this.pnlDeMuc.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDeMuc.Location = new System.Drawing.Point(0, 0);
            this.pnlDeMuc.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDeMuc.Name = "pnlDeMuc";
            this.pnlDeMuc.Size = new System.Drawing.Size(664, 50);
            this.pnlDeMuc.TabIndex = 71;
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnQuayLai.Location = new System.Drawing.Point(9, 7);
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
            this.btnQuayLai.TabIndex = 48;
            this.btnQuayLai.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnQuayLai.Values.Image")));
            this.btnQuayLai.Values.Text = " QUAY LẠI";
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // lblThanhToanHocPhi
            // 
            this.lblThanhToanHocPhi.BackColor = System.Drawing.Color.Transparent;
            this.lblThanhToanHocPhi.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThanhToanHocPhi.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblThanhToanHocPhi.Location = new System.Drawing.Point(218, 11);
            this.lblThanhToanHocPhi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblThanhToanHocPhi.Name = "lblThanhToanHocPhi";
            this.lblThanhToanHocPhi.Size = new System.Drawing.Size(274, 28);
            this.lblThanhToanHocPhi.TabIndex = 0;
            this.lblThanhToanHocPhi.Text = "THANH TOÁN HỌC PHÍ";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(462, 383);
            this.txtTongTien.Margin = new System.Windows.Forms.Padding(2);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(163, 29);
            this.txtTongTien.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtTongTien.StateActive.Border.Rounding = 15;
            this.txtTongTien.StateActive.Content.Color1 = System.Drawing.Color.Red;
            this.txtTongTien.StateActive.Content.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTien.StateActive.Content.Padding = new System.Windows.Forms.Padding(2, -1, -1, -1);
            this.txtTongTien.TabIndex = 58;
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
            // ThanhToanHocPhi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(664, 424);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.pnlDeMuc);
            this.Controls.Add(this.lblDSPhieuDKHPChuaTT);
            this.Controls.Add(this.grbDSPhieuDKHP);
            this.Controls.Add(this.lblTongTien);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "ThanhToanHocPhi";
            this.Palette = this.plt1;
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ThanhToanHocPhi_FormClosing);
            this.Load += new System.EventHandler(this.ThanhToanHocPhi_Load);
            this.grbDSPhieuDKHP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSHPChuaThanhToan)).EndInit();
            this.pnlDeMuc.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblDSPhieuDKHPChuaTT;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.GroupBox grbDSPhieuDKHP;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvDSHPChuaThanhToan;
        private System.Windows.Forms.Panel pnlDeMuc;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnQuayLai;
        private System.Windows.Forms.Label lblThanhToanHocPhi;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtTongTien;
        private ComponentFactory.Krypton.Toolkit.KryptonPalette plt1;
    }
}