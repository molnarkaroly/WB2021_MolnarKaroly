using System;
using MySqlConnector; 

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("C# MySQL Adatbázis Lekérdezés (MySqlConnector)");
        Console.WriteLine("----------------------------------------------");

        // 1. Kapcsolati Sztring Definiálása
        // CSERÉLD LE AZ ALÁBBI ÉRTÉKEKET A SAJÁT MySQL SZERVERED ADATAIVAL!
        // - Server: A MySQL szerver címe (pl. localhost, vagy egy IP cím)
        // - Port: A MySQL szerver portja (alapértelmezetten 3306). Ha az alapértelmezett, elhagyható.
        // - Database: Az adatbázis neve, amihez csatlakozni szeretnél.
        // - Uid: A MySQL felhasználónév.
        // - Pwd: A MySQL felhasználó jelszava.
        // - Charset: Karakterkészlet, utf8mb4 ajánlott a legtöbb esetben.
        string connectionString = "Server=localhost;" +
                                "Port=3306;Database=gyakorlas;" +
                                "Uid=root;Pwd=;";

        // Példa adatbázis és tábla:
        // Az alábbi kód egy 'Users' nevű táblából próbál lekérdezni,
        // amelynek legalább 'Id' (INT), 'Name' (VARCHAR) és 'Email' (VARCHAR) oszlopai vannak.
        // Hozz létre egy ilyen táblát a 'mydatabase'-ben a teszteléshez:
        // CREATE TABLE Users (
        //     Id INT AUTO_INCREMENT PRIMARY KEY,
        //     Name VARCHAR(100) NOT NULL,
        //     Email VARCHAR(100)
        // );
        // INSERT INTO Users (Name, Email) VALUES ('Teszt Elek', 'teszt.elek@example.com');
        // INSERT INTO Users (Name, Email) VALUES ('Minta Panna', 'minta.panna@example.com');

        try
        {
            // 2. Kapcsolat Létrehozása (`MySqlConnection`)
            // A 'using' blokk biztosítja, hogy a kapcsolat megfelelően lezárásra kerüljön,
            // még akkor is, ha hiba történik.
            using (var connection = new MySqlConnection(connectionString))
            {
                Console.WriteLine("Kapcsolódás a MySQL adatbázishoz...");
                // 3. Kapcsolat Megnyitása
                connection.Open();
                Console.WriteLine("Sikeres kapcsolódás!");

                // 4. Parancs Létrehozása (`MySqlCommand`)
                // Egy egyszerű SELECT lekérdezés.
                string sqlQuery = "SELECT * FROM pizza";
                using (var command = new MySqlCommand(sqlQuery, connection))
                {
                    // 5. Parancs Végrehajtása (`ExecuteReader()` lekérdezésekhez)
                    Console.WriteLine($"\nLekérdezés futtatása: {sqlQuery}");
                    using (var reader = command.ExecuteReader())
                    {
                        // 6. Eredmények Feldolgozása
                        if (reader.HasRows)
                        {
                            Console.WriteLine("\nLekérdezés eredménye:");
                            Console.WriteLine("--------------------------------------------------");
                            // Oszlopnevek kiírása
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.Write(reader.GetName(i) + "\t|\t");
                            }
                            Console.WriteLine("\n--------------------------------------------------");

                            while (reader.Read())
                            {
                                // Adatok kiolvasása az aktuális sorból
                                // Használhatod az oszlop nevét vagy az indexét

                                int pazon = reader.GetInt32("pazon"); 
                                string pnev = reader.GetString("pnev");
                                int par = reader.GetInt32("par");
                                

                                Console.WriteLine($"{pazon}\t|\t{pnev}\t|\t{par}");
                            }
                            Console.WriteLine("--------------------------------------------------");
                        }
                        else
                        {
                            Console.WriteLine("Nincs találat a lekérdezésre.");
                        }
                        // A reader automatikusan bezáródik a 'using' blokk végén.
                    }
                }
                // 7. Kapcsolat Lezárása
                // A kapcsolat automatikusan bezáródik a 'using (connection ...)' blokk végén.
                Console.WriteLine("\nKapcsolat lezárva.");
            }

           
            
            
            // 2. Kapcsolat Létrehozása (`MySqlConnection`)
            // A 'using' blokk biztosítja, hogy a kapcsolat megfelelően lezárásra kerüljön,
            // még akkor is, ha hiba történik.
            using (var connection = new MySqlConnection(connectionString))
            {
                Console.WriteLine("Kapcsolódás a MySQL adatbázishoz...");
                // 3. Kapcsolat Megnyitása
                connection.Open();
                Console.WriteLine("Sikeres kapcsolódás!");

                // 4. Parancs Létrehozása (`MySqlCommand`)
                // Egy egyszerű SELECT lekérdezés.
                string sqlQuery = "SELECT * FROM vevo";
                using (var command = new MySqlCommand(sqlQuery, connection))
                {
                    // 5. Parancs Végrehajtása (`ExecuteReader()` lekérdezésekhez)
                    Console.WriteLine($"\nLekérdezés futtatása2: {sqlQuery}");
                    using (var reader = command.ExecuteReader())
                    {
                        // 6. Eredmények Feldolgozása
                        if (reader.HasRows)
                        {
                            Console.WriteLine("\nLekérdezés eredménye:");
                            Console.WriteLine("--------------------------------------------------");
                            // Oszlopnevek kiírása
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.Write(reader.GetName(i) + "\t|\t");
                            }
                            Console.WriteLine("\n--------------------------------------------------");

                            while (reader.Read())
                            {
                                // Adatok kiolvasása az aktuális sorból
                                // Használhatod az oszlop nevét vagy az indexét

                                int vazon = reader.GetInt32("vazon");
                                string vnev = reader.GetString("vnev");
                                string vcim = reader.GetString("vcim");


                                Console.WriteLine($"{vazon}\t|\t{vnev}\t|\t{vcim}");
                            }
                            Console.WriteLine("--------------------------------------------------");
                        }
                        else
                        {
                            Console.WriteLine("Nincs találat a lekérdezésre.");
                        }
                        // A reader automatikusan bezáródik a 'using' blokk végén.
                    }
                }
                // 7. Kapcsolat Lezárása
                // A kapcsolat automatikusan bezáródik a 'using (connection ...)' blokk végén.
                Console.WriteLine("\nKapcsolat lezárva.");
            }






        }
        finally
        {
            Console.WriteLine("\nA program futása befejeződött. Nyomj egy gombot a kilépéshez...");
            Console.ReadKey();
        }
    }
}