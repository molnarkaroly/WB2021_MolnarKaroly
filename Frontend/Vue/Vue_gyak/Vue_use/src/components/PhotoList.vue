<template>
  <div class="container mt-5">
    <h2 class="mb-4">
      <i class="bi bi-image-fill me-2 text-primary"></i>Photos
    </h2>

    <!-- Loading spinner -->
    <div v-if="loading" class="text-center py-5">
      <div class="spinner-border text-primary" role="status">
        <span class="visually-hidden">Betöltés...</span>
      </div>
      <p class="mt-3 text-muted">Képek betöltése...</p>
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
            <th>Cím</th>
            <th>URL</th>
            <th>Thumbnail URL</th>
            <th>Kép</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(photo) in photos" :key="photo.id">
            <td>{{ photo.id }}</td>
            <td>{{ photo.title }}</td>
            <td>{{ photo.url }}</td>
            <td>{{ photo.thumbnailUrl }}</td>
            <td><img :src="photo.url" :alt="photo.title" :title="photo.thumbnailUrl"></td>
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

const photos = ref([])
const loading = ref(true)
const error = ref(null)

onMounted(async () => {
  try {
    const response = await axios.get('/photos')
    photos.value = response.data
  } catch (err) {
    error.value = 'Hiba történt a felhasználók betöltésekor.'
  } finally {
    loading.value = false
  }
})
</script>

<style scoped>
.table {
  border-radius: 10px;
  overflow: hidden;
}

.table-hover tbody tr:hover {
  background-color: rgba(13, 110, 253, 0.05);
}
</style>
