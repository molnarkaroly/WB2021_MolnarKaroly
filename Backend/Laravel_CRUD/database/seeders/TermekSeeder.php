<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use App\Models\Termek;

class TermekSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        Termek::create([
            'nev' => 'Okostelefon',
            'ar' => 150000,
            'kategoria_id' => 1
        ]);

        Termek::create([
            'nev' => 'Laptop',
            'ar' => 300000,
            'kategoria_id' => 1
        ]);

        Termek::create([
            'nev' => 'Fülhallgató',
            'ar' => 25000,
            'kategoria_id' => 1
        ]);
    }
}
