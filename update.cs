using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace eokul
{
    internal class update
    {
        
        public void kontrol(string ogr_no)
        {
            insert ekleme=new insert();
            dataview see = new dataview();
            update idkontrol = new update();
            try
            {
                
                MySqlConnection conn = new MySqlConnection("Server=localhost;Database=eokul;Uid=root;Pwd='Usmanım';");
                conn.Open();
                string sql = "select ogr_no  from ogr_bilgileri where ogr_no=@x";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@x", ogr_no);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    
                    Console.WriteLine(ogr_no + "'ya sahip öğrenci var");
                lkl:
                    Console.WriteLine("NE YAPMAK İSTİYORSUNUZ");
                    Console.WriteLine("1--GÜNCELLEME YAPMAK İSTİYORUM");
                    Console.WriteLine("2--ÇIKIŞ YAPMAK İSTİYORUM ");
                    string kjk = Console.ReadLine();
                    if(kjk == "1")
                    {
                        
                        try
                        {
                            bas:
                            try
                            {
                                dr.Close();
                                Console.Write("SINIF PUANINI GİRİNİZ;");
                                int sınıfpuanı = Convert.ToInt32(Console.ReadLine());
                                xcx:
                                Console.Write("ÖĞRENCİ ADINI GİRİNİZ:");
                                string ogr_ad = Console.ReadLine();
                                if (String.IsNullOrEmpty(ogr_ad))
                                {
                                    Console.WriteLine("boş değer girdiniz");
                                    Console.WriteLine("tekrar değer giriniz");
                                    goto xcx;
                                }
                                xc:
                                Console.Write("ÖĞRENCİ SOYADINI GİRİNİZ:");
                                string ogr_soyad = Console.ReadLine();
                                if (String.IsNullOrEmpty(ogr_soyad))
                                {
                                    Console.WriteLine("boş değer girdiniz");
                                    Console.WriteLine("tekrar değer giriniz");
                                    goto xc;
                                }
                                xcxx:
                                Console.Write("SINIF ÖĞRETMENİNİN ADINI GİRİNİZ:");
                                string ogrt_ad = Console.ReadLine();
                                if (String.IsNullOrEmpty(ogr_ad))
                                {
                                    Console.WriteLine("boş değer girdiniz");
                                    Console.WriteLine("tekrar değer giriniz");
                                    goto xcxx;
                                }
                            nm:
                                Console.Write("ÖĞRENCİ NUMARASI GİRİNİZ(güncellemek istemiyorsanız enter a basın);");
                                string ogr_noo = Console.ReadLine();
                                if (String.IsNullOrEmpty(ogr_noo)) 
                                {
                                    ogr_noo = ogr_no;
                                }
                                else
                                {
                                    string sql8 = "select ogr_no  from ogr_bilgileri where ogr_no=@p";
                                    MySqlCommand cmd8 = new MySqlCommand(sql8, conn);
                                    cmd8.Parameters.AddWithValue("@p", ogr_noo);
                                    MySqlDataReader dr8 = cmd8.ExecuteReader();
                                    if (dr8.Read() == true)
                                    { 
                                        dr8.Close();
                                        Console.WriteLine(ogr_noo + " numaralı öğrenci var");
                                        Console.WriteLine("aynı numaralı öğrenci olamaz");
                                        Console.WriteLine("tekrar öğrenci numarası giriniz");
                                        goto nm;
                                    }
                                    dr8.Close();
                                }
                                                              
                               



                                string sqlup = "update eokul.ogr_bilgileri set ogr_ad=@p,ogr_soyad=@r,ogr_no=@s where ogr_no=@t";
                                MySqlCommand cmdd = new MySqlCommand(sqlup, conn);
                                cmdd.Parameters.AddWithValue("@p", ogr_ad);
                                cmdd.Parameters.AddWithValue("@r", ogr_soyad);
                                cmdd.Parameters.AddWithValue("@s", ogr_noo);
                                cmdd.Parameters.AddWithValue("@t", ogr_no);
                                MySqlDataReader drr = cmdd.ExecuteReader();
                                while (drr.Read()) { }
                                drr.Close();
                                string sqlupp = "update eokul.sınıf set ogrt_ad=@f,sinifpuanı=@g,ogr_no=@h where ogr_no=@j";
                                MySqlCommand cmddd = new MySqlCommand(sqlupp, conn);
                                cmddd.Parameters.AddWithValue("@f", ogrt_ad);
                                cmddd.Parameters.AddWithValue("@g",sınıfpuanı);
                                cmddd.Parameters.AddWithValue("@h", ogr_noo);
                                cmddd.Parameters.AddWithValue("@j", ogr_no);
                                MySqlDataReader drrr = cmddd.ExecuteReader();
                                while (drrr.Read()) { }
                                conn.Close();
                                Console.WriteLine("VERİLER GÜNCELLENDİ");

                            }
                            catch (FormatException err)
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
                                string xx = Console.ReadLine();
                                if (xx == "1") { goto bas; }
                                else if (xx == "2") { Environment.Exit(0); }
                                else
                                {
                                    Console.WriteLine("Hatalı bir veri girdiniz...");
                                    goto sonn;
                                }


                            }
                            
                        }
                        catch (Exception err)
                        {
                            Console.WriteLine(err.ToString());
                        }

                    }
                    else if(kjk == "2") { Environment.Exit(0); }
                    else 
                    {
                        Console.WriteLine("hatalı giriş yaptınız");
                        goto lkl;
                   
                    }
                   

                }
                else
                {
                    Console.WriteLine(ogr_no + "'ya sahip öğrenci YOKKK");
                    lkll:
                    Console.WriteLine("NE YAPMAK İSTİYORSUNUZ");
                    Console.WriteLine("1--YENİ KAYIT YAPMAK İSTİYORUM");
                    Console.WriteLine("2--TABLOYU GÖRMEK İSTİYORUM ");
                    Console.WriteLine("3--TEKRAR ÖĞRENCİ NUMARASI GİRMEK İSTİYORUM ");
                    Console.WriteLine("4--ÇIKIŞ YAPMAK İSTİYORUM ");
                    string kj = Console.ReadLine();
                    if (kj == "1")
                    {
                        ekleme.ekle();
                    }
                    else if (kj == "2")
                    {
                        see.fullgörme();
                    }
                    else if (kj == "3") 
                    {
                        Console.WriteLine("öğrenci numarası giriniz");
                        string ogr_noo=Console.ReadLine();
                        idkontrol.kontrol(ogr_noo);
                    }
                    else if (kj == "4") { Environment.Exit(0); }
                    else
                    {
                        Console.WriteLine("hatalı giriş yaptınız");
                        goto lkll;
                    }
                    
                }

            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }
        }
    }
}
