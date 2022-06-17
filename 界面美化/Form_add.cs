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
                        textBox6.Text.Trim() + "','" + comboBox1.Text + "','" + textBox4.Text.Trim() + "','" + textBox5.Text.Trim() + "','" + textBox7.Text.Trim() +
                        "','" + textBox8.Text.Trim() + "','" + textBox9.Text.Trim() + "','" + textBox10.Text.Trim() + "','" + dateTimePicker1.Value + "')";
                    SqlCommand mycom = new SqlCommand(sql1, conn1);
                    mycom.ExecuteNonQuery();
                    conn1.Close();
                    MessageBox.Show("添加成功");
                    Form4_customer f4;
                    f4 = (Form4_customer)this.Owner;
                    f4.refresh();
                    //更新系统日志
                    String logsql = "insert into 系统日志 values('"+Login.User.name+"','"+"添加客户"+"','"+DateTime.Now+"')";
                    SqlConnection log = new SqlConnection(str);
                    log.Open();
                    SqlCommand logcom = new SqlCommand(logsql,log);
                    logcom.ExecuteNonQuery();
                }
                else
                {
                    label1.Text = "供应商名称：";
                    SqlConnection conn1 = new SqlConnection(str);
                    conn1.Open();
                    string sql1 = "insert into 供应商信息表 values('" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "','" +
                        textBox6.Text.Trim() + "','" + comboBox1.Text + "','" + textBox4.Text.Trim() + "','" + textBox5.Text.Trim() + "','" + textBox7.Text.Trim() +
                        "','" + textBox8.Text.Trim() + "','" + textBox9.Text.Trim() + "','" + textBox10.Text.Trim() + "','" + dateTimePicker1.Value + "')";
                    SqlCommand mycom = new SqlCommand(sql1, conn1);
                    mycom.ExecuteNonQuery();
                    conn1.Close();
                    MessageBox.Show("添加成功");
                    Form5_supplier f;
                    f = (Form5_supplier)this.Owner;
                    f.refresh();
                    //更新系统日志
                    String logsql = "insert into 系统日志 values('" + Login.User.name + "','" + "添加供应商" + "','" + DateTime.Now + "')";
                    SqlConnection log = new SqlConnection(str);
                    log.Open();
                    SqlCommand logcom = new SqlCommand(logsql, log);
                    logcom.ExecuteNonQuery();
                }
                this.Close();
            }
        }

        private void Form_add_Load(object sender, EventArgs e)
        {
            
            if (owner.text == "客户名称：")
            {
                label1.Text = "客户名称：";
                SqlConnection conn1 = new SqlConnection(str);
                conn1.Open();
                string sql1 = "select 客户类别 from 客户种类";
                DataSet dataset1 = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(sql1, conn1);
                adapter.Fill(dataset1, "客户种类");
           