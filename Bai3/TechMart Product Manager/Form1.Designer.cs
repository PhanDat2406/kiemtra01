namespace TechMart_Product_Manager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dgvCellStyleHeader = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvCellStylePrice = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvCellStyleQuantity = new DataGridViewCellStyle();
            
            menuStripMain = new MenuStrip();
            menuFile = new ToolStripMenuItem();
            menuExportCsv = new ToolStripMenuItem();
            toolStripMenuItemSeparator1 = new ToolStripSeparator();
            menuExit = new ToolStripMenuItem();
            statusStripMain = new StatusStrip();
            lblStatusCount = new ToolStripStatusLabel();
            lblStatusSpring = new ToolStripStatusLabel();
            lblStatusAction = new ToolStripStatusLabel();
            tlpMain = new TableLayoutPanel();
            grpProductInfo = new GroupBox();
            tlpInputFields = new TableLayoutPanel();
            lblProductId = new Label();
            txtProductId = new TextBox();
            lblProductName = new Label();
            txtProductName = new TextBox();
            lblCategory = new Label();
            cboCategory = new ComboBox();
            lblUnitPrice = new Label();
            txtUnitPrice = new TextBox();
            lblQuantity = new Label();
            txtQuantity = new TextBox();
            lblAvatar = new Label();
            pnlAvatarContainer = new Panel();
            picAvatar = new PictureBox();
            pnlAvatarButtons = new FlowLayoutPanel();
            btnChooseImage = new Button();
            btnClearImage = new Button();
            pnlActionButtons = new TableLayoutPanel();
            btnAddNew = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            grpProductList = new GroupBox();
            pnlGridContainer = new Panel();
            dgvProducts = new DataGridView();
            colProductId = new DataGridViewTextBoxColumn();
            colProductName = new DataGridViewTextBoxColumn();
            colCategory = new DataGridViewTextBoxColumn();
            colUnitPrice = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewTextBoxColumn();
            pnlSearch = new Panel();
            btnExportCsv = new Button();
            txtSearch = new TextBox();
            lblSearch = new Label();
            errorProvider = new ErrorProvider(components);

            menuStripMain.SuspendLayout();
            statusStripMain.SuspendLayout();
            tlpMain.SuspendLayout();
            grpProductInfo.SuspendLayout();
            tlpInputFields.SuspendLayout();
            pnlAvatarContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            pnlAvatarButtons.SuspendLayout();
            pnlActionButtons.SuspendLayout();
            grpProductList.SuspendLayout();
            pnlGridContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();

            // 
            // menuStripMain
            // 
            menuStripMain.ImageScalingSize = new Size(20, 20);
            menuStripMain.Items.AddRange(new ToolStripItem[] { menuFile });
            menuStripMain.Location = new Point(0, 0);
            menuStripMain.Name = "menuStripMain";
            menuStripMain.Size = new Size(1150, 28);
            menuStripMain.TabIndex = 0;
            menuStripMain.Text = "menuStrip1";

            // 
            // menuFile
            // 
            menuFile.DropDownItems.AddRange(new ToolStripItem[] { menuExportCsv, toolStripMenuItemSeparator1, menuExit });
            menuFile.Name = "menuFile";
            menuFile.Size = new Size(46, 24);
            menuFile.Text = "&File";

            // 
            // menuExportCsv
            // 
            menuExportCsv.Name = "menuExportCsv";
            menuExportCsv.ShortcutKeys = Keys.Control | Keys.E;
            menuExportCsv.Size = new Size(224, 26);
            menuExportCsv.Text = "&Export CSV";
            menuExportCsv.Click += menuExportCsv_Click;

            // 
            // toolStripMenuItemSeparator1
            // 
            toolStripMenuItemSeparator1.Name = "toolStripMenuItemSeparator1";
            toolStripMenuItemSeparator1.Size = new Size(221, 6);

            // 
            // menuExit
            // 
            menuExit.Name = "menuExit";
            menuExit.ShortcutKeys = Keys.Control | Keys.X;
            menuExit.Size = new Size(224, 26);
            menuExit.Text = "E&xit";
            menuExit.Click += menuExit_Click;

            // 
            // statusStripMain
            // 
            statusStripMain.ImageScalingSize = new Size(20, 20);
            statusStripMain.Items.AddRange(new ToolStripItem[] { lblStatusCount, lblStatusSpring, lblStatusAction });
            statusStripMain.Location = new Point(0, 668);
            statusStripMain.Name = "statusStripMain";
            statusStripMain.Size = new Size(1150, 26);
            statusStripMain.TabIndex = 2;
            statusStripMain.Text = "statusStrip1";

            // 
            // lblStatusCount
            // 
            lblStatusCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStatusCount.Name = "lblStatusCount";
            lblStatusCount.Size = new Size(147, 20);
            lblStatusCount.Text = "Tổng số sản phẩm: 0";

            // 
            // lblStatusSpring
            // 
            lblStatusSpring.Name = "lblStatusSpring";
            lblStatusSpring.Size = new Size(934, 20);
            lblStatusSpring.Spring = true;

            // 
            // lblStatusAction
            // 
            lblStatusAction.ForeColor = Color.DarkSlateGray;
            lblStatusAction.Name = "lblStatusAction";
            lblStatusAction.Size = new Size(54, 20);
            lblStatusAction.Text = "Sẵn sàng";

            // 
            // tlpMain
            // 
            tlpMain.ColumnCount = 2;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tlpMain.Controls.Add(grpProductInfo, 0, 0);
            tlpMain.Controls.Add(grpProductList, 1, 0);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(0, 28);
            tlpMain.Name = "tlpMain";
            tlpMain.RowCount = 1;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.Size = new Size(1150, 640);
            tlpMain.TabIndex = 1;

            // 
            // grpProductInfo
            // 
            grpProductInfo.Controls.Add(tlpInputFields);
            grpProductInfo.Dock = DockStyle.Fill;
            grpProductInfo.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            grpProductInfo.Location = new Point(8, 8);
            grpProductInfo.Margin = new Padding(8);
            grpProductInfo.Name = "grpProductInfo";
            grpProductInfo.Padding = new Padding(12);
            grpProductInfo.Size = new Size(386, 624);
            grpProductInfo.TabIndex = 0;
            grpProductInfo.TabStop = false;
            grpProductInfo.Text = "Khung Nhập Liệu Sản Phẩm";

            // 
            // tlpInputFields
            // 
            tlpInputFields.ColumnCount = 2;
            tlpInputFields.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tlpInputFields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpInputFields.Controls.Add(lblProductId, 0, 0);
            tlpInputFields.Controls.Add(txtProductId, 1, 0);
            tlpInputFields.Controls.Add(lblProductName, 0, 1);
            tlpInputFields.Controls.Add(txtProductName, 1, 1);
            tlpInputFields.Controls.Add(lblCategory, 0, 2);
            tlpInputFields.Controls.Add(cboCategory, 1, 2);
            tlpInputFields.Controls.Add(lblUnitPrice, 0, 3);
            tlpInputFields.Controls.Add(txtUnitPrice, 1, 3);
            tlpInputFields.Controls.Add(lblQuantity, 0, 4);
            tlpInputFields.Controls.Add(txtQuantity, 1, 4);
            tlpInputFields.Controls.Add(lblAvatar, 0, 5);
            tlpInputFields.Controls.Add(pnlAvatarContainer, 1, 5);
            tlpInputFields.Controls.Add(pnlActionButtons, 0, 6);
            tlpInputFields.Dock = DockStyle.Fill;
            tlpInputFields.Font = new Font("Segoe UI", 9F);
            tlpInputFields.Location = new Point(12, 34);
            tlpInputFields.Name = "tlpInputFields";
            tlpInputFields.RowCount = 7;
            tlpInputFields.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tlpInputFields.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tlpInputFields.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tlpInputFields.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tlpInputFields.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tlpInputFields.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpInputFields.RowStyles.Add(new RowStyle(SizeType.Absolute, 85F));
            tlpInputFields.Size = new Size(362, 578);
            tlpInputFields.TabIndex = 0;

            // 
            // lblProductId
            // 
            lblProductId.Anchor = AnchorStyles.Left;
            lblProductId.AutoSize = true;
            lblProductId.Location = new Point(3, 9);
            lblProductId.Name = "lblProductId";
            lblProductId.Size = new Size(54, 20);
            lblProductId.TabIndex = 0;
            lblProductId.Text = "Mã SP:";

            // 
            // txtProductId
            // 
            txtProductId.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtProductId.Location = new Point(103, 5);
            txtProductId.Margin = new Padding(3, 3, 20, 3);
            txtProductId.Name = "txtProductId";
            txtProductId.Size = new Size(239, 27);
            txtProductId.TabIndex = 1;

            // 
            // lblProductName
            // 
            lblProductName.Anchor = AnchorStyles.Left;
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(3, 47);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(56, 20);
            lblProductName.TabIndex = 2;
            lblProductName.Text = "Tên SP:";

            // 
            // txtProductName
            // 
            txtProductName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtProductName.Location = new Point(103, 43);
            txtProductName.Margin = new Padding(3, 3, 20, 3);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(239, 27);
            txtProductName.TabIndex = 3;

            // 
            // lblCategory
            // 
            lblCategory.Anchor = AnchorStyles.Left;
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(3, 85);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(79, 20);
            lblCategory.TabIndex = 4;
            lblCategory.Text = "Danh mục:";

            // 
            // cboCategory
            // 
            cboCategory.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(103, 81);
            cboCategory.Margin = new Padding(3, 3, 20, 3);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(239, 28);
            cboCategory.TabIndex = 5;

            // 
            // lblUnitPrice
            // 
            lblUnitPrice.Anchor = AnchorStyles.Left;
            lblUnitPrice.AutoSize = true;
            lblUnitPrice.Location = new Point(3, 123);
            lblUnitPrice.Name = "lblUnitPrice";
            lblUnitPrice.Size = new Size(65, 20);
            lblUnitPrice.TabIndex = 6;
            lblUnitPrice.Text = "Đơn giá:";

            // 
            // txtUnitPrice
            // 
            txtUnitPrice.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtUnitPrice.Location = new Point(103, 119);
            txtUnitPrice.Margin = new Padding(3, 3, 20, 3);
            txtUnitPrice.Name = "txtUnitPrice";
            txtUnitPrice.Size = new Size(239, 27);
            txtUnitPrice.TabIndex = 7;

            // 
            // lblQuantity
            // 
            lblQuantity.Anchor = AnchorStyles.Left;
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(3, 161);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(72, 20);
            lblQuantity.TabIndex = 8;
            lblQuantity.Text = "Số lượng:";

            // 
            // txtQuantity
            // 
            txtQuantity.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtQuantity.Location = new Point(103, 157);
            txtQuantity.Margin = new Padding(3, 3, 20, 3);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(239, 27);
            txtQuantity.TabIndex = 9;

            // 
            // lblAvatar
            // 
            lblAvatar.AutoSize = true;
            lblAvatar.Location = new Point(3, 196);
            lblAvatar.Margin = new Padding(3, 6, 3, 0);
            lblAvatar.Name = "lblAvatar";
            lblAvatar.Size = new Size(68, 20);
            lblAvatar.TabIndex = 10;
            lblAvatar.Text = "Hình ảnh:";

            // 
            // pnlAvatarContainer
            // 
            pnlAvatarContainer.Controls.Add(picAvatar);
            pnlAvatarContainer.Controls.Add(pnlAvatarButtons);
            pnlAvatarContainer.Dock = DockStyle.Fill;
            pnlAvatarContainer.Location = new Point(103, 193);
            pnlAvatarContainer.Name = "pnlAvatarContainer";
            pnlAvatarContainer.Size = new Size(256, 297);
            pnlAvatarContainer.TabIndex = 11;

            // 
            // picAvatar
            // 
            picAvatar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            picAvatar.BackColor = Color.WhiteSmoke;
            picAvatar.BorderStyle = BorderStyle.FixedSingle;
            picAvatar.Location = new Point(3, 3);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(236, 245);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabIndex = 0;
            picAvatar.TabStop = false;

            // 
            // pnlAvatarButtons
            // 
            pnlAvatarButtons.Controls.Add(btnChooseImage);
            pnlAvatarButtons.Controls.Add(btnClearImage);
            pnlAvatarButtons.Dock = DockStyle.Bottom;
            pnlAvatarButtons.Location = new Point(0, 254);
            pnlAvatarButtons.Name = "pnlAvatarButtons";
            pnlAvatarButtons.Size = new Size(256, 43);
            pnlAvatarButtons.TabIndex = 1;

            // 
            // btnChooseImage
            // 
            btnChooseImage.Location = new Point(3, 3);
            btnChooseImage.Name = "btnChooseImage";
            btnChooseImage.Size = new Size(110, 32);
            btnChooseImage.TabIndex = 0;
            btnChooseImage.Text = "Chọn Ảnh...";
            btnChooseImage.UseVisualStyleBackColor = true;
            btnChooseImage.Click += btnChooseImage_Click;

            // 
            // btnClearImage
            // 
            btnClearImage.Location = new Point(119, 3);
            btnClearImage.Name = "btnClearImage";
            btnClearImage.Size = new Size(90, 32);
            btnClearImage.TabIndex = 1;
            btnClearImage.Text = "Xóa Ảnh";
            btnClearImage.UseVisualStyleBackColor = true;
            btnClearImage.Click += btnClearImage_Click;

            // 
            // pnlActionButtons
            // 
            tlpInputFields.SetColumnSpan(pnlActionButtons, 2);
            pnlActionButtons.ColumnCount = 2;
            pnlActionButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            pnlActionButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            pnlActionButtons.Controls.Add(btnAddNew, 0, 0);
            pnlActionButtons.Controls.Add(btnUpdate, 1, 0);
            pnlActionButtons.Controls.Add(btnDelete, 0, 1);
            pnlActionButtons.Controls.Add(btnClear, 1, 1);
            pnlActionButtons.Dock = DockStyle.Fill;
            pnlActionButtons.Location = new Point(3, 496);
            pnlActionButtons.Name = "pnlActionButtons";
            pnlActionButtons.RowCount = 2;
            pnlActionButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            pnlActionButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            pnlActionButtons.Size = new Size(356, 79);
            pnlActionButtons.TabIndex = 12;

            // 
            // btnAddNew
            // 
            btnAddNew.Dock = DockStyle.Fill;
            btnAddNew.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddNew.Location = new Point(3, 3);
            btnAddNew.Name = "btnAddNew";
            btnAddNew.Size = new Size(172, 33);
            btnAddNew.TabIndex = 0;
            btnAddNew.Text = "Thêm mới";
            btnAddNew.UseVisualStyleBackColor = true;
            btnAddNew.Click += btnAddNew_Click;

            // 
            // btnUpdate
            // 
            btnUpdate.Dock = DockStyle.Fill;
            btnUpdate.Location = new Point(181, 3);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(172, 33);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;

            // 
            // btnDelete
            // 
            btnDelete.Dock = DockStyle.Fill;
            btnDelete.Location = new Point(3, 42);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(172, 34);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;

            // 
            // btnClear
            // 
            btnClear.Dock = DockStyle.Fill;
            btnClear.Location = new Point(181, 42);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(172, 34);
            btnClear.TabIndex = 3;
            btnClear.Text = "Làm mới";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;

            // 
            // grpProductList
            // 
            grpProductList.Controls.Add(pnlGridContainer);
            grpProductList.Controls.Add(pnlSearch);
            grpProductList.Dock = DockStyle.Fill;
            grpProductList.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            grpProductList.Location = new Point(410, 8);
            grpProductList.Margin = new Padding(8);
            grpProductList.Name = "grpProductList";
            grpProductList.Padding = new Padding(10);
            grpProductList.Size = new Size(732, 624);
            grpProductList.TabIndex = 1;
            grpProductList.TabStop = false;
            grpProductList.Text = "Danh Sách Sản Phẩm";

            // 
            // pnlGridContainer
            // 
            pnlGridContainer.Controls.Add(dgvProducts);
            pnlGridContainer.Dock = DockStyle.Fill;
            pnlGridContainer.Font = new Font("Segoe UI", 9F);
            pnlGridContainer.Location = new Point(10, 82);
            pnlGridContainer.Name = "pnlGridContainer";
            pnlGridContainer.Size = new Size(712, 532);
            pnlGridContainer.TabIndex = 1;

            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AllowUserToResizeRows = false;
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.BackgroundColor = SystemColors.Window;
            dgvProducts.BorderStyle = BorderStyle.Fixed3D;
            dgvCellStyleHeader.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyleHeader.BackColor = SystemColors.Control;
            dgvCellStyleHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvCellStyleHeader.ForeColor = SystemColors.WindowText;
            dgvCellStyleHeader.SelectionBackColor = SystemColors.Highlight;
            dgvCellStyleHeader.SelectionForeColor = SystemColors.HighlightText;
            dgvCellStyleHeader.WrapMode = DataGridViewTriState.True;
            dgvProducts.ColumnHeadersDefaultCellStyle = dgvCellStyleHeader;
            dgvProducts.ColumnHeadersHeight = 32;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvProducts.Columns.AddRange(new DataGridViewColumn[] { colProductId, colProductName, colCategory, colUnitPrice, colQuantity });
            dgvProducts.Dock = DockStyle.Fill;
            dgvProducts.EnableHeadersVisualStyles = true;
            dgvProducts.Location = new Point(0, 0);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.RowTemplate.Height = 29;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(712, 532);
            dgvProducts.TabIndex = 0;
            dgvProducts.CellFormatting += dgvProducts_CellFormatting;
            dgvProducts.SelectionChanged += dgvProducts_SelectionChanged;

            // 
            // colProductId
            // 
            colProductId.DataPropertyName = "ProductId";
            colProductId.HeaderText = "Mã SP";
            colProductId.MinimumWidth = 70;
            colProductId.Name = "colProductId";
            colProductId.ReadOnly = true;
            colProductId.Width = 90;

            // 
            // colProductName
            // 
            colProductName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colProductName.DataPropertyName = "ProductName";
            colProductName.HeaderText = "Tên SP";
            colProductName.MinimumWidth = 150;
            colProductName.Name = "colProductName";
            colProductName.ReadOnly = true;

            // 
            // colCategory
            // 
            colCategory.DataPropertyName = "CategoryName";
            colCategory.HeaderText = "Danh Mục";
            colCategory.MinimumWidth = 100;
            colCategory.Name = "colCategory";
            colCategory.ReadOnly = true;
            colCategory.Width = 120;

            // 
            // colUnitPrice
            // 
            colUnitPrice.DataPropertyName = "UnitPrice";
            dgvCellStylePrice.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCellStylePrice.Format = "N0";
            colUnitPrice.DefaultCellStyle = dgvCellStylePrice;
            colUnitPrice.HeaderText = "Đơn Giá";
            colUnitPrice.MinimumWidth = 110;
            colUnitPrice.Name = "colUnitPrice";
            colUnitPrice.ReadOnly = true;
            colUnitPrice.Width = 140;

            // 
            // colQuantity
            // 
            colQuantity.DataPropertyName = "Quantity";
            dgvCellStyleQuantity.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCellStyleQuantity.Format = "N0";
            colQuantity.DefaultCellStyle = dgvCellStyleQuantity;
            colQuantity.HeaderText = "Số Lượng";
            colQuantity.MinimumWidth = 70;
            colQuantity.Name = "colQuantity";
            colQuantity.ReadOnly = true;
            colQuantity.Width = 90;

            // 
            // pnlSearch
            // 
            pnlSearch.Controls.Add(btnExportCsv);
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Controls.Add(lblSearch);
            pnlSearch.Dock = DockStyle.Top;
            pnlSearch.Font = new Font("Segoe UI", 9F);
            pnlSearch.Location = new Point(10, 32);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(712, 50);
            pnlSearch.TabIndex = 0;

            // 
            // btnExportCsv
            // 
            btnExportCsv.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportCsv.Location = new Point(599, 8);
            btnExportCsv.Name = "btnExportCsv";
            btnExportCsv.Size = new Size(110, 32);
            btnExportCsv.TabIndex = 2;
            btnExportCsv.Text = "Xuất CSV";
            btnExportCsv.UseVisualStyleBackColor = true;
            btnExportCsv.Click += btnExportCsv_Click;

            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Location = new Point(135, 11);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập tên sản phẩm để tìm kiếm...";
            txtSearch.Size = new Size(448, 27);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;

            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblSearch.Location = new Point(3, 14);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(126, 20);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Tìm kiếm tên SP:";

            // 
            // errorProvider
            // 
            errorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
            errorProvider.ContainerControl = this;

            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1150, 694);
            Controls.Add(tlpMain);
            Controls.Add(statusStripMain);
            Controls.Add(menuStripMain);
            MainMenuStrip = menuStripMain;
            MinimumSize = new Size(950, 620);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TechMart Product Manager - Quản lý Danh mục Thiết bị Công nghệ";
            Load += Form1_Load;
            menuStripMain.ResumeLayout(false);
            menuStripMain.PerformLayout();
            statusStripMain.ResumeLayout(false);
            statusStripMain.PerformLayout();
            tlpMain.ResumeLayout(false);
            grpProductInfo.ResumeLayout(false);
            tlpInputFields.ResumeLayout(false);
            tlpInputFields.PerformLayout();
            pnlAvatarContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            pnlAvatarButtons.ResumeLayout(false);
            pnlActionButtons.ResumeLayout(false);
            grpProductList.ResumeLayout(false);
            pnlGridContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStripMain;
        private ToolStripMenuItem menuFile;
        private ToolStripMenuItem menuExportCsv;
        private ToolStripSeparator toolStripMenuItemSeparator1;
        private ToolStripMenuItem menuExit;
        private StatusStrip statusStripMain;
        private ToolStripStatusLabel lblStatusCount;
        private ToolStripStatusLabel lblStatusSpring;
        private ToolStripStatusLabel lblStatusAction;
        private TableLayoutPanel tlpMain;
        private GroupBox grpProductInfo;
        private GroupBox grpProductList;
        private TableLayoutPanel tlpInputFields;
        private Label lblProductId;
        private TextBox txtProductId;
        private Label lblProductName;
        private TextBox txtProductName;
        private Label lblCategory;
        private ComboBox cboCategory;
        private Label lblUnitPrice;
        private TextBox txtUnitPrice;
        private Label lblQuantity;
        private TextBox txtQuantity;
        private Label lblAvatar;
        private Panel pnlAvatarContainer;
        private PictureBox picAvatar;
        private FlowLayoutPanel pnlAvatarButtons;
        private Button btnChooseImage;
        private Button btnClearImage;
        private TableLayoutPanel pnlActionButtons;
        private Button btnAddNew;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Panel pnlSearch;
        private Button btnExportCsv;
        private TextBox txtSearch;
        private Label lblSearch;
        private Panel pnlGridContainer;
        private DataGridView dgvProducts;
        private DataGridViewTextBoxColumn colProductId;
        private DataGridViewTextBoxColumn colProductName;
        private DataGridViewTextBoxColumn colCategory;
        private DataGridViewTextBoxColumn colUnitPrice;
        private DataGridViewTextBoxColumn colQuantity;
        private ErrorProvider errorProvider;
    }
}
