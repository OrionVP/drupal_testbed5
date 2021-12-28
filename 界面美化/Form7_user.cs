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

namespace 界面美化
{
    public partial class Form7_user : Form
    {
        public Form7_user()
        {
            InitializeComponent();
        }
        string str = "Server=LAPTOP-17RT7OKE;Database=库存管理系统;Trusted_Connection=Yes;Connect Timeout=90";
        public  void refresh()
        {
            //树的生成
            treeView1.Nodes[0].Remove();
            TreeNode root = new TreeNode("所有用户");
            String sql = "select 权限 from 用户种类 ";
            DataSet dataset = new DataSet();
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlCommand mycom = new SqlCommand(sql, conn);
            SqlDataReader myread = mycom.ExecuteReader();
            while (myread.Read())
            {
                root.Nodes.Add(myread[0].ToString());
            }
            treeView1.Nodes.Add(root);
            conn.Close();
            treeView1.ExpandAll();
            //用户资料的生成
            SqlConnection conn1 = new SqlConnection(str);
            conn1.Open();
            string sql1 = "select 姓名,权限 from 用户信息表";
            DataSet dataset1 = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(sql1, conn1);
            adapter.Fill(dataset1, "用户信息表");
            dataGridView1.DataSource = dataset1.Tables["用户信息表"];
            conn1.Close();
        }
        public class select {
            public static String cname;
        }
        private void button1_Click(obj