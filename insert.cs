using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;


namespace eokul
{
    class insert
    {
        public void ekle()
        {
        bas:
            try
            {

                Console.Write("SINIF PUANINI GİRİNİZ;");
                int sınıfpuanı = Convert.ToInt32(Console.ReadLine());
                Console.Write("SINIF ÖĞRETMENİNİN ADINI GİRİNİZ:");
                string ogrt_ad = Console.ReadLine();
                Console.Write("ÖĞRENCİ NUMARASINI GİRİNİZ:");
                int ogr_no = Convert.ToInt32(Console.ReadLine());
                Console.Write("ÖĞRENCİ ADINI GİRİNİZ:");
                string ogr_ad = Console.ReadLine();
                Console.Write("ÖĞRENCİ SOYADINI GİRİNİZ:");
                string ogr_soyad = Console.ReadLine();
                


                try
                {
                    MySqlConnection conn = new MySqlConnection("Server=localhost;Database=eokul;Uid=root;Pwd='Usmanım';");
                    conn.Open();
                    string sql = "INSERT INTO eokul.sınıf(ogrt_ad,sinifpuanı,ogr_no) values(@x,@y,@z)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@x", ogrt_ad);
                    cmd.Parameters.AddWithValue("@y", sınıfpuanı);
                    cmd.Parameters.AddWithValue("@z", ogr_no);

                    cmd.ExecuteNonQuery();
                    string sqll = "INSERT INTO eokul.ogr_bilgileri(ogr_ad,ogr_soyad,ogr_no) values(@k,@l,@n)";
                    MySqlCommand cd = new MySqlCommand(sqll, conn);
                    cd.Parameters.AddWithValue("@k", ogr_ad);
                    cd.Parameters.AddWithValue("@l", ogr_soyad);
                    cd.Parameters.AddWithValue("@n", ogr_no);

                    cd.ExecuteNonQuery();
                    Console.WriteLine("bilgiler başarıyla eklendi");
                    conn.Close();
                }
                catch (Exception err)
                {
                    Console.WriteLine("bilgiler eklenemedi");
                    Console.Write("nedeni --->" + err.Message);

                }
            }
            catch(FormatException err)
            {
                Console.WriteLine("!!!!!!!!!!!!!!!");
                Console.WriteLine(err.Message);
                Console.WriteLine("!!!!!!!!!!!!!!!");
            sonn:
                Console.WriteLine("--------------------------");
                Console.WriteLine("NE YAPMAK İSTİYORSUN");
                Console.WriteLine("1--VERİLERİ TEKRAR GİRMEK");
                Console.WriteLine("2--ÇIKIŞ YAPMAK");
                Console.WriteLine("--------------------------");
                string xx=Console.ReadLine();
                if (xx == "1") { goto bas; }
                else if(xx== "2") { Environment.Exit(0); }
                else 
                {
                    Console.WriteLine("Hatalı bir veri girdiniz...");
                    goto sonn; 
                }


            }

        }
    }
}
