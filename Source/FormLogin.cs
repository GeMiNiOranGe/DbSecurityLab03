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

namespace Source {
    public partial class FormLogin : Form {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        public FormLogin() {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(Config.CONNECTION_STRING);
            try
            {
                sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "SP_LOGIN";
                sqlCommand.Connection = sqlConnection;

                sqlCommand.Parameters.Add("@TENDN", SqlDbType.NVarChar).Value = txtDangNhap.Text;
                sqlCommand.Parameters.Add("@MATKHAU", SqlDbType.VarChar).Value = txtMatKhau.Text;
                sqlCommand.Parameters.Add("@KETQUA", SqlDbType.Int);
                sqlCommand.Parameters.Add("@MANV", SqlDbType.VarChar, 100);
                sqlCommand.Parameters["@KETQUA"].Direction = ParameterDirection.Output;
                sqlCommand.Parameters["@MANV"].Direction = ParameterDirection.Output;
                sqlCommand.Parameters["@MANV"].Size = 100;

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();

                int ketqua = Convert.ToInt32(sqlCommand.Parameters["@KETQUA"].Value);
                string manv = sqlCommand.Parameters["@MANV"].Value.ToString();
                if (ketqua == 1)
                {
                    MessageBox.Show("Đăng nhập tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (!string.IsNullOrEmpty(manv))
                    {
                        FormMenu formMenu = new FormMenu(manv);
                        this.Hide();
                        formMenu.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Mã nhân viên không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
