namespace StokUrunYonetim
{
    partial class MainForm
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
            this.parcaTanim_button = new System.Windows.Forms.Button();
            this.urunTanim_button = new System.Windows.Forms.Button();
            this.parcaStok_button = new System.Windows.Forms.Button();
            this.urunStok_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // parcaTanim_button
            // 
            this.parcaTanim_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.parcaTanim_button.Location = new System.Drawing.Point(12, 12);
            this.parcaTanim_button.Name = "parcaTanim_button";
            this.parcaTanim_button.Size = new System.Drawing.Size(180, 75);
            this.parcaTanim_button.TabIndex = 0;
            this.parcaTanim_button.Text = "Parça Tanımlama";
            this.parcaTanim_button.UseVisualStyleBackColor = true;
            this.parcaTanim_button.Click += new System.EventHandler(this.parcaTanim_button_Click);
            // 
            // urunTanim_button
            // 
            this.urunTanim_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.urunTanim_button.Location = new System.Drawing.Point(198, 12);
            this.urunTanim_button.Name = "urunTanim_button";
            this.urunTanim_button.Size = new System.Drawing.Size(180, 75);
            this.urunTanim_button.TabIndex = 1;
            this.urunTanim_button.Text = "Ürün Tanımlama";
            this.urunTanim_button.UseVisualStyleBackColor = true;
            this.urunTanim_button.Click += new System.EventHandler(this.urunTanim_button_Click);
            // 
            // parcaStok_button
            // 
            this.parcaStok_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.parcaStok_button.Location = new System.Drawing.Point(12, 91);
            this.parcaStok_button.Name = "parcaStok_button";
            this.parcaStok_button.Size = new System.Drawing.Size(180, 75);
            this.parcaStok_button.TabIndex = 2;
            this.parcaStok_button.Text = "Parça Stokları";
            this.parcaStok_button.UseVisualStyleBackColor = true;
            this.parcaStok_button.Click += new System.EventHandler(this.parcaStok_button_Click);
            // 
            // urunStok_button
            // 
            this.urunStok_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.urunStok_button.Location = new System.Drawing.Point(198, 90);
            this.urunStok_button.Name = "urunStok_button";
            this.urunStok_button.Size = new System.Drawing.Size(180, 75);
            this.urunStok_button.TabIndex = 3;
            this.urunStok_button.Text = "Ürün Stokları";
            this.urunStok_button.UseVisualStyleBackColor = true;
            this.urunStok_button.Click += new System.EventHandler(this.urunStok_button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 177);
            this.Controls.Add(this.urunStok_button);
            this.Controls.Add(this.parcaStok_button);
            this.Controls.Add(this.urunTanim_button);
            this.Controls.Add(this.parcaTanim_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ana Menü";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button parcaTanim_button;
        private System.Windows.Forms.Button urunTanim_button;
        private System.Windows.Forms.Button parcaStok_button;
        private System.Windows.Forms.Button urunStok_button;
    }
}