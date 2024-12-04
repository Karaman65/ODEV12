
class Dugum
{
    public int Deger { get; set; } // Düğümün taşıdığı değeri temsil eder.
    public List<Dugum> Ogrenciler { get; set; } // Düğümün bağlı alt düğümlerini (öğrencilerini) tutar.

    public Dugum(int deger)
    {
        Deger = deger; // Yeni bir düğüm oluşturulurken değer atanır.
        Ogrenciler = new List<Dugum>(); // Düğümün alt düğümleri için bir liste oluşturulur.
    }

    public void OgrenciEkle(Dugum yeniOgrenci)
    {
        Ogrenciler.Add(yeniOgrenci); // Mevcut düğüme yeni bir alt düğüm (öğrenci) eklenir.
    }

    public void AgaciYazdir(string girinti = "")
    {
        Console.WriteLine($"{girinti}- {Deger}"); // Düğümün değeri ekrana yazdırılır.
        foreach (var ogrenci in Ogrenciler) // Alt düğümler üzerinden döngüyle geçilir.
        {
            ogrenci.AgaciYazdir(girinti + "  "); // Alt düğümler artan girintiyle yazdırılır.
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Dugum kok = new Dugum(1); // Ağacın kök düğümü oluşturulur ve başlangıç değeri atanır.
        bool cikis = false; // Programın çalışmaya devam edip etmeyeceğini kontrol eden bayrak.

        Console.WriteLine("Kodlama Ağacına Hoşgeldiniz!"); // Kullanıcıya başlangıç mesajı.
        Console.WriteLine("Kök düğüm: 1"); // Kök düğümün değeri gösterilir.

        while (!cikis) // Çıkış yapılana kadar döngü devam eder.
        {
            Console.WriteLine("\nBir işlem seçin:"); // Kullanıcıya işlem seçenekleri sunulur.
            Console.WriteLine("1 - Yeni düğüm ekle"); // Yeni düğüm ekleme seçeneği.
            Console.WriteLine("2 - Ağacı göster"); // Ağacın yapısını gösterme seçeneği.
            Console.WriteLine("3 - Çıkış yap"); // Programdan çıkış yapma seçeneği.
            Console.Write("Seçiminiz: "); // Kullanıcıdan seçim alınır.

            string secim = Console.ReadLine(); // Kullanıcının seçimi okunur.

            if (secim == "1") // Seçim 1 ise yeni düğüm ekleme işlemi yapılır.
            {
                DugumEkle(kok); // Yeni düğüm eklemek için ilgili metod çağrılır.
            }
            else if (secim == "2") // Seçim 2 ise ağacın yapısı gösterilir.
            {
                Console.WriteLine("\nAğaç:"); // Ekrana ağacın başlık bilgisi yazılır.
                kok.AgaciYazdir(); // Kök düğümden başlayarak ağaç yapısı yazdırılır.
            }
            else if (secim == "3") // Seçim 3 ise programdan çıkılır.
            {
                cikis = true; // Çıkış bayrağı true yapılarak döngü sonlanır.
                Console.WriteLine("Çıkış yapılıyor..."); // Çıkış mesajı yazdırılır.
            }
            else // Geçersiz bir seçim yapılırsa:
            {
                Console.WriteLine("Geçersiz seçim, tekrar deneyin."); // Uyarı mesajı yazdırılır.
            }
        }
    }

    static void DugumEkle(Dugum kok)
    {
        Console.Write("\nHangi düğümün altına eklemek istiyorsunuz? (Düğüm Değeri): "); // Kullanıcıdan hedef düğüm değeri istenir.
        int anaDeger;
        if (int.TryParse(Console.ReadLine(), out anaDeger)) // Kullanıcının girdiği değer sayıya dönüştürülmeye çalışılır.
        {
            Dugum anaDugum = DugumBul(kok, anaDeger); // Hedef düğüm bulunmaya çalışılır.
            if (anaDugum != null) // Hedef düğüm varsa:
            {
                Console.Write("Yeni düğümün değerini girin: "); // Yeni düğümün değeri istenir.
                int yeniDeger;
                if (int.TryParse(Console.ReadLine(), out yeniDeger)) // Yeni düğümün değeri sayıya dönüştürülmeye çalışılır.
                {
                    anaDugum.OgrenciEkle(new Dugum(yeniDeger)); // Yeni düğüm hedef düğümün altına eklenir.
                    Console.WriteLine("Düğüm başarıyla eklendi!"); // Başarı mesajı yazdırılır.
                }
                else // Geçersiz bir değer girildiyse:
                {
                    Console.WriteLine("Geçersiz değer. Lütfen bir sayı girin."); // Uyarı mesajı yazdırılır.
                }
            }
            else // Hedef düğüm bulunamazsa:
            {
                Console.WriteLine("Belirttiğiniz düğüm bulunamadı."); // Uyarı mesajı yazdırılır.
            }
        }
        else // Kullanıcının girdiği değer sayıya dönüştürülemezse:
        {
            Console.WriteLine("Geçersiz değer. Lütfen bir sayı girin."); // Uyarı mesajı yazdırılır.
        }
    }

    static Dugum DugumBul(Dugum kok, int deger)
    {
        if (kok.Deger == deger) // Eğer düğümün değeri aranan değere eşitse:
        {
            return kok; // O düğüm döndürülür.
        }

        foreach (var ogrenci in kok.Ogrenciler) // Alt düğümlerin her biri üzerinde gezinilir.
        {
            Dugum sonuc = DugumBul(ogrenci, deger); // Alt düğümler içinde arama yapılır.
            if (sonuc != null) // Eğer aranan düğüm bulunursa:
            {
                return sonuc; // Bulunan düğüm döndürülür.
            }
        }

        return null; // Aranan düğüm bulunamazsa null döndürülür.
    }
}
