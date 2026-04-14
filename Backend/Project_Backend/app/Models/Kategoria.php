<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class Kategoria extends Model
{
    protected $table = 'kategoriak';   // explicit táblanév
    public $timestamps = false;         // nincs created_at / updated_at
 
    protected $fillable = ['nev'];
 
    public function ingatlanok()
    {
        return $this->hasMany(Ingatlan::class, 'kategoria');
    }

}
