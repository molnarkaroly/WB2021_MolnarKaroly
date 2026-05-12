<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;
use App\Models\kategoriak;

class ingatlanok extends Model
{
    public $timestamps = false;
    protected $fillable = ['id', 'kategoria', 'leiras', 'hirdetesDatuma', 'tehermentes', 'ar', 'kepUrl'];
    protected $table = 'ingatlanok';

   
     public function kategoriak()
    {
        return $this->belongsTo(kategoriak::class, 'kategoria');
    }

}
