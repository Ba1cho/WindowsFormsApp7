using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp7
{
    class DataBase
    {
        SqlConnection sqlConnect = new SqlConnection(@"Data Source=DESKTOP-BPLHA3P;Initial Catalog=ДоговорыDB;Integrated Security=True");

        public void openConection()
        {
            if(sqlConnect.State == System.Data.ConnectionState.Closed)
            {
                sqlConnect.Open();
            }
        }
        public void closeConection()
        {
            if (sqlConnect.State == System.Data.ConnectionState.Open)
            {
                sqlConnect.Close();
            }
        }
        public SqlConnection getConnect()
        {
            return sqlConnect;
        }
    }
}
