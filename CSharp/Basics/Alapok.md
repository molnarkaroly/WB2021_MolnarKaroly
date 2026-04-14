Oké, íme egy C# jegyzet Markdown stílusban, részletes, de rövid magyarázatokkal:

markdown
# C# Gyors Jegyzet

## 1. Alapok

### 1.1. Hello World és Programszerkezet
Minden C# programnak van egy `Main` metódusa, ami a program belépési pontja.

```csharp
using System; // Névtér importálása (pl. Console osztályhoz)

namespace HelloWorldApp // Névtér a saját kódunk szervezésére
{
    class Program // Osztály deklarációja
    {
        static void Main(string[] args) // Belépési pont
        {
            Console.WriteLine("Hello, World!"); // Kiírja a szöveget a konzolra
        }
    }
}
```

-   **`using System;`**: Importálja a `System` névteret, ami alapvető osztályokat tartalmaz.
-   **`namespace`**: Kódszervezési egység, segít elkerülni a névütközéseket.
-   **`class`**: Az objektum-orientált programozás alapegysége; tervrajz objektumok létrehozásához.
-   **`static void Main(string[] args)`**: A program végrehajtásának kezdőpontja.
    -   `static`: Nem kell példányosítani az osztályt a hívásához.
    -   `void`: Nem ad vissza értéket.
    -   `string[] args`: Parancssori argumentumok tömbje.

### 1.2. Kommentek

```csharp
// Egysoros komment

/*
Többsoros
komment
*/

/// <summary>
/// XML dokumentációs komment (metódusok, osztályok stb. leírására)
/// </summary>
public void MyMethod() { }
```

## 2. Változók és Adattípusok

### 2.1. Deklaráció és Inicializálás

```csharp
// Deklaráció: típus név;
int age;
string name;

// Inicializálás: változó = érték;
age = 30;
name = "John Doe";

// Deklaráció és inicializálás egyben:
double salary = 50000.75;
bool isActive = true;
```

### 2.2. Alapvető Adattípusok

-   **Egész számok**: `int` (32-bit), `long` (64-bit), `short` (16-bit), `byte` (8-bit)
-   **Lebegőpontos számok**: `float` (32-bit), `double` (64-bit), `decimal` (128-bit, pénzügyi számításokhoz)
-   **Logikai**: `bool` (`true` vagy `false`)
-   **Karakter**: `char` (egy Unicode karakter, pl. 'A')
-   **Szöveg**: `string` (Unicode karakterek sorozata, pl. "Hello")

### 2.3. `var` Kulcsszó

A fordító automatikusan meghatározza a változó típusát az inicializáló érték alapján.

```csharp
var count = 10;         // int lesz
var message = "Hi";     // string lesz
var price = 19.99m;     // decimal lesz (m szuffix miatt)
```

### 2.4. Konstansok

Értékük a fordítási időben rögzül, és nem változtatható meg.

```csharp
const double PI = 3.14159;
```

## 3. Operátorok

### 3.1. Aritmetikai

`+` (összeadás), `-` (kivonás), `*` (szorzás), `/` (osztás), `%` (maradék)
`++` (növelés eggyel), `--` (csökkentés eggyel)

### 3.2. Összehasonlító

`==` (egyenlő), `!=` (nem egyenlő), `>` (nagyobb), `<` (kisebb), `>=` (nagyobb vagy egyenlő), `<=` (kisebb vagy egyenlő)

### 3.3. Logikai

`&&` (logikai ÉS), `||` (logikai VAGY), `!` (logikai NEM)

### 3.4. Értékadó

`=` (egyszerű értékadás)
`+=`, `-=`, `*=`, `/=`, `%=` (kombinált értékadás, pl. `x += 5` ugyanaz, mint `x = x + 5`)

## 4. Vezérlési Szerkezetek

### 4.1. `if-else if-else`

Feltételes elágazás.

```csharp
int number = 10;
if (number > 0)
{
    Console.WriteLine("Pozitív");
}
else if (number < 0)
{
    Console.WriteLine("Negatív");
}
else
{
    Console.WriteLine("Nulla");
}
```

### 4.2. `switch`

Többirányú elágazás egy kifejezés értéke alapján.

```csharp
char grade = 'B';
switch (grade)
{
    case 'A':
        Console.WriteLine("Kiváló");
        break;
    case 'B':
        Console.WriteLine("Jó");
        break;
    case 'C':
        Console.WriteLine("Közepes");
        break;
    default:
        Console.WriteLine("Elégtelen");
        break;
}
```

### 4.3. Ciklusok

-   **`for`**: Meghatározott számú ismétlésre.

    ```csharp
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine($"i értéke: {i}"); // String interpoláció
    }
    ```

