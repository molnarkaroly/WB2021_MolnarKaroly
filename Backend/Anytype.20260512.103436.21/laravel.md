---
# yaml-language-server: $schema=schemas\page.schema.json
Object type:
    - Page
Backlinks:
    - Jegyzet
Creation date: "2026-04-25T08:07:31Z"
Created by:
    - molnarkaroly
Links:
    - API_DOCUMENTATION
id: bafyreielbnhaum4bjfscx5wv3v6aifdbws4qfnxglt7ofpkdgk5jsph7ra
---
# :Laravel:   
Projekt létrehozása:   
```
composer create-project laravel/laravel [projekt-nev]

```
```
cd [projektmappa]
```
Modellek generálása migrácioval   
```
php artisan make:model Category -m
php artisan make:model Event -m

```
migrations   
```
    public function up(): void
    {
        Schema::create('events', function (Blueprint $table) {
            $table->id();
            $table->string('cim');
            $table->text('leiras');
            $table->dateTime('idopont');
            $table->string('helyszin');
            $table->foreignId('category_id')->constrained('categories')->cascadeOnDelete();
            $table->timestamps();
        });
    }


```
ha nem kell timestamp:   
```
// a migration fájlbol csak kivesz és a app/modell fájlba kell írni hogy:
    public $timestamps = false;

```
```
   // ha átnevezed a táblát és fájlokat
    protected $table = 'radio';

```
migráció futtatása   
```
php artisan migrate

```
ezz kell hogy ne adjon hibát a kitölthető cellák neveit megadni:

   
```
    protected $fillable = [
        'cim',
        'leiras',
        'idopont',
        'helyszin',
        'category_id'
    ];

```
Táblák összekötése:
   
több   
```
public function events()
    {
        return $this->hasMany(Event::class, 'category_id');
    }
```
1es   
```
 public function category()
    {
        return $this->belongsTo(Category::class, 'category_id');
    }
```
FONTOS! azt kell hamarabb létrehozni amelyikre hivatkozik a másik tábla (amelyikben van a kulcs amire a másik idegenkulcsa szól = nem az idegenkulcsos tábla)   
Seeder   
Seeder létrehozása:   
```
php artisan make:seeder CategorySeeder

```
forma:   
```
		Category::create(['nev' => 'Zenei programok']);
        Category::create(['nev' => 'Sport események']);
        Category::create(['nev' => 'Színházi előadások']);
```
DatabaseSeeder fájlba ki venni a run() fügvényből a usert és be rakni a helyére a saját seeder fájl elérését
   
```
//run()
        $this->call(CategorySeeder::class);

```
```
php artisan migrate:fresh --seed

```
Api kontroller létrehozása apik megírása:   
```
php artisan install:api

```
```
php artisan make:controller EventController --api
```
> app/https/contorllers megírása   
>    

   
routesbe kell megadni hogy    
```
use App\Http\Controllers\RadioController;
use Illuminate\Support\Facades\Route;

Route::get('/radios', [RadioController::class, 'index']);
Route::post('/radios', [RadioController::class, 'store']);
Route::get('/radios/{id}', [RadioController::class, 'show']);

// Update (Frissítés) - A PUT a teljes csere, a PATCH a részleges frissítés standardja
Route::put('/radios/{id}', [RadioController::class, 'update']);
Route::patch('/radios/{id}', [RadioController::class, 'update']);

// Delete (Törlés)
Route::delete('/radios/{id}', [RadioController::class, 'destroy']);


```
```
php artisan serve

```
[API_DOCUMENTATION](files\api_documentation.md)    
   
