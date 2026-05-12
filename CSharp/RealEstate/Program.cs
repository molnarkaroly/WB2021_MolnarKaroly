using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RealEstate
{
    // Minden osztály legyen public az elérhetőség miatt!
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
        public int Area { get; set; }
        public Category Category { get; set; }
        public DateTime CreateAt { get; set; }
        public string Description { get; set; }
        public int Floors { get; set; }
        public bool FreeOfCharge { get; set; }
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string LatLong { get; set; }
        public int Rooms { get; set; }
        public Seller Seller { get; set; }

        public Ad(int area, Category category, DateTime createAt, string description, int floors, bool freeOfCharge, int id, string imageUrl, string latLong, int rooms, Seller seller)
        {
            Area = area;
            Category = category;
            CreateAt = createAt;
            Description = description;
            Floors = floors;
            FreeOfCharge = freeOfCharge;
            Id = id;
            ImageUrl = imageUrl;
            LatLong = latLong;
            Rooms = rooms;
            Seller = seller;
        }

        public static List<Ad> LoadFromCsv(string filename)
        {
            List<Ad> ads = new List<Ad>();
            if (!File.Exists(filename)) return ads;

            string[] lines = File.ReadAllLines(filename);

            // i=1-től indulunk a fejléc miatt
            for (int i = 1; i < lines.Length; i++)
            {
                string[] v = lines[i].Split(';');

                // Itt párosítjuk össze a CSV oszlopait a konstruktor paramétereivel:
                Ad ad = new Ad(
                    int.Parse(v[4]),           // area
                    new Category { Id = int.Parse(v[12]), Name = v[13] }, // category
                    DateTime.Parse(v[8]),      // createAt
                    v[5],                      // description
                    int.Parse(v[3]),           // floors
                    v[6] == "1",               // freeOfCharge (0 vagy 1)
                    int.Parse(v[0]),           // id
                    v[7],                      // imageUrl
                    v[2],                      // latLong
                    int.Parse(v[1]),           // rooms
                    new Seller { Id = int.Parse(v[9]), Name = v[10], Phone = v[11] } // seller
                );

                ads.Add(ad);
            }
            return ads;
        }

        public double DistanceTo(string latlong)
        {
            string[] parts = this.LatLong.Split(',');
            string[] targetParts = latlong.Split(',');

                double lat = double.Parse(parts[0], System.Globalization.CultureInfo.InvariantCulture);
                double lon = double.Parse(parts[1], System.Globalization.CultureInfo.InvariantCulture);
                double targetLat = double.Parse(targetParts[0], System.Globalization.CultureInfo.InvariantCulture);
                double targetLong = double.Parse(targetParts[1], System.Globalization.CultureInfo.InvariantCulture);

                double a = lat - targetLat;
                double b = lon - targetLong;

                return Math.Sqrt(a * a + b * b);
        }

    } // Ad osztály vége

    class Program
    {
        static void Main(string[] args)
        {
            
                List<Ad> ads = Ad.LoadFromCsv("realestates.csv");
                double osszeg = 0;
                int darab = 0;

                foreach (var ad in ads)
                {
                    if (ad.Floors == 0)
                    {
                        osszeg += ad.Area;
                        darab++;
                    }
                }

                if (darab > 0)
                {
                    double atlag = osszeg / darab;
                    Console.WriteLine($"A földszinti ingatlanok átlagos alapterülete: {atlag:0.00} m2");
                }

            Console.WriteLine($"2. Mesevar óvodához légvonalban legkozelebbi tehermentes ingatlan adatai:");
            Ad legkozelebbi = ads[0];

            for (int i = 0; i < ads.Count; i++)
            {
                double tavolsag = ads[i].DistanceTo("47.4164220114023,19.066342425796986");
                if (tavolsag < legkozelebbi.DistanceTo("47.4164220114023,19.066342425796986"))
                {
                    legkozelebbi = ads[i];
                }
            }
            Console.WriteLine($"\t Eladó neve:{legkozelebbi.Seller.Name}" +
                $"\n\t Eladó telefonja: {legkozelebbi.Seller.Phone}" +
                $"\n\t Alapterulet: {legkozelebbi.Area}" +
                $"\n\t Szobák száma: {legkozelebbi.Rooms}");

        }
    }
}