-   **`while`**: Amíg egy feltétel igaz.

    ```csharp
    int count = 0;
    while (count < 3)
    {
        Console.WriteLine($"Számláló: {count}");
        count++;
    }
    ```

-   **`do-while`**: Hasonló a `while`-hoz, de a ciklusmag legalább egyszer lefut.

    ```csharp
    int j = 0;
    do
    {
        Console.WriteLine($"j értéke: {j}");
        j++;
    } while (j < 3);
    ```

-   **`foreach`**: Gyűjtemények (pl. tömbök, listák) elemeinek bejárására.

    ```csharp
    string[] names = { "Alice", "Bob", "Charlie" };
    foreach (string name in names)
    {
        Console.WriteLine(name);
    }
    ```

### 4.4. Ciklusvezérlő utasítások

-   `break`: Azonnal kilép a ciklusból (vagy `switch`-ből).
-   `continue`: Átugorja a ciklusmag aktuális iterációjának hátralévő részét, és a következő iterációval folytatja.

## 5. Metódusok (Függvények)

Újrafelhasználható kódrészletek.

```csharp
// Metódus definíciója
// Láthatóság VisszatérésiTípus Név(Paraméterlista)
public int AddNumbers(int a, int b)
{
    return a + b;
}

// Metódus hívása
int sum = AddNumbers(5, 3); // sum értéke 8 lesz

// void metódus (nem ad vissza értéket)
public void Greet(string name)
{
    Console.WriteLine($"Hello, {name}!");
}
Greet("Anna");
```

### 5.1. Opcionális és Nevesített Argumentumok

```csharp
public void PrintDetails(string name, int age = 30, string city = "Budapest")
{
    Console.WriteLine($"{name}, {age} éves, város: {city}");
}

PrintDetails("Péter"); // age és city alapértelmezett
PrintDetails("Kati", 25); // city alapértelmezett
PrintDetails("Laci", city: "Debrecen"); // age alapértelmezett, city nevesítve
```

## 6. Tömbök és Kollekciók

### 6.1. Tömbök (Arrays)

Fix méretű, azonos típusú elemek sorozata.

```csharp
// Deklaráció és inicializálás
int[] numbers = new int[3]; // 3 elemű int tömb
numbers[0] = 10;
numbers[1] = 20;
numbers[2] = 30;

string[] fruits = { "alma", "körte", "szilva" }; // Rövidített inicializálás

Console.WriteLine(fruits[1]); // "körte"
Console.WriteLine(numbers.Length); // 3 (tömb hossza)
```

### 6.2. Listák (`List<T>`)

Dinamikus méretű gyűjtemény (a `System.Collections.Generic` névtérben).

```csharp
using System.Collections.Generic;

List<string> names = new List<string>();
names.Add("Erik");
names.Add("Zsófia");
names.Add("Bence");

names.Remove("Zsófia");

foreach (string name in names)
{
    Console.WriteLine(name);
}
Console.WriteLine(names.Count); // Lista elemeinek száma
```

## 7. Objektum Orientált Programozás (OOP)

### 7.1. Osztályok és Objektumok

-   **Osztály (`class`)**: Tervrajz vagy sablon objektumok létrehozásához. Adattagokat (mezőket, tulajdonságokat) és viselkedést (metódusokat) definiál.
-   **Objektum**: Az osztály egy konkrét példánya.

```csharp
public class Car
{
    // Mezők (általában private)
    private string _color;
    private int _maxSpeed;

    // Tulajdonságok (Properties) - kontrolált hozzáférés a mezőkhöz
    public string Color
    {
        get { return _color; }
        set { _color = value; }
    }

    public int MaxSpeed
    {
        get { return _maxSpeed; }
        set
        {
            if (value > 0) // Validáció
                _maxSpeed = value;
        }
    }
    
    // Auto-implemented property (rövidített szintaxis)
    public string Model { get; set; }

    // Konstruktor (objektum létrehozásakor hívódik meg)
    public Car(string model, string color, int maxSpeed)
    {
        Model = model;
        Color = color; // A settert hívja meg
        MaxSpeed = maxSpeed; // A settert hívja meg
        Console.WriteLine($"{Model} autó létrehozva.");
    }

    // Metódus
    public void StartEngine()
    {
        Console.WriteLine($"{Model} motorja beindult.");
    }
}

// Objektum létrehozása (példányosítás)
Car myCar = new Car("Tesla Model S", "Piros", 250);
myCar.StartEngine();
Console.WriteLine($"Az autóm színe: {myCar.Color}");
myCar.Color = "Kék"; // Tulajdonság settere hívódik
```

### 7.2. Öröklődés

Lehetővé teszi új osztályok létrehozását meglévő osztályok alapján, örökölve azok tagjait.
Jelölése: `: OsztályNév`

