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

namespace Source
{
    public partial class FormInputPoints : Form
    {
            string CONNECTION_STRING = @"Data Source=LAPTOP-3MHE919R\SQLSERVER22;Initial Catalog=QLSVNhom;Integrated Security=True";
            public FormInputPoints()
            {
                InitializeComponent();
                loadPoints();
        }

            private void FormInputPoints_Load(object sender, EventArgs e)
            {
                
            }
            private void loadPoints()
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                    {
                        connection.Open();
                        string query = "select MASV,MAHP from BANGDIEM";
                        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dtgvPoints.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi tải dữ liệu: " + ex.Message);
                }
        }

        private void dtgvPoints_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowIndex = e.RowIndex;

            if (selectedRowIndex >= 0 && selectedRowIndex < dtgvPoints.Rows.Count)
            {
                DataGridViewRow selectedRow = dtgvPoints.Rows[selectedRowIndex];
                string masv = Convert.ToString(selectedRow.Cells["MASV"].Value);
                string mahp = Convert.ToString(selectedRow.Cells["MAHP"].Value);
                   tbMaSV.Text = masv;
                   tbHP.Text = mahp;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();

                    // Execute SQL update statement
                    string updateQuery = "UPDATE BANGDIEM SET DIEMTHI="+rtbDiemThi.Text+"  WHERE MASV="+tbMaSV.Text+"";
                    SqlCommand command = new SqlCommand(updateQuery, connection);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Data updated successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating data: " + ex.Message);
            }
        }
    }
            
 }
  

