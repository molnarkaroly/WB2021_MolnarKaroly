A programozási alaptételek azok a klasszikus algoritmusok, amelyekkel szinte minden adatfeldolgozási feladat megoldható. C#-ban ezeket megírhatjuk hagyományosan (ciklusokkal) vagy modern módon (LINQ-val).

Íme a legfontosabbak

### 1. Összegzés tétele (Summation)
Egy sorozat elemeinek összegét számoljuk ki.
   Működése Kell egy változó (szumma), amit nulláról indítunk, majd minden elemet hozzáadunk.
```csharp
int osszeg = 0;
foreach (var elem in lista) {
    osszeg += elem;
}
 LINQ int osszeg = lista.Sum();
```

### 2. Megszámolás tétele (Counting)
Megszámoljuk, hány elem felel meg egy adott feltételnek.
   Működése Kell egy számláló változó, amit nulláról indítunk. Ha az elem igaz a feltételre, növeljük eggyel.
```csharp
int db = 0;
foreach (var elem in lista) {
    if (elem  50) db++;  Példa feltétel
}
 LINQ int db = lista.Count(x = x  50);
```

### 3. Eldöntés tétele (Decision)
Van-e legalább egy olyan elem a sorozatban, ami megfelel a feltételnek
   Működése Addig megyünk a ciklussal, amíg meg nem találjuk az elsőt. Ha megvan, kilépünk (break).
```csharp
bool vanE = false;
foreach (var elem in lista) {
    if (elem == keresettErtek) {
        vanE = true;
        break;  Megvan, nem kell tovább nézni
    }
}
 LINQ bool vanE = lista.Any(x = x == keresettErtek);
```

### 4. Kiválasztás tétele (Selection)
Biztosan tudjuk, hogy az elem benne van a sorozatban, és keressük a helyét (indexét) vagy magát az objektumot.
```csharp
int i = 0;
while (lista[i] != keresettErtek) {
    i++;
}
 Az eredmény az 'i' index.
```

### 5. Keresés tétele (Linear Search)
Kombinálja az eldöntést és a kiválasztást. Nem tudjuk, benne van-e, ha igen, megkeressük hol.
```csharp
int index = -1;  -1-gyel indítjuk, ha nem találjuk meg
for (int i = 0; i  lista.Count; i++) {
    if (lista[i] == keresettErtek) {
        index = i;
        break;
    }
}
```

### 6. Szélsőérték keresése (MinMax)
A legkisebb vagy legnagyobb elemet keressük.
   Működése Kinevezzük a legelső elemet legnagyobbnak. Majd végigmenve a többieken, ha találunk nála is nagyobbat, lecseréljük.
```csharp
int legnagyobb = lista[0];
foreach (var elem in lista) {
    if (elem  legnagyobb) {
        legnagyobb = elem;
    }
}
 LINQ int max = lista.Max();
```

### 7. Kiválogatás tétele (Filtering)
Egy meglévő listából kigyűjtjük azokat az elemeket egy ÚJ listába, amik megfelelnek egy feltételnek.
```csharp
Listint valogatott = new Listint();
foreach (var elem in lista) {
    if (elem % 2 == 0) {  Párosak kiválogatása
        valogatott.Add(elem);
    }
}
 LINQ var valogatott = lista.Where(x = x % 2 == 0).ToList();
```

---

### Melyiket mikor használd a vizsgán

1.  Ha átlagot kérnek Használd az Összegzést és a Megszámolást (Átlag = Összeg  Darabszám).
2.  Ha a leg-valamilyenebbet kérik (legolcsóbb, leggyorsabb) Használd a Szélsőérték keresést.
3.  Ha azt kérdezik, van-e olyan... Használd az Eldöntést.
4.  Ha listát kell készíteni bizonyos elemekből Használd a Kiválogatást.

Tipp A modern C# fejlesztésben a LINQ (Sum, Count, Any, Max, Where) sokkal gyorsabb és kevesebb hibalehetőséget rejt, de a vizsgán néha kérik, hogy tudd a hagyományos ciklusos megoldást is!