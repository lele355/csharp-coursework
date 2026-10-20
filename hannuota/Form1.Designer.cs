namespace hannuota
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelPegA = new System.Windows.Forms.Panel();
            this.panelPegB = new System.Windows.Forms.Panel();
            this.panelPegC = new System.Windows.Forms.Panel();
            this.pegPanel1 = new System.Windows.Forms.Panel();
            this.pegPanel2 = new System.Windows.Forms.Panel();
            this.pegPanel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.numDisksInput = new System.Windows.Forms.NumericUpDown();
            this.btnStartReset = new System.Windows.Forms.Button();
            this.lblMoves = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnShowHighScores = new System.Windows.Forms.Button();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.btnAutoSolve = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numDisksInput)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPegA
            // 
            this.panelPegA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPegA.Location = new System.Drawing.Point(50, 250);
            this.panelPegA.Name = "panelPegA";
            this.panelPegA.Size = new System.Drawing.Size(150, 20);
            this.panelPegA.TabIndex = 1;
            // 
            // panelPegB
            // 
            this.panelPegB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPegB.Location = new System.Drawing.Point(250, 250);
            this.panelPegB.Name = "panelPegB";
            this.panelPegB.Size = new System.Drawing.Size(140, 20);
            this.panelPegB.TabIndex = 2;
            // 
            // panelPegC
            // 
            this.panelPegC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPegC.Location = new System.Drawing.Point(450, 250);
            this.panelPegC.Name = "panelPegC";
            this.panelPegC.Size = new System.Drawing.Size(150, 20);
            this.panelPegC.TabIndex = 3;
            // 
            // pegPanel1
            // 
            this.pegPanel1.BackColor = System.Drawing.Color.Black;
            this.pegPanel1.Location = new System.Drawing.Point(125, 50);
            this.pegPanel1.Name = "pegPanel1";
            this.pegPanel1.Size = new System.Drawing.Size(10, 200);
            this.pegPanel1.TabIndex = 4;
            this.pegPanel1.Click += new System.EventHandler(this.Peg_Click);
            this.pegPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pegPanel2
            // 
            this.pegPanel2.BackColor = System.Drawing.Color.Black;
            this.pegPanel2.Location = new System.Drawing.Point(315, 50);
            this.pegPanel2.Name = "pegPanel2";
            this.pegPanel2.Size = new System.Drawing.Size(10, 200);
            this.pegPanel2.TabIndex = 5;
            this.pegPanel2.Click += new System.EventHandler(this.Peg_Click);
            // 
            // pegPanel3
            // 
            this.pegPanel3.BackColor = System.Drawing.Color.Black;
            this.pegPanel3.Location = new System.Drawing.Point(520, 50);
            this.pegPanel3.Name = "pegPanel3";
            this.pegPanel3.Size = new System.Drawing.Size(10, 200);
            this.pegPanel3.TabIndex = 6;
            this.pegPanel3.Click += new System.EventHandler(this.Peg_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 336);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 33);
            this.label1.TabIndex = 7;
            this.label1.Text = "盘子数量";
            // 
            // numDisksInput
            // 
            this.numDisksInput.Location = new System.Drawing.Point(218, 334);
            this.numDisksInput.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numDisksInput.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numDisksInput.Name = "numDisksInput";
            this.numDisksInput.Size = new System.Drawing.Size(120, 44);
            this.numDisksInput.TabIndex = 8;
            this.numDisksInput.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // btnStartReset
            // 
            this.btnStartReset.Location = new System.Drawing.Point(407, 326);
            this.btnStartReset.Name = "btnStartReset";
            this.btnStartReset.Size = new System.Drawing.Size(175, 52);
            this.btnStartReset.TabIndex = 9;
            this.btnStartReset.Text = "开始游戏";
            this.btnStartReset.UseVisualStyleBackColor = true;
            this.btnStartReset.Click += new System.EventHandler(this.btnStartReset_Click);
            // 
            // lblMoves
            // 
            this.lblMoves.AutoSize = true;
            this.lblMoves.Location = new System.Drawing.Point(73, 432);
            this.lblMoves.Name = "lblMoves";
            this.lblMoves.Size = new System.Drawing.Size(111, 33);
            this.lblMoves.TabIndex = 10;
            this.lblMoves.Text = "步数:0";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(227, 432);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(127, 33);
            this.lblTime.TabIndex = 11;
            this.lblTime.Text = "用时:0s";
            // 
            // btnShowHighScores
            // 
            this.btnShowHighScores.Location = new System.Drawing.Point(394, 426);
            this.btnShowHighScores.Name = "btnShowHighScores";
            this.btnShowHighScores.Size = new System.Drawing.Size(188, 45);
            this.btnShowHighScores.TabIndex = 12;
            this.btnShowHighScores.Text = "排行榜";
            this.btnShowHighScores.UseVisualStyleBackColor = true;
            this.btnShowHighScores.Click += new System.EventHandler(this.btnShowHighScores_Click);
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 1000;
            // 
            // btnAutoSolve
            // 
            this.btnAutoSolve.Font = new System.Drawing.Font("楷体", 4.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAutoSolve.ForeColor = System.Drawing.Color.Black;
            this.btnAutoSolve.Location = new System.Drawing.Point(608, 475);
            this.btnAutoSolve.Name = "btnAutoSolve";
            this.btnAutoSolve.Size = new System.Drawing.Size(54, 20);
            this.btnAutoSolve.TabIndex = 13;
            this.btnAutoSolve.Text = "作弊";
            this.btnAutoSolve.UseVisualStyleBackColor = true;
            this.btnAutoSolve.Click += new System.EventHandler(this.btnAutoSolve_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 507);
            this.Controls.Add(this.btnAutoSolve);
            this.Controls.Add(this.btnShowHighScores);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblMoves);
            this.Controls.Add(this.btnStartReset);
            this.Controls.Add(this.numDisksInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pegPanel3);
            this.Controls.Add(this.pegPanel2);
            this.Controls.Add(this.pegPanel1);
            this.Controls.Add(this.panelPegC);
            this.Controls.Add(this.panelPegB);
            this.Controls.Add(this.panelPegA);
            this.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "汉诺塔游戏";
            ((System.ComponentModel.ISupportInitialize)(this.numDisksInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelPegA;
        private System.Windows.Forms.Panel panelPegB;
        private System.Windows.Forms.Panel panelPegC;
        private System.Windows.Forms.Panel pegPanel1;
        private System.Windows.Forms.Panel pegPanel2;
        private System.Windows.Forms.Panel pegPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numDisksInput;
        private System.Windows.Forms.Button btnStartReset;
        private System.Windows.Forms.Label lblMoves;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Button btnShowHighScores;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Button btnAutoSolve;
    }
}

