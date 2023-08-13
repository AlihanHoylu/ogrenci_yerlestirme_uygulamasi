using System;
using System.Linq;
using System.Diagnostics.Contracts;


namespace Ogrenci;


public static class Program


{
	public static int ogrencisayi;
	public static string[] ogrenci;
	public static string okulismi;
	public static int sinifsayisi;
	public static int sinifoturaksayisi;
	public static Okulcuk yeniokul = new Okulcuk();
	public static int ation;
	public static int test=0;
	public static int[] gelenler;



	public static void Main()
    {
      // Console.Clear();
	Console.WriteLine("-------------------------------------------------------");
    Console.WriteLine("ogrenci yerlestirme uygulamasina hosgeldiniz...");
	Console.WriteLine("ogrencieri tanimlamak icin 1 tuslayiniz...");
	Console.WriteLine("okul tanimlamak icin 2 tuslayiniz...");
	Console.WriteLine("ogrencileri listelemek icin 3 tuslayiniz...");
	Console.WriteLine("okul bilgilerini listelemek icin 4 tuslayiniz...");
	Console.WriteLine("ogrencileri yerlestirmek icin 5 tuslayiniz....");
	Console.WriteLine("ogrenci oturma nolarini listelemek icin 6 tuslayiniz...");
	Console.WriteLine("20 kisilik ogrenci listesi ve 20 kisilik sinif olusturmak icin 7 tuslayiniz...");
	Console.WriteLine("--------------------------------------------------------");	
        ation = Convert.ToInt32(Console.ReadLine());
        
		Console.Clear();
		if (ation == 1)
		{
			ogrenciolustur();
		}

		if (ation == 2)
		{
			okulolustur();
		}


		if (ation == 3)
		{
			ogrenciyaz();
		}

		if (ation == 4)
		{
			okuozellik();
		}
		if (ation == 5)
		{

			yerlestir();

		}
		if (ation == 7)
		{
			yirmiogrenci();
		}
		if(ation == 6)
		{
			fast();
		}
		

	}



	public static void ogrenciolustur()
	{



		Console.WriteLine("ogrenci sayisini giriniz...");
		ogrencisayi = Convert.ToInt32(Console.ReadLine());
		ogrenci = new String[ogrencisayi];

		for (int i = 0; i < ogrencisayi; i++)
		{
			Console.WriteLine(Convert.ToString(i + 1) + " numarali ogrencinin ismini girin");
			ogrenci[i] = Console.ReadLine();
			Nsan yeniinsan = new Nsan(ogrenci[i]);
		}
		Console.WriteLine(ogrencisayi + " ogrenci girildi");

		Main();
	}


	public static void yirmiogrenci()
	{
		ogrencisayi = 20;
		ogrenci = new String[] { "ali", "veli", "kerem", "ahmet", "zeynep", "aybuke", "muhammet", "sila", "hamza", "zisan", "samet", "murat", "yigit", "kazim", "zeren", "petek", "lara", "jake", "nejat", "behzat" };
		Console.WriteLine("20'lik liste olusturuldu");
		okulismi = "20 kislik sinif";

		sinifsayisi = 1;

		sinifoturaksayisi = 20;
		yeniokul.isimokul = okulismi;
		yeniokul.sinifsayi = sinifsayisi;
		yeniokul.sinifkoltuk = sinifoturaksayisi;
		yeniokul.toplamkoltuk = sinifoturaksayisi * sinifsayisi;
		Main();
	}




	public static void okulolustur()
	{
		Console.WriteLine("Okulun ismini giriniz");
		okulismi = Console.ReadLine();
		Console.WriteLine("Okulun sinif sayisini giriniz");
		sinifsayisi = Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("Okulun siniflarinin koltuk sayisini giriniz");
		sinifoturaksayisi = Convert.ToInt32(Console.ReadLine());
		yeniokul.isimokul = okulismi;
		yeniokul.sinifsayi = sinifsayisi;
		yeniokul.sinifkoltuk = sinifoturaksayisi;
		yeniokul.toplamkoltuk = sinifoturaksayisi * sinifsayisi;

		Main();


	}

	public static void ogrenciyaz()
	{
		for (int z = 0; z < ogrencisayi; z++)
		{

			Console.WriteLine(ogrenci[z]);

		}
		Main();

	}
	public static void okuozellik()
	{
		Console.WriteLine("okul ismi " + yeniokul.isimokul);
		Console.WriteLine("okul sinif sayisi " + yeniokul.sinifsayi);
		Console.WriteLine("okul siniflardaki koltuk sayisi " + yeniokul.sinifkoltuk);
		Console.WriteLine("okul daki toplam oturak sayisi " + yeniokul.toplamkoltuk);
		Main();
	}

	public static void fast()
	{
		for(int z = 0;z<ogrencisayi;z++)
		{
		Console.Write(ogrenci[z]);
		Console.Write(" ");
		Console.WriteLine(gelenler[z]);
		
		}
		Main();
	}

	public static void yerlestir()
	{
		int sinif;
		int koltuk;
		
		bool kontrol = false;
		gelenler = new int[ogrencisayi];


		for (int i = 0; i < ogrencisayi; i++)
		{


			Nsan insancik = new Nsan(ogrenci[i]);


			Random rnd = new Random();

			insancik.no = rnd.Next(yeniokul.toplamkoltuk);
			insancik.no++;

			gelenler[i] = insancik.no;
			
			for(int b = 0; b < i;b++)
            {

			 if(gelenler[i]==gelenler[b])
			 {

				kontrol=true;
				while(kontrol==true)
				{
					test=0;
					insancik.no=rnd.Next(yeniokul.toplamkoltuk);

                    insancik.no++;
					gelenler[i]=insancik.no;
					//Console.WriteLine(insancik.no);
					for(int c = 0;c<i;c++)
					{
						if(gelenler[i]==gelenler[c])
						{
							test=1;
						}

					}
					if(test==0)
					{
						kontrol=false;
					}
					else
					{
					test = 0;
					kontrol=true;
					}
					
					
				}

			 }


            }




            //Console.WriteLine(insancik.no);

			sinif = ((((insancik.no / yeniokul.sinifkoltuk) * 10000) - 1) / 10000) + 1;

			koltuk = (insancik.no - (sinif - 1) * yeniokul.sinifkoltuk);
			if (koltuk > yeniokul.sinifkoltuk)
			{
				koltuk = koltuk - yeniokul.sinifkoltuk;
				sinif++;

			}
			Console.WriteLine(ogrenci[i] + " isimli ogrenci ");
			Console.WriteLine(yeniokul.isimokul + " isimli okul ");
			Console.WriteLine(sinif + " numarali sinif ");
			Console.WriteLine(koltuk + " numarali koltuk ");
			Console.WriteLine("---------------------------");


		}
		Main();

	}
}
