<template>
  <div class="container mt-5">
    <h2 class="mb-4">
      <i class="bi bi-plus-circle-fill me-2 text-success"></i>Új feladat rögzítése
    </h2>

    <!-- Success message -->
    <div v-if="successMsg" class="alert alert-success">
      <i class="bi bi-check-circle me-2"></i>{{ successMsg }}
    </div>

    <!-- Error message -->
    <div v-if="errorMsg" class="alert alert-danger">
      <i class="bi bi-exclamation-triangle me-2"></i>{{ errorMsg }}
    </div>

    <!-- Form -->
    <form @submit.prevent="submitTask" class="card shadow-sm p-4 border-0">
      <!-- User ID -->
      <div class="mb-3">
        <label for="userId" class="form-label fw-bold">Felhasználó</label>
        <select id="userId" v-model="form.userId" class="form-select" required>
          <option value="" disabled>Válasszon felhasználót...</option>
          <option v-for="user in users" :key="user.id">{{ user.name }}</option>
        </select>
      </div>

      <!-- Title -->
      <div class="mb-3">
        <label for="title" class="form-label fw-bold">Feladat címe</label>
        <input
          id="title"
          v-model="form.title"
          type="text"
          class="form-control"
          placeholder="Írja be a feladat címét..."
          required
        />
      </div>

      <!-- Completed checkbox -->
      <div class="mb-4 form-check">
        <input
          id="completed"
          v-model="form.completed"
          type="checkbox"
          class="form-check-input"
        />
        <label for="completed" class="form-check-label fw-bold">Elkészült</label>
      </div>

      <!-- Buttons -->
      <div class="d-flex gap-2">
        <button type="submit" class="btn btn-success" :disabled="loading">
          <span v-if="loading" class="spinner-border spinner-border-sm me-2"></span>
          <i v-else class="bi bi-save me-2"></i>Mentés
        </button>
        <router-link to="/" class="btn btn-outline-secondary">
          <i class="bi bi-arrow-left me-2"></i>Vissza
        </router-link>
      </div>
    </form>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue'
import { useRouter } from 'vue-router'
import axios from 'axios'

const router = useRouter()

const form = ref({
  userId: '',
  title: '',
  completed: false
})

const loading = ref(false)
const successMsg = ref('')
const errorMsg = ref('')
const users = ref([])
const loading1 = ref(true)
const error = ref(null)

onMounted(async () => {
  try {
    const response = await axios.get('/users')
    users.value = response.data
  } catch (err) {
    error.value = 'Hiba történt a felhasználók betöltésekor.'
  } finally {
    loading1.value = false
  }
})
async function submitTask() {
  loading.value = true
  successMsg.value = ''
  errorMsg.value = ''

  try {
    await axios.post('/todos', {
      userId: form.value.userId,
      title: form.value.title,
      completed: form.value.completed
    })

    successMsg.value = 'Feladat sikeresen mentve! Átirányítás a főoldalra...'

    // Redirect after 2 seconds
    setTimeout(() => {
      router.push('/')
    }, 2000)
  } catch (err) {
    errorMsg.value = 'Hiba történt a feladat mentésekor. Kérjük, próbálja újra.'
  } finally {
    loading.value = false
  }
}
</script>

<style scoped>
.card {
  border-radius: 15px;
  max-width: 600px;
}

.form-control:focus,
.form-select:focus {
  border-color: #198754;
  box-shadow: 0 0 0 0.2rem rgba(25, 135, 84, 0.25);
}
</style>
