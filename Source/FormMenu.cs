using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Source
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }
        public FormMenu(string manv)
        {
            InitializeComponent();
            txtMaNV.Text = manv;
        }
        private void btnLopHoc_Click(object sender, EventArgs e)
        {
            Form formClass = new FormClass();
            formClass.ShowDialog();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
