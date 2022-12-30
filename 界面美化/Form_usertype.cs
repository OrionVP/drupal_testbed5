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
    public partial class Form_usertype : Form
    {
        public Form_usertype()
        {
            InitializeComponent();
        }
        string str = "Server=LAPTOP-17RT7OKE;Database=库存管理系统;Trusted_Connection=Yes;Connect Timeout=90";
        String select = null;
        TreeNode root = new TreeNode("所有用户");
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
                    return false;
                }
                    
            }
            return true;
        }

        private void Form_customertype_Load(object sender, EventArgs e)
        {
            
            String sql = "select * from 用户种类 ";
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
            treeView1.ExpandAll();
            refresh(sender,e);
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Iswrite(sender, e))
            {
                root.Nodes.Add("请输入新的类别名称");
                treeView1.LabelEdit = true;
  