<?php

namespace App\Http\Controllers;

use App\Models\Ingatlan;
use Illuminate\Http\Request;

class IngatlanController extends Controller
{
    
       public function index()
    {
        $ingatlanok = Ingatlan::with('kategoriaRel')->get();
 
        $result = $ingatlanok->map(function ($i) {
            return [
                'id'             => $i->id,
                'kategoria'      => $i->kategoriaRel->nev,
                'leiras'         => $i->leiras,
                'hirdetesDatuma' => $i->hirdetesDatuma,
                'tehermentes'    => (bool) $i->tehermentes? 'Igen' : 'Nem',
                'ar'             => $i->ar . ' Ft',
                'kepUrl'         => $i->kepUrl,
            ];
        });
 
        return response()->json($result, 200);
    }


        public function store(Request $request)
    {
        // Kötelező mezők ellenőrzése
        if (!$request->filled('kategoria') ||
            !$request->filled('leiras') ||
            !$request->filled('tehermentes') ||
            !$request->filled('ar')) {
            return response()->json('Hiányos adatok.', 400);
        }
 
        $ingatlan = Ingatlan::create([
            'kategoria'      => $request->kategoria,
            'leiras'         => $request->leiras,
            'hirdetesDatuma' => $request->hirdetesDatuma ?? now()->toDateString(),
            'tehermentes'    => $request->tehermentes,
            'ar'             => $request->ar,
            'kepUrl'         => $request->kepUrl,
        ]);
 
        return response()->json(['Id' => $ingatlan->id], 201);
    }




    public function destroy(Ingatlan $ingatlan)
    {
        $ingatlan = Ingatlan::find($id);
 
        if (!$ingatlan) {
            return response()->json('Az ingatlan nem létezik.', 404);
        }
 
        $ingatlan->delete();
 
        return response()->noContent(); // 204 NO CONTENT
    }
}
