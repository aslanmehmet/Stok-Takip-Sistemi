namespace StokUrunYonetim
{
    partial class UrunStokEkleForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUrunStokMiktar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUrunStokGoruntule = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblToplamMaliyet = new System.Windows.Forms.Label();
            this.btnUrunStokKaydet = new System.Windows.Forms.Button();
            this.lblEksikParcaMaliyet = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 42);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(175, 294);
            this.dataGridView1.TabIndex = 29;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(269, 42);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(186, 294);
            this.dataGridView2.TabIndex = 30;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToResizeRows = false;
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(520, 42);
            this.dataGridView3.MultiSelect = false;
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView3.Size = new System.Drawing.Size(194, 294);
            this.dataGridView3.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 17);
            this.label1.TabIndex = 32;
            this.label1.Text = "Gerekli Parçalar >>\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(266, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 17);
            this.label2.TabIndex = 33;
            this.label2.Text = "Mevcut Parçalar >>\r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(517, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 17);
            this.label3.TabIndex = 34;
            this.label3.Text = "Eksik Parçalar >>\r\n";
            // 
            // txtUrunStokMiktar
            // 
            this.txtUrunStokMiktar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUrunStokMiktar.Location = new System.Drawing.Point(325, 372);
            this.txtUrunStokMiktar.Name = "txtUrunStokMiktar";
            this.txtUrunStokMiktar.Size = new System.Drawing.Size(65, 23);
            this.txtUrunStokMiktar.TabIndex = 36;
            this.txtUrunStokMiktar.Text = "1";
            this.txtUrunStokMiktar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUrunStokMiktar.TextChanged += new System.EventHandler(this.txtUrunStokMiktar_TextChanged);
            this.txtUrunStokMiktar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUrunStokMiktar_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(231, 351);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(214, 17);
            this.label4.TabIndex = 35;
            this.label4.Text = ":..Stoğa Eklenecek Ürün Sayisi..:";
            // 
            // btnUrunStokGoruntule
            // 
            this.btnUrunStokGoruntule.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUrunStokGoruntule.Location = new System.Drawing.Point(283, 402);
            this.btnUrunStokGoruntule.Name = "btnUrunStokGoruntule";
            this.btnUrunStokGoruntule.Size = new System.Drawing.Size(148, 55);
            this.btnUrunStokGoruntule.TabIndex = 37;
            this.btnUrunStokGoruntule.Text = "Stoğu Görüntüle";
            this.btnUrunStokGoruntule.UseVisualStyleBackColor = true;
            this.btnUrunStokGoruntule.Click += new System.EventHandler(this.btnUrunStokGoruntule_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(13, 358);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 17);
            this.label5.TabIndex = 38;
            this.label5.Text = "Toplam Maliyet..:";
            // 
            // lblToplamMaliyet
            // 
            this.lblToplamMaliyet.AutoSize = true;
            this.lblToplamMaliyet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblToplamMaliyet.Location = new System.Drawing.Point(134, 356);
            this.lblToplamMaliyet.Name = "lblToplamMaliyet";
            this.lblToplamMaliyet.Size = new System.Drawing.Size(24, 17);
            this.lblToplamMaliyet.TabIndex = 39;
            this.lblToplamMaliyet.Text = "00";
            // 
            // btnUrunStokKaydet
            // 
            this.btnUrunStokKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUrunStokKaydet.Location = new System.Drawing.Point(3, 393);
            this.btnUrunStokKaydet.Name = "btnUrunStokKaydet";
            this.btnUrunStokKaydet.Size = new System.Drawing.Size(141, 73);
            this.btnUrunStokKaydet.TabIndex = 40;
            this.btnUrunStokKaydet.Text = " Ürünü Stoğa Kaydet";
            this.btnUrunStokKaydet.UseVisualStyleBackColor = true;
            this.btnUrunStokKaydet.Click += new System.EventHandler(this.btnUrunStokKaydet_Click);
            // 
            // lblEksikParcaMaliyet
            // 
            this.lblEksikParcaMaliyet.AutoSize = true;
            this.lblEksikParcaMaliyet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblEksikParcaMaliyet.Location = new System.Drawing.Point(686, 358);
            this.lblEksikParcaMaliyet.Name = "lblEksikParcaMaliyet";
            this.lblEksikParcaMaliyet.Size = new System.Drawing.Size(24, 17);
            this.lblEksikParcaMaliyet.TabIndex = 42;
            this.lblEksikParcaMaliyet.Text = "00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(538, 358);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 17);
            this.label7.TabIndex = 41;
            this.label7.Text = "Eksik Parca Maliyet..:";
            // 
            // UrunStokEkleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 470);
            this.Controls.Add(this.lblEksikParcaMaliyet);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnUrunStokKaydet);
            this.Controls.Add(this.lblToplamMaliyet);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnUrunStokGoruntule);
            this.Controls.Add(this.txtUrunStokMiktar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "UrunStokEkleForm";
            this.Text = "Urun Stok Ekle";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UrunStokEkleForm_FormClosing);
            this.Load += new System.EventHandler(this.UrunStokEkleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUrunStokMiktar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnUrunStokGoruntule;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblToplamMaliyet;
        private System.Windows.Forms.Button btnUrunStokKaydet;
        private System.Windows.Forms.Label lblEksikParcaMaliyet;
        private System.Windows.Forms.Label label7;
    }
}