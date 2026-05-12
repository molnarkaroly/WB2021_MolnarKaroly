using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Keresztrejtveny
{
    class KeresztrejtvenyRacs
    {
        private List<string> Adatsorok;
        private char[,] racs;
        private int[,] sorokSzama;

        public int SorokDb => Adatsorok.Count;
        public int OszlopokDb => Adatsorok.Count > 0 ? Adatsorok[0].Length : 0;

        public KeresztrejtvenyRacs(string forrasallomany)
        {
            Adatsorok = new List<string>();
            BeolvasAdatsorok(forrasallomany);

            if (SorokDb > 0)
            {
                // Mátrixok inicializálása kerettel (+2)
                racs = new char[SorokDb + 2, OszlopokDb + 2];
                sorokSzama = new int[SorokDb + 2, OszlopokDb + 2];

                Console.WriteLine("5. feladat: A keresztrejtvény mérete");
                Console.WriteLine("\tSorok száma: " + SorokDb);
                Console.WriteLine("\tOszlopok száma: " + OszlopokDb);

                // Mátrix feltöltése és keretezés (#-tel)
                for (int i = 0; i < SorokDb + 2; i++)
                    for (int j = 0; j < OszlopokDb + 2; j++)
                        racs[i, j] = '#';

                for (int i = 0; i < SorokDb; i++)
                {
                    for (int j = 0; j < OszlopokDb; j++)
                    {
                        racs[i + 1, j + 1] = Adatsorok[i][j];
                    }
                }
            }
            else
            {
                Console.WriteLine("Hiba: A fájl üres vagy nem található.");
            }
        }

        // 6. feladat: Rács megjelenítése
        public void MegjelenitRacs()
        {
            Console.WriteLine("\n6. feladat: A beolvasott keresztrejtvény:");
            for (int i = 0; i < SorokDb; i++)
            {
                Console.Write("\t");
                for (int j = 0; j < OszlopokDb; j++)
                {
                    // Ha a karakter '-' (fehér négyzet), írjunk "[]"-et, különben "##"-et (fekete)
                    if (Adatsorok[i][j] == '-') Console.Write("[]");
                    else Console.Write("##");
                }
                Console.WriteLine();
            }
        }

        // 7. feladat: Leghosszabb függőleges szó hossza
        public void LeghosszabbFuggolegesSzo()
        {
            int maxHossz = 0;

            // Függőleges keresés: oszlopokon megyünk végig (külső ciklus a 'j')
            for (int j = 1; j <= OszlopokDb; j++)
            {
                int aktualisDb = 0;
                for (int i = 1; i <= SorokDb + 1; i++) // +1 a keret miatti lezáráshoz
                {
                    // Ha nem fekete négyzet (feltételezzük, hogy a '-' a betű helye)
                    if (racs[i, j] == '-')
                    {
                        aktualisDb++;
                    }
                    else
                    {
                        if (aktualisDb > maxHossz) maxHossz = aktualisDb;
                        aktualisDb = 0;
                    }
                }
            }
            Console.WriteLine($"\n7. feladat: A leghosszabb függőleges szó: {maxHossz} karakter.");
        }

        private void BeolvasAdatsorok(string fajlnev)
        {
            if (File.Exists(fajlnev))
            {
                Adatsorok = File.ReadAllLines(fajlnev).ToList();
            }
            else
            {
                Console.WriteLine($"HIBA: A(z) '{fajlnev}' nem található!");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            KeresztrejtvenyRacs kr = new KeresztrejtvenyRacs("kr1.txt");

            if (kr.SorokDb > 0)
            {
                kr.MegjelenitRacs();
                kr.LeghosszabbFuggolegesSzo();
            }

            Console.ReadKey();
        }
    }
}