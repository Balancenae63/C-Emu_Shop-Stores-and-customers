namespace SystemShop
{
    partial class CustomerShop
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
            this.dgvShop = new System.Windows.Forms.DataGridView();
            this.dgvBasket = new System.Windows.Forms.DataGridView();
            this.btnCart = new System.Windows.Forms.Button();
            this.btnDeletestore = new System.Windows.Forms.Button();
            this.btnBuy = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNameCS = new System.Windows.Forms.TextBox();
            this.tbPriceCS = new System.Windows.Forms.TextBox();
            this.tbQuantityCS = new System.Windows.Forms.TextBox();
            this.tbSumCS = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnShowSummary = new System.Windows.Forms.Button();
            this.btnAdninAddStore = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasket)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvShop
            // 
            this.dgvShop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvShop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShop.Location = new System.Drawing.Point(12, 12);
            this.dgvShop.Name = "dgvShop";
            this.dgvShop.ReadOnly = true;
            this.dgvShop.Size = new System.Drawing.Size(484, 580);
            this.dgvShop.TabIndex = 0;
            this.dgvShop.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShop_CellClick);
            // 
            // dgvBasket
            // 
            this.dgvBasket.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvBasket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBasket.Location = new System.Drawing.Point(516, 12);
            this.dgvBasket.Name = "dgvBasket";
            this.dgvBasket.ReadOnly = true;
            this.dgvBasket.Size = new System.Drawing.Size(562, 371);
            this.dgvBasket.TabIndex = 1;
            // 
            // btnCart
            // 
            this.btnCart.Font = new System.Drawing.Font("TH Sarabun New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnCart.Location = new System.Drawing.Point(169, 621);
            this.btnCart.Name = "btnCart";
            this.btnCart.Size = new System.Drawing.Size(143, 55);
            this.btnCart.TabIndex = 2;
            this.btnCart.Text = "เพิ่มลงในตะกร้า";
            this.btnCart.UseVisualStyleBackColor = true;
            this.btnCart.Click += new System.EventHandler(this.btnCart_Click);
            // 
            // btnDeletestore
            // 
            this.btnDeletestore.Font = new System.Drawing.Font("TH Sarabun New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnDeletestore.Location = new System.Drawing.Point(516, 408);
            this.btnDeletestore.Name = "btnDeletestore";
            this.btnDeletestore.Size = new System.Drawing.Size(125, 51);
            this.btnDeletestore.TabIndex = 3;
            this.btnDeletestore.Text = "นำสินค้าออก";
            this.btnDeletestore.UseVisualStyleBackColor = true;
            this.btnDeletestore.Click += new System.EventHandler(this.btnDeletestore_Click);
            // 
            // btnBuy
            // 
            this.btnBuy.Font = new System.Drawing.Font("TH Sarabun New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnBuy.Location = new System.Drawing.Point(867, 611);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(151, 40);
            this.btnBuy.TabIndex = 4;
            this.btnBuy.Text = "สั่งซื้อสินค้า";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poor Richard", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(686, 413);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "ชื่อสินค้า";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poor Richard", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(686, 458);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "ราคา";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poor Richard", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(686, 505);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "จำนวน";
            // 
            // tbNameCS
            // 
            this.tbNameCS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNameCS.Cursor = System.Windows.Forms.Cursors.No;
            this.tbNameCS.Enabled = false;
            this.tbNameCS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tbNameCS.Location = new System.Drawing.Point(767, 414);
            this.tbNameCS.Multiline = true;
            this.tbNameCS.Name = "tbNameCS";
            this.tbNameCS.ReadOnly = true;
            this.tbNameCS.Size = new System.Drawing.Size(235, 20);
            this.tbNameCS.TabIndex = 10;
            // 
            // tbPriceCS
            // 
            this.tbPriceCS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPriceCS.Cursor = System.Windows.Forms.Cursors.No;
            this.tbPriceCS.Enabled = false;
            this.tbPriceCS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tbPriceCS.Location = new System.Drawing.Point(766, 452);
            this.tbPriceCS.Multiline = true;
            this.tbPriceCS.Name = "tbPriceCS";
            this.tbPriceCS.ReadOnly = true;
            this.tbPriceCS.Size = new System.Drawing.Size(195, 20);
            this.tbPriceCS.TabIndex = 11;
            // 
            // tbQuantityCS
            // 
            this.tbQuantityCS.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbQuantityCS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tbQuantityCS.Location = new System.Drawing.Point(766, 499);
            this.tbQuantityCS.Name = "tbQuantityCS";
            this.tbQuantityCS.Size = new System.Drawing.Size(195, 26);
            this.tbQuantityCS.TabIndex = 12;
            // 
            // tbSumCS
            // 
            this.tbSumCS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSumCS.Cursor = System.Windows.Forms.Cursors.No;
            this.tbSumCS.Enabled = false;
            this.tbSumCS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tbSumCS.Location = new System.Drawing.Point(855, 563);
            this.tbSumCS.Multiline = true;
            this.tbSumCS.Name = "tbSumCS";
            this.tbSumCS.ReadOnly = true;
            this.tbSumCS.Size = new System.Drawing.Size(175, 20);
            this.tbSumCS.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Poor Richard", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(968, 455);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 24);
            this.label4.TabIndex = 14;
            this.label4.Text = "บาท";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Poor Richard", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(968, 502);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 24);
            this.label5.TabIndex = 15;
            this.label5.Text = "เล่ม";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Poor Richard", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(813, 558);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 24);
            this.label6.TabIndex = 16;
            this.label6.Text = "รวม";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Poor Richard", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1036, 559);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 24);
            this.label7.TabIndex = 17;
            this.label7.Text = "บาท";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 612);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 19;
            // 
            // btnShowSummary
            // 
            this.btnShowSummary.Font = new System.Drawing.Font("TH Sarabun New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnShowSummary.Location = new System.Drawing.Point(855, 729);
            this.btnShowSummary.Name = "btnShowSummary";
            this.btnShowSummary.Size = new System.Drawing.Size(101, 32);
            this.btnShowSummary.TabIndex = 20;
            this.btnShowSummary.Text = "แสดงประวัติ";
            this.btnShowSummary.UseVisualStyleBackColor = true;
            this.btnShowSummary.Click += new System.EventHandler(this.btnShowSummary_Click);
            // 
            // btnAdninAddStore
            // 
            this.btnAdninAddStore.Font = new System.Drawing.Font("TH Sarabun New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnAdninAddStore.Location = new System.Drawing.Point(975, 729);
            this.btnAdninAddStore.Name = "btnAdninAddStore";
            this.btnAdninAddStore.Size = new System.Drawing.Size(101, 32);
            this.btnAdninAddStore.TabIndex = 21;
            this.btnAdninAddStore.Text = "Admin Only";
            this.btnAdninAddStore.UseVisualStyleBackColor = true;
            this.btnAdninAddStore.Click += new System.EventHandler(this.btnAdninAddStore_Click_1);
            // 
            // CustomerShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1088, 773);
            this.Controls.Add(this.btnAdninAddStore);
            this.Controls.Add(this.btnShowSummary);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbSumCS);
            this.Controls.Add(this.tbQuantityCS);
            this.Controls.Add(this.tbPriceCS);
            this.Controls.Add(this.tbNameCS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuy);
            this.Controls.Add(this.btnDeletestore);
            this.Controls.Add(this.btnCart);
            this.Controls.Add(this.dgvBasket);
            this.Controls.Add(this.dgvShop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "CustomerShop";
            this.Text = "Shop";
            this.Load += new System.EventHandler(this.CustomerShop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvShop;
        private System.Windows.Forms.DataGridView dgvBasket;
        private System.Windows.Forms.Button btnCart;
        private System.Windows.Forms.Button btnDeletestore;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNameCS;
        private System.Windows.Forms.TextBox tbPriceCS;
        private System.Windows.Forms.TextBox tbQuantityCS;
        private System.Windows.Forms.TextBox tbSumCS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnShowSummary;
        private System.Windows.Forms.Button btnAdninAddStore;
    }
}