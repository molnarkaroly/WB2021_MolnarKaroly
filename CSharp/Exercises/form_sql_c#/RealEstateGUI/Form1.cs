// Szükséges névterek importálása a program működéséhez.
// System: Alapvető .NET osztályokat tartalmaz (pl. Console, Math, DateTime).
// System.Collections.Generic: Gyűjteményeket (pl. List<T>) biztosít.
// System.ComponentModel: Komponensek és vezérlők viselkedésének kezelésére szolgál (pl. háttérben futó feladatok).
// System.Data: Adatbázis-elérési osztályokat tartalmaz (pl. DataTable, DataSet).
// System.Drawing: Grafikus felületekhez kapcsolódó osztályokat (pl. Color, Point, Font) biztosít.
// System.Linq: Adatgyűjtemények lekérdezésére szolgáló LINQ (Language Integrated Query) funkciókat tesz elérhetővé.
// System.Text: Szövegkezelési osztályokat tartalmaz (pl. StringBuilder).
// System.Threading.Tasks: Aszinkron programozáshoz szükséges osztályokat (pl. Task) biztosít.
// System.Windows.Forms: Windows Forms alkalmazások készítéséhez szükséges osztályokat (pl. Form, Button, ListBox) tartalmaz.
// MySqlConnector: A MySQL adatbázis-szerverrel való kommunikációhoz szükséges külső csomag (NuGet) osztályait tartalmazza.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector; // MySQL adatbázis-kapcsolathoz

// A program fő névtere.
namespace RealEstateGUI
{
    // A fő ablak (Form) osztálya. A 'partial' kulcsszó jelzi, hogy az osztály definíciója
    // több fájlban is lehet (jellemzően egy a kódnak, egy a tervező által generált részeknek).
    public partial class Form1 : Form
    {
        // Statikus MySQL kapcsolat objektum.
        // Statikus, hogy az osztály minden példánya (bár itt csak egy van) ugyanazt a kapcsolatot használja,
        // és hogy a statikus metódusok (activeRead, fullRead) is elérjék.
        static MySqlConnection connection;

        // Statikus lista az aktuálisan megjelenített vagy feldolgozott eladók tárolására.
        // A 'Seller' egy később definiált saját osztály.
        static List<Seller> activeSellers = new List<Seller>();

        // A Form1 osztály konstruktora. Akkor fut le, amikor létrehozzuk az ablakot.
        public Form1()
        {
            // A vizuális komponensek inicializálása (pl. gombok, listák helyzete, mérete).
            // Ezt a metódust a Windows Forms tervező generálja és tartja karban.
            InitializeComponent();

            // MySQL kapcsolati karakterlánc (connection string) összeállítása.
            // A MySqlConnectionStringBuilder segít a paraméterek biztonságos és helyes megadásában.
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "127.0.0.1", // Adatbázis szerver címe (localhost)
                UserID = "root",      // Adatbázis felhasználónév
                Password = "",         // Adatbázis jelszó (itt üres)
                Database = "ingatlan"   // Adatbázis neve
            };

            // Létrehozzuk a MySQL kapcsolat objektumot a megadott kapcsolati karakterlánccal.
            connection = new MySqlConnection(builder.ConnectionString);

            // Megpróbáljuk megnyitni az adatbázis-kapcsolatot.
            // Ha sikertelen, kivételt dob (pl. ha a szerver nem elérhető vagy a hitelesítő adatok rosszak).
            connection.Open();

            // Kezdeti állapotok beállítása a felhasználói felületen.
            // A 'buttonActive' (valószínűleg az aktív/összes eladó közötti váltógomb) háttérszínét pirosra állítjuk.
            // Ez jelzi, hogy kezdetben az összes eladó látszik (a 'fullRead' miatt).
            buttonActive.BackColor = Color.Red;

            // Az 'activeSellers' listát feltöltjük az összes eladóval az adatbázisból.
            // A 'fullRead()' egy saját metódus, ami lekérdezi az adatokat.
            activeSellers = fullRead();

            // A 'listBoxSellers' (eladókat megjelenítő lista) tartalmát töröljük, hogy ne legyenek duplikációk.
            listBoxSellers.Items.Clear();

            // Végigmegyünk az 'activeSellers' listán, és minden eladó nevét hozzáadjuk a 'listBoxSellers'-hez.
            foreach (var item in activeSellers)
            {
                listBoxSellers.Items.Add(item.name);
            }
        }

