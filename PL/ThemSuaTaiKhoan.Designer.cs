namespace PL
{
    partial class ThemSuaTaiKhoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThemSuaTaiKhoan));
            this.plt1 = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.txtTenDangNhap = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblLoaiTaiKhoan = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblTenDangNhap = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblThemSuaTaiKhoan = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.bgWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cmbLoaiTaiKhoan = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.plt2 = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.btnClear = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnXacNhan = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnQuayLai = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLoaiTaiKhoan)).BeginInit();
            this.SuspendLayout();
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
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Location = new System.Drawing.Point(134, 55);
            this.txtTenDangNhap.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(234, 29);
            this.txtTenDangNhap.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtTenDangNhap.StateActive.Border.Rounding = 15;
            this.txtTenDangNhap.StateActive.Content.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenDangNhap.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtTenDangNhap.StateCommon.Content.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenDangNhap.StateCommon.Content.Padding = new System.Windows.Forms.Padding(2, -1, -1, -1);
            this.txtTenDangNhap.TabIndex = 60;
            this.txtTenDangNhap.Text = "Sinh viên";
            // 
            // lblLoaiTaiKhoan
            // 
            this.lblLoaiTaiKhoan.Location = new System.Drawing.Point(34, 100);
            this.lblLoaiTaiKhoan.Margin = new System.Windows.Forms.Padding(2);
            this.lblLoaiTaiKhoan.Name = "lblLoaiTaiKhoan";
            this.lblLoaiTaiKhoan.Size = new System.Drawing.Size(96, 19);
            this.lblLoaiTaiKhoan.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.lblLoaiTaiKhoan.StateCommon.ShortText.Color2 = System.Drawing.Color.Black;
            this.lblLoaiTaiKhoan.StateCommon.ShortText.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoaiTaiKhoan.TabIndex = 59;
            this.lblLoaiTaiKhoan.Values.Text = "Loại tài khoản:";
            // 
            // lblTenDangNhap
            // 
            this.lblTenDangNhap.Location = new System.Drawing.Point(34, 61);
            this.lblTenDangNhap.Margin = new System.Windows.Forms.Padding(2);
            this.lblTenDangNhap.Name = "lblTenDangNhap";
            this.lblTenDangNhap.Size = new System.Drawing.Size(98, 19);
            this.lblTenDangNhap.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.lblTenDangNhap.StateCommon.ShortText.Color2 = System.Drawing.Color.Black;
            this.lblTenDangNhap.StateCommon.ShortText.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenDangNhap.TabIndex = 57;
            this.lblTenDangNhap.Values.Text = "Tên đăng nhập:";
            // 
            // lblThemSuaTaiKhoan
            // 
            this.lblThemSuaTaiKhoan.Location = new System.Drawing.Point(134, 6);
            this.lblThemSuaTaiKhoan.Margin = new System.Windows.Forms.Padding(2);
            this.lblThemSuaTaiKhoan.Name = "lblThemSuaTaiKhoan";
            this.lblThemSuaTaiKhoan.Size = new System.Drawing.Size(146, 22);
            this.lblThemSuaTaiKhoan.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.lblThemSuaTaiKhoan.StateCommon.ShortText.Color2 = System.Drawing.Color.Black;
            this.lblThemSuaTaiKhoan.StateCommon.ShortText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThemSuaTaiKhoan.TabIndex = 56;
            this.lblThemSuaTaiKhoan.Values.Text = "SỬA TÀI KHOẢN";
            // 
            // cmbLoaiTaiKhoan
            // 
            this.cmbLoaiTaiKhoan.DisplayMember = "Text";
            this.cmbLoaiTaiKhoan.DropDownWidth = 221;
            this.cmbLoaiTaiKhoan.Location = new System.Drawing.Point(134, 95);
            this.cmbLoaiTaiKhoan.Margin = new System.Windows.Forms.Padding(2);
            this.cmbLoaiTaiKhoan.Name = "cmbLoaiTaiKhoan";
            this.cmbLoaiTaiKhoan.Size = new System.Drawing.Size(234, 34);
            this.cmbLoaiTaiKhoan.StateActive.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbLoaiTaiKhoan.StateActive.ComboBox.Border.Rounding = 15;
            this.cmbLoaiTaiKhoan.StateActive.ComboBox.Content.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cmbLoaiTaiKhoan.TabIndex = 62;
            this.cmbLoaiTaiKhoan.ValueMember = "value";
            // 
            // plt2
            // 
            this.plt2.ButtonSpecs.FormClose.Image = global::PL.Properties.Resources.icons8_orange_circle_20;
            this.plt2.ButtonSpecs.FormClose.ImageStates.ImageTracking = global::PL.Properties.Resources.icons8_orange_circle_201;
            this.plt2.ButtonSpecs.FormMax.Image = global::PL.Properties.Resources.icons8_yellow_circle_20;
            this.plt2.ButtonSpecs.FormMax.ImageStates.ImageTracking = global::PL.Properties.Resources.icons8_yellow_circle_20;
            this.plt2.ButtonSpecs.FormMin.Image = global::PL.Properties.Resources.icons8_green_circle_20;
            this.plt2.ButtonSpecs.FormMin.ImageStates.ImageTracking = global::PL.Properties.Resources.icons8_green_circle_20;
            this.plt2.FormStyles.FormMain.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.plt2.FormStyles.FormMain.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.plt2.FormStyles.FormMain.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.plt2.FormStyles.FormMain.StateCommon.Border.Rounding = 20;
            this.plt2.HeaderStyles.HeaderCommon.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.plt2.HeaderStyles.HeaderCommon.StateCommon.Back.Color2 = System.Drawing.Color.White;
            // 
            // btnClear
            // 
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Location = new System.Drawing.Point(258, 150);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(109)))), ((int)(((byte)(69)))));
            this.btnClear.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(173)))), ((int)(((byte)(124)))));
            this.btnClear.OverrideDefault.Back.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnClear.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnClear.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnClear.OverrideDefault.Border.Rounding = 18;
            this.btnClear.Size = new System.Drawing.Size(98, 36);
            this.btnClear.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(64)))), ((int)(((byte)(77)))));
            this.btnClear.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(64)))), ((int)(((byte)(77)))));
            this.btnClear.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(109)))), ((int)(((byte)(69)))));
            this.btnClear.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(173)))), ((int)(((byte)(124)))));
            this.btnClear.StateCommon.Border.ColorAngle = 45F;
            this.btnClear.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnClear.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnClear.StateCommon.Border.Rounding = 20;
            this.btnClear.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.SeaShell;
            this.btnClear.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
            this.btnClear.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
            this.btnClear.StatePressed.Back.ColorAngle = 130F;
            this.btnClear.StatePressed.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
            this.btnClear.StatePressed.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
            this.btnClear.StatePressed.Border.ColorAngle = 130F;
            this.btnClear.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnClear.StatePressed.Border.Rounding = 20;
            this.btnClear.StatePressed.Border.Width = 1;
            this.btnClear.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(64)))), ((int)(((byte)(77)))));
            this.btnClear.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(64)))), ((int)(((byte)(77)))));
            this.btnClear.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnClear.StateTracking.Border.Rounding = 20;
            this.btnClear.StateTracking.Border.Width = 1;
            this.btnClear.TabIndex = 64;
            this.btnClear.Values.Text = "CLEAR";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXacNhan.Location = new System.Drawing.Point(135, 150);
            this.btnXacNhan.Margin = new System.Windows.Forms.Padding(2);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(226)))), ((int)(((byte)(192)))));
            this.btnXacNhan.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(226)))), ((int)(((byte)(192)))));
            this.btnXacNhan.OverrideDefault.Back.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnXacNhan.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnXacNhan.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnXacNhan.OverrideDefault.Border.Rounding = 18;
            this.btnXacNhan.Size = new System.Drawing.Size(107, 36);
            this.btnXacNhan.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(136)))), ((int)(((byte)(61)))));
            this.btnXacNhan.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(136)))), ((int)(((byte)(61)))));
            this.btnXacNhan.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(136)))), ((int)(((byte)(61)))));
            this.btnXacNhan.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(136)))), ((int)(((byte)(61)))));
            this.btnXacNhan.StateCommon.Border.ColorAngle = 45F;
            this.btnXacNhan.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnXacNhan.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnXacNhan.StateCommon.Border.Rounding = 20;
            this.btnXacNhan.StateCommon.Content.Padding = new System.Windows.Forms.Padding(2, -1, -1, -1);
            this.btnXacNhan.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.SeaShell;
            this.btnXacNhan.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(226)))), ((int)(((byte)(192)))));
            this.btnXacNhan.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(226)))), ((int)(((byte)(192)))));
            this.btnXacNhan.StatePressed.Back.ColorAngle = 130F;
            this.btnXacNhan.StatePressed.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(226)))), ((int)(((byte)(192)))));
            this.btnXacNhan.StatePressed.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(226)))), ((int)(((byte)(192)))));
            this.btnXacNhan.StatePressed.Border.ColorAngle = 130F;
            this.btnXacNhan.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnXacNhan.StatePressed.Border.Rounding = 20;
            this.btnXacNhan.StatePressed.Border.Width = 1;
            this.btnXacNhan.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(136)))), ((int)(((byte)(61)))));
            this.btnXacNhan.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(136)))), ((int)(((byte)(61)))));
            this.btnXacNhan.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnXacNhan.StateTracking.Border.Rounding = 20;
            this.btnXacNhan.StateTracking.Border.Width = 1;
            this.btnXacNhan.TabIndex = 63;
            this.btnXacNhan.Values.Text = "XÁC NHẬN";
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuayLai.Location = new System.Drawing.Point(3, 1);
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
            this.btnQuayLai.TabIndex = 65;
            this.btnQuayLai.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnQuayLai.Values.Image")));
            this.btnQuayLai.Values.Text = "";
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // ThemSuaTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(404, 208);
            this.Controls.Add(this.btnQuayLai);
            this.Controls.Add(this.txtTenDangNhap);
            this.Controls.Add(this.lblLoaiTaiKhoan);
            this.Controls.Add(this.lblTenDangNhap);
            this.Controls.Add(this.lblThemSuaTaiKhoan);
            this.Controls.Add(this.cmbLoaiTaiKhoan);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnXacNhan);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "ThemSuaTaiKhoan";
            this.Palette = this.plt1;
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sửa tài khoản";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ThemSuaTaiKhoan_FormClosing);
            this.Load += new System.EventHandler(this.ThemSuaTaiKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbLoaiTaiKhoan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPalette plt1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtTenDangNhap;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblLoaiTaiKhoan;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblTenDangNhap;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblThemSuaTaiKhoan;
        private System.ComponentModel.BackgroundWorker bgWorker1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbLoaiTaiKhoan;
        private ComponentFactory.Krypton.Toolkit.KryptonPalette plt2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClear;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnXacNhan;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnQuayLai;
    }
}