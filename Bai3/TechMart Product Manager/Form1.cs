using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Text;
using TechMart_Product_Manager.Models;

namespace TechMart_Product_Manager
{
    public partial class Form1 : Form
    {
        private readonly List<Category> _categories = new();
        private readonly BindingList<Product> _allProducts = new();
        private readonly BindingList<Product> _displayProducts = new();
        private readonly BindingSource _bindingSource = new();

        private string? _currentSelectedImagePath = null;
        private bool _isBindingOrClearing = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeCategories();
            InitializeDataBinding();
            LoadSampleProducts();
            UpdateStatus();
        }

        /// <summary>
        /// Khởi tạo danh mục sản phẩm theo yêu cầu: Điện thoại, Laptop, Phụ kiện
        /// Gán DisplayMember và ValueMember theo đặc tả
        /// </summary>
        private void InitializeCategories()
        {
            _categories.Clear();
            _categories.Add(new Category("CAT01", "Điện thoại"));
            _categories.Add(new Category("CAT02", "Laptop"));
            _categories.Add(new Category("CAT03", "Phụ kiện"));

            cboCategory.DisplayMember = "CategoryName";
            cboCategory.ValueMember = "CategoryId";
            cboCategory.DataSource = _categories;
        }

        /// <summary>
        /// Cấu hình Data Binding sử dụng BindingSource và BindingList<T> làm trung gian
        /// </summary>
        private void InitializeDataBinding()
        {
            dgvProducts.AutoGenerateColumns = false;
            _bindingSource.DataSource = _displayProducts;
            dgvProducts.DataSource = _bindingSource;
        }

        /// <summary>
        /// Nạp các sản phẩm mẫu ban đầu phủ khắp các danh mục
        /// </summary>
        private void LoadSampleProducts()
        {
            _allProducts.Clear();
            _allProducts.Add(new Product("SP01", "iPhone 16 Pro Max 256GB", "CAT01", "Điện thoại", 34990000m, 15));
            _allProducts.Add(new Product("SP02", "Laptop Dell XPS 15 9530", "CAT02", "Laptop", 45500000m, 8));
            _allProducts.Add(new Product("SP03", "Chuột Logitech MX Master 3S", "CAT03", "Phụ kiện", 2490000m, 30));
            _allProducts.Add(new Product("SP04", "Samsung Galaxy S24 Ultra", "CAT01", "Điện thoại", 31990000m, 12));
            _allProducts.Add(new Product("SP05", "Tai nghe Sony WH-1000XM5", "CAT03", "Phụ kiện", 8490000m, 20));

            ApplyFilter();

            if (dgvProducts.Rows.Count > 0)
            {
                dgvProducts.Rows[0].Selected = true;
                LoadProductToInputs(dgvProducts.Rows[0].DataBoundItem as Product);
            }
        }

        /// <summary>
        /// Lọc danh sách sản phẩm theo từ khóa tìm kiếm (Live search)
        /// </summary>
        private void ApplyFilter()
        {
            string keyword = txtSearch.Text.Trim();
            _isBindingOrClearing = true;

            _displayProducts.RaiseListChangedEvents = false;
            _displayProducts.Clear();

            var filtered = string.IsNullOrWhiteSpace(keyword)
                ? _allProducts
                : _allProducts.Where(p => p.ProductName.Contains(keyword, StringComparison.OrdinalIgnoreCase));

            foreach (var item in filtered)
            {
                _displayProducts.Add(item);
            }

            _displayProducts.RaiseListChangedEvents = true;
            _displayProducts.ResetBindings();

            _isBindingOrClearing = false;
            UpdateStatus();

            if (dgvProducts.Rows.Count > 0 && dgvProducts.CurrentRow != null)
            {
                LoadProductToInputs(dgvProducts.CurrentRow.DataBoundItem as Product);
            }
            else if (dgvProducts.Rows.Count > 0)
            {
                dgvProducts.Rows[0].Selected = true;
                LoadProductToInputs(dgvProducts.Rows[0].DataBoundItem as Product);
            }
            else
            {
                ClearInputFields(keepSearch: true);
            }
        }

