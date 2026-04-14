<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;


class IngatlanokSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        DB::table('ingatlanok')->insert([
    [
        'kategoria'      => 2,
        'leiras'         => 'Eladó lakás a belvárosban',
        'hirdetesDatuma' => '2022-03-10',
        'tehermentes'    => true,
        'ar'             => 26990000,
        'kepUrl'         => 'https://example.com/kep.jpg',
    ],
    // ... több rekord
]);
    }
}
