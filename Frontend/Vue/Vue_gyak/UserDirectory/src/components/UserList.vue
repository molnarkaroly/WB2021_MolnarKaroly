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
      <p class="mt-3 text-muted">Felhasználók betöltése...</p>
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
            <th>Város</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(user, index) in users" :key="user.id">
            <td>{{ index + 1 }}</td>
            <td>{{ user.name }}</td>
            <td>{{ user.username }}</td>
            <td>{{ user.email }}</td>
            <td>{{ user.address.city }}</td>
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

const users = ref([])
const loading = ref(true)
const error = ref(null)

onMounted(async () => {
  try {
    const response = await axios.get('/users')
    users.value = response.data
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
