using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemShop
{
    public partial class FormSummay : Form
    {
        SqlConnection myCon = new SqlConnection();

        public FormSummay()
        {
            InitializeComponent();
        }

        private void FormSummay_Load(object sender, EventArgs e)
        {
            myCon.ConnectionString = "Data Source=localhost; Integrated Security=True; Initial Catalog=DataStore; Trusted_Connection=True; TrustServerCertificate=True";
            myCon.Open();
            LoadTransaction();
            dgvShowSummary.CellFormatting += dgvShowSummary_CellFormatting;
        }

        private void dgvShowSummary_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvShowSummary.Columns[e.ColumnIndex].Name == "customerType" && e.Value != null)
            {
                e.Value = TranslateTransactionsType(e.Value.ToString());
                e.FormattingApplied = true;
            }
        }

        private void LoadTransaction()
        {
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandText = @"SELECT c.customerID, c.customerType, p.productID, p.productName, c.customerAuantity, c.customerDate FROM customerData c INNER JOIN productStore p ON c.productId = p.productID ORDER BY c.customerDate DESC";
            myCommand.CommandType = CommandType.Text;
            myCommand.Connection = myCon;

            

            SqlDataAdapter adapter = new SqlDataAdapter(myCommand);
            DataTable myDataTable = new DataTable();
            adapter.Fill(myDataTable);

            if (myDataTable.Rows.Count > 0)
            {
                dgvShowSummary.DataSource = myDataTable;
                dgvShowSummary.Columns["customerID"].HeaderText = "รหัสธุรกรรม";
                dgvShowSummary.Columns["customerType"].HeaderText = "ประเภทธุรกรรม";
                dgvShowSummary.Columns["productID"].HeaderText = "รหัสสินค้า";
                dgvShowSummary.Columns["productName"].HeaderText = "ชื่อสินค้า";
                dgvShowSummary.Columns["customerAuantity"].HeaderText = "จำนวน";
                dgvShowSummary.Columns["customerDate"].HeaderText = "วันที่บันทึกรายการ";

                dgvShowSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvShowSummary.Columns["customerDate"].DefaultCellStyle.Format = "dd/mm/yyyy HH:mm:ss";
            }
            else
            {
                dgvShowSummary.DataSource = null;
            }
            dgvShowSummary.Refresh();
        }

        private string TranslateTransactionsType(string customerType)
        {
            switch (customerType.ToLower())
            {
                case "purchase": return "ชื่อ";
                case "sale": return "ขาย";
                case "stockreturn": return "คืนสินค้า";
                default: return customerType;
            }
        }
    }
}
