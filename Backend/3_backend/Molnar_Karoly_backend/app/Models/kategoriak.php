<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;
use App\Models\ingatlanok;

class kategoriak extends Model
{
    public $timestamps = false;
    protected $fillable = ['id', 'nev'];
    protected $table = 'kategoriak';

    public function ingatlanok()
    {
        return $this->hasMany(ingatlanok::class, 'kategoria');
    }

}
