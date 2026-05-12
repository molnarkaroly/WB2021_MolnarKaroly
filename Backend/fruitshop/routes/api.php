<?php

use App\Http\Controllers\fruitController;
use Illuminate\Support\Facades\Route;

Route::get('/fruits', [fruitController::class, 'index']);
Route::post('/fruits', [fruitController::class, 'store']);
Route::get('/fruits/{id}', [fruitController::class, 'show']);
Route::put('/fruits/{id}', [fruitController::class, 'update']);
Route::delete('/fruits/{id}', [fruitController::class, 'destroy']);
