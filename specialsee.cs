using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;


namespace eokul
{
    class specialsee
    {


        public void ReadMyData(string kall)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("Server=localhost;Database=eokul;Uid=root;Pwd='Usmanım';");

                string mySelectQuery = "select * from eokul.ogr_bilgileri where ogr_no=@x or ogr_ad=@z or ogr_soyad=@y or " +
                    "ogr_no=(select ogr_no from sınıf where ogrt_ad=@k ) or ogr_no=(select ogr_no from sınıf where sinifpuanı=@l )";
                    
                MySqlCommand myCommand = new MySqlCommand(mySelectQuery, conn);
                myCommand.Parameters.AddWithValue("@x", kall);
                myCommand.Parameters.AddWithValue("@z", kall);
                myCommand.Parameters.AddWithValue("@y", kall);
                myCommand.Parameters.AddWithValue("@k", kall);
                myCommand.Parameters.AddWithValue("@l", kall);

                conn.Open();
                MySqlDataReader myReader;
                myReader = myCommand.ExecuteReader();
                Console.WriteLine("----------------------------");
                Console.WriteLine("ÖĞRENCİ BİLGİLERİ");
                Console.WriteLine("İD ÖĞRENCİ--ÖĞRENCİ AD-ÖĞRENCİ SOYAD--ÖĞRENCİ NUAMARSI");

                while (myReader.Read())
                {
                    Console.WriteLine(myReader.GetInt32(0) + "--" + myReader.GetString(1)+"--"+myReader.GetString(2) + "--" + myReader.GetString(3));
                }
                myReader.Close();
                string myySelectQuery = "select * from eokul.sınıf where ogr_no =@x or " +
                    " ogr_no=(select ogr_no from ogr_bilgileri where ogr_ad=@z or ogr_soyad=@y ) or ogrt_ad=@k or sinifpuanı=@l";
                
                MySqlCommand myComand = new MySqlCommand(myySelectQuery, conn);
                myComand.Parameters.AddWithValue("@z", kall);
                myComand.Parameters.AddWithValue("@x", kall);
                myComand.Parameters.AddWithValue("@y", kall);
                myComand.Parameters.AddWithValue("@k", kall);
                myComand.Parameters.AddWithValue("@l", kall);



                MySqlDataReader mReader;
                mReader = myComand.ExecuteReader();
                Console.WriteLine("----------------------------");
                Console.WriteLine("SINIF BİLGİLERİ");
                Console.WriteLine("İDSINIF--ÖĞRETMEN ADI--SINIF PUANI--ÖĞRENCİ NUMARASI");
                while (mReader.Read())
                {
                    Console.WriteLine(mReader.GetInt32(0) + "--" + mReader.GetString(1) + "--" + mReader.GetString(2) + "--" + mReader.GetString(3));
                }
                conn.Close();
                Console.WriteLine("----------------------------");


            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }

        }
    }
}

