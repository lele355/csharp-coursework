using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.NetworkInformation;

namespace _006
{
    public partial class C6_dataSqlList: Form
    {
        public C6_dataSqlList()
        {
            InitializeComponent();
        }

        private void C6_dataSqlList_Load(object sender, EventArgs e)
        {
            dataBinding("");
        }

        public void dataBinding(string strwhere)
        {
            string SqlStr = "Data Source=localhost;Initial Catalog=Stud_学号;User ID=sa;Password=YOUR_PASSWORD_HERE";
            SqlConnection conn = new SqlConnection(SqlStr);         //实例化SqlConnection数据库连接对象
            conn.Open();                                            // 打开数据库连接
            SqlDataAdapter oleda = new SqlDataAdapter();            // 实例化数据库桥接器对象
            DataSet myds = new DataSet();                           //实例化数据集对象                      
            string strsql = "";
           
            if (string.IsNullOrEmpty(strwhere))
                strsql = "select * from course";
            else
                strsql = string.Format("select * from course where 课程名称 like '%{0}%'", strwhere);
                oleda.SelectCommand = new SqlCommand(strsql, conn);
                oleda.Fill(myds, "tabName");                        // 填充数据集中的指定表
                dataGridView1.DataSource = myds.Tables["tabName"];  //为dataGridView1指定数据源
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string wherestr = txtSearch.Text.Trim();
            dataBinding(wherestr);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            C6_dataSQLAdd addfrom = new C6_dataSQLAdd("");
            addfrom.Owner = this;
            addfrom.ShowDialog();
            dataBinding("");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int num = dataGridView1.CurrentRow.Index;
            string id = dataGridView1.Rows[num].Cells["课程编号"].Value.ToString();
            C6_dataSQLAdd addfrom = new C6_dataSQLAdd(id);
            addfrom.Owner = this;
            addfrom.ShowDialog();
            dataBinding("");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
            {
                if (!r.IsNewRow)
                {
                    string delete = "delete from course where课程编号 = " + r.Cells["课程编号"].Value.ToString()+"";
                    if (ExcuteSql(delete) > 0)
                    {
                        MessageBox.Show("删除成功！");
                        dataBinding("");
                    }
                    else
                        MessageBox.Show("删除失败！");
                }
                else
                    MessageBox.Show("请选择数据！"); 
            }
        }

        public int ExcuteSql(string strSql)
        {
            int nResult = 0;
            SqlCommand ole_command = new SqlCommand();
            string SqlStr = "Data Source=localhost;Initial Catalog=Stud_学号;User ID=sa;Password=YOUR_PASSWORD_HERE";
            try
            {
                SqlConnection ole_connection = new SqlConnection(SqlStr); //SqlConnection数据库连接对象
                ole_connection.Open();
                if (ole_connection.State == ConnectionState.Closed)
                {
                    return nResult;
                }
                ole_command.Connection = ole_connection;
                ole_command.CommandText = strSql;
                nResult = ole_command.ExecuteNonQuery();
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
                return nResult;
            }
            return nResult;           
        }


    }
}
