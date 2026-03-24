<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    /**
     * Run the migrations.
     */
   public function up(): void
    {
        Schema::create('ingatlanok', function (Blueprint $table) {
        $table->id();                                      // PK, auto increment
        $table->unsignedBigInteger('kategoria');           // FK mező
        $table->foreign('kategoria')->references('id')->on('kategoriak');
        $table->text('leiras');
        $table->date('hirdetesDatuma')->default(now());    // 4. feladat: alapért. = ma
        $table->boolean('tehermentes');
        $table->integer('ar');
        $table->string('kepUrl')->nullable();
    });
}


    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('ingatlans');
    }
};
