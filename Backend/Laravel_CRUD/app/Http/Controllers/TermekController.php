<?php

namespace App\Http\Controllers;

use App\Models\Termek;
use Illuminate\Http\Request;

class TermekController extends Controller
{
    /**
     * Display a listing of the resource.
     */
   public function index()
{
    return Termek::with('kategoria')->orderBy('nev','asc')->get();
}

    /**
     * Store a newly created resource in storage.
     */
    public function store(Request $request)
{
    // 1. Validáljuk az adatokat a megadott szabályok alapján
    $validatedData = $request->validate([
        'nev' => 'required|string|max:255',
        'ar' => 'required|numeric|min:0',
        'kategoria_id' => 'required|exists:kategorias,id',
    ]);

    // 2. A veszélyes $request->all() helyett csak a már ellenőrzött adatokat mentjük el
    return Termek::create($validatedData);
}


    /**
     * Display the specified resource.
     */
    public function show($id)
    {
        // FELADAT: A show metódus egyetlen konkrét terméket ad vissza. 
        // Bővítsük ki úgy, hogy betöltse a termékhez tartozó kategória teljes dokumentumát is!
        // A findOrFail() pedig biztosítja: ha az ID nem létezik (például törölték már),
        // a Laravel nem engedi összeomlani az alkalmazást, hanem elegánsan bedob egy 404-es "Not Found" hibát.
        return Termek::with('kategoria')->findOrFail($id);
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, $id)
    {
        // 1. lépés: Felkutatjuk a módosítandó terméket. Ha nincs, 404-es hiba miatt azonnal leáll a futtatás.
        $termek = Termek::findOrFail($id);

        // 2. lépés: FELADAT: Vezessünk be egy okosabb validációt (okos ellenőrzést).
        // A PUT/PATCH kéréseknél (módosításnál) gyakran nem az összes mezőt akarják frissíteni, hanem például CSAK az árat.
        // A 'sometimes' kulcsszó azt jelenti: "Csak akkor végezd el az ellenőrzéseket (hogy kötelező/szám-e), 
        // ha a felhasználó egyáltalán elküldte nekünk azt a mezőt."
        $validatedData = $request->validate([
            'nev' => 'sometimes|required|string|max:255',
            'ar' => 'sometimes|required|numeric|min:0',
            'kategoria_id' => 'sometimes|required|exists:kategorias,id',
        ]);

        // 3. lépés: A veszélyes összesítés helyett csak a tiszta adatokat frissítjük az objektumon.
        $termek->update($validatedData);

        // 4. lépés: Visszaadjuk válaszban a frissített terméket a kliensnek.
        return $termek;
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy($id)
    {
        // 1. lépés: Ellenőrizzük, hogy van-e mit letörölni. (ha nincs, 404 hiba)
        $termek = Termek::findOrFail($id);

        // 2. lépés: Ha túl vagyunk az ellenőrzésen, ténylegesen letöröljük az elemet.
        $termek->delete();

        // 3. lépés: FELADAT: Kulturált válaszadás elkészítése!
        // A destroy() csak egy "1"-es számot vagy "true" értéket szokott visszaadni, ha sikeres.
        // Ehelyett építsünk egy egyedi, professzionális formátumú JSON választ, hogy a front-endes 
        // és a mobil fejlesztők (vagy te, a képernyő túloldalán) pontosan tudjátok, mi is történt!
        return response()->json([
            'sikeres' => true,
            'uzenet' => 'A megadott terméket (' . $id . '. ID) sikeresen töröltük a rendszerből!'
        ], 200); // A 200 jelzi a "Sikeres" HTTP válaszkódot.
    }
}
