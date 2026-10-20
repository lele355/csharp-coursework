namespace _006
{
    partial class SQL_student
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.stud_学号DataSet = new _006.Stud_学号DataSet();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.学号DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.姓名DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.性别DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.所属专业DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.出生日期DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.密码DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentTableAdapter = new _006.Stud_学号DataSetTableAdapters.studentTableAdapter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stud_学号DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(164, 352);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 65);
            this.button1.TabIndex = 0;
            this.button1.Text = "新增";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(400, 352);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 65);
            this.button2.TabIndex = 1;
            this.button2.Text = "修改";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(650, 352);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(114, 62);
            this.button3.TabIndex = 2;
            this.button3.Text = "删除";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(865, 352);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(114, 62);
            this.button4.TabIndex = 3;
            this.button4.Text = "放弃";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 33);
            this.label2.TabIndex = 5;
            this.label2.Text = "学号：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(88, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 33);
            this.label3.TabIndex = 6;
            this.label3.Text = "出生日期：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(445, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 33);
            this.label4.TabIndex = 7;
            this.label4.Text = "姓名：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(451, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 33);
            this.label5.TabIndex = 8;
            this.label5.Text = "所属专业：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(862, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 33);
            this.label6.TabIndex = 9;
            this.label6.Text = "性别：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(868, 198);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 33);
            this.label7.TabIndex = 10;
            this.label7.Text = "密码：";
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource1, "学号", true));
            this.textBox1.Location = new System.Drawing.Point(270, 118);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 44);
            this.textBox1.TabIndex = 11;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "student";
            this.bindingSource1.DataSource = this.stud_学号DataSet;
            // 
            // stud_学号DataSet
            // 
            this.stud_学号DataSet.DataSetName = "Stud_学号DataSet";
            this.stud_学号DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBox2
            // 
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource1, "出生日期", true));
            this.textBox2.Location = new System.Drawing.Point(270, 195);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 44);
            this.textBox2.TabIndex = 12;
            // 
            // textBox3
            // 
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource1, "姓名", true));
            this.textBox3.Location = new System.Drawing.Point(620, 118);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 44);
            this.textBox3.TabIndex = 13;
            // 
            // textBox4
            // 
            this.textBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource1, "所属专业", true));
            this.textBox4.Location = new System.Drawing.Point(620, 195);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 44);
            this.textBox4.TabIndex = 14;
            // 
            // textBox5
            // 
            this.textBox5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource1, "性别", true));
            this.textBox5.Location = new System.Drawing.Point(1006, 118);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 44);
            this.textBox5.TabIndex = 15;
            // 
            // textBox6
            // 
            this.textBox6.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource1, "密码", true));
            this.textBox6.Location = new System.Drawing.Point(1006, 195);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 44);
            this.textBox6.TabIndex = 16;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.学号DataGridViewTextBoxColumn,
            this.姓名DataGridViewTextBoxColumn,
            this.性别DataGridViewTextBoxColumn,
            this.所属专业DataGridViewTextBoxColumn,
            this.出生日期DataGridViewTextBoxColumn,
            this.密码DataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(49, 454);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 37;
            this.dataGridView1.Size = new System.Drawing.Size(1254, 359);
            this.dataGridView1.TabIndex = 17;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // 学号DataGridViewTextBoxColumn
            // 
            this.学号DataGridViewTextBoxColumn.DataPropertyName = "学号";
            this.学号DataGridViewTextBoxColumn.HeaderText = "学号";
            this.学号DataGridViewTextBoxColumn.MinimumWidth = 10;
            this.学号DataGridViewTextBoxColumn.Name = "学号DataGridViewTextBoxColumn";
            this.学号DataGridViewTextBoxColumn.Width = 200;
            // 
            // 姓名DataGridViewTextBoxColumn
            // 
            this.姓名DataGridViewTextBoxColumn.DataPropertyName = "姓名";
            this.姓名DataGridViewTextBoxColumn.HeaderText = "姓名";
            this.姓名DataGridViewTextBoxColumn.MinimumWidth = 10;
            this.姓名DataGridViewTextBoxColumn.Name = "姓名DataGridViewTextBoxColumn";
            this.姓名DataGridViewTextBoxColumn.Width = 200;
            // 
            // 性别DataGridViewTextBoxColumn
            // 
            this.性别DataGridViewTextBoxColumn.DataPropertyName = "性别";
            this.性别DataGridViewTextBoxColumn.HeaderText = "性别";
            this.性别DataGridViewTextBoxColumn.MinimumWidth = 10;
            this.性别DataGridViewTextBoxColumn.Name = "性别DataGridViewTextBoxColumn";
            this.性别DataGridViewTextBoxColumn.Width = 200;
            // 
            // 所属专业DataGridViewTextBoxColumn
            // 
            this.所属专业DataGridViewTextBoxColumn.DataPropertyName = "所属专业";
            this.所属专业DataGridViewTextBoxColumn.HeaderText = "所属专业";
            this.所属专业DataGridViewTextBoxColumn.MinimumWidth = 10;
            this.所属专业DataGridViewTextBoxColumn.Name = "所属专业DataGridViewTextBoxColumn";
            this.所属专业DataGridViewTextBoxColumn.Width = 200;
            // 
            // 出生日期DataGridViewTextBoxColumn
            // 
            this.出生日期DataGridViewTextBoxColumn.DataPropertyName = "出生日期";
            this.出生日期DataGridViewTextBoxColumn.HeaderText = "出生日期";
            this.出生日期DataGridViewTextBoxColumn.MinimumWidth = 10;
            this.出生日期DataGridViewTextBoxColumn.Name = "出生日期DataGridViewTextBoxColumn";
            this.出生日期DataGridViewTextBoxColumn.Width = 200;
            // 
            // 密码DataGridViewTextBoxColumn
            // 
            this.密码DataGridViewTextBoxColumn.DataPropertyName = "密码";
            this.密码DataGridViewTextBoxColumn.HeaderText = "密码";
            this.密码DataGridViewTextBoxColumn.MinimumWidth = 10;
            this.密码DataGridViewTextBoxColumn.Name = "密码DataGridViewTextBoxColumn";
            this.密码DataGridViewTextBoxColumn.Width = 200;
            // 
            // studentTableAdapter
            // 
            this.studentTableAdapter.ClearBeforeFill = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(22, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1198, 271);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "学生信息";
            // 
            // SQL_student
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1358, 852);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SQL_student";
            this.Text = "SQL_student";
            this.Load += new System.EventHandler(this.SQL_student_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stud_学号DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private Stud_学号DataSet stud_学号DataSet;
        private Stud_学号DataSetTableAdapters.studentTableAdapter studentTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn 学号DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 姓名DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 性别DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 所属专业DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出生日期DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 密码DataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}