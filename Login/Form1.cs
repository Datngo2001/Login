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

namespace Login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet data = new DataSet();
            string userName = textBox1.Text;
            string password = textBox2.Text;
            string query = @"SELECT ID
                                 , UserName
                                 , Password
                            FROM dbo.User_Table
                            WHERE UserName = '" + userName + @"'";
            using (SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-CGKU0T3D\SQLEXPRESS;Initial Catalog=AppDB;Integrated Security=True"))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(data);
                connection.Close();
            }
            try
            {
                DataRow row = data.Tables[0].Rows[0];
                if (password == row["Password"].ToString())
                {
                    MessageBox.Show("Dang nhap thanh cong!");
                }
                else
                {
                    MessageBox.Show("Dang nhap that bai!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Dang nhap that bai!");
            }
        }
    }
}
