using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemShop
{
    public partial class adminShop : Form
    {
        SqlConnection myCon = new SqlConnection();
        DataSet mydataset = new DataSet();
        DataView mydataView = new DataView();

        private int selectedProductid;

        public adminShop()
        {
            InitializeComponent();
        }

        private void adminShop_Load(object sender, EventArgs e)
        {
            myCon.ConnectionString = "Data Source=localhost; Integrated Security=True; Initial Catalog=DataStore; Trusted_Connection=True; TrustServerCertificate=True";
            myCon.Open();
        }

        private void DataShow()
        {
            SqlDataReader myDataReader;
            DataTable myDataTable = new DataTable();
            SqlCommand myCommand = new SqlCommand();

            myCommand.CommandText = "SELECT productID, productName, price, quantity FROM productStore";
            myCommand.CommandType = CommandType.Text;
            myCommand.Connection = myCon;
            myDataReader = myCommand.ExecuteReader();
            dgvResult.Refresh();
            if (myDataReader.HasRows)
            {
                myDataTable.Load(myDataReader);
                mydataView = new DataView(myDataTable);
                dgvResult.DataSource = mydataView;
            }
            else
            {
                dgvResult.DataSource = null;
            }
            myDataReader.Close();

            if (dgvResult.RowCount > 0)
            {
                dgvResult.Columns[0].HeaderText = "รหัสสินค้า";
                dgvResult.Columns[1].HeaderText = "ชื่อสินค้า";
                dgvResult.Columns[2].HeaderText = "ราคาสินค้า";
                dgvResult.Columns[3].HeaderText = "จำนวนคงเหลือ";

                dgvResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string boxSrarch = tbSearch.Text;
            if (!string.IsNullOrEmpty(boxSrarch))
            {
                if (int.TryParse(boxSrarch, out int productId))
                {
                    mydataView.RowFilter = $"productID = {productId}";
                }
                else
                {
                    mydataView.RowFilter = $"productName LIKE '%{boxSrarch}%'";
                }
            }
            else
            {
                mydataView.RowFilter = string.Empty;
            }
            dgvResult.DataSource = mydataView;
            if (mydataView.Count == 0)
            {
                MessageBox.Show("ไม่พบข้อมูลที่ค้นหา", "ผลการค้นหา", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbID.Clear();
            tbName.Clear();
            tbPrice.Clear();
            tbQuantity.Clear();
            selectedProductid = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbID.Text))
            {
                MessageBox.Show("กรุณาใส่รหัสสินค้าให้ถูกต้อง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("กรุณาใส่ชื่อบริษัทให้ถูกต้อง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(tbPrice.Text))
            {
                MessageBox.Show("กรุณากรอกราคาให้ถูกต้อง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (!int.TryParse(tbPrice.Text, out int boxPrice))
                {
                    MessageBox.Show("กรุณากรอกจำนวนราคาเป็นตัวเลขเท่านั้น", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (string.IsNullOrEmpty(tbQuantity.Text))
            {
                MessageBox.Show("กรุณากรอกจำนวนให้ถูกต้อง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (!int.TryParse(tbQuantity.Text, out int boxQuantity))
                {
                    MessageBox.Show("กรุณากรอกจำนวนสินค้าเป็นตัวเลขเท่านั้น", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            SqlTransaction myTransaction;
            using (SqlCommand myCommand = new SqlCommand())
            {
                if (MessageBox.Show("ต้องการเพิ่มข้อมูลหรือไม่", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (myTransaction = myCon.BeginTransaction())
                    {
                        try
                        {
                            myCommand.CommandText = "INSERT INTO productStore (productID, productName, price, quantity) VALUES (@productID, @productName, @price, @quantity)";
                            myCommand.CommandType = CommandType.Text;
                            myCommand.Transaction = myTransaction;
                            myCommand.Connection = myCon;
                            myCommand.Parameters.AddWithValue("@productID", tbID.Text);
                            myCommand.Parameters.AddWithValue("@productName", tbName.Text);
                            myCommand.Parameters.AddWithValue("@price", tbPrice.Text);
                            myCommand.Parameters.AddWithValue("@quantity", tbQuantity.Text);

                            myCommand.ExecuteNonQuery();
                            myTransaction.Commit();

                            DataShow();
                            tbID.Text = "";
                            tbName.Text = "";
                            tbPrice.Text = "";
                            tbQuantity.Text = "";

                        }
                        catch (Exception)
                        {
                            myTransaction.Rollback();
                            MessageBox.Show($"ไม่สามารถเพิ่มข้อมูลได้ เนื่องจากมีข้อมูลนี้อยู่แล้ว", "ดำเนินการไม่สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
        }

        private void dgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow data_row = dgvResult.Rows[e.RowIndex];
                selectedProductid = Convert.IsDBNull(data_row.Cells[0].Value) ? 0 : Convert.ToInt32(data_row.Cells[0].Value); ;
                tbID.Text = selectedProductid.ToString();
                tbName.Text = data_row.Cells[1].Value.ToString();
                tbPrice.Text = data_row.Cells[2].Value.ToString();
                tbQuantity.Text = data_row.Cells[3].Value.ToString();
            }
        }

        private void btnRefach_Click(object sender, EventArgs e)
        {
            DataShow();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (selectedProductid == 0)
            {
                MessageBox.Show("กรุณาเลือกสินค้าที่ต้องการแก้ไข", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("คุณต้องการลบข้อมูลหรือไม่", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlTransaction myTransaction;
                using (SqlCommand myCommand = new SqlCommand())
                {
                    using (myTransaction = myCon.BeginTransaction())
                    {
                        myCommand.CommandText = "DELETE FROM productStore WHERE productID = @productID";
                        myCommand.CommandType = CommandType.Text;
                        myCommand.Transaction = myTransaction;
                        myCommand.Connection = myCon;
                        myCommand.Parameters.Add(new SqlParameter("@productID", selectedProductid));

                        myCommand.ExecuteNonQuery();
                        myTransaction.Commit();

                        DataShow();
                        tbID.Text = "";
                        tbName.Text = "";
                        tbPrice.Text = "";
                        tbQuantity.Text = "";
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedProductid == 0)
            {
                MessageBox.Show("กรุณาเลือกสินค้าที่ต้องการแก้ไข", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("คุณต้องการแก้ไขข้อมูลนี้หรือไม่", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlTransaction myTransaction;
                using (SqlCommand myCommand = new SqlCommand())
                {
                    using (myTransaction = myCon.BeginTransaction())
                    {
                        try
                        {
                            myCommand.Connection = myCon;
                            myCommand.Transaction = myTransaction;
                            myCommand.CommandText = "UPDATE productStore SET productName = @productName, price = @price, quantity = @quantity WHERE productID = @productID";
                            myCommand.Parameters.AddWithValue("@productName", tbName.Text);
                            myCommand.Parameters.AddWithValue("@price", tbPrice.Text);
                            myCommand.Parameters.AddWithValue("@quantity", tbQuantity.Text);
                            myCommand.Parameters.AddWithValue("@productID", selectedProductid);

                            myCommand.ExecuteNonQuery();
                            myTransaction.Commit();

                            MessageBox.Show("แก้ไขข้อมูลเรียบร้อย", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DataShow();
                            tbID.Text = "";
                            tbName.Text = "";
                            tbPrice.Text = "";
                            tbQuantity.Text = "";
                            selectedProductid = 0;
                        }
                        catch (Exception ex)
                        {
                            myTransaction.Rollback();
                            MessageBox.Show("ไม่สามารถเพิ่มสินค้าได้" + ex.Message, "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
