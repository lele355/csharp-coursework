namespace hannuota
{
    partial class HighScoresForm
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
            this.dgvHighScores = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHighScores)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHighScores
            // 
            this.dgvHighScores.AllowUserToAddRows = false;
            this.dgvHighScores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHighScores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHighScores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHighScores.Location = new System.Drawing.Point(0, 0);
            this.dgvHighScores.Name = "dgvHighScores";
            this.dgvHighScores.ReadOnly = true;
            this.dgvHighScores.RowHeadersWidth = 82;
            this.dgvHighScores.RowTemplate.Height = 37;
            this.dgvHighScores.Size = new System.Drawing.Size(1067, 619);
            this.dgvHighScores.TabIndex = 0;
            // 
            // HighScoresForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 619);
            this.Controls.Add(this.dgvHighScores);
            this.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "HighScoresForm";
            this.Text = "HighScoresForm";
            this.Load += new System.EventHandler(this.HighScoresForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHighScores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHighScores;
    }
}