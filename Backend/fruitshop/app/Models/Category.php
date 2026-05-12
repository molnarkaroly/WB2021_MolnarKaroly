<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;
use App\Models\Fruits;

class Category extends Model
{
    protected $fillable = [
        'name',
        'description',
    ];

    public function fruits()
    {
        return $this->hasMany(Fruits::class);
    }

    public $timestamps = false;
    protected $table = 'categories';
}