        /// <summary>
        /// Cập nhật hiển thị StatusStrip: "Tổng số sản phẩm: X"
        /// </summary>
        private void UpdateStatus()
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                lblStatusCount.Text = $"Tổng số sản phẩm: {_allProducts.Count}";
            }
            else
            {
                lblStatusCount.Text = $"Tổng số sản phẩm: {_displayProducts.Count} / {_allProducts.Count}";
            }
        }

        /// <summary>
        /// Nạp thông tin sản phẩm lên các ô nhập liệu bên trái (Click chọn 1 dòng trên DataGridView)
        /// </summary>
        private void LoadProductToInputs(Product? product)
        {
            if (product == null) return;

            _isBindingOrClearing = true;
            try
            {
                txtProductId.Text = product.ProductId;
                txtProductName.Text = product.ProductName;
                cboCategory.SelectedValue = product.CategoryId;
                txtUnitPrice.Text = product.UnitPrice.ToString("0.##", CultureInfo.InvariantCulture);
                txtQuantity.Text = product.Quantity.ToString();

                _currentSelectedImagePath = product.ImagePath;
                LoadImageToAvatar(_currentSelectedImagePath);

                errorProvider.Clear();
            }
            finally
            {
                _isBindingOrClearing = false;
            }
        }

        /// <summary>
        /// Nạp ảnh an toàn vào PictureBox với chế độ Zoom (không khóa file)
        /// </summary>
        private void LoadImageToAvatar(string? imagePath)
        {
            picAvatar.Image?.Dispose();
            picAvatar.Image = null;

            if (!string.IsNullOrWhiteSpace(imagePath) && File.Exists(imagePath))
            {
                try
                {
                    using var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    picAvatar.Image = Image.FromStream(stream);
                }
                catch
                {
                    picAvatar.Image = null;
                }
            }
        }

        /// <summary>
        /// Xóa trắng các ô nhập liệu
        /// </summary>
        private void ClearInputFields(bool keepSearch = false)
        {
            _isBindingOrClearing = true;
            try
            {
                txtProductId.Clear();
                txtProductName.Clear();
                if (cboCategory.Items.Count > 0)
                {
                    cboCategory.SelectedIndex = 0;
                }
                txtUnitPrice.Clear();
                txtQuantity.Clear();

                picAvatar.Image?.Dispose();
                picAvatar.Image = null;
                _currentSelectedImagePath = null;

                errorProvider.Clear();

                if (!keepSearch)
                {
                    txtSearch.Clear();
                }
            }
            finally
            {
                _isBindingOrClearing = false;
            }
        }

        /// <summary>
        /// Tự sinh mã sản phẩm tiếp theo (SP01, SP02... -> SP06)
        /// </summary>
        private string GenerateNextProductId()
        {
            int maxNumber = 0;
            foreach (var p in _allProducts)
            {
                if (p.ProductId.StartsWith("SP", StringComparison.OrdinalIgnoreCase))
                {
                    if (int.TryParse(p.ProductId.AsSpan(2), out int num))
                    {
                        if (num > maxNumber) maxNumber = num;
                    }
                }
            }
            return $"SP{(maxNumber + 1):D2}";
        }

        /// <summary>
        /// Kiểm tra tính hợp lệ của dữ liệu nhập (Validation với ErrorProvider)
        /// Không để trống Tên SP, Đơn giá > 0, Số lượng ≥ 0
        /// </summary>
        private bool ValidateInput(bool isAddingNew)
        {
            errorProvider.Clear();
            bool isValid = true;

            // Kiểm tra Mã SP
            string productId = txtProductId.Text.Trim();
            if (string.IsNullOrWhiteSpace(productId))
            {
                errorProvider.SetError(txtProductId, "Mã sản phẩm không được để trống!");
                isValid = false;
            }
            else if (isAddingNew && _allProducts.Any(p => string.Equals(p.ProductId.Trim(), productId, StringComparison.OrdinalIgnoreCase)))
            {
                errorProvider.SetError(txtProductId, "Mã sản phẩm đã tồn tại trong danh sách!");
                isValid = false;
            }

            // Kiểm tra Tên SP: Không để trống
            string productName = txtProductName.Text.Trim();
            if (string.IsNullOrWhiteSpace(productName))
            {
                errorProvider.SetError(txtProductName, "Tên sản phẩm không được để trống!");
                isValid = false;
            }

            // Kiểm tra Đơn giá: Đơn giá > 0
            string unitPriceText = txtUnitPrice.Text.Trim();
            if (string.IsNullOrWhiteSpace(unitPriceText) || !TryParsePrice(unitPriceText, out decimal unitPrice) || unitPrice <= 0)
            {
                errorProvider.SetError(txtUnitPrice, "Đơn giá phải là số lớn hơn 0!");
                isValid = false;
            }

            // Kiểm tra Số lượng: Số lượng ≥ 0
            string quantityText = txtQuantity.Text.Trim();
            if (string.IsNullOrWhiteSpace(quantityText) || !int.TryParse(quantityText, out int quantity) || quantity < 0)
            {
                errorProvider.SetError(txtQuantity, "Số lượng phải là số nguyên không âm (≥ 0)!");
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// Hỗ trợ parse đơn giá linh hoạt nhiều định dạng (số nguyên, số thập phân, có dấu phẩy/chấm)
        /// </summary>
        private static bool TryParsePrice(string input, out decimal price)
        {
            price = 0m;
            if (string.IsNullOrWhiteSpace(input)) return false;

            string clean = input.Trim()
                               .Replace(" VNĐ", "", StringComparison.OrdinalIgnoreCase)
                               .Replace("VNĐ", "", StringComparison.OrdinalIgnoreCase)
                               .Replace("đ", "", StringComparison.OrdinalIgnoreCase)
                               .Trim();

            // Trường hợp số âm
            if (clean.StartsWith('-'))
            {
                if (decimal.TryParse(clean, NumberStyles.Any, CultureInfo.InvariantCulture, out price)) return true;
                if (decimal.TryParse(clean, NumberStyles.Any, CultureInfo.CurrentCulture, out price)) return true;
            }

            if (decimal.TryParse(clean, NumberStyles.Any, CultureInfo.InvariantCulture, out price)) return true;
            if (decimal.TryParse(clean, NumberStyles.Any, CultureInfo.CurrentCulture, out price)) return true;

            string withoutCommas = clean.Replace(",", "");
            if (decimal.TryParse(withoutCommas, NumberStyles.Any, CultureInfo.InvariantCulture, out price)) return true;

            string withoutDots = clean.Replace(".", "");
            if (decimal.TryParse(withoutDots, NumberStyles.Any, CultureInfo.InvariantCulture, out price)) return true;

            return false;
        }

        #region Event Handlers

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (_isBindingOrClearing) return;

            if (dgvProducts.CurrentRow != null && dgvProducts.CurrentRow.DataBoundItem is Product selectedProduct)
            {
                LoadProductToInputs(selectedProduct);
            }
        }

        private void dgvProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvProducts.Columns[e.ColumnIndex].Name == "colUnitPrice" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal price))
                {
                    // Định dạng theo đúng TC03: 25,000,000 VNĐ
                    e.Value = string.Format(CultureInfo.InvariantCulture, "{0:N0} VNĐ", price);
                    e.FormattingApplied = true;
                }
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(isAddingNew: true))
            {
                lblStatusAction.Text = "Thêm mới thất bại: Vui lòng kiểm tra các ô báo lỗi màu đỏ.";
                return;
            }

            TryParsePrice(txtUnitPrice.Text, out decimal unitPrice);
            int quantity = int.Parse(txtQuantity.Text.Trim());

            var newProduct = new Product(
                productId: txtProductId.Text.Trim(),
                productName: txtProductName.Text.Trim(),
                categoryId: cboCategory.SelectedValue?.ToString() ?? "",
                categoryName: cboCategory.Text,
                unitPrice: unitPrice,
                quantity: quantity,
                imagePath: _currentSelectedImagePath
            );

            _allProducts.Add(newProduct);
            ApplyFilter();
            SelectProductInGrid(newProduct.ProductId);

            lblStatusAction.Text = $"Đã thêm thành công sản phẩm: {newProduct.ProductName}";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null || dgvProducts.CurrentRow.DataBoundItem is not Product selectedProduct)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm trên bảng để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidateInput(isAddingNew: false))
            {
                lblStatusAction.Text = "Cập nhật thất bại: Vui lòng kiểm tra các ô báo lỗi màu đỏ.";
                return;
            }

            string newId = txtProductId.Text.Trim();
            // Nếu người dùng đổi Mã SP, kiểm tra không được trùng với sản phẩm khác
            if (!string.Equals(selectedProduct.ProductId, newId, StringComparison.OrdinalIgnoreCase) &&
                _allProducts.Any(p => p != selectedProduct && string.Equals(p.ProductId, newId, StringComparison.OrdinalIgnoreCase)))
            {
                errorProvider.SetError(txtProductId, "Mã sản phẩm đã trùng với sản phẩm khác!");
                return;
            }

            TryParsePrice(txtUnitPrice.Text, out decimal unitPrice);
            int quantity = int.Parse(txtQuantity.Text.Trim());

            selectedProduct.ProductId = newId;
            selectedProduct.ProductName = txtProductName.Text.Trim();
            selectedProduct.CategoryId = cboCategory.SelectedValue?.ToString() ?? "";
            selectedProduct.CategoryName = cboCategory.Text;
            selectedProduct.UnitPrice = unitPrice;
            selectedProduct.Quantity = quantity;
            selectedProduct.ImagePath = _currentSelectedImagePath;

            _bindingSource.ResetBindings(false);
            lblStatusAction.Text = $"Đã cập nhật sản phẩm: {selectedProduct.ProductName}";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null || dgvProducts.CurrentRow.DataBoundItem is not Product selectedProduct)
            {
                MessageBox.Show("Vui lòng chọn một dòng sản phẩm cần xóa trên bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kịch bản TC05: MessageBox popup xác nhận Yes/No với Icon Question
            var dialogResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa sản phẩm \"{selectedProduct.ProductName}\" (Mã: {selectedProduct.ProductId}) không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                string deletedName = selectedProduct.ProductName;
                _allProducts.Remove(selectedProduct);
                ApplyFilter();
                btnClear_Click(this, EventArgs.Empty);
                lblStatusAction.Text = $"Đã xóa sản phẩm: {deletedName}";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputFields(keepSearch: true);
            txtProductId.Text = GenerateNextProductId();
            txtQuantity.Text = "1";
            txtProductName.Focus();
            lblStatusAction.Text = "Đã làm mới: Sẵn sàng nhập sản phẩm mới.";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn ảnh đại diện sản phẩm";
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.bmp;*.gif)|*.png;*.jpg;*.jpeg;*.bmp;*.gif|PNG Image (*.png)|*.png|JPEG Image (*.jpg)|*.jpg;*.jpeg|All Files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _currentSelectedImagePath = openFileDialog.FileName;
                    LoadImageToAvatar(_currentSelectedImagePath);
                    lblStatusAction.Text = $"Đã chọn ảnh: {Path.GetFileName(_currentSelectedImagePath)}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Không thể mở tệp ảnh: {ex.Message}", "Lỗi ảnh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClearImage_Click(object sender, EventArgs e)
        {
            picAvatar.Image?.Dispose();
            picAvatar.Image = null;
            _currentSelectedImagePath = null;
            lblStatusAction.Text = "Đã xóa ảnh đại diện.";
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            ExportToCsv();
        }

        private void menuExportCsv_Click(object sender, EventArgs e)
        {
            ExportToCsv();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        /// <summary>
        /// Xuất danh sách sản phẩm ra tệp CSV với định dạng UTF-8 with BOM
        /// </summary>
        private void ExportToCsv()
        {
            if (_allProducts.Count == 0)
            {
                MessageBox.Show("Danh sách sản phẩm đang trống, không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Xuất danh mục sản phẩm ra file CSV";
            saveFileDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
            saveFileDialog.FileName = $"TechMart_Products_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Ghi file với mã hóa UTF-8 có BOM để Excel hiển thị tiếng Việt chuẩn xác
                    using (var writer = new StreamWriter(saveFileDialog.FileName, false, new UTF8Encoding(true)))
                    {
                        writer.WriteLine("Mã SP,Tên SP,Danh Mục,Đơn Giá,Số Lượng,Đường Dẫn Ảnh");

                        foreach (var product in _allProducts)
                        {
                            string id = EscapeCsv(product.ProductId);
                            string name = EscapeCsv(product.ProductName);
                            string category = EscapeCsv(product.CategoryName);
                            string price = product.UnitPrice.ToString(CultureInfo.InvariantCulture);
                            string quantity = product.Quantity.ToString();
                            string image = EscapeCsv(product.ImagePath ?? string.Empty);

                            writer.WriteLine($"\"{id}\",\"{name}\",\"{category}\",{price},{quantity},\"{image}\"");
                        }
                    }

                    lblStatusAction.Text = $"Xuất CSV thành công: {Path.GetFileName(saveFileDialog.FileName)}";
                    MessageBox.Show("Xuất danh mục sản phẩm ra file CSV thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xuất file CSV: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static string EscapeCsv(string value)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;
            return value.Replace("\"", "\"\"");
        }

        private void SelectProductInGrid(string productId)
        {
            for (int i = 0; i < dgvProducts.Rows.Count; i++)
            {
                if (dgvProducts.Rows[i].DataBoundItem is Product p &&
                    string.Equals(p.ProductId, productId, StringComparison.OrdinalIgnoreCase))
                {
                    dgvProducts.ClearSelection();
                    dgvProducts.Rows[i].Selected = true;
                    dgvProducts.CurrentCell = dgvProducts.Rows[i].Cells[0];
                    break;
                }
            }
        }
    }
}
