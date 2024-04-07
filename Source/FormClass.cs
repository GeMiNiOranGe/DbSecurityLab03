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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Source
{
    public partial class FormClass : Form
    {
        //string manv = "";
        string connectionString = @"Data Source=ADMIN;Initial Catalog=QLSVNhom;Integrated Security=True";
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        SqlDataAdapter adapter;
        DataTable dt;
        public FormClass()
        {
            InitializeComponent();
        }
        public FormClass(string manv)
        {
            InitializeComponent();
            //this.manv = manv;
            txtmanv.Text = manv;
        }

        private void FormClass_Load(object sender, EventArgs e)
        {
            
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection();
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("select * from lop", sqlConnection);
                //sqlCommand.Parameters.Add("@MANV", SqlDbType.VarChar, 100).Value = txtmanv.Text;
                adapter = new SqlDataAdapter(sqlCommand);
                dt = new DataTable();
                adapter.Fill(dt);
                dgvLopHoc.DataSource = dt;
                sqlConnection.Close();
            }
            catch (Exception ex) 
            {
                
            }
        }
    }
}
