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
    public partial class Form_password : Form
    {
        public Form_password()
        {
            InitializeComponent();
        }
        string str = "Server=LAPTOP-17RT7OKE;Database=库存管理系统;Trusted_Connection=Yes;Connect Timeout=90";

        private void button1_Click(object sender, EventArgs e)
        {
            if (Login.User.password == textBox1.Text.Trim())
            {
                if (textBox2.Text.Trim() == textBox3.Text.Trim())
                {
                    String sql = "update 用户登录表 set 密码='" + textBox