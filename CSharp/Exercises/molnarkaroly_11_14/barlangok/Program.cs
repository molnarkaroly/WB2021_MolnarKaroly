using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace barlangok
{
    class Barlang 
    {
     public int azon { get; private set; }
     public string nev { get; private set; }
     public string telepules { get; private set; }
     public string vedettseg { get; set; }

     private int H;

    public int hossz 
        { 
            get 
            {
                return H;
            } 
            set 
            {
                if (H <= value || value == 0)
                {
                    H = value;
                }
            }
        }

        private int M;
        public int melyseg
        {
            get
            {
                return M;
            }
            set
            {
                if (M <= value)
                {
                    M = value;
                }
            }
        }



        public Barlang(string line) 
        {
            try
            {
                string[] strings = line.Split(';');
                azon = int.Parse(strings[0]);
                nev = strings[1];
                hossz = int.Parse(strings[2]);
                melyseg = int.Parse(strings[3]);
                telepules = strings[4];
                vedettseg = strings[5];
            }
            catch (Exception)
            {
                hossz = 0;
            }


        }
        public override string ToString()
        {
            return $" Azon: {azon}\n Nev: {nev}\n Hossz: {hossz}\n Melyseg: {melyseg}\n Telepules: {telepules}\n Vedettseg: {vedettseg}\n";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            /* 
            Barlang a = new Barlang("1;Név;500;50;telepules;vedetseg");
            Console.WriteLine(a.ToString());
            */
            StreamReader sr = new StreamReader("..\\..\\..\\barlangok.txt", Encoding.UTF8);
            List<Barlang> barlangok = new List<Barlang>();
            while (!sr.EndOfStream)
            {
                Barlang tmp= new Barlang(sr.ReadLine());
                if (tmp.hossz != 0) barlangok.Add(tmp);
            }
            sr.Close();


            //Feladat 2
            Console.WriteLine(barlangok.Count);

            //Feldat 3
            int db = 0;
            int sum = 0;
            foreach (Barlang b in barlangok)
            {
                if (b.telepules.Contains("Miskolc"))
                {
                 db++;
                 sum += b.melyseg;
                }
            }

            if (db == 0) Console.WriteLine("Nincs ilyen telepules");
            else Console.WriteLine($"A Miskolci barlangokátlagos mélysége: {sum/db} melyseg");
            
            //Feladat 4


            Console.ReadKey();
        }
    }
}
