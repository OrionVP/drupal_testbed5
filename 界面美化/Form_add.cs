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
    public partial class Form_add : Form
    {
        public Form_add()
        {
            InitializeComponent();
        }
        string str = "Server=LAPTOP-17RT7OKE;Database=库存管理系统;Trusted_Connection=Yes;Connect Timeout=90";
        public class owner
        {
            public static String text=null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == String.Empty)
            {
                MessageBox.Show("客户名称为空");
            }
            else {
                if (owner.text == "客户名称：")
                {
                    label1.Text = "客户名称：";
                    SqlConnection conn1 = new SqlConnection(str);
                    conn1.Open();
                    string sql1 = "insert into 客户信息表 values('" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "','" +
                        textBox6.Text.Trim() + "','" + comboBox1.Text + "','" + textBox4.Text.Trim() + "','" + textBox5.Text.Trim() + "','" + t