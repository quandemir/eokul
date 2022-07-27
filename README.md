# eokul
MySql Workbench version 8.0.29 kurmalısın 
     -- mysql workbence gir ve bir sorgu aç
      
      // yeni database oluşturuyoruz
      create database eokul
      
      //oluşturduğumuz databasei kullanıyoruz
      use eokul
       
      // ogr_bilgileri tablosunu oluşturuyoruz
      CREATE TABLE eokul.ogr_bilgileri (
      idogr_bilgileri INT NOT NULL AUTO_INCREMENT,
      ogr_ad VARCHAR(45) NOT NULL,
      ogr_soyad VARCHAR(45) NOT NULL,
      ogr_no INT NOT NULL,
      PRIMARY KEY (idogr_bilgileri));
      
      //sınıf tablosunu oluşturuyoruz
      CREATE TABLE eokul.sınıf (
      idsınıf INT NOT NULL AUTO_INCREMENT,
      ogrt_ad VARCHAR(45) NOT NULL,
      sinifpuanı INT NOT NULL,
      ogr_no INT NOT NULL,
      PRIMARY KEY (`idsınıf`));
  
visual studio 2022 kurmalısın 
