using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace eokul
{
    class DB_connect
    {
        MySqlConnection conn;

        public void baglanti_kontrol()
        {
           
            try
            {
                conn = new MySqlConnection("Server=localhost;Database=eokul;Uid=root;Pwd='Usmanım';");
                conn.Open();
                Console.WriteLine("bağlantı başarılı");
            }

            catch (Exception)
            {
                Console.WriteLine("bağlantı başarısız");
            }
        }
    }
}
