using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace eokul
{
    
    internal class Program
    {
        
        static void Main(string[] args)
        {


        hatay_durum:
            Console.WriteLine("========================================");
            Console.WriteLine("-----NE YAPMAK İSTİYORSUNUZ ?-----|");
            Console.WriteLine("1--YENİ KAYIT YAPMAK ");
            Console.WriteLine("2--KAYIT GÜNCELLEMEK ");
            Console.WriteLine("3--KAYIT GÖRMEK");
            Console.WriteLine("4--KAYIT SİL ");
            Console.WriteLine("5--ÇIKIŞ");
            Console.WriteLine("========================================");
            string secim = Console.ReadLine();

            DB_connect db_kontrol = new DB_connect();
            insert ekleme = new insert();
            dataview see = new dataview();
            specialsee specialsee = new specialsee();
            delete sil = new delete();
            update güncelleme = new update();


            if (secim == "1")
            {
                db_kontrol.baglanti_kontrol();
                ekleme.ekle();
                goto hatay_durum;
            }


            else if (secim == "2")
            {
            ttt:
                Console.WriteLine("GÜNCELLEME YAPMAK İSTEDİĞİNİZ ÖĞRENCİNİN NUMARASINI GİRİNİZ");
                string id = Console.ReadLine();

                if (String.IsNullOrEmpty(id))
                {
                    Console.WriteLine("!!!BOŞ DEĞER GİRDİNİZ");
                    Console.WriteLine("NE YAPMAK İSTİYORSUNUZ");
                    Console.WriteLine("11--tüm tabloyu görmek");
                    Console.WriteLine("12--tekrar öğrenci numarası girmek");
                    Console.WriteLine("13--en başa dönmek");
                    Console.WriteLine("14--çıkış yapmak");
                    string xnxx = Console.ReadLine();
                    if (xnxx == "11")
                    { see.fullgörme(); }
                    else if (xnxx == "12") { goto ttt; }
                    else if(xnxx == "13") { goto hatay_durum; }
                    else
                    { Environment.Exit(0); }
                }
                güncelleme.kontrol(id);
                goto hatay_durum;
            }


            else if (secim == "3")
            {
            pıpı:
                Console.WriteLine("========================================");
                Console.WriteLine("31--TÜM BŞİLGİLERİ GÖRMEK İSTİYORUM");
                Console.WriteLine("32--ÖZEL BİLGİYE GÖRE GÖRMEK İSTİYORUM ");
                Console.WriteLine("33--EN BAŞA DÖNMEK İSTİYORUM ");
                Console.WriteLine("34--ÇIKIŞ YAPMAK  İSTİYORUM ");
                
                Console.WriteLine("========================================");
                string secim2 = Console.ReadLine();
                Console.WriteLine("========================================");
                if (secim2 == "31")
                {

                    see.fullgörme();
                    goto pıpı;
                }
                else if (secim2 == "32")
                {
                ppp:
                    Console.WriteLine("========================================");
                    Console.WriteLine("HANGİ ÖZEL BİLGİYE GÖRE GÖRMEK İSTİYORSUNUZ");
                    Console.WriteLine("1--ÖĞRENCİ NUMARASINI GÖRE");
                    Console.WriteLine("2--ÖĞRENCİ ADINA GÖRE");
                    Console.WriteLine("3--ÖĞRENCİ SOYADINA GÖRE");
                    Console.WriteLine("4--ÖĞRETMEN ADINA GÖRE");
                    Console.WriteLine("5--SINIF PUANINA GÖRE");
                    Console.WriteLine("6--TÜM BİLGİLERİ TEKRAR GÖRMEK İSTİYORUM");
                    Console.WriteLine("7--ÇIKIŞ YAPMAK İSTİYORUM");
                    Console.WriteLine("========================================");
                    String bbb = Console.ReadLine();
                    if (bbb == "1")
                    {

                    aaa:

                        try
                        {
                            Console.WriteLine("öğrenci numarasını giriniz");
                            string no = Console.ReadLine();
                            if(String.IsNullOrEmpty(no)) 
                            {
                                Console.WriteLine("!!!BOŞ DEĞER GİRDİNİZ");
                                Console.WriteLine("NE YAPMAK İSTİYORSUNUZ");
                                Console.WriteLine("11--tüm tabloyu görmek");
                                Console.WriteLine("12--tekrar numara girmek");
                                Console.WriteLine("13--çıkış yapmak");
                                string xnxx = Console.ReadLine();
                                if (xnxx == "11")
                                { see.fullgörme(); }
                                else if (xnxx == "12") { goto aaa; }
                                else
                                { Environment.Exit(0); }
                            }
                            else
                            {
                                specialsee.ReadMyData(no);
                            }
                            
                        }
                        catch (FormatException err)
                        {
                            Console.WriteLine(err.Message);
                        }

                    }
                    else if (bbb == "2")
                    {
                        
                    kkk:
                        try
                        {
                            Console.WriteLine("öğrenci adını giriniz");
                            string ad = Console.ReadLine();
                            if (String.IsNullOrEmpty(ad))
                            {
                                Console.WriteLine("!!!BOŞ DEĞER GİRDİNİZ");
                                Console.WriteLine("NE YAPMAK İSTİYORSUNUZ");
                                Console.WriteLine("11--tüm tabloyu görmek");
                                Console.WriteLine("12--tekrar ad girmek");
                                Console.WriteLine("13--çıkış yapmak");
                                string xnxx = Console.ReadLine();
                                if (xnxx == "11")
                                { see.fullgörme(); }
                                else if (xnxx == "12") { goto kkk; }
                                else
                                { Environment.Exit(0); }
                            }
                            else
                            {
                                specialsee.ReadMyData(ad);
                            }

                        }
                        catch (FormatException err)
                        {
                            Console.WriteLine(err.Message);
                        }
                    }

                    else if (bbb == "3") 
                    {
                    ttt:
                        try
                        {
                            Console.WriteLine("öğrenci adını giriniz");
                            string ogr_soyad = Console.ReadLine();
                            if (String.IsNullOrEmpty(ogr_soyad))
                            {
                                Console.WriteLine("!!!BOŞ DEĞER GİRDİNİZ");
                                Console.WriteLine("NE YAPMAK İSTİYORSUNUZ");
                                Console.WriteLine("11--tüm tabloyu görmek");
                                Console.WriteLine("12--tekrar soyadad girmek");
                                Console.WriteLine("13--çıkış yapmak");
                                string xnxx = Console.ReadLine();
                                if (xnxx == "11")
                                { see.fullgörme(); }
                                else if (xnxx == "12") { goto ttt; }
                                else
                                { Environment.Exit(0); }
                            }
                            else
                            {
                                specialsee.ReadMyData(ogr_soyad);
                            }
                        }
                        catch (FormatException err)
                        {
                            Console.WriteLine(err.Message);
                        }
                    }
                    
                    
                    
                    else if (bbb == "4")
                    {
                    ttt:
                        try
                        {
                            Console.WriteLine("öğretmen adını giriniz");
                            string ogrt_ad = Console.ReadLine();
                            if (String.IsNullOrEmpty(ogrt_ad))
                            {
                                Console.WriteLine("!!!BOŞ DEĞER GİRDİNİZ");
                                Console.WriteLine("NE YAPMAK İSTİYORSUNUZ");
                                Console.WriteLine("11--tüm tabloyu görmek");
                                Console.WriteLine("12--tekrar öğretmen adını  girmek");
                                Console.WriteLine("13--çıkış yapmak");
                                string xnxx = Console.ReadLine();
                                if (xnxx == "11")
                                { see.fullgörme(); }
                                else if (xnxx == "12") { goto ttt; }
                                else
                                { Environment.Exit(0); }
                            }
                            else
                            {
                                specialsee.ReadMyData(ogrt_ad);
                            }
                        }
                        catch (FormatException err)
                        {
                            Console.WriteLine(err.Message);
                        }
                    }
                    else if (bbb == "5")
                    {
                    ttt:
                        try
                        {
                            Console.WriteLine("öğrenci sınıf puanını  giriniz");
                            string sınıfpuanı = Console.ReadLine();
                            if (String.IsNullOrEmpty(sınıfpuanı))
                            {
                                Console.WriteLine("!!!BOŞ DEĞER GİRDİNİZ");
                                Console.WriteLine("NE YAPMAK İSTİYORSUNUZ");
                                Console.WriteLine("11--tüm tabloyu görmek");
                                Console.WriteLine("12--tekrar sınıf puanını girmek");
                                Console.WriteLine("13--çıkış yapmak");
                                string xnxx = Console.ReadLine();
                                if (xnxx == "11")
                                { see.fullgörme(); }
                                else if (xnxx == "12") { goto ttt; }
                                else
                                { Environment.Exit(0); }
                            }
                            else
                            {
                                specialsee.ReadMyData(sınıfpuanı);
                            }
                        }
                        catch (FormatException err)
                        {
                            Console.WriteLine(err.Message);
                        }
                    }
                    else if (bbb == "6") { see.fullgörme(); }
                    else if (bbb == "7") { Environment.Exit(0); }
                    else
                    {
                        Console.WriteLine("Hatalı bir veri girdiniz...");
                        goto ppp;
                    }
                    goto pıpı;
                }
                else if(secim2 == "33") { goto hatay_durum; }
                else if (secim2 == "34")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Hatalı bir veri girdiniz...");
                    goto pıpı;
                }
                goto hatay_durum;
            }


            else if (secim == "4")
            {
            kjk:
                Console.WriteLine("silmek istediğin öğrencinin numarasını giriniz");
                string id =Console.ReadLine();
            
                if (String.IsNullOrEmpty(id))
                {
                kkk:
                    Console.WriteLine("hiçbir değer girmediniz");
                    Console.WriteLine("ne yapmak istersiniz");
                    Console.WriteLine("1--tüm tabloyu görmek ");
                    Console.WriteLine("2--tekrar numara girmek");
                    Console.WriteLine("3--çıkış yapmak");
                    string ggg = Console.ReadLine();
                    if (ggg == "1") { see.fullgörme(); }
                    else if (ggg == "2") { goto kjk; }
                    else if (ggg == "3") { Environment.Exit(0); }
                    else
                    {
                        Console.WriteLine("hatalı giriş yaptınız");
                        goto kkk;
                    }
                }
                sil.silme(id);
                goto hatay_durum;
            }


            else if (secim == "5")
            {
                Environment.Exit(0);
            }


            else
            {
                Console.WriteLine("Hatalı bir veri girdiniz...");
                goto hatay_durum;
            }


        }
    }
}
