Ez a feladat egy tipikus emelt szintű szoftverfejlesztői vizsgafeladat. Az alábbiakban lépésről lépésre bemutatom a megoldást a kért kódokkal és rövid magyarázatokkal.

### Megoldás lépései

1.  **Modell osztályok (2. feladat):** Létrehozzuk a `Category`, `Seller` és `Ad` osztályokat a diagram alapján.
2.  **Konstruktor és Adatbetöltés (3-5. feladat):** Az `Ad` osztályba elkészítjük a konstruktort és a `LoadFromCsv` metódust, ami beolvassa a fájlt.
3.  **Átlagkeresés (6. feladat):** Megszámoljuk a földszinti (`Floors == 0`) ingatlanokat és kiszámoljuk az átlagos területüket.
4.  **Távolság számítás (7. feladat):** Implementáljuk a Pitagorasz-tételt a koordináták különbségére.
5.  **Legközelebbi keresése (8. feladat):** Megkeressük azt a **tehermentes** (`FreeOfCharge == true`) ingatlant, amely a legkisebb távolságra van a megadott ponttól.

---

### A teljes forráskód (Program.cs)

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;

namespace RealEstate
{
    // 2. feladat: Modell osztályok létrehozása
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }

    public class Ad
    {
        public int Id { get; set; }
        public int Rooms { get; set; }
        public string LatLong { get; set; }
        public int Floors { get; set; }
        public int Area { get; set; }
        public string Description { get; set; }
        public bool FreeOfCharge { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreateAt { get; set; }
        public Seller Seller { get; set; }
        public Category Category { get; set; }

        // 4. feladat: Konstruktor az adatok beállításához
        public Ad(int id, int rooms, string latLong, int floors, int area, string description, bool freeOfCharge, string imageUrl, DateTime createAt, Seller seller, Category category)
        {
            Id = id;
            Rooms = rooms;
            LatLong = latLong;
            Floors = floors;
            Area = area;
            Description = description;
            FreeOfCharge = freeOfCharge;
            ImageUrl = imageUrl;
            CreateAt = createAt;
            Seller = seller;
            Category = category;
        }

        // 3. feladat: Statikus metódus a CSV betöltéséhez
        public static List<Ad> LoadFromCsv(string filename)
        {
            List<Ad> ads = new List<Ad>();
            string[] lines = File.ReadAllLines(filename);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] v = lines[i].Split(';');
                
                // Objektumok példányosítása a sor adatai alapján
                Seller s = new Seller { Id = int.Parse(v[9]), Name = v[10], Phone = v[11] };
                Category c = new Category { Id = int.Parse(v[12]), Name = v[13] };

                Ad ad = new Ad(
                    int.Parse(v[0]), v[1] == "" ? 0 : int.Parse(v[1]), v[2], int.Parse(v[3]), int.Parse(v[4]),
                    v[5], v[6] == "1", v[7], DateTime.Parse(v[8]), s, c
                );
                ads.Add(ad);
            }
            return ads;
        }

        // 7. feladat: Távolság számítása Pitagorasz-tétellel
        public double DistanceTo(string targetLatLong)
        {
            var p1 = this.LatLong.Split(',');
            var p2 = targetLatLong.Split(',');

            double x1 = double.Parse(p1[0], CultureInfo.InvariantCulture);
            double y1 = double.Parse(p1[1], CultureInfo.InvariantCulture);
            double x2 = double.Parse(p2[0], CultureInfo.InvariantCulture);
            double y2 = double.Parse(p2[1], CultureInfo.InvariantCulture);

            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 5. feladat: Adatok beolvasása
            List<Ad> ads = Ad.LoadFromCsv("realestates.csv");

            // 6. feladat: Földszinti ingatlanok átlagos alapterülete
            var groundFloors = ads.Where(a => a.Floors == 0).ToList();
            if (groundFloors.Any())
            {
                double averageArea = groundFloors.Average(a => a.Area);
                Console.WriteLine($"1. Földszinti ingatlanok átlagos alapterülete: {averageArea:0.00} m2");
            }

            // 8. feladat: Legközelebbi tehermentes ingatlan keresése
            string oviCoord = "47.4164220114023,19.066342425796986";
            
            // Csak a tehermentesek (FreeOfCharge == true) közül válogatunk
            Ad minAd = ads.Where(a => a.FreeOfCharge)
                          .OrderBy(a => a.DistanceTo(oviCoord))
                          .FirstOrDefault();

            if (minAd != null)
            {
                Console.WriteLine("2. Mesevár óvodához légvonalban legközelebbi tehermentes ingatlan adatai:");
                Console.WriteLine($"\tEladó neve      : {minAd.Seller.Name}");
                Console.WriteLine($"\tEladó telefonja : {minAd.Seller.Phone}");
                Console.WriteLine($"\tAlapterület     : {minAd.Area}");
                Console.WriteLine($"\tSzobák száma    : {minAd.Rooms}");
            }

            Console.ReadKey();
        }
    }
}
```

### Magyarázat a megoldáshoz:

*   **3. feladat (`LoadFromCsv`):** A `File.ReadAllLines` beolvassa a fájlt, a `Split(';')` pedig darabolja a sorokat. Mivel a fájl első sora fejléc, a ciklust az 1. indextől indítjuk.
*   **6. feladat (Átlag):** A LINQ `Where` és `Average` függvényeit használtam a tömörség kedvéért. A feltétel a `Floors == 0` (földszint). Az eredményt a `:0.00` formátumkóddal kerekítjük két tizedesre.
*   **7. feladat (`DistanceTo`):** Fontos a `CultureInfo.InvariantCulture` használata a `double.Parse`-nál, mert a CSV-ben pont a tizedesjel, de a magyar Windows vesszőt várna alapból. A képlet: $\sqrt{(x_1-x_2)^2 + (y_1-y_2)^2}$.
*   **8. feladat (Keresés):** Két fontos feltétel van: 
    1.  **Tehermentes** legyen (`FreeOfCharge == true`).
    2.  A **legkisebb távolságú** legyen. A kódban az `OrderBy` rendezi távolság szerint növekvőbe, a `FirstOrDefault` pedig kiveszi a legelsőt (a legkisebbet).