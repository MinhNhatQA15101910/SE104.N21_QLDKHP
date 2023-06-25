
namespace PL
{
    partial class QuanLyChuongTrinhHoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuanLyChuongTrinhHoc));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlDeMuc = new System.Windows.Forms.Panel();
            this.btnQuayLai = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblChuongTrinhHoc = new System.Windows.Forms.Label();
            this.grbChuongTrinhHoc = new System.Windows.Forms.GroupBox();
            this.dgv_ChuongTrinhHoc = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.cb_HocKy = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.grbHocKy = new System.Windows.Forms.GroupBox();
            this.cb_Khoa = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.grbKhoa = new System.Windows.Forms.GroupBox();
            this.cb_Nganh = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.grbNganh = new System.Windows.Forms.GroupBox();
            this.btn_Delete = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btn_AddUpdate = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.plt1 = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.img_Sort = new System.Windows.Forms.PictureBox();
            this.img_CancelSort = new System.Windows.Forms.PictureBox();
            this.pnlDeMuc.SuspendLayout();
            this.grbChuongTrinhHoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ChuongTrinhHoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_HocKy)).BeginInit();
            this.grbHocKy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cb_Khoa)).BeginInit();
            this.grbKhoa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cb_Nganh)).BeginInit();
            this.grbNganh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_Sort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_CancelSort)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDeMuc
            // 
            this.pnlDeMuc.Controls.Add(this.btnQuayLai);
            this.pnlDeMuc.Controls.Add(this.lblChuongTrinhHoc);
            this.pnlDeMuc.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDeMuc.Location = new System.Drawing.Point(0, 0);
            this.pnlDeMuc.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDeMuc.Name = "pnlDeMuc";
            this.pnlDeMuc.Size = new System.Drawing.Size(686, 44);
            this.pnlDeMuc.TabIndex = 61;
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.Location = new System.Drawing.Point(9, 3);
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
            // lblChuongTrinhHoc
            // 
            this.lblChuongTrinhHoc.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChuongTrinhHoc.Location = new System.Drawing.Point(203, 11);
            this.lblChuongTrinhHoc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblChuongTrinhHoc.Name = "lblChuongTrinhHoc";
            this.lblChuongTrinhHoc.Size = new System.Drawing.Size(290, 32);
            this.lblChuongTrinhHoc.TabIndex = 0;
            this.lblChuongTrinhHoc.Text = "CHƯƠNG TRÌNH HỌC";
            // 
            // grbChuongTrinhHoc
            // 
            this.grbChuongTrinhHoc.Controls.Add(this.dgv_ChuongTrinhHoc);
            this.grbChuongTrinhHoc.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbChuongTrinhHoc.Location = new System.Drawing.Point(16, 129);
            this.grbChuongTrinhHoc.Margin = new System.Windows.Forms.Padding(2);
            this.grbChuongTrinhHoc.Name = "grbChuongTrinhHoc";
            this.grbChuongTrinhHoc.Padding = new System.Windows.Forms.Padding(2);
            this.grbChuongTrinhHoc.Size = new System.Drawing.Size(531, 398);
            this.grbChuongTrinhHoc.TabIndex = 66;
            this.grbChuongTrinhHoc.TabStop = false;
            this.grbChuongTrinhHoc.Text = "Danh sách chương trình học";
            // 
            // dgv_ChuongTrinhHoc
            // 
            this.dgv_ChuongTrinhHoc.AllowUserToAddRows = false;
            this.dgv_ChuongTrinhHoc.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgv_ChuongTrinhHoc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ChuongTrinhHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ChuongTrinhHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ChuongTrinhHoc.Location = new System.Drawing.Point(2, 18);
            this.dgv_ChuongTrinhHoc.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_ChuongTrinhHoc.Name = "dgv_ChuongTrinhHoc";
            this.dgv_ChuongTrinhHoc.ReadOnly = true;
            this.dgv_ChuongTrinhHoc.RowHeadersVisible = false;
            this.dgv_ChuongTrinhHoc.RowHeadersWidth = 51;
            this.dgv_ChuongTrinhHoc.RowTemplate.Height = 24;
            this.dgv_ChuongTrinhHoc.Size = new System.Drawing.Size(527, 378);
            this.dgv_ChuongTrinhHoc.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dgv_ChuongTrinhHoc.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dgv_ChuongTrinhHoc.StateCommon.DataCell.Back.Color1 = System.Drawing.Color.White;
            this.dgv_ChuongTrinhHoc.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(64)))), ((int)(((byte)(77)))));
            this.dgv_ChuongTrinhHoc.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(64)))), ((int)(((byte)(77)))));
            this.dgv_ChuongTrinhHoc.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White;
            this.dgv_ChuongTrinhHoc.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_ChuongTrinhHoc.StateCommon.HeaderColumn.Content.Padding = new System.Windows.Forms.Padding(2, -1, -1, -1);
            this.dgv_ChuongTrinhHoc.StateCommon.HeaderColumn.Content.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.dgv_ChuongTrinhHoc.TabIndex = 1;
            this.dgv_ChuongTrinhHoc.SelectionChanged += new System.EventHandler(this.dgv_ChuongTrinhHoc_SelectionChanged);
            // 
            // cb_HocKy
            // 
            this.cb_HocKy.DropDownWidth = 221;
            this.cb_HocKy.Location = new System.Drawing.Point(13, 21);
            this.cb_HocKy.Margin = new System.Windows.Forms.Padding(2);
            this.cb_HocKy.Name = "cb_HocKy";
            this.cb_HocKy.Size = new System.Drawing.Size(141, 34);
            this.cb_HocKy.StateActive.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cb_HocKy.StateActive.ComboBox.Border.Rounding = 15;
            this.cb_HocKy.StateActive.ComboBox.Content.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_HocKy.StateActive.ComboBox.Content.Padding = new System.Windows.Forms.Padding(2, -1, -1, -1);
            this.cb_HocKy.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_HocKy.StateCommon.ComboBox.Content.Padding = new System.Windows.Forms.Padding(2, -1, -1, -1);
            this.cb_HocKy.TabIndex = 5;
            this.cb_HocKy.SelectedIndexChanged += new System.EventHandler(this.cb_HocKy_SelectedIndexChanged);
            // 
            // grbHocKy
            // 
            this.grbHocKy.Controls.Add(this.cb_HocKy);
            this.grbHocKy.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbHocKy.Location = new System.Drawing.Point(368, 60);
            this.grbHocKy.Margin = new System.Windows.Forms.Padding(2);
            this.grbHocKy.Name = "grbHocKy";
            this.grbHocKy.Padding = new System.Windows.Forms.Padding(2);
            this.grbHocKy.Size = new System.Drawing.Size(164, 64);
            this.grbHocKy.TabIndex = 63;
            this.grbHocKy.TabStop = false;
            this.grbHocKy.Text = "Học Kỳ";
            // 
            // cb_Khoa
            // 
            this.cb_Khoa.DropDownWidth = 221;
            this.cb_Khoa.Location = new System.Drawing.Point(4, 21);
            this.cb_Khoa.Margin = new System.Windows.Forms.Padding(2);
            this.cb_Khoa.Name = "cb_Khoa";
            this.cb_Khoa.Size = new System.Drawing.Size(156, 34);
            this.cb_Khoa.StateActive.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cb_Khoa.StateActive.ComboBox.Border.Rounding = 15;
            this.cb_Khoa.StateActive.ComboBox.Content.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Khoa.StateActive.ComboBox.Content.Padding = new System.Windows.Forms.Padding(2, -1, -1, -1);
            this.cb_Khoa.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Khoa.StateCommon.ComboBox.Content.Padding = new System.Windows.Forms.Padding(2, -1, -1, -1);
            this.cb_Khoa.TabIndex = 4;
            this.cb_Khoa.SelectedIndexChanged += new System.EventHandler(this.cb_Khoa_SelectedIndexChanged);
            // 
            // grbKhoa
            // 
            this.grbKhoa.Controls.Add(this.cb_Khoa);
            this.grbKhoa.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbKhoa.Location = new System.Drawing.Point(16, 60);
            this.grbKhoa.Margin = new System.Windows.Forms.Padding(2);
            this.grbKhoa.Name = "grbKhoa";
            this.grbKhoa.Padding = new System.Windows.Forms.Padding(2);
            this.grbKhoa.Size = new System.Drawing.Size(165, 64);
            this.grbKhoa.TabIndex = 64;
            this.grbKhoa.TabStop = false;
            this.grbKhoa.Text = "Khoa";
            // 
            // cb_Nganh
            // 
            this.cb_Nganh.DropDownWidth = 221;
            this.cb_Nganh.Location = new System.Drawing.Point(8, 21);
            this.cb_Nganh.Margin = new System.Windows.Forms.Padding(2);
            this.cb_Nganh.Name = "cb_Nganh";
            this.cb_Nganh.Size = new System.Drawing.Size(156, 34);
            this.cb_Nganh.StateActive.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cb_Nganh.StateActive.ComboBox.Border.Rounding = 15;
            this.cb_Nganh.StateActive.ComboBox.Content.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Nganh.StateActive.ComboBox.Content.Padding = new System.Windows.Forms.Padding(2, -1, -1, -1);
            this.cb_Nganh.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Nganh.StateCommon.ComboBox.Content.Padding = new System.Windows.Forms.Padding(2, -1, -1, -1);
            this.cb_Nganh.TabIndex = 5;
            this.cb_Nganh.SelectedIndexChanged += new System.EventHandler(this.cb_Nganh_SelectedIndexChanged);
            // 
            // grbNganh
            // 
            this.grbNganh.Controls.Add(this.cb_Nganh);
            this.grbNganh.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbNganh.Location = new System.Drawing.Point(196, 60);
            this.grbNganh.Margin = new System.Windows.Forms.Padding(2);
            this.grbNganh.Name = "grbNganh";
            this.grbNganh.Padding = new System.Windows.Forms.Padding(2);
            this.grbNganh.Size = new System.Drawing.Size(168, 64);
            this.grbNganh.TabIndex = 62;
            this.grbNganh.TabStop = false;
            this.grbNganh.Text = "Ngành";
            // 
            // btn_Delete
            // 
            this.btn_Delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Delete.Location = new System.Drawing.Point(566, 302);
            this.btn_Delete.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.OverrideDefault.Back.Color1 = System.Drawing.Color.White;
            this.btn_Delete.OverrideDefault.Back.Color2 = System.Drawing.Color.White;
            this.btn_Delete.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(64)))), ((int)(((byte)(77)))));
            this.btn_Delete.OverrideDefault.Border.Color2 = System.Drawing.Color.White;
            this.btn_Delete.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_Delete.Size = new System.Drawing.Size(111, 41);
            this.btn_Delete.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btn_Delete.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btn_Delete.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(64)))), ((int)(((byte)(77)))));
            this.btn_Delete.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.btn_Delete.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_Delete.StateCommon.Border.Rounding = 15;
            this.btn_Delete.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btn_Delete.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.btn_Delete.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Trebuchet MS", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btn_Delete.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btn_Delete.StateTracking.Back.Color1 = System.Drawing.Color.White;
            this.btn_Delete.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btn_Delete.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(64)))), ((int)(((byte)(77)))));
            this.btn_Delete.StateTracking.Border.Color2 = System.Drawing.Color.White;
            this.btn_Delete.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_Delete.TabIndex = 76;
            this.btn_Delete.Values.Image = global::PL.Properties.Resources.icons8_delete_document_253;
            this.btn_Delete.Values.Text = "XÓA";
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_AddUpdate
            // 
            this.btn_AddUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_AddUpdate.Location = new System.Drawing.Point(566, 248);
            this.btn_AddUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btn_AddUpdate.Name = "btn_AddUpdate";
            this.btn_AddUpdate.OverrideDefault.Back.Color1 = System.Drawing.Color.White;
            this.btn_AddUpdate.OverrideDefault.Back.Color2 = System.Drawing.Color.White;
            this.btn_AddUpdate.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(64)))), ((int)(((byte)(77)))));
            this.btn_AddUpdate.OverrideDefault.Border.Color2 = System.Drawing.Color.White;
            this.btn_AddUpdate.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_AddUpdate.Size = new System.Drawing.Size(111, 41);
            this.btn_AddUpdate.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btn_AddUpdate.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btn_AddUpdate.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(64)))), ((int)(((byte)(77)))));
            this.btn_AddUpdate.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.btn_AddUpdate.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_AddUpdate.StateCommon.Border.Rounding = 15;
            this.btn_AddUpdate.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddUpdate.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btn_AddUpdate.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.btn_AddUpdate.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Trebuchet MS", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddUpdate.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btn_AddUpdate.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btn_AddUpdate.StateTracking.Back.Color1 = System.Drawing.Color.White;
            this.btn_AddUpdate.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btn_AddUpdate.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(64)))), ((int)(((byte)(77)))));
            this.btn_AddUpdate.StateTracking.Border.Color2 = System.Drawing.Color.White;
            this.btn_AddUpdate.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_AddUpdate.TabIndex = 74;
            this.btn_AddUpdate.Values.Image = global::PL.Properties.Resources.icons8_add_properties_253;
            this.btn_AddUpdate.Values.Text = " THÊM/SỬA";
            this.btn_AddUpdate.Click += new System.EventHandler(this.btn_AddUpdate_Click);
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
            // img_Sort
            // 
            this.img_Sort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.img_Sort.Image = ((System.Drawing.Image)(resources.GetObject("img_Sort.Image")));
            this.img_Sort.Location = new System.Drawing.Point(552, 70);
            this.img_Sort.Margin = new System.Windows.Forms.Padding(2);
            this.img_Sort.Name = "img_Sort";
            this.img_Sort.Size = new System.Drawing.Size(30, 37);
            this.img_Sort.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_Sort.TabIndex = 77;
            this.img_Sort.TabStop = false;
            this.img_Sort.Click += new System.EventHandler(this.img_Sort_Click);
            // 
            // img_CancelSort
            // 
            this.img_CancelSort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.img_CancelSort.Image = ((System.Drawing.Image)(resources.GetObject("img_CancelSort.Image")));
            this.img_CancelSort.Location = new System.Drawing.Point(586, 76);
            this.img_CancelSort.Margin = new System.Windows.Forms.Padding(2);
            this.img_CancelSort.Name = "img_CancelSort";
            this.img_CancelSort.Size = new System.Drawing.Size(30, 31);
            this.img_CancelSort.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_CancelSort.TabIndex = 78;
            this.img_CancelSort.TabStop = false;
            this.img_CancelSort.Click += new System.EventHandler(this.img_CancelSort_Click);
            // 
            // QuanLyChuongTrinhHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(686, 531);
            this.Controls.Add(this.img_CancelSort);
            this.Controls.Add(this.img_Sort);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_AddUpdate);
            this.Controls.Add(this.grbChuongTrinhHoc);
            this.Controls.Add(this.grbHocKy);
            this.Controls.Add(this.grbKhoa);
            this.Controls.Add(this.grbNganh);
            this.Controls.Add(this.pnlDeMuc);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "QuanLyChuongTrinhHoc";
            this.Palette = this.plt1;
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuanLyChuongTrinhHoc_FormClosing);
            this.pnlDeMuc.ResumeLayout(false);
            this.grbChuongTrinhHoc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ChuongTrinhHoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_HocKy)).EndInit();
            this.grbHocKy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cb_Khoa)).EndInit();
            this.grbKhoa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cb_Nganh)).EndInit();
            this.grbNganh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.img_Sort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_CancelSort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDeMuc;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnQuayLai;
        private System.Windows.Forms.Label lblChuongTrinhHoc;
        private System.Windows.Forms.GroupBox grbChuongTrinhHoc;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cb_HocKy;
        private System.Windows.Forms.GroupBox grbHocKy;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cb_Khoa;
        private System.Windows.Forms.GroupBox grbKhoa;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cb_Nganh;
        private System.Windows.Forms.GroupBox grbNganh;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_Delete;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_AddUpdate;
        private ComponentFactory.Krypton.Toolkit.KryptonPalette plt1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgv_ChuongTrinhHoc;
        private System.Windows.Forms.PictureBox img_Sort;
        private System.Windows.Forms.PictureBox img_CancelSort;
    }
}