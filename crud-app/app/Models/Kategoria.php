<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class Kategoria extends Model
{
    protected $fillable = ['nev'];

    public function termekek()
    {
        return $this->hasMany(Termek::class);
    }
}
