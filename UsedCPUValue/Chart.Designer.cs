namespace UsedCPUValue
{
    partial class Chart
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
            System.Windows.Forms.ColumnHeader CPU_name;
            this.listView1 = new System.Windows.Forms.ListView();
            this.CPU_rating = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CPU_lowest_price_found_on_ebay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CPU_value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            CPU_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            CPU_name,
            this.CPU_rating,
            this.CPU_lowest_price_found_on_ebay,
            this.CPU_value});
            this.listView1.Location = new System.Drawing.Point(29, 26);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(780, 414);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // CPU_name
            // 
            CPU_name.Text = "CPU_name";
            CPU_name.Width = 203;
            // 
            // CPU_rating
            // 
            this.CPU_rating.Text = "CPU_rating";
            this.CPU_rating.Width = 161;
            // 
            // CPU_lowest_price_found_on_ebay
            // 
            this.CPU_lowest_price_found_on_ebay.Text = "CPU_lowest_price_found_on_ebay";
            this.CPU_lowest_price_found_on_ebay.Width = 193;
            // 
            // CPU_value
            // 
            this.CPU_value.Text = "CPU_value(rating/price)";
            this.CPU_value.Width = 166;
            // 
            // Chart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 452);
            this.Controls.Add(this.listView1);
            this.Name = "Chart";
            this.Text = "Chart";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader CPU_rating;
        private System.Windows.Forms.ColumnHeader CPU_lowest_price_found_on_ebay;
        private System.Windows.Forms.ColumnHeader CPU_value;
    }
}