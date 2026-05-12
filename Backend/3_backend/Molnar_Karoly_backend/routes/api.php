<?php

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;
use App\Http\Controllers\ingatlanController;

Route::get('/ingatlan', [ingatlanController::class, 'index']);
Route::post('/ingatlan', [ingatlanController::class, 'store']);
Route::delete('/ingatlan/{id}', [ingatlanController::class, 'destroy']);
