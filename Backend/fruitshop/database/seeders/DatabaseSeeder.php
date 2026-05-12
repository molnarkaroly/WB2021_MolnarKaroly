<?php

namespace Database\Seeders;

use App\Models\User;
use App\Models\Category;
use App\Models\Fruits;
use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;

class DatabaseSeeder extends Seeder
{
    use WithoutModelEvents;

    /**
     * Seed the application's database.
     */
    public function run(): void
    {
        // User::factory(10)->create();

        User::factory()->create([
            'name' => 'Test User',
            'email' => 'test@example.com',
        ]);

        $kategoriak = [
            ['name' => 'Déli gyümölcsök', 'description' => 'Trópusi és szubtrópusi tájakról származó gyümölcsök.'],
            ['name' => 'Hazai gyümölcsök', 'description' => 'Magyarországon őshonos vagy termesztett gyümölcsök.'],
            ['name' => 'Bogyós gyümölcsök', 'description' => 'Apró termésű, lédús bogyók.'],
            ['name' => 'Csonthéjasok', 'description' => 'Csonthéjas maggal rendelkező gyümölcsök.'],
            ['name' => 'Egzotikus gyümölcsök', 'description' => 'Különleges, ritka gyümölcsfajták.'],
        ];

        foreach ($kategoriak as $kat) {
            Category::create($kat);
        }

        $gyumolcsok = [
            ['name' => 'Banán', 'image' => 'banan.jpg', 'price' => 500, 'description' => 'Sárga és édes.', 'category_id' => 1],
            ['name' => 'Alma', 'image' => 'alma.jpg', 'price' => 350, 'description' => 'Piros pozsgás Jonatán.', 'category_id' => 2],
            ['name' => 'Eper', 'image' => 'eper.jpg', 'price' => 1200, 'description' => 'Friss tavaszi íz.', 'category_id' => 3],
            ['name' => 'Barack', 'image' => 'barack.jpg', 'price' => 600, 'description' => 'Lédús sárgabarack.', 'category_id' => 4],
            ['name' => 'Mangó', 'image' => 'mango.jpg', 'price' => 800, 'description' => 'Érett, lédús mangó.', 'category_id' => 5],
        ];

        foreach ($gyumolcsok as $gy) {
            Fruits::create($gy);
        }
    }
}
