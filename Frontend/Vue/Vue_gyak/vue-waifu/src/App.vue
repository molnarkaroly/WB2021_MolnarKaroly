<script setup>
import { ref } from 'vue';
import axios from 'axios';

// Reaktív változó a képek tárolására.
// A 'ref' biztosítja, hogy a változó frissülésekor a template is újrarenderelődjön.
const images = ref([]);
const isLoading = ref(false);
const errorMessage = ref('');

// Aszinkron függvény a képek lekérésére.
const fetchWaifuImage = async () => {
  isLoading.value = true;
  errorMessage.value = '';
  images.value = []; // Töröljük a korábbi képeket minden új kérésnél

  try {
    // Axios GET kérés az API végpontra.
    const response = await axios.get('https://api.waifu.im/images?IncludedTags=waifu&IsNsfw=True');

    // A válaszban kapott képeket elmentjük a reaktív változóba.
    // A waifu.im API egy 'images' tömböt ad vissza, ami objektumokat tartalmaz.
    if (response.data.items && response.data) {
      images.value = response.data.items;
    } else {
      errorMessage.value = 'Nem található kép a válaszban.';
    }

  } catch (error) {
    // Hiba esetén beállítjuk a hibaüzenetet.
    console.error('Hiba történt az API kérés során:', error);
    errorMessage.value = 'Hiba történt a képek lekérése közben. Kérlek, próbáld újra később.';
  } finally {
    // Betöltés vége, a betöltési állapotot hamisra állítjuk.
    isLoading.value = false;
  }
};
</script>

<template>
  <main>
    <div class="header">
      <h1>Waifu Kép Lekérő</h1>
      <p>Kattints a gombra egy véletlenszerű kép lekéréséhez a waifu.im API-ról.</p>
    </div>

    <div class="controls">
      <!-- A gombra kattintva lefut a fetchWaifuImage függvény -->
      <button @click="fetchWaifuImage" :disabled="isLoading">
        {{ isLoading ? 'Betöltés...' : 'Új Kép Kérése' }}
      </button>
    </div>

    <!-- Hibaüzenet megjelenítése, ha van -->
    <div v-if="errorMessage" class="error">
      {{ errorMessage }}
    </div>

    <!-- Betöltési animáció -->
    <div v-if="isLoading" class="loading">
      <p>Képek betöltése...</p>
    </div>

    <!-- Képek megjelenítése, ha sikeres volt a lekérés -->
    <div v-if="images.length > 0" class="image-gallery">
      <!-- A 'v-for' végigmegy a 'images' tömbön és minden elemre létrehoz egy 'img' taget. -->
      <div v-for="image in images" :key="image.image_id" class="image-container">
        <img :src="image.url" :alt="image.tags[0]?.description || 'Waifu kép'">
      </div>
    </div>
  </main>
</template>

<style>
  body {
    font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, Helvetica, Arial, sans-serif;
    background-color: #f0f2f5;
    color: #333;
    display: flex;
    justify-content: center;
    align-items: center;
    min-height: 100vh;
    margin: 0;
  }

  main {
    background-color: white;
    padding: 2rem;
    border-radius: 12px;
    box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
    text-align: center;
    max-width: 90%;
    width: 800px;
  }

  .header h1 {
    margin-top: 0;
    color: #1a1a1a;
  }

  .controls {
    margin: 1.5rem 0;
  }

  button {
    padding: 0.8rem 1.5rem;
    font-size: 1rem;
    cursor: pointer;
    background-color: #42b883;
    color: white;
    border: none;
    border-radius: 8px;
    transition: background-color 0.3s ease;
  }

  button:disabled {
    background-color: #a4d4be;
    cursor: not-allowed;
  }

  button:hover:not(:disabled) {
    background-color: #33a06f;
  }

  .error {
    color: #e74c3c;
    margin-top: 1rem;
  }

  .image-gallery {
    margin-top: 2rem;
    display: flex;
    justify-content: center;
    flex-wrap: wrap;
    gap: 1rem;
  }

  .image-container img {
    max-width: 100%;
    height: auto;
    border-radius: 8px;
    box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);
  }
</style>