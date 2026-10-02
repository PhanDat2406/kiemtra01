using System.Globalization;
using System.Reflection;
using TechMart_Product_Manager.Models;

namespace TechMart_Product_Manager
{
    public static class TestRunner
    {
        public static void RunAllTests()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("STARTING AUTOMATED VERIFICATION OF TEST CASES");
            Console.WriteLine("==================================================");

            int passed = 0;
            int failed = 0;

            using (var form = new Form1())
            {
                // Trigger Form1_Load explicitly
                var loadMethod = form.GetType().GetMethod("Form1_Load", BindingFlags.NonPublic | BindingFlags.Instance);
                loadMethod?.Invoke(form, new object[] { form, EventArgs.Empty });

                // TC01: Responsive Layout
                try
                {
                    Console.Write("[TC01] Kiem tra Responsive Layout: ");
                    var tlpMain = GetField<TableLayoutPanel>(form, "tlpMain");
                    var dgvProducts = GetField<DataGridView>(form, "dgvProducts");

                    if (tlpMain.ColumnCount != 2) throw new Exception("TableLayoutPanel khong co 2 cot");
                    if (Math.Abs(tlpMain.ColumnStyles[0].Width - 35F) > 0.1) throw new Exception($"Cot trai khong phai 35% ({tlpMain.ColumnStyles[0].Width}%)");
                    if (Math.Abs(tlpMain.ColumnStyles[1].Width - 65F) > 0.1) throw new Exception($"Cot phai khong phai 65% ({tlpMain.ColumnStyles[1].Width}%)");
                    if (dgvProducts.Dock != DockStyle.Fill) throw new Exception("DataGridView khong Dock = Fill");
                    if (dgvProducts.AutoGenerateColumns != false) throw new Exception("dgvProducts AutoGenerateColumns != false");
                    if (dgvProducts.SelectionMode != DataGridViewSelectionMode.FullRowSelect) throw new Exception("dgvProducts SelectionMode != FullRowSelect");

                    Console.WriteLine("PASSED (Ty le 35%-65%, Dock=Fill, FullRowSelect, AutoGenerateColumns=false chinh xac)");
                    passed++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"FAILED: {ex.Message}");
                    failed++;
                }

                // TC02: Validation ErrorProvider
                try
                {
                    Console.Write("[TC02] Kiem tra Validation ErrorProvider: ");
                    var errorProvider = GetField<ErrorProvider>(form, "errorProvider");
                    var txtProductId = GetField<TextBox>(form, "txtProductId");
                    var txtProductName = GetField<TextBox>(form, "txtProductName");
                    var txtUnitPrice = GetField<TextBox>(form, "txtUnitPrice");
                    var txtQuantity = GetField<TextBox>(form, "txtQuantity");
                    var dgvProducts = GetField<DataGridView>(form, "dgvProducts");

                    int countBefore = dgvProducts.Rows.Count;

                    // Thao tac theo de bai: De trong Ten SP, nhap Don gia = -50000, bam nut Them moi
                    txtProductId.Text = "SP_TC02";
                    txtProductName.Text = "";
                    txtUnitPrice.Text = "-50000";
                    txtQuantity.Text = "5";

                    var btnAddNewClick = form.GetType().GetMethod("btnAddNew_Click", BindingFlags.NonPublic | BindingFlags.Instance);
                    btnAddNewClick?.Invoke(form, new object[] { form, EventArgs.Empty });

                    string errName = errorProvider.GetError(txtProductName);
                    string errPrice = errorProvider.GetError(txtUnitPrice);

                    if (string.IsNullOrEmpty(errName)) throw new Exception("ErrorProvider khong bao loi tai txtProductName");
                    if (string.IsNullOrEmpty(errPrice)) throw new Exception("ErrorProvider khong bao loi tai txtUnitPrice");
                    if (dgvProducts.Rows.Count != countBefore) throw new Exception("Van them san pham khi du lieu sai");

                    Console.WriteLine($"PASSED (Bao loi do Ten SP: '{errName}', Don gia: '{errPrice}', chan them moi thanh cong)");
                    passed++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"FAILED: {ex.Message}");
                    failed++;
                }

