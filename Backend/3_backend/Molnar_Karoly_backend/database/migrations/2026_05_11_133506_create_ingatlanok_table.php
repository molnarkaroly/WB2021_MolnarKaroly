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
            $table->id();
            $table->foreignId('kategoria')->references('id')->on('kategoriak');
            $table->string('leiras');
            $table->timestamp('hirdetesDatuma')->default(now());
            $table->boolean('tehermentes');
            $table->integer('ar');
            $table->string('kepUrl');
        });
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('ingatlanok');
    }
};
