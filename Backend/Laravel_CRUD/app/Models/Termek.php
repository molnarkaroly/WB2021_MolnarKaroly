<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class Termek extends Model
{
    protected $fillable = ['nev', 'ar', 'kategoria_id'];

    public function kategoria()
    {
        return $this->belongsTo(Kategoria::class);
    }
}
