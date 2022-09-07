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
    public partial class Form_goodstype : Form
    {
        public Form_goodstype()

        {
            InitializeComponent();
        }
        string str = "Server=LAPTOP-17RT7OKE;Database=库存管理系统;Trusted_Connection=Yes;Connect Timeout=90";
        String select = null;
        TreeNode root = new TreeNode("所有商品");
        public void refresh(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < root.Nodes.Count; i++)
            {
                dataGridView1.Rows.Add(root.Nodes[i].Text, root.Text);
            }
        }
        public Boolean Iswrite(object sender, EventArgs e)
        {
            for (int i = 0; i < root.Nodes.Count; i++)
            {
                if (root.Nodes[i].Text == "请输入新的类别名称")
                {
                    MessageBox.Show("请先输入新的类别名称，再在进行操作");
                    