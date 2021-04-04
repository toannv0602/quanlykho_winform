using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.DAO
{
    class DataProvider
    {
        // dùng đi dùng lại nhiều
        private static DataProvider instance; //  phím tắt đóng gói ctrl+ R+ E

        // kiến trúc singleton
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        private DataProvider() { }

        string connectionSTR = @"Data Source=DESKTOP-ALMMIJJ\SQLEXPRESS;Initial Catalog=QuanLyQuanCafe;Integrated Security=True";

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();


            //tạo kết nối tới database
            // using khi mà kết thúc khối lệnh thì dữ liệu sẽ tự giải phóng
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                // cần chạy câu query để truy vấn
                connection.Open();

                // chạy câu thực thi câu truy vấn query trên data connection
                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                // Là thằng trung gian lấy dữ liệu nó ra
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                connection.Close();
            }
            return data;
        }

        // số dòng trả ra thành công
        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;


            //tạo kết nối tới database
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                // cần chạy câu query để truy vấn
                connection.Open();

                // chạy câu thực thi câu truy vấn query trên data connection
                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery(); // trả ra số dòng thành công

                connection.Close();
            }
            return data;
        }

        // đếm số lượng trả ra
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;


            //tạo kết nối tới database
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                // cần chạy câu query để truy vấn
                connection.Open();

                // chạy câu thực thi câu truy vấn query trên data connection
                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteScalar();

                connection.Close();
            }
            return data;
        }
    }
}
