
namespace PL
{
    partial class XacNhanHocPhi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XacNhanHocPhi));
            this.grbDSPhieuThuHP = new System.Windows.Forms.GroupBox();
            this.dgv_PhieuThuHP = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.btn_Confirm = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.pnlDeMuc = new System.Windows.Forms.Panel();
            this.lblXacNhanHocPhi = new System.Windows.Forms.Label();
            this.paleDangNhap = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.btnQuayLai = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.grbDSPhieuThuHP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PhieuThuHP)).BeginInit();
            this.pnlDeMuc.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbDSPhieuThuHP
            // 
            this.grbDSPhieuThuHP.Controls.Add(this.dgv_PhieuThuHP);
            this.grbDSPhieuThuHP.Location = new System.Drawing.Point(22, 63);
            this.grbDSPhieuThuHP.Margin = new System.Windows.Forms.Padding(2);
            this.grbDSPhieuThuHP.Name = "grbDSPhieuThuHP";
            this.grbDSPhieuThuHP.Padding = new System.Windows.Forms.Padding(2);
            this.grbDSPhieuThuHP.Size = new System.Drawing.Size(847, 313);
            this.grbDSPhieuThuHP.TabIndex = 68;
            this.grbDSPhieuThuHP.TabStop = false;
            this.grbDSPhieuThuHP.Text = "Danh sách phiếu ĐKHP";
            // 
            // dgv_PhieuThuHP
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgv_PhieuThuHP.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_PhieuThuHP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_PhieuThuHP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_PhieuThuHP.Location = new System.Drawing.Point(2, 15);
            this.dgv_PhieuThuHP.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_PhieuThuHP.Name = "dgv_PhieuThuHP";
            this.dgv_PhieuThuHP.RowHeadersVisible = false;
            this.dgv_PhieuThuHP.RowHeadersWidth = 51;
            this.dgv_PhieuThuHP.RowTemplate.Height = 24;
            this.dgv_PhieuThuHP.Size = new System.Drawing.Size(843, 296);
            this.dgv_PhieuThuHP.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dgv_PhieuThuHP.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dgv_PhieuThuHP.StateCommon.DataCell.Back.Color1 = System.Drawing.Color.White;
            this.dgv_PhieuThuHP.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(64)))), ((int)(((byte)(77)))));
            this.dgv_PhieuThuHP.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(64)))), ((int)(((byte)(77)))));
            this.dgv_PhieuThuHP.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White;
            this.dgv_PhieuThuHP.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_PhieuThuHP.StateCommon.HeaderColumn.Content.Padding = new System.Windows.Forms.Padding(2, 2, -1, -1);
            this.dgv_PhieuThuHP.StateCommon.HeaderColumn.Content.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.dgv_PhieuThuHP.TabIndex = 1;
            this.dgv_PhieuThuHP.SelectionChanged += new System.EventHandler(this.dgv_PhieuThuHP_SelectionChanged);
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.Location = new System.Drawing.Point(408, 388);
            this.btn_Confirm.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(136)))), ((int)(((byte)(61)))));
            this.btn_Confirm.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(136)))), ((int)(((byte)(61)))));
            this.btn_Confirm.Size = new System.Drawing.Size(116, 37);
            this.btn_Confirm.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(136)))), ((int)(((byte)(61)))));
            this.btn_Confirm.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(136)))), ((int)(((byte)(61)))));
            this.btn_Confirm.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(136)))), ((int)(((byte)(61)))));
            this.btn_Confirm.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(136)))), ((int)(((byte)(61)))));
            this.btn_Confirm.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_Confirm.StateCommon.Border.Rounding = 20;
            this.btn_Confirm.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.SeaShell;
            this.btn_Confirm.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.SeaShell;
            this.btn_Confirm.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Confirm.StatePressed.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_Confirm.StatePressed.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_Confirm.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_Confirm.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(136)))), ((int)(((byte)(61)))));
            this.btn_Confirm.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(136)))), ((int)(((byte)(61)))));
            this.btn_Confirm.TabIndex = 7;
            this.btn_Confirm.Values.Text = "XÁC NHẬN";
            this.btn_Confirm.Click += new System.EventHandler(this.btn_Confirm_Click);
            // 
            // pnlDeMuc
            // 
            this.pnlDeMuc.Controls.Add(this.btnQuayLai);
            this.pnlDeMuc.Controls.Add(this.lblXacNhanHocPhi);
            this.pnlDeMuc.Location = new System.Drawing.Point(4, 2);
            this.pnlDeMuc.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDeMuc.Name = "pnlDeMuc";
            this.pnlDeMuc.Size = new System.Drawing.Size(862, 44);
            this.pnlDeMuc.TabIndex = 69;
            // 
            // lblXacNhanHocPhi
            // 
            this.lblXacNhanHocPhi.AutoSize = true;
            this.lblXacNhanHocPhi.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXacNhanHocPhi.Location = new System.Drawing.Point(331, 6);
            this.lblXacNhanHocPhi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblXacNhanHocPhi.Name = "lblXacNhanHocPhi";
            this.lblXacNhanHocPhi.Size = new System.Drawing.Size(219, 25);
            this.lblXacNhanHocPhi.TabIndex = 0;
            this.lblXacNhanHocPhi.Text = "XÁC NHẬN HỌC PHÍ";
            // 
            // paleDangNhap
            // 
            this.paleDangNhap.ButtonSpecs.FormClose.Image = global::PL.Properties.Resources.icons8_orange_circle_20;
            this.paleDangNhap.ButtonSpecs.FormClose.ImageStates.ImageTracking = global::PL.Properties.Resources.icons8_orange_circle_201;
            this.paleDangNhap.ButtonSpecs.FormMax.Image = global::PL.Properties.Resources.icons8_yellow_circle_20;
            this.paleDangNhap.ButtonSpecs.FormMax.ImageStates.ImageTracking = global::PL.Properties.Resources.icons8_yellow_circle_20;
            this.paleDangNhap.ButtonSpecs.FormMin.Image = global::PL.Properties.Resources.icons8_green_circle_20;
            this.paleDangNhap.ButtonSpecs.FormMin.ImageStates.ImageTracking = global::PL.Properties.Resources.icons8_green_circle_20;
            this.paleDangNhap.FormStyles.FormMain.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.paleDangNhap.FormStyles.FormMain.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.paleDangNhap.FormStyles.FormMain.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.paleDangNhap.FormStyles.FormMain.StateCommon.Border.Rounding = 20;
            this.paleDangNhap.HeaderStyles.HeaderCommon.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.paleDangNhap.HeaderStyles.HeaderCommon.StateCommon.Back.Color2 = System.Drawing.Color.White;
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.Location = new System.Drawing.Point(7, 3);
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
            // XacNhanHocPhi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(878, 435);
            this.Controls.Add(this.pnlDeMuc);
            this.Controls.Add(this.btn_Confirm);
            this.Controls.Add(this.grbDSPhieuThuHP);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "XacNhanHocPhi";
            this.Palette = this.paleDangNhap;
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.grbDSPhieuThuHP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PhieuThuHP)).EndInit();
            this.pnlDeMuc.ResumeLayout(false);
            this.pnlDeMuc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grbDSPhieuThuHP;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgv_PhieuThuHP;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_Confirm;
        private System.Windows.Forms.Panel pnlDeMuc;
        private System.Windows.Forms.Label lblXacNhanHocPhi;
        private ComponentFactory.Krypton.Toolkit.KryptonPalette paleDangNhap;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnQuayLai;
    }
}