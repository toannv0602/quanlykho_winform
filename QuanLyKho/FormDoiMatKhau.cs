using QuanLyKho.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho
{
    public partial class FormDoiMatKhau : Form
    {
        private string userName;
        public FormDoiMatKhau(string userName)
        {
            InitializeComponent();
            this.UserName = userName;

        }

        public string UserName { get => userName; set => userName = value; }

        private void btnChangePass(object sender, EventArgs e)
        {
            string reNewPass = txtReNewPass.Text;
            string oldPass = txtOldPass.Text;
            string newPass = txtNewPass.Text;
            if (!newPass.Equals(reNewPass))
            {
                MessageBox.Show("Vui lòng nhập đúng mật khẩu mới!");
                txtReNewPass.Focus();
            }
            else
            {
                if (EmployeeDAO.Instance.changePassword(userName, oldPass, newPass))
                {
                    MessageBox.Show("Cập nhập thành công!");
                    
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đúng mật khẩu");
                }
            }
        }
    }
}