```csharp
public class Animal
{
    public string Name { get; set; }
    public virtual void MakeSound() // virtual: felülírhatóvá teszi a leszármazott osztályokban
    {
        Console.WriteLine("Generic animal sound");
    }
}

public class Dog : Animal // Dog örököl Animal-től
{
    public override void MakeSound() // override: felülírja az ősosztály metódusát
    {
        Console.WriteLine("Vau!");
    }
}

Dog myDog = new Dog { Name = "Bodri" };
myDog.MakeSound(); // "Vau!"
```

### 7.3. Polimorfizmus (Többalakúság)

"Sok forma". Lehetővé teszi, hogy egy ősosztály típusú referencián keresztül különböző leszármazott osztályok objektumait kezeljük, és azok a saját, felülírt metódusaikat hívják.

```csharp
Animal myAnimal = new Dog(); // Dog objektum Animal referencián keresztül
myAnimal.MakeSound(); // A Dog.MakeSound() hívódik meg ("Vau!")
```

### 7.4. Absztrakt Osztályok és Metódusok

-   **`abstract class`**: Nem lehet példányosítani. Arra szolgál, hogy közös alapot biztosítson leszármazott osztályoknak. Tartalmazhat absztrakt és konkrét metódusokat is.
-   **`abstract method`**: Nincs implementációja az absztrakt osztályban, a leszármazott osztályoknak kötelező implementálniuk (felülírniuk).

```csharp
public abstract class Shape
{
    public abstract double CalculateArea(); // Nincs törzse
    public void Display()
    {
        Console.WriteLine("Ez egy alakzat.");
    }
}

public class Circle : Shape
{
    public double Radius { get; set; }
    public Circle(double radius) { Radius = radius; }

    public override double CalculateArea() // Kötelező implementálni
    {
        return Math.PI * Radius * Radius;
    }
}
```

### 7.5. Interfészek (`interface`)

Szerződést definiálnak, amit az implementáló osztályoknak teljesíteniük kell. Csak metódus-szignatúrákat, tulajdonságokat, eseményeket és indexelőket tartalmazhatnak (implementáció nélkül, bár C# 8.0+ verziótól lehet default implementáció).

```csharp
public interface IDrawable
{
    void Draw(); // Nincs implementáció, nincs láthatósági módosító (automatikusan public)
}

public class Button : IDrawable
{
    public void Draw() // Implementálja az interfész metódusát
    {
        Console.WriteLine("Gomb kirajzolása.");
    }
}

IDrawable myButton = new Button();
myButton.Draw();
```

## 8. Kivételkezelés (`try-catch-finally`)

Hibák és rendellenes helyzetek kezelése.

```csharp
try
{
    // Potenciálisan hibát dobó kód
    int x = 10;
    int y = 0;
    int result = x / y; // System.DivideByZeroException
    Console.WriteLine(result);
}
catch (DivideByZeroException ex) // Specifikus kivétel elkapása
{
    Console.WriteLine($"Hiba: Nullával való osztás! ({ex.Message})");
}
catch (Exception ex) // Általános kivétel elkapása (mindig a specifikusabbak után)
{
    Console.WriteLine($"Általános hiba történt: {ex.Message}");
}
finally
{
    // Ez a blokk mindig lefut, akár volt kivétel, akár nem
    // (pl. erőforrások felszabadítására)
    Console.WriteLine("A finally blokk lefutott.");
}
```

## 9. További Fontosabb Fogalmak (Röviden)

-   **`enum` (Enumerációk)**: Nevesített konstansok halmaza.
    ```csharp
    public enum Day { Mon, Tue, Wed, Thu, Fri, Sat, Sun }
    Day today = Day.Mon;
    ```
-   **`struct` (Struktúrák)**: Értéktípusok, hasonlóak az osztályokhoz, de könnyebb, "kisebb" adatszerkezetekhez ajánlottak. Stack-en tárolódnak (általában).
-   **Generikusok (`<T>`)**: Típusparaméterezett osztályok és metódusok létrehozása, pl. `List<T>`, `Dictionary<TKey, TValue>`. Növelik a kód újrafelhasználhatóságát és típusbiztonságát.
-   **LINQ (Language Integrated Query)**: Egységes lekérdező nyelv adatforrások (objektumgyűjtemények, adatbázisok, XML) kezelésére.
    ```csharp
    List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
    var evenNumbers = numbers.Where(n => n % 2 == 0).ToList(); // 2, 4, 6
    ```
-   **Aszinkron Programozás (`async`/`await`)**: Hosszú ideig futó műveletek kezelése a felhasználói felület blokkolása nélkül.
    ```csharp
    public async Task<string> GetDataAsync()
    {
        // Hosszú művelet, pl. hálózati kérés
        await Task.Delay(1000); // Szimulál egy másodperces késleltetést
        return "Adat letöltve";
    }
    ```

