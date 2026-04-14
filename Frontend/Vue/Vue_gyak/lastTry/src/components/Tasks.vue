<template>
  <div class="container mt-5">
    <h2 class="mb-4">
      <i class="bi bi-people-fill me-2 text-primary"></i>Felhasználók listája
    </h2>

    <!-- Loading spinner -->
    <div v-if="loading" class="text-center py-5">
      <div class="spinner-border text-primary" role="status">
        <span class="visually-hidden">Betöltés...</span>
      </div>
      <p class="mt-3 text-muted">Adatok betöltés...</p>
    </div>

    <!-- Error message -->
    <div v-else-if="error" class="alert alert-danger">
      <i class="bi bi-exclamation-triangle me-2"></i>{{ error }}
    </div>

    <!-- Users table -->
    <div v-else class="table-responsive">
      <table class="table table-striped table-hover table-dark shadow-sm">
        <thead class="table-dark">
          <tr>
            <th>#</th>
            <th>Név</th>
            <th>Felhasználónév</th>
            <th>E-mail</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(task, index) in tasks" :key="task.id">
            <td v-if ="task.completed">{{ task.userId }}</td>
            <td v-if ="task.completed">{{ task.id }}</td>
            <td v-if ="task.completed">{{task.title }}</td>
            <td v-if ="task.completed">{{ task.completed ? 'Teljesítve' : 'Nem teljesítve' }}</td>
        </tr>
          <tr>
            <td colspan="4" style="color: red; font-weight: bold;" class="text-center">Nem teljesített feladatok</td>
          </tr>
          <tr v-for="(task, index) in tasks" :key="task.id">
            <td v-if ="!task.completed">{{ task.userId }}</td>
            <td v-if ="!task.completed">{{ task.id }}</td>
            <td v-if ="!task.completed">{{task.title }}</td>
            <td v-if ="!task.completed">{{ task.completed ? 'Teljesítve' : 'Nem teljesítve' }}</td>
          </tr>
        </tbody>
      </table>
    </div>

    <!-- Back button -->
    <router-link to="/" class="btn btn-outline-secondary mt-3">
      <i class="bi bi-arrow-left me-2"></i>Vissza a főoldalra
    </router-link>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue'
import axios from 'axios'

const tasks = ref([])
const loading = ref(true)
const error = ref(null)

onMounted(async () => {
  try {
    const response = await axios.get('/todos')
    tasks.value = response.data
  } catch (err) {
    error.value = 'Hiba történt a feladatok betöltésekor.'
  } finally {
    loading.value = false
  }
})

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
    // Hiba esetén a hibaüzenetet elmentjük a reaktív változóba.
    errorMessage.value = 'Hiba történt a kép lekérésekor: ' + error.message;
  } finally {
    // A betöltés állapotát false-ra állítjuk, hogy a spinner eltűnjön.
    isLoading.value = false;
  }
}

</script>

<style scoped>
.table {
  border-radius: 10px;
  overflow: hidden;
}

.table-hover tbody tr:hover {
  background-color: rgba(13, 110, 253, 0.05);
}

body {
  background-color: #202020 !important;
}
</style>