        // Statikus metódus, ami csak azokat az eladókat olvassa be az adatbázisból,
        // akiknek van legalább egy hirdetésük ('realestates' táblában).
        static List<Seller> activeRead()
        {
            // Létrehozunk egy új listát az aktív eladók tárolására.
            List<Seller> a = new List<Seller>();

            // Létrehozunk egy parancs objektumot a meglévő adatbázis-kapcsolaton.
            var command = connection.CreateCommand();

            // Beállítjuk az SQL lekérdezést.
            // "SELECT * FROM sellers WHERE id IN (SELECT sellerid FROM realestates) ORDER BY name;"
            // Jelentése: Válaszd ki az összes oszlopot (*) a 'sellers' táblából,
            // ahol az 'id' mező értéke benne van azoknak a 'sellerid'-knek a listájában,
            // amelyek szerepelnek a 'realestates' táblában (azaz van hirdetésük).
            // Az eredményt név szerint (name) rendezzük.
            command.CommandText = "SELECT * FROM sellers WHERE id IN (SELECT sellerid FROM realestates) ORDER BY name;";

            // Végrehajtjuk a lekérdezést, és kapunk egy 'MySqlDataReader' objektumot,
            // amivel soronként olvashatjuk az eredményeket.
            var reader = command.ExecuteReader();

            // Ciklus, ami addig fut, amíg van olvasható sor az eredményhalmazban.
            while (reader.Read())
            {
                // Létrehozunk egy új 'Seller' objektumot az aktuális sor adatainak tárolására.
                Seller tmp = new Seller();
                // Kiolvassuk az adatokat a sorból az oszlopindexek (0, 1, 2) alapján.
                // Fontos, hogy az indexek és az adattípusok (GetInt32, GetString) megfeleljenek a tábla struktúrájának.
                tmp.id = reader.GetInt32(0);    // Az 'id' oszlop (feltételezhetően az első)
                tmp.name = reader.GetString(1); // A 'name' oszlop (feltételezhetően a második)
                tmp.phone = reader.GetString(2);// A 'phone' oszlop (feltételezhetően a harmadik)
                // Hozzáadjuk a feltöltött 'Seller' objektumot a listához.
                a.Add(tmp);
            }
            // Bezárjuk a 'MySqlDataReader'-t. Ez fontos, mert amíg nyitva van,
            // más parancsokat nem lehet ugyanazon a kapcsolaton végrehajtani.
            reader.Close();
            // Visszaadjuk az aktív eladókat tartalmazó listát.
            return a;
        }

        // Statikus metódus, ami az összes eladót beolvassa az adatbázisból, név szerint rendezve.
        static List<Seller> fullRead()
        {
            // Létrehozunk egy új listát az összes eladó tárolására.
            List<Seller> a = new List<Seller>();
            // Létrehozunk egy parancs objektumot.
            var command = connection.CreateCommand();
            // SQL lekérdezés: Válaszd ki az összes oszlopot a 'sellers' táblából, név szerint rendezve.
            command.CommandText = "SELECT * FROM sellers ORDER BY name;";
            // Lekérdezés végrehajtása és eredmény olvasása.
            var reader = command.ExecuteReader();
            // Ciklus az eredmény sorain.
            while (reader.Read())
            {
                // Új 'Seller' objektum létrehozása.
                Seller tmp = new Seller();
                // Adatok kiolvasása és hozzárendelése a 'Seller' objektum mezőihez.
                tmp.id = reader.GetInt32(0);
                tmp.name = reader.GetString(1);
                tmp.phone = reader.GetString(2);
                // Hozzáadás a listához.
                a.Add(tmp);
            }
            // Reader bezárása.
            reader.Close();
            // Visszaadjuk az összes eladót tartalmazó listát.
            return a;
        }

        // Eseménykezelő metódus, ami akkor fut le, amikor a Form betöltődik (de még nem feltétlenül látható).
        private void Form1_Load(object sender, EventArgs e)
        {
            // A 'buttonLoad' (hirdetések betöltése gomb) letiltása.
            // Kezdetben nincs kiválasztott eladó, így nincs mit betölteni.
            buttonLoad.Enabled = false;
            // A 'listBoxAds' (hirdetéseket megjelenítő lista) vízszintes görgetősávjának engedélyezése.
            listBoxAds.HorizontalScrollbar = true;
            // A 'listBoxAds' görgetősávjának mindig láthatóvá tétele (akkor is, ha nincs elég elem a görgetéshez).
            listBoxAds.ScrollAlwaysVisible = true; // Megjegyzés: Ez a tulajdonság nem mindig működik minden ListBox stílussal, vagy a HorizontalScrollbar felülírhatja.
                                                   // Általában a görgetősáv automatikusan jelenik meg, ha szükséges.
        }

