
﻿using System;
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
    public partial class Form3_import : Form
    {
        public Form3_import()
        {
            InitializeComponent();
        }
        string str = "Server=LAPTOP-17RT7OKE;Database=库存管理系统;Trusted_Connection=Yes;Connect Timeout=90";

        public class Price {
            public static int price=0; 
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();         
        }

        private void Form3_import_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_menu fm = new Form_menu();
            fm = (Form_menu)this.Owner;
            fm.Deletetabpage("采购进货");
        }

        private void Form3_import_Load(object sender, EventArgs e)
        {
            //树的生成
            TreeNode root = new TreeNode("所有商品");
            String sql = "select * from 商品种类 ";
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
            //商品资料的生成
            SqlConnection conn1 = new SqlConnection(str);
            conn1.Open();
            string sql1 = "select * from 商品资料";
            DataSet dataset1 = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(sql1, conn1);
            adapter.Fill(dataset1, "商品资料");
            dataGridView1.DataSource = dataset1.Tables["商品资料"];
            conn1.Close();
            //供应商combox加载
            SqlConnection conn2 = new SqlConnection(str);
            conn2.Open();
            string sql2 = "select 供应商名称 from 供应商信息表";
            DataSet dataset2 = new DataSet();
            SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, conn2);
            adapter2.Fill(dataset2, "供应商信息表");
            comboBox1.DataSource = dataset2.Tables["供应商信息表"];
            comboBox1.DisplayMember = "供应商名称";
            conn2.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into 待审核采购订单 values('" + textBox1.Text + "','" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "','" + dataGridView1.CurrentRow.Cells[1].Value.ToString() +
                "','" + textBox2.Text.Trim() + "','" + dataGridView1.CurrentRow.Cells[9].Value.ToString() + "','" + textBox3.Text.Trim() + "','"+comboBox1.Text.Trim()+"','"+dateTimePicker1.Value+"')";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlCommand mycom = new SqlCommand(sql, conn);
            int i=mycom.ExecuteNonQuery();
            if (i > 0)
                label5.Text = "创建订单成功";
            //更新系统日志
            String logsql = "insert into 系统日志 values('" + Login.User.name + "','" + "创建了采购订单" + "','" + DateTime.Now + "')";
            SqlConnection log = new SqlConnection(str);
            log.Open();
            SqlCommand logcom = new SqlCommand(logsql, log);
            logcom.ExecuteNonQuery();
        }

        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            String sql = "select * from 商品资料 where 类别='" + treeView1.SelectedNode.Text + "'";
            if (treeView1.SelectedNode.Text == "所有商品")
            {
                sql = "select * from 商品资料";
            }
            DataSet dataset = new DataSet();
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            DataSet dataset1 = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            adapter.Fill(dataset, "商品资料");
            dataGridView1.DataSource = dataset.Tables["商品资料"];
            conn.Close();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            //获取销售单号
            int id = 100001;
            String sql1 = "select * from  待审核采购订单";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlCommand mycom1 = new SqlCommand(sql1, conn);
            SqlDataReader myread1 = mycom1.ExecuteReader();
            while (myread1.Read())
            {
                if(myread1.IsDBNull(0))
                    id = Convert.ToInt32(myread1[0].ToString().Substring(2)) + 1;
            }
            conn.Close();
            //
            string sql = "select * from 商品资料 where 商品编号='"+ dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
            conn.Open();
            SqlCommand mycom = new SqlCommand(sql,conn);
            SqlDataReader myread = mycom.ExecuteReader();
            if(myread.Read())
            {
                textBox1.Text = "cg"+Convert.ToString(id);
                if (myread.IsDBNull(7))
                    comboBox1.Text = myread[7].ToString();
            }
            conn.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            long money;
            if (textBox2.Text.Trim() != String.Empty)
            {
                Price.price = Convert.ToInt32(dataGridView1.CurrentRow.Cells[9].Value.ToString());
                 money = Convert.ToInt32(textBox2.Text.Trim()) * Price.price;    
            }
            else
            {
                money = 0;
            }
            textBox3.Text = money.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Trim() != String.Empty)
            {
                String sql = "select * from 商品资料 where 商品编号 like '" + textBox4.Text.Trim() + "%' or 商品名称 like '" + textBox4.Text.Trim() + "%'";
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                SqlCommand mycom = new SqlCommand(sql, conn);
                mycom.ExecuteNonQuery();
                DataSet dataset = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                adapter.Fill(dataset, "商品资料");
                dataGridView1.DataSource = dataset.Tables["商品资料"];
            }
        }
    }
}