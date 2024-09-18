namespace SystemShop
{
    partial class FormSummay
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
            this.dgvShowSummary = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowSummary)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvShowSummary
            // 
            this.dgvShowSummary.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvShowSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShowSummary.Location = new System.Drawing.Point(-6, -5);
            this.dgvShowSummary.Name = "dgvShowSummary";
            this.dgvShowSummary.ReadOnly = true;
            this.dgvShowSummary.Size = new System.Drawing.Size(1072, 657);
            this.dgvShowSummary.TabIndex = 0;
            this.dgvShowSummary.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvShowSummary_CellFormatting);
            // 
            // FormSummay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 645);
            this.Controls.Add(this.dgvShowSummary);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "FormSummay";
            this.Text = "ประวัติการสั่งซื้อ";
            this.Load += new System.EventHandler(this.FormSummay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowSummary)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvShowSummary;
    }
}