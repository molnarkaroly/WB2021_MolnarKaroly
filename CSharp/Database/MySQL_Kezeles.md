# Adatbázis-lekérdezés C# Konzol Alkalmazásból MySQL-hez (MySqlConnector)

Ez az útmutató bemutatja, hogyan csatlakozhatunk egy MySQL adatbázishoz, hogyan futtathatunk lekérdezéseket és hogyan dolgozhatjuk fel az eredményeket egy C# konzolos alkalmazásban a `MySqlConnector` NuGet csomag segítségével.

## 1. Előfeltételek

1.  **MySQL Adatbázis**: Győződj meg róla, hogy van egy elérhető MySQL szerver példányod (pl. helyi telepítés, Docker konténer, felhő szolgáltatás) és egy adatbázisod, amiből lekérdezhetsz.
2.  **Visual Studio**: Vagy bármely C# fejlesztőkörnyezet.
3.  **NuGet Csomag**: Telepítened kell a `MySqlConnector` csomagot.
    *   Projektben jobb klikk a `Dependencies` (vagy `References`) -> `Manage NuGet Packages...`
    *   Keresd meg és telepítsd: `MySqlConnector`

## 2. Projekt Létrehozása és Csomag Telepítése

1.  Hozz létre egy új C# Konzol Alkalmazás (.NET Core vagy .NET 5+) projektet a Visual Studio-ban.
2.  Telepítsd a `MySqlConnector` NuGet csomagot a fent leírt módon.

## 3. Az Alapvető Lépések

Az adatbázis-lekérdezés MySQL esetén (és általában ADO.NET-tel) a következő lépésekből áll:

1.  **Kapcsolati Sztring (Connection String) Definiálása**: Megadja, hogyan csatlakozzon az alkalmazás a MySQL adatbázishoz.
2.  **Kapcsolat Létrehozása (`MySqlConnection`)**: Létrehoz egy kapcsolat objektumot a kapcsolati sztring alapján.
3.  **Kapcsolat Megnyitása**: Megnyitja a fizikai kapcsolatot az adatbázissal.
4.  **Parancs Létrehozása (`MySqlCommand`)**: Definiálja a futtatandó SQL lekérdezést vagy tárolt eljárást.
5.  **Parancs Végrehajtása**:
    *   `ExecuteReader()`: Lekérdezésekhez, amik több sort és oszlopot adnak vissza.
    *   `ExecuteNonQuery()`: `INSERT`, `UPDATE`, `DELETE` utasításokhoz, vagy DDL parancsokhoz (amik nem adnak vissza eredményhalmazt). Visszaadja az érintett sorok számát.
    *   `ExecuteScalar()`: Olyan lekérdezésekhez, amik egyetlen értéket adnak vissza (pl. `COUNT(*)`, `MAX(ID)`).
6.  **Eredmények Feldolgozása (ha van)**: Beolvassa és feldolgozza a lekérdezés eredményeit.
7.  **Kapcsolat Lezárása**: Felszabadítja az erőforrásokat. Erősen ajánlott `using` blokkokat használni a kapcsolatok és parancsok automatikus lezárásához/megsemmisítéséhez.

## 4. Példa Kód
```csharp
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
        }
        catch (MySqlException ex)
        {
            // Specifikus MySQL hibák kezelése
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nMySQL Hiba történt: ({ex.Number}) {ex.Message}");
            Console.WriteLine("Ellenőrizd a kapcsolati sztringet, a szerver elérhetőségét és a felhasználói jogosultságokat.");
            if (ex.Number == 1045) // Access denied
            {
                Console.WriteLine("Ez a hiba (1045) általában hibás felhasználónévre vagy jelszóra utal.");
            }
            else if (ex.Number == 1049) // Unknown database
            {
                Console.WriteLine("Ez a hiba (1049) azt jelzi, hogy a megadott adatbázis nem létezik.");
            }
            else if (ex.Number == 0 && ex.InnerException is System.Net.Sockets.SocketException)
            {
                Console.WriteLine("Nem sikerült kapcsolódni a MySQL szerverhez. Ellenőrizd, hogy a szerver fut-e és a cím/port helyes-e.");
            }
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            // Egyéb, általános hibák kezelése
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nÁltalános hiba történt: {ex.Message}");
            Console.ResetColor();
        }
        finally
        {
            Console.WriteLine("\nA program futása befejeződött. Nyomj egy gombot a kilépéshez...");
            Console.ReadKey();
        }
    }
}

```

## 5. Fontos Megjegyzések (MySqlConnector specifikus és általános)

*   **NuGet Csomag**: A `MySqlConnector` egy közösség által fejlesztett, modern, nagy teljesítményű, teljesen aszinkron MySQL ADO.NET szolgáltató .NET-hez. Aktívan fejlesztik és támogatják. (Másik elterjedt csomag a `MySql.Data`, amit az Oracle tart karban.)
*   **SQL Injection Védelem**: **Mindig** használj paraméterezett lekérdezéseket (`command.Parameters.AddWithValue("@ParamName", value)`) vagy tárolt eljárásokat, amikor felhasználói bemenetet illesztesz SQL parancsokba.
*   **Erőforráskezelés (`using`)**: A `MySqlConnection`, `MySqlCommand` és `MySqlDataReader` objektumok implementálják az `IDisposable` interfészt. A `using` blokk biztosítja a `Dispose()` metódus automatikus meghívását.
*   **Hibakezelés (`try-catch`)**: A `MySqlException` specifikus MySQL hibákat tartalmaz. A `Number` tulajdonsága tartalmazza a MySQL hiba kódját.
*   **Kapcsolati Sztringek Biztonsága**: Ne égesd be a kapcsolati sztringeket éles környezetben. Használj konfigurációs fájlokat (`appsettings.json`), környezeti változókat, vagy biztonságos tárolókat.
*   **`Charset`**: A kapcsolati sztringben a `Charset=utf8mb4` (vagy `utf8`) használata ajánlott a helyes karakterkódolás érdekében, különösen nemzetközi karakterek esetén.
*   **Aszinkron Műveletek**: A `MySqlConnector` erősen támogatja az aszinkron műveleteket. Nagyobb alkalmazásoknál vagy ahol a UI válaszkészsége kritikus, használd az `ExecuteReaderAsync()`, `ExecuteNonQueryAsync()`, `ExecuteScalarAsync()` stb. metódusokat `async`/`await` kulcsszavakkal.
*   **ORM-ek (Object-Relational Mappers)**: Komplexebb alkalmazásoknál az ADO.NET közvetlen használata helyett fontolóra veheted ORM eszközök, mint az Entity Framework Core (aminek van MySQL provider-e, pl. `Pomelo.EntityFrameworkCore.MySql`) vagy Dapper használatát.

Ez az útmutató lefedi a `MySqlConnector` használatának alapjait C# konzolos alkalmazásokban. A gyakorlat és a `MySqlConnector` dokumentációjának (elérhető a GitHubon) tanulmányozása segít elmélyíteni a tudásodat!
## 