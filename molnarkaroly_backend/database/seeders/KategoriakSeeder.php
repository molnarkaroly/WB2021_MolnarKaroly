<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class KategoriakSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
       public function run(): void
    {
        DB::table('kategoriak')->insert([
            ['id' => 1, 'nev' => 'Ház'],
            ['id' => 2, 'nev' => 'Lakás'],
            ['id' => 3, 'nev' => 'Építési telek'],
            ['id' => 4, 'nev' => 'Garázs'],
            ['id' => 5, 'nev' => 'Mezőgazdasági terület'],
            ['id' => 6, 'nev' => 'Ipari ingatlan'],
        ]);
    }

}
