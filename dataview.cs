using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace eokul
{
    internal class dataview
    {
        public void fullgörme()
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=eokul;port=3306;password=Usmanım");
            try
            {
                
                Console.WriteLine("MySQL'e bağlanılıyor...");
                conn.Open();
                string sql = "select * from eokul.ogr_bilgileri ;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                Console.WriteLine("-----ÖĞRENCİ BİLGİLERİ-----");
                Console.WriteLine("idogr_bilgileri--ADI--SOYADI--ÖĞRENCİ NUMARASI ");

                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0] + " -- " + rdr[1] + " -- " + rdr[2] + "--" + rdr[3] );

                }
                rdr.Close();
                
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }
            try
            {
                string sqll = "select * from eokul.sınıf ;";
                MySqlCommand cmmd = new MySqlCommand(sqll, conn);
                MySqlDataReader rd = cmmd.ExecuteReader();
                Console.WriteLine("----SINIF BİLGİLERİ----");
                Console.WriteLine("idsınıf--SINIF ÖĞRETMENİNİN ADI--SINIF PUANI--ÖĞRENCİ NUMARASI");

                while (rd.Read())
                {
                    Console.WriteLine(rd[0] + " -- " + rd[1] + " -- " + rd[2] + "--" + rd[3]);

                }
                rd.Close();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }
        }
    }
}
