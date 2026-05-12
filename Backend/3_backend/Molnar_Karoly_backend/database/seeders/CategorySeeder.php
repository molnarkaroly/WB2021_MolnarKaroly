<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use App\Models\kategoriak;

class CategorySeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        kategoriak::create(['nev' => 'Ház']);
        kategoriak::create(['nev' => 'Lakás']);
        kategoriak::create(['nev' => 'Építési telek']);
        kategoriak::create(['nev' => 'Garázs']);
        kategoriak::create(['nev' => 'Mezőgazdasági terület']);
        kategoriak::create(['nev' => 'Ipari ingatlan']);
    }
}
