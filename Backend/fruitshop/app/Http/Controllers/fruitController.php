<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Fruits;

class fruitController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        $fruits = Fruits::with('category')->get();
        return response()->json($fruits);
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(Request $request)
    {
        $validated = $request->validate([
            'name' => 'required',
            'image' => 'required',
            'price' => 'required',
            'description' => 'nullable|string',
            'category_id' => 'required|exists:categories,id',
        ]);

        return Fruits::create($validated);
    }

    /**
     * Display the specified resource.
     */
    public function show(string $id)
    {
        return Fruits::with('category')->find($id);
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, string $id)
    {
        $validated = $request->validate([
            'name' => 'required',
            'image' => 'required',
            'price' => 'required',
            'description' => 'nullable|string',
            'category_id' => 'required|exists:categories,id',
        ]);

        $fruit = Fruits::find($id);
        $fruit->update($validated);
        return $fruit;
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(string $id)
    {
        $fruit = Fruits::find($id);
        $fruit->delete();
        return response()->json(['message' => 'Gyümölcs sikeresen törölve']);
    }
}
