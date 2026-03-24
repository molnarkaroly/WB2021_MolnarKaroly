<?php
 
namespace App\Models;
 
use Illuminate\Database\Eloquent\Model;
 
class Ingatlan extends Model
{
    protected $table = 'ingatlanok';
    public $timestamps = false;
 
    protected $fillable = [
        'kategoria',
        'leiras',
        'hirdetesDatuma',
        'tehermentes',
        'ar',
        'kepUrl',
    ];
 
    public function kategoriaRel()
    {
        return $this->belongsTo(Kategoria::class, 'kategoria');
    }
}