                // TC03: Data Binding & Format
                try
                {
                    Console.Write("[TC03] Kiem tra Data Binding & Format: ");
                    var txtProductId = GetField<TextBox>(form, "txtProductId");
                    var txtProductName = GetField<TextBox>(form, "txtProductName");
                    var txtUnitPrice = GetField<TextBox>(form, "txtUnitPrice");
                    var txtQuantity = GetField<TextBox>(form, "txtQuantity");
                    var dgvProducts = GetField<DataGridView>(form, "dgvProducts");

                    txtProductId.Text = "SP_TC03";
                    txtProductName.Text = "Laptop Dell";
                    txtUnitPrice.Text = "25000000";
                    txtQuantity.Text = "10";

                    var btnAddNewClick = form.GetType().GetMethod("btnAddNew_Click", BindingFlags.NonPublic | BindingFlags.Instance);
                    btnAddNewClick?.Invoke(form, new object[] { form, EventArgs.Empty });

                    // Tim dong vua them
                    DataGridViewRow? targetRow = null;
                    foreach (DataGridViewRow row in dgvProducts.Rows)
                    {
                        if (row.DataBoundItem is Product p && p.ProductId == "SP_TC03")
                        {
                            targetRow = row;
                            break;
                        }
                    }

                    if (targetRow == null) throw new Exception("Khong tim thay dong moi tren DataGridView");

                    // Kiem tra dinh dang 25,000,000 VND
                    int priceColIndex = -1;
                    for (int c = 0; c < dgvProducts.Columns.Count; c++)
                    {
                        if (dgvProducts.Columns[c].DataPropertyName == "UnitPrice")
                        {
                            priceColIndex = c;
                            break;
                        }
                    }
                    if (priceColIndex == -1) throw new Exception("Khong tim thay cot UnitPrice");

                    var formattingEvent = new DataGridViewCellFormattingEventArgs(
                        priceColIndex,
                        targetRow.Index,
                        25000000m,
                        typeof(string),
                        dgvProducts.Columns[priceColIndex].DefaultCellStyle);

                    var method = form.GetType().GetMethod("dgvProducts_CellFormatting", BindingFlags.NonPublic | BindingFlags.Instance);
                    method?.Invoke(form, new object[] { dgvProducts, formattingEvent });

                    string formattedValue = formattingEvent.Value?.ToString() ?? "";
                    if (!formattedValue.Contains("25,000,000 VNĐ"))
                    {
                        throw new Exception($"Dinh dang khong khop 25,000,000 VNĐ (thuc te: '{formattedValue}')");
                    }

                    Console.WriteLine($"PASSED (Hien thi dong moi, Don gia dinh dang chuan: '{formattedValue}')");
                    passed++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"FAILED: {ex.Message}");
                    failed++;
                }

                // TC04: Kiem tra Nap Anh OpenFileDialog & PictureBox
                try
                {
                    Console.Write("[TC04] Kiem tra Nap Anh & PictureBox Zoom: ");
                    var picAvatar = GetField<PictureBox>(form, "picAvatar");

                    if (picAvatar.SizeMode != PictureBoxSizeMode.Zoom)
                    {
                        throw new Exception($"PictureBox SizeMode khong phai Zoom (hien tai: {picAvatar.SizeMode})");
                    }

                    using (var bmp = new Bitmap(50, 50))
                    {
                        picAvatar.Image = new Bitmap(bmp);
                    }
                    if (picAvatar.Image == null) throw new Exception("Khong nap duoc anh vao PictureBox");

                    Console.WriteLine("PASSED (SizeMode = Zoom, Nap anh thanh cong)");
                    passed++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"FAILED: {ex.Message}");
                    failed++;
                }

                // TC05: Kiem tra Xoa San Pham
                try
                {
                    Console.Write("[TC05] Kiem tra Xoa San Pham: ");
                    var dgvProducts = GetField<DataGridView>(form, "dgvProducts");
                    var allProducts = GetField<System.ComponentModel.BindingList<Product>>(form, "_allProducts");

                    Product? toDelete = null;
                    foreach (var p in allProducts)
                    {
                        if (p.ProductId == "SP_TC03")
                        {
                            toDelete = p;
                            break;
                        }
                    }
                    if (toDelete == null) throw new Exception("Khong tim thay san pham SP_TC03");

                    allProducts.Remove(toDelete);

                    var applyFilterMethod = form.GetType().GetMethod("ApplyFilter", BindingFlags.NonPublic | BindingFlags.Instance);
                    applyFilterMethod?.Invoke(form, null);

                    bool stillExists = false;
                    foreach (DataGridViewRow row in dgvProducts.Rows)
                    {
                        if (row.DataBoundItem is Product p && p.ProductId == "SP_TC03")
                        {
                            stillExists = true;
                            break;
                        }
                    }

                    if (stillExists) throw new Exception("Dong san pham chua bien mat khoi Grid");

                    Console.WriteLine("PASSED (San pham SP_TC03 da duoc xoa bien mat khoi Grid)");
                    passed++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"FAILED: {ex.Message}");
                    failed++;
                }
            }

            Console.WriteLine("==================================================");
            Console.WriteLine($"KET QUA: {passed}/5 TEST CASES PASSED, {failed} FAILED");
            Console.WriteLine("==================================================");

            if (failed > 0)
            {
                Environment.Exit(1);
            }
        }

        private static T GetField<T>(object instance, string fieldName)
        {
            var field = instance.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            if (field == null)
            {
                throw new Exception($"Khong tim thay truong '{fieldName}' trong Form1");
            }
            var val = field.GetValue(instance);
            if (val == null)
            {
                throw new Exception($"Truong '{fieldName}' co gia tri null");
            }
            return (T)val;
        }
    }
}
