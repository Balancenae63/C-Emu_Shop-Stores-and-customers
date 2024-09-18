using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Diagnostics;
using System.Net.Http;

namespace SystemShop
{
    public partial class CustomerShop : Form
    {
        SqlConnection myCon = new SqlConnection();
        DataView mydataView_S = new DataView();
        DataView mydataView_B = new DataView();

        private int proQuantity;
        private int selectedProductId_Sh;
        private bool boxBool = true;

        public CustomerShop()
        {
            InitializeComponent();
            mainLoop();
        }

        private void CustomerShop_Load(object sender, EventArgs e)
        {
            myCon.ConnectionString = "Data Source=localhost; Integrated Security=True; Initial Catalog=DataStore; Trusted_Connection=True; TrustServerCertificate=True";
            myCon.Open();

            DataShow_S();
            if (dgvShop.RowCount > 0)
            {
                dgvShop.Columns[0].HeaderText = "รหัสสินค้า";
                dgvShop.Columns[1].HeaderText = "ชื่อสินค้า";
                dgvShop.Columns[2].HeaderText = "ราคาสินค้า";
                dgvShop.Columns[3].HeaderText = "จำนวนคงเหลือ";

                dgvShop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            dgvBasket.Columns.Add("ProductID", "รหัสสินค้า");
            dgvBasket.Columns.Add("ProductName", "ชื่อสินค้า");
            dgvBasket.Columns.Add("Price", "ราคา");
            dgvBasket.Columns.Add("Quantity", "จำนวน");
            dgvBasket.Columns.Add("TotalPrice", "ราคารวม");
            dgvBasket.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private async Task mainLoop()
        {
            Task LoopDBS0 = LoopDBB(); await LoopDBS0;
            await Task.Delay(100);
            Console.WriteLine("Run");
        }

        private async Task LoopDBB()
        {
            while (boxBool)
            {
                await Task.Delay(100);
                SqlDataReader myDataReader;
                DataTable myDataTable = new DataTable();
                SqlCommand myCommand = new SqlCommand();

                myCommand.CommandText = "SELECT productID, productName, price, quantity FROM productStore";
                myCommand.CommandType = CommandType.Text;
                myCommand.Connection = myCon;

                myDataReader = myCommand.ExecuteReader();

                myDataTable.Load(myDataReader);
                myDataReader.Close();
                int count = myDataTable.Rows.Count + 1;
                int listcount = dgvShop.RowCount;
                if (count != listcount)
                {
                    DataShow_S();
                }
                label8.Text = count.ToString();
                dgvShop.Refresh();
            }
        }

        private int GetProductstock(int productId, SqlTransaction transaction = null)
        {
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandText = "SELECT QUANTITY FROM productStore WHERE productID = @productID"; //***
            myCommand.CommandType = CommandType.Text;
            myCommand.Connection = myCon;
            myCommand.Parameters.AddWithValue("@productID", productId);
            if (transaction != null)
            {
                myCommand.Transaction = transaction;
            }
            try
            {
                object result = myCommand.ExecuteScalar(); // จะดึงค่าที่เรากำหนดให้เท่านั่น เช่น ให้อ่าน Product  = 1  เท่านั่น Product  = 2 จะไม่อ่าน
                if (result != null && int.TryParse(result.ToString(), out int stock))
                {
                    return stock;
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาด : {ex.Message}", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void dgvShop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvShop.Rows[e.RowIndex];
                selectedProductId_Sh = Convert.IsDBNull(row.Cells["productID"].Value) ? 0 : Convert.ToInt32(row.Cells["productID"].Value);
                tbNameCS.Text = row.Cells["productName"].Value.ToString();
                tbPriceCS.Text = row.Cells["price"].Value.ToString();
            }
        }

        private void DataShow_S()
        {
            SqlDataReader myDataReader;
            DataTable myDataTable = new DataTable();
            SqlCommand myCommand = new SqlCommand();

            myCommand.CommandText = "SELECT productID, productName, price, quantity FROM productStore";
            myCommand.CommandType = CommandType.Text;
            myCommand.Connection = myCon;
            myDataReader = myCommand.ExecuteReader();
            dgvShop.Refresh();
            if (myDataReader.HasRows)
            {
                myDataTable.Load(myDataReader);
                mydataView_S = new DataView(myDataTable);
                dgvShop.DataSource = mydataView_S;
            }
            else
            {
                dgvShop.DataSource = null;
            }
            myDataReader.Close();
        }

        private void DataShow_B()
        {
            SqlDataReader myDataReader;
            DataTable myDataTable = new DataTable();
            SqlCommand myCommand = new SqlCommand();

            myCommand.CommandText = "SELECT productID, productName, price, quantity FROM productStore";
            myCommand.CommandType = CommandType.Text;
            myCommand.Connection = myCon;
            myDataReader = myCommand.ExecuteReader();
            dgvBasket.Refresh();
            if (myDataReader.HasRows)
            {
                myDataTable.Load(myDataReader);
                mydataView_B = new DataView(myDataTable);
                dgvBasket.DataSource = mydataView_B;
            }
            else
            {
                dgvBasket.DataSource = null;
            }
            myDataReader.Close();

            if (dgvBasket.RowCount > 0)
            {
                dgvBasket.Columns[0].HeaderText = "รหัสสินค้า";
                dgvBasket.Columns[1].HeaderText = "ชื่อสินค้า";
                dgvBasket.Columns[2].HeaderText = "ราคาสินค้า";
                dgvBasket.Columns[3].HeaderText = "จำนวนคงเหลือ";

                dgvBasket.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void btnAdninAddStore_Click_1(object sender, EventArgs e)
        {
            adminShop formadmin = new adminShop();
            formadmin.Show();
        }

        private void btnShowSummary_Click(object sender, EventArgs e)
        {
            FormSummay newFormSummary = new FormSummay();
            newFormSummary.ShowDialog();
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            if (selectedProductId_Sh == 0)
            {
                MessageBox.Show("กรุณาเลือกสินค้าที่ต้องการ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(tbQuantityCS.Text, out proQuantity) || proQuantity <= 0)
            {
                MessageBox.Show("กรุณากรอกจำนวนสินค้า และเป็นตัวเลขจะต้องมากกว่า 0 เท่านั่น", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbQuantityCS.Focus();
                return;
            }
            if (!double.TryParse(tbPriceCS.Text, out double price))
            {
                MessageBox.Show("ราคาสินค้าไม่ถูกต้อง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int stock = GetProductstock(selectedProductId_Sh);
            if (proQuantity > stock)
            {
                MessageBox.Show($"จำนวนที่สั่งซื้อมากกว่าจำนวนที่อยู่ในส็อก (เหลือ : {stock})", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning); //***
                return;
            }

            double totalPrice = proQuantity * price;
            dgvBasket.Rows.Add(selectedProductId_Sh, tbNameCS.Text, price.ToString("F2"), proQuantity, totalPrice.ToString("F2"));
            CalculeteTotalCost();

            tbNameCS.Clear();
            tbPriceCS.Clear();
            tbQuantityCS.Clear();
            selectedProductId_Sh = 0;
        
        }

        private void RestoreProductStock(int productId, int quantity, SqlTransaction transaction)
        {
            using (SqlCommand myCommand = new SqlCommand())
            {
                myCommand.Connection = myCon;
                myCommand.Transaction = transaction;
                myCommand.CommandText = "UPDATE productStore SET quantity = quantity + @quantity WHERE productID = @productID";
                myCommand.Parameters.AddWithValue("@productID", productId); //เพิ่มมา
                myCommand.Parameters.AddWithValue("@quantity", quantity);

                int rowAffected = myCommand.ExecuteNonQuery();

                if (rowAffected == 0)
                {
                    throw new Exception($"ไม่สามารถคืนรหัสสินค้า {productId} กลับไปยังสต็อกได้");
                }
                SeveTransaction(transaction, "StockReturn", productId, quantity); //บันทึก Transaction ธุรกรรมการคืนสินค้า
            }
        }

        private void SeveTransaction(SqlTransaction transaction, string customerType, int productId, int quantity)
        {
            SqlCommand checkCommand = new SqlCommand();
            checkCommand.CommandText = "SELECT COUNT(*) FROM productStore WHERE productID = @productID";
            checkCommand.CommandType = CommandType.Text;
            checkCommand.Connection = myCon;
            checkCommand.Transaction = transaction;
            checkCommand.Parameters.AddWithValue("@productID", productId);

            int productCount = (int)checkCommand.ExecuteScalar();

            if (productCount == 0)
            {
                throw new Exception($"ไม่พบสินค้ารหัส {productId} ในฐานข้อมูล");
            }
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandText = "INSERT INTO customerData (customerType, productID, customerAuantity, customerDate) VALUES (@customerType, @productID, @customerAuantity, GETDATE())";
            myCommand.CommandType = CommandType.Text;
            myCommand.Connection = myCon;
            myCommand.Transaction = transaction;
            myCommand.Parameters.AddWithValue("@customerType", customerType); //@Transaction
            myCommand.Parameters.AddWithValue("@productID", productId);
            myCommand.Parameters.AddWithValue("@customerAuantity", quantity);

            myCommand.ExecuteNonQuery();
        }

        private void btnDeletestore_Click(object sender, EventArgs e)
        {
            if (dgvBasket.SelectedRows.Count > 0)
            {
                SqlTransaction transaction = myCon.BeginTransaction();
                try
                {
                    foreach (DataGridViewRow row in dgvBasket.SelectedRows)
                    {
                        int productId = Convert.ToInt32(row.Cells["productID"].Value);
                        int quantity = Convert.ToInt32(row.Cells["quantity"].Value);
                        RestoreProductStock(productId, quantity, transaction); //คืนค่ากลับไปยังสต็อก
                        dgvBasket.Rows.Remove(row);
                    }
                    CalculeteTotalCost();
                    MessageBox.Show("ลบสินค้าที่เลือกออกจากตะกร้าและคืนสต็อกแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"เกิดข้อผิดพลาด {ex.Message}", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("กรุณาเลือกสินค้าที่ต้องการลบ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CalculeteTotalCost()
        {
            double totalCost = 0;
            foreach (DataGridViewRow row in dgvBasket.Rows)  //ถ้า for จะหาไม่เจอเนื่องจากอยู่ใน Datatable
            {
                if (row.Cells[4].Value != null && double.TryParse(row.Cells[4].Value.ToString(), out double rowTotal))
                {
                    totalCost += rowTotal;
                }
            }
            tbSumCS.Text = totalCost.ToString("C2");
        }

        private int GetProductstock(SqlTransaction transaction, int productId)
        {
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandText = "SELECT QUANTITY FROM productStore WHERE productID = @productID"; //***
            myCommand.CommandType = CommandType.Text;
            myCommand.Connection = myCon;
            myCommand.Transaction = transaction;
            myCommand.Parameters.AddWithValue("@productID", productId);

            try
            {

                object result = myCommand.ExecuteScalar(); // จะดึงค่าที่เรากำหนดให้เท่านั่น เช่น ให้อ่าน Product  = 1  เท่านั่น Product  = 2 จะไม่อ่าน
                if (result != null && int.TryParse(result.ToString(), out int stock))
                {
                    return stock;
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาด : {ex.Message}", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            if (dgvBasket.Rows.Count <= 1 )
            {
                MessageBox.Show("กรุณาเพิ่มสินค้าในตะกร้าก่อนสั่งซื้อ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                using (SqlTransaction transaction = myCon.BeginTransaction())
                {
                    try
                    {
                        foreach (DataGridViewRow row in dgvBasket.Rows)
                        {
                            if (row.IsNewRow) continue; //ข้ามแถวที่ยังไม่มีข้อมูล

                            if (row.Cells["productID"].Value == null || !int.TryParse(row.Cells["productID"].Value.ToString(), out int productId) || productId == 0)
                            {
                                throw new Exception($"พบ productID ไม่ถูกต้องในตะกร้าสินค้า : {row.Cells["productID"].Value}");
                            }

                            int quantity = Convert.ToInt32(row.Cells["quantity"].Value);

                            int stock = GetProductstock(transaction, productId);
                            if (quantity > stock)
                            {
                                throw new Exception($"สินค้าในสต็อกไม่เพียงพอสำหรับสินค้า");
                            }

                            SqlCommand myCommand = new SqlCommand();
                            myCommand.CommandText = "UPDATE productStore SET quantity = quantity - @quantity WHERE productID = @productID";
                            myCommand.CommandType = CommandType.Text;
                            myCommand.Transaction = transaction;
                            myCommand.Connection = myCon;
                            myCommand.Parameters.AddWithValue("@productID", productId);
                            myCommand.Parameters.AddWithValue("@quantity", quantity);
                            int rowAffected = myCommand.ExecuteNonQuery();

                            if (rowAffected == 0)
                            {
                                throw new Exception($"ไม่พบรหัสสินค้า {productId} ในฐานข้อมูล");
                            }

                            SeveTransaction(transaction, "Purchase", productId, quantity);

                        }
                        transaction.Commit();
                        MessageBox.Show("การซื้อสินค้าสำเร็จ", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvBasket.Rows.Clear();
                        tbSumCS.Text = "0.00";
                        DataShow_S();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"เกิดข้อผิดพลาด {ex.Message}", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}

