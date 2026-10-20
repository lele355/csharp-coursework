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

namespace _006
{
    public partial class C6_dataSQLAdd: Form
    {
        public C6_dataSQLAdd()
        {
            InitializeComponent();
        }

        string SqlConnectionString = "Data Source=localhost;Initial Catalog=Stud_学号;User ID=sa;Password=YOUR_PASSWORD_HERE";
        string ID = "";

        private void C6_dataSQLAdd_Load(object sender, EventArgs e)
        {

        }

        public C6_dataSQLAdd(string id)
        {
            InitializeComponent();
            ID = id;
            if (!string.IsNullOrEmpty(id))
            {
                DataTable dt = GetDS("select*from course where 课程编号=" + id + "").Tables[0];
                Label1.Text = dt.Rows[0]["课程编号"].ToString();
                Label3.Text = dt.Rows[0]["课程名称"].ToString();
                Label2.Text = dt.Rows[0]["计划学时"].ToString();
                Label5.Text = dt.Rows[0]["主讲教师"].ToString();
                Label4.Text = dt.Rows[0]["课程学分"].ToString();
                Label6.Text = dt.Rows[0]["备注"].ToString();
            }
        }

        public int RunSql(string strSql)
        {
            SqlConnection cnn = new SqlConnection(SqlConnectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                if (cnn.State == ConnectionState.Closed)
                    cnn.Open();
                cmd = new SqlCommand(strSql, cnn);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                cmd.Dispose();
                if (cnn != null)
                {
                    if (cnn.State == ConnectionState.Open)
                        cnn.Close();
                    cnn.Dispose();
                }
            }
        }

        public DataSet GetDS(string strSql)
        {
            SqlConnection cnn = new SqlConnection(SqlConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter();
            try
            {
                if (cnn.State == ConnectionState.Closed)
                    cnn.Open();
                sda = new SqlDataAdapter(strSql, cnn);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sda.Dispose();
                if (cnn != null)
                {
                    if (cnn.State == ConnectionState.Open)
                        cnn.Close();
                    cnn.Dispose();
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ID))
            {
                string insertSql = "insert into course(课程编号, 课程名称, 计划学时, 主讲教师, 课程学分, 备注) values ('" +
                    txtcode.Text.Trim() + "', '" + txtcorseName.Text.Trim() + "', " + Convert.ToDecimal(txtjhxs.Text.Trim()) + ", '" +
                    txtteacher.Text.Trim() + "', " + Convert.ToDecimal(txtxf.Text.Trim()) + ", '" + txtbz.Text.Trim() + "')";
                if (RunSql(insertSql) > 0)
                    MessageBox.Show("添加成功！");
                else
                    MessageBox.Show("添加失败！");
            }
            else // 修改
            {
                string updateSql = "Update course set 课程编号= '" + txtcode.Text.Trim() + "', 课程名称= '" + txtcorseName.Text.Trim() +
                    "', 课程学分= " + Convert.ToDecimal(txtxf.Text.Trim()) + ", 主讲教师= '" + txtteacher.Text.Trim() +
                    "', 计划学时= " + Convert.ToDecimal(txtjhxs.Text.Trim()) + ", 备注= '" + txtbz.Text.Trim() +
                    "' where 课程编号 = '" + ID + "'";
                if (RunSql(updateSql) > 0)
                    MessageBox.Show("修改成功！");
                else
                    MessageBox.Show("修改失败！");
            }

            this.Close();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            
                this.Close();
        }
    }
}
