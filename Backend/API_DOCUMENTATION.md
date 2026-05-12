# Radio API Dokumentáció

Ez a dokumentum részletesen bemutatja az API felépítését, a kódmagyarázatokat és a használt JSON formátumokat.

---

## 1. API Útvonalak (`routes/api.php`)

Az útvonalak határozzák meg, hogy milyen URL-eken keresztül érhető el az API. Minden itt definiált útvonal automatikusan megkapja az `/api` előtagot.

### A kód:
```php
use App\Http\Controllers\RadioController;
use Illuminate\Support\Facades\Route;

Route::get('/radios', [RadioController::class, 'index']);
Route::post('/radios', [RadioController::class, 'store']);
Route::get('/radios/{id}', [RadioController::class, 'show']);
Route::put('/radios/{id}', [RadioController::class, 'update']);
```

### Magyarázat:
- **`GET /api/radios`**: Meghívja az `index` metódust. Lekéri az összes rádiót.
- **`POST /api/radios`**: Meghívja a `store` metódust. Új rádiót ment el.
- **`GET /api/radios/{id}`**: Meghívja a `show` metódust. Egy adott azonosítójú (`id`) rádiót ad vissza.
- **`PUT /api/radios/{id}`**: Meghívja az `update` metódust. Frissíti egy létező rádió adatait.

---

## 2. Controller Magyarázat (`app/Http/Controllers/RadioController.php`)

A controller tartalmazza az üzleti logikát. Itt dől el, hogy mi történjen az adatokkal.

### `index()` - Listázás
```php
public function index()
{
    // Lekéri az összes rádiót az 'adok' kapcsolattal együtt, név szerint sorba rendezve.
    return Radio::with('adok')->orderBy('name', 'asc')->get();
}
```
- **Működés**: A `with('adok')` betölti a rádióhoz tartozó adótorony adatait is, így nem kell külön lekérdezést futtatni értük (Eager Loading).

### `store(Request $request)` - Mentés
```php
public function store(Request $request)
{
    // Adatok validálása
    $validated = $request->validate([
        'name' => 'required',
        'frequency' => 'required',
        'adok_id' => 'required|exists:adok,id',
        'image_link' => 'nullable|string',
        'link' => 'nullable|string',
    ]);

    // Új rekord létrehozása a validált adatokkal
    return Radio::create($validated);
}
```
- **Működés**: Ellenőrzi, hogy minden kötelező mező megvan-e, és hogy az `adok_id` létezik-e az adatbázisban.

### `show(string $id)` - Megtekintés
```php
public function show(string $id)
{
    // Egy konkrét rádió megkeresése az adótorony adataival együtt
    return Radio::with('adok')->find($id);
}
```

### `update(Request $request, string $id)` - Módosítás
```php
public function update(Request $request, string $id)
{
    $validated = $request->validate([
        'name' => 'required',
        'frequency' => 'required',
        'adok_id' => 'required|exists:adok,id',
        'image_link' => 'nullable|string',
        'link' => 'nullable|string',
    ]);

    $radio = Radio::find($id);
    $radio->update($validated); // Adatok frissítése
    return $radio;
}
```

### `destroy(string $id)` - Törlés
```php
public function destroy(string $id)
{
    $radio = Radio::find($id);
    $radio->delete(); // Rekord törlése
    return response()->json([
        'message' => 'Radio deleted successfully',
    ]);
}
```

---

## 3. JSON Formátumok

### Adatküldés (Request Body)
Új rádió létrehozásakor vagy módosításakor (`POST`/`PUT`) ezt a JSON-t kell küldeni:
```json
{
    "name": "Rádió Neve",
    "frequency": "101.5",
    "adok_id": 1,
    "image_link": "http://link.hu/kep.jpg",
    "link": "http://stream.hu/live"
}
```

### Adatfogadás (Response Body)
A szerver ilyen formátumban adja vissza az adatokat:
```json
{
    "id": 1,
    "name": "Rádió Neve",
    "frequency": "101.5",
    "image_link": "...",
    "link": "...",
    "adok_id": 1,
    "adok": {
        "id": 1,
        "name": "Adótorony Neve",
        "city": "Város"
    }
}
```
