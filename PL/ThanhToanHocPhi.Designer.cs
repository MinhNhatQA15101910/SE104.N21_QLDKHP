
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThanhToanHocPhi));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.kryptonDataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.stt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mamh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenmh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ghichu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonButton6 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblQLMB = new System.Windows.Forms.Label();
            this.kryptonTextBox1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.paleDangNhap = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(41, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Danh sách phiếu ĐKHP chưa thanh toán";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(529, 478);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tổng tiền:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.kryptonDataGridView1);
            this.groupBox4.Location = new System.Drawing.Point(27, 104);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(833, 351);
            this.groupBox4.TabIndex = 69;
            this.groupBox4.TabStop = false;
            // 
            // kryptonDataGridView1
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.kryptonDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.kryptonDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kryptonDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stt,
            this.mamh,
            this.tenmh,
            this.ghichu,
            this.Column1});
            this.kryptonDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonDataGridView1.Location = new System.Drawing.Point(3, 18);
            this.kryptonDataGridView1.Name = "kryptonDataGridView1";
            this.kryptonDataGridView1.RowHeadersVisible = false;
            this.kryptonDataGridView1.RowHeadersWidth = 51;
            this.kryptonDataGridView1.RowTemplate.Height = 24;
            this.kryptonDataGridView1.Size = new System.Drawing.Size(827, 330);
            this.kryptonDataGridView1.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.kryptonDataGridView1.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.kryptonDataGridView1.StateCommon.DataCell.Back.Color1 = System.Drawing.Color.White;
            this.kryptonDataGridView1.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(64)))), ((int)(((byte)(77)))));
            this.kryptonDataGridView1.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(64)))), ((int)(((byte)(77)))));
            this.kryptonDataGridView1.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White;
            this.kryptonDataGridView1.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonDataGridView1.StateCommon.HeaderColumn.Content.Padding = new System.Windows.Forms.Padding(2, -1, -1, -1);
            this.kryptonDataGridView1.StateCommon.HeaderColumn.Content.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.kryptonDataGridView1.TabIndex = 1;
            // 
            // stt
            // 
            this.stt.HeaderText = "Mã Phiếu ĐKHP";
            this.stt.MinimumWidth = 6;
            this.stt.Name = "stt";
            this.stt.Width = 120;
            // 
            // mamh
            // 
            this.mamh.HeaderText = "Ngày lập";
            this.mamh.MinimumWidth = 6;
            this.mamh.Name = "mamh";
            this.mamh.Width = 92;
            // 
            // tenmh
            // 
            this.tenmh.HeaderText = "Học kỳ";
            this.tenmh.MinimumWidth = 6;
            this.tenmh.Name = "tenmh";
            this.tenmh.Width = 320;
            // 
            // ghichu
            // 
            this.ghichu.HeaderText = "Năm học";
            this.ghichu.MinimumWidth = 6;
            this.ghichu.Name = "ghichu";
            this.ghichu.Width = 125;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Số tiền còn thiếu";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.kryptonButton6);
            this.panel1.Controls.Add(this.lblQLMB);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(886, 61);
            this.panel1.TabIndex = 71;
            // 
            // kryptonButton6
            // 
            this.kryptonButton6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.kryptonButton6.Location = new System.Drawing.Point(12, 9);
            this.kryptonButton6.Name = "kryptonButton6";
            this.kryptonButton6.Size = new System.Drawing.Size(52, 48);
            this.kryptonButton6.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.kryptonButton6.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.kryptonButton6.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton6.StateCommon.Border.Rounding = 15;
            this.kryptonButton6.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton6.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton6.TabIndex = 48;
            this.kryptonButton6.Values.Image = ((System.Drawing.Image)(resources.GetObject("kryptonButton6.Values.Image")));
            this.kryptonButton6.Values.Text = " QUAY LẠI";
            // 
            // lblQLMB
            // 
            this.lblQLMB.BackColor = System.Drawing.Color.Transparent;
            this.lblQLMB.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQLMB.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblQLMB.Location = new System.Drawing.Point(291, 13);
            this.lblQLMB.Name = "lblQLMB";
            this.lblQLMB.Size = new System.Drawing.Size(366, 34);
            this.lblQLMB.TabIndex = 0;
            this.lblQLMB.Text = "THANH TOÁN HỌC PHÍ";
            // 
            // kryptonTextBox1
            // 
            this.kryptonTextBox1.Location = new System.Drawing.Point(616, 471);
            this.kryptonTextBox1.Name = "kryptonTextBox1";
            this.kryptonTextBox1.Size = new System.Drawing.Size(217, 33);
            this.kryptonTextBox1.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonTextBox1.StateActive.Border.Rounding = 15;
            this.kryptonTextBox1.StateActive.Content.Color1 = System.Drawing.Color.Red;
            this.kryptonTextBox1.StateActive.Content.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonTextBox1.StateActive.Content.Padding = new System.Windows.Forms.Padding(2, -1, -1, -1);
            this.kryptonTextBox1.TabIndex = 58;
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
            // ThanhToanHocPhi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(886, 522);
            this.Controls.Add(this.kryptonTextBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.Name = "ThanhToanHocPhi";
            this.Palette = this.paleDangNhap;
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ThanhToanHocPhi_Load);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kryptonDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn stt;
        private System.Windows.Forms.DataGridViewTextBoxColumn mamh;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenmh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ghichu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Panel panel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton6;
        private System.Windows.Forms.Label lblQLMB;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonPalette paleDangNhap;
    }
}