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
    public partial class Form_goodsstore : Form
    {
        public Form_goodsstore()
        {
            InitializeComponent();
        }
        string str = "Server=LAPTOP-17RT7OKE;Database=库存管理系统;Trusted_Connection=Yes;Connect Timeout=90";

        public class select {
            public static String goods = null;
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_goodsstore_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_menu fm = new Form_menu();
            fm = (Form_menu)this.Owner;
            fm.Deletetabpage("商品库存");
        }
        public void refresh()
        {
            //商品资料的生成
            SqlConnection conn1 = new SqlConnection(str);
            conn1.Open();
            string sql1 = "select * from 商品库存";
            DataSet dataset1 = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(sql1, conn1);
            adapter.Fill(dataset1, "商品库存");
            dataGridView1.DataSource = dataset1.Tables["商品库存"];
            conn1.Close();
        }
        private void Form_goodsstore_Load(object sender,