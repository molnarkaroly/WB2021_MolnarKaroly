<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;
use App\Models\Category;

class Fruits extends Model
{
    protected $table = 'fruits';
    protected $fillable = [
        'name',
        'image',
        'price',
        'description',
        'category_id',
    ];

    public function category()
    {
        return $this->belongsTo(Category::class);
    }

    public $timestamps = false;
}