        // Eseménykezelő metódus, ami akkor fut le, ha a 'listBoxSellers'-ben megváltozik a kiválasztott elem.
        private void listBoxSellers_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ellenőrizzük, hogy van-e ténylegesen kiválasztott elem (-1 jelenti, hogy nincs).
            if (listBoxSellers.SelectedIndex != -1)
            {
                // A 'labelSellerName' címke szövegének beállítása a kiválasztott eladó nevére.
                // Az 'activeSellers' listából a 'listBoxSellers.SelectedIndex' alapján vesszük ki a megfelelő eladót.
                labelSellerName.Text = $"Eladó Neve: {activeSellers[listBoxSellers.SelectedIndex].name}";
                // A 'labelSellerPhone' címke szövegének beállítása a kiválasztott eladó telefonszámára.
                labelSellerPhone.Text = $"Eladó Telefonszáma: {activeSellers[listBoxSellers.SelectedIndex].phone}";
                // A 'labelAdCount' címke (hirdetések száma) szövegének alaphelyzetbe állítása.
                labelAdCount.Text = $"Hirdetések Szám: -";
                // A 'listBoxAds' (hirdetések listája) tartalmának törlése, mert új eladót választottunk.
                listBoxAds.Items.Clear();

                // A 'buttonLoad' (hirdetések betöltése) gomb engedélyezése,
                // mivel most már van kiválasztott eladó, akinek a hirdetéseit be lehet tölteni.
                buttonLoad.Enabled = true;
            }
            else
            {
                // Ha nincs kiválasztott elem (pl. a lista üres, vagy a kijelölés megszűnt)
                // akkor a gombot letiltjuk.
                buttonLoad.Enabled = false;
                // És a címkéket is alaphelyzetbe állíthatjuk.
                labelSellerName.Text = "Eladó Neve: ";
                labelSellerPhone.Text = "Eladó Telefonszáma: ";
                labelAdCount.Text = "Hirdetések Szám: -";
                listBoxAds.Items.Clear();
            }
        }

        // Eseménykezelő metódus, ami a 'buttonActive' (aktív/összes eladó váltó) gombra kattintáskor fut le.
        private void buttonActive_Click(object sender, EventArgs e)
        {
            // Ellenőrizzük a gomb aktuális háttérszínét, hogy eldöntsük, milyen állapotban van.
            if (buttonActive.BackColor == Color.Red) // Ha jelenleg piros (azaz az összes eladó látszik)
            {
                // Átváltunk zöldre (azaz csak az aktív eladók fognak látszani).
                buttonActive.BackColor = Color.Green;
                // Betöltjük csak az aktív eladókat az 'activeSellers' listába.
                activeSellers = activeRead();
                // Töröljük a 'listBoxSellers' tartalmát.
                listBoxSellers.Items.Clear();
                // Feltöltjük a 'listBoxSellers'-t az aktív eladók neveivel.
                foreach (var item in activeSellers)
                {
                    listBoxSellers.Items.Add(item.name);
                }
            }
            else // Ha nem piros (azaz zöld, tehát az aktív eladók látszanak)
            {
                // Visszaváltunk pirosra (azaz újra az összes eladó fog látszani).
                buttonActive.BackColor = Color.Red;
                // Betöltjük az összes eladót az 'activeSellers' listába.
                activeSellers = fullRead();
                // Töröljük a 'listBoxSellers' tartalmát.
                listBoxSellers.Items.Clear();
                // Feltöltjük a 'listBoxSellers'-t az összes eladó neveivel.
                foreach (var item in activeSellers)
                {
                    listBoxSellers.Items.Add(item.name);
                }
            }
            // A lista tartalmának megváltozása után érdemes lehet a címkéket és a hirdetések listáját is frissíteni/törölni,
            // és a 'buttonLoad'-ot letiltani, mivel a kiválasztás valószínűleg megszűnik vagy megváltozik.
            // Ezt a `listBoxSellers_SelectedIndexChanged` esemény automatikusan kezelheti, ha a lista ürítése/feltöltése
            // kiváltja azt (általában igen, ha a SelectedIndex megváltozik, pl. -1 lesz).
            // Ha mégsem, manuálisan kellene:
            // labelSellerName.Text = "Eladó Neve: ";
            // labelSellerPhone.Text = "Eladó Telefonszáma: ";
            // labelAdCount.Text = "Hirdetések Szám: -";
            // listBoxAds.Items.Clear();
            // buttonLoad.Enabled = false;
        }

        // Eseménykezelő metódus, ami a 'buttonLoad' (hirdetések betöltése) gombra kattintáskor fut le.
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            // Ellenőrizzük, hogy van-e kiválasztott eladó. Bár a gomb elvileg csak akkor engedélyezett,
            // ha van, egy extra ellenőrzés sosem árt.
            if (listBoxSellers.SelectedIndex == -1)
            {
                MessageBox.Show("Kérem, válasszon ki egy eladót a listából!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Kilépünk a metódusból, ha nincs kiválasztott eladó.
            }

            // Létrehozunk egy parancs objektumot.
            var command = connection.CreateCommand();
            // SQL lekérdezés: Válaszd ki az összes oszlopot a 'realestates' táblából,
            // ahol a 'sellerid' megegyezik a 'listBoxSellers'-ben kiválasztott eladó 'id'-jával.
            // Az 'activeSellers[listBoxSellers.SelectedIndex].id' adja meg a kiválasztott eladó ID-ját.
            // FONTOS: Ez a fajta SQL string összefűzés sebezhető SQL Injection támadásokkal szemben!
            // Helyette paraméteres lekérdezést kellene használni (pl. command.Parameters.AddWithValue).
            command.CommandText = "SELECT * FROM realestates WHERE sellerid = " + activeSellers[listBoxSellers.SelectedIndex].id + ";";

            // Töröljük a hirdetések listáját, mielőtt újakat töltenénk be.
            listBoxAds.Items.Clear();

            // Lekérdezés végrehajtása.
            var reader = command.ExecuteReader();
            // Ciklus az eredmény sorain.
            while (reader.Read())
            {
                // Egy string változó az aktuális hirdetés adatainak formázott tárolására.
                string a = "";
                // Összeállítjuk a hirdetés adatait tartalmazó stringet.
                // Az oszlopnevekkel (`"id"`, `"rooms"`, stb.) hivatkozunk az adatokra, ami robusztusabb,
                // mint az indexek használata, mert kevésbé érzékeny az oszlopok sorrendjének esetleges megváltozására.
                a += $"Hirdetés Azonosító: {reader.GetInt64("id")} | "; // A 'id' oszlop neve a realestates táblában lehet, hogy nem 'id', hanem pl. 'ad_id' vagy 'hirdetes_id'. Ellenőrizni kell.
                a += $"Szobák Száma: {reader.GetInt32("rooms")} | "; // Adattípus (GetInt32 vagy GetInt64) ellenőrizendő a DB sémában.
                a += $"Terület: {reader.GetInt32("area")} m^2 | ";   // Adattípus ellenőrizendő.
                a += $"Koordináta: {reader.GetString("latlong")}";
                // Hozzáadjuk a formázott stringet a 'listBoxAds'-hoz.
                listBoxAds.Items.Add(a);
            }
            // Frissítjük a 'labelAdCount' címkét a betöltött hirdetések számával.
            labelAdCount.Text = $"Hirdetések Száma: {listBoxAds.Items.Count}";
            // Reader bezárása.
            reader.Close();
        }

        // Eseménykezelő metódus, ami akkor fut le, amikor a Form-ot be akarják zárni.
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Bezárjuk az adatbázis-kapcsolatot.
            // Ez nagyon fontos lépés, hogy felszabadítsuk az erőforrásokat és elkerüljük
            // az adatbázis-szerveren maradó nyitott kapcsolatokat.
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }

    // Egy egyszerű osztály a 'Category' (kategória) adatok tárolására.
    // Jelenleg ez az osztály nincs aktívan használva a Form1 logikájában, de a struktúra létezik.
    internal class Category
    {
        public int id;        // Kategória azonosítója
        public string name;   // Kategória neve
    }

    // Egy egyszerű osztály a 'Seller' (eladó) adatok tárolására.
    internal class Seller
    {
        public int id;        // Eladó azonosítója
        public string name;   // Eladó neve
        public string phone;  // Eladó telefonszáma
    }

    // Egy egyszerű osztály az 'Ad' (hirdetés) adatok tárolására.
    // Jelenleg a 'buttonLoad_Click' csak néhány mezőt használ ki (id, rooms, area, latlong),
    // de az osztály tartalmazhatna több adatot is a hirdetésről.
    internal class Ad
    {
        public int id;                // Hirdetés azonosítója
        public int rooms;             // Szobák száma
        public string latlong;        // GPS koordináták (szélesség, hosszúság)
        public int floors;            // Emeletek száma (vagy melyik emeleten van)
        public int area;              // Alapterület (pl. négyzetméterben)
        public string description;    // Hirdetés leírása
        public bool freeOfCharge;     // Ingatlan tehermentes-e
        public string imageUrl;       // Kép URL címe
        public DateTime createAt;     // Hirdetés létrehozásának dátuma
        public Seller seller;         // Az eladó objektuma (kapcsolat a Seller osztályhoz)
        public Category category;     // A kategória objektuma (kapcsolat a Category osztályhoz)
    }
}