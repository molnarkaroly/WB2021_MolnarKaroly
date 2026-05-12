<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\ingatlanok;
use Illuminate\Support\Facades\Validator;

class ingatlanController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        return ingatlanok::join('kategoriak', 'ingatlanok.kategoria', 'kategoriak.id')
            ->get(['ingatlanok.*', 'kategoriak.nev as kategoria']);
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(Request $request)
    {
        // 1. Ellenőrzés (Validator) létrehozása a szabályokkal
        $validator = Validator::make($request->all(), [
            'kategoria' => 'required',
            'leiras' => 'required',
            'hirdetesDatuma' => 'nullable',
            'tehermentes' => 'required',
            'ar' => 'required',
            'kepUrl' => 'required',
        ]);

        // 2. Ha az ellenőrzés elbukik (hiányzik valami), 400-as hibát küldünk
        if ($validator->fails()) {
            return response()->json([
            'Hiányos adatok.',
            ], 400);
        }

        // 3. Ha minden rendben, létrehozzuk az adatbázis rekordot
        $ujIngatlan = ingatlanok::create($validator->validated());

        // 4. Visszaküldjük az új rekord ID-ját 201-es kóddal
        return response()->json([
            'id' => $ujIngatlan->id
        ], 201);
    }


    /**
     * Remove the specified resource from storage.
     */
    public function destroy(string $id)
    {
        $deletedCount = ingatlanok::destroy($id);
        if ($deletedCount > 0) {
            return response()->json(null, 204);
        } else {
            return response()->json([
                'Az ingatlan nem létezik.'
            ], 404);
        }
    }
}
