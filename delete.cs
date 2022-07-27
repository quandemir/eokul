using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace eokul
{
    internal class delete 
    {
        public void silme(string id)
        {
            dataview see = new dataview();
            
                // id kontrol yapılıp devam edliceek
                MySqlConnection conn4 = new MySqlConnection("server=localhost;user=root;database=eokul;port=3306;password=Usmanım");
                string sql = "select ogr_no  from ogr_bilgileri where ogr_no=@x";
                conn4.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn4);
                cmd.Parameters.AddWithValue("@x", id);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    dr.Close();
                    Console.WriteLine(id + "'ya sahip öğrenci var");
                    try
                    {
                        string sql4 = "delete FROM eokul.sınıf where ogr_no =@x";
                        MySqlCommand cmd4 = new MySqlCommand(sql4, conn4);
                        cmd4.Parameters.AddWithValue("@x", id);
                        cmd4.ExecuteNonQuery();
                        Console.WriteLine("öğrenci numarası " + id + "  olan sınıf bilgileri silindi ");

                        string sqll = "delete from eokul.ogr_bilgileri where ogr_no=@x;";
                        MySqlCommand cmdd = new MySqlCommand(sqll, conn4);
                        cmdd.Parameters.AddWithValue("@x", id);
                        cmdd.ExecuteNonQuery();
                        Console.WriteLine("öğrenci numarası " + id + "  olan öğrenci bilgileri silindi ");
                        conn4.Close();

                    }
                    catch (Exception err)
                    {
                        Console.WriteLine(err.ToString());
                    }
                }
                else
                {
                    Console.WriteLine(id + "'ya sahip öğrenci yokk");
                puha:
                    Console.WriteLine("NE YAPMAK İSTİYORSUN");
                    Console.WriteLine("1--TEKRAR ÖĞRENCİ NUMARASI GİRİNİZ");
                    Console.WriteLine("2--TÜM TABLOYU GÖRMEK");
                    Console.WriteLine("3--ÇIKIŞ YAPMAK");
                    string asa=Console.ReadLine();
                    if(asa == "1") 
                    {
                    Console.WriteLine("TEKRAR ÖĞRENCİ NUMARASI GİRİNİZ");
                    string idd = Console.ReadLine();
                    silme(idd);
                    }
                    else if(asa == "2") { see.fullgörme(); }
                    else if (asa == "3") { Environment.Exit(0); }
                    else
                    {
                    Console.WriteLine("hatalı giriş yaptınız");
                    goto puha;
                }
                    
                }
            




        }
    }
}
