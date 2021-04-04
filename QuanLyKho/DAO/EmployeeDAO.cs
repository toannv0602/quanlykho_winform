using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.DAO
{
    class EmployeeDAO
    {
        private static EmployeeDAO instance;

        public static EmployeeDAO Instance
        {
            get { if (instance == null) instance = new EmployeeDAO(); return instance; }
            private set { instance = value; }
        }
        private EmployeeDAO() { }
        public bool changePassword(string userName, string oldPass, string newPass)
        {
            int result = DataProvider.Instance.ExecuteNonQuery(" exec SP_CapNhatMK @userName , @password , @newPassword ",
                new object[] { userName, oldPass, newPass });

            return result > 0;
        }
    }
}
