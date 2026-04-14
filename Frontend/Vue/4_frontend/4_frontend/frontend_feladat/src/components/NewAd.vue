<template>
  <div class="container">
    <h2 class="mb-4 text-center">Új hirdetés elküldése</h2>
    <div class="row">
      <div class="offset-lg-3 offset-md-2 col-lg-6 col-md-8 col-12">
        <div class="mb-3">
          <label for="category" class="form-label">Ingatlan kategóriája</label>
          <select class="form-select" v-model="form.kategoriaId">
            <option value="0">Kérem válasszon</option>
            <option v-for="kat in kategoriak" :key="kat.id" :value="kat.id">{{ kat.nev }}</option>
          </select>
        </div>

        <div class="mb-3">
          <label for="date" class="form-label">Hirdetés dátuma</label>
          <input type="date" class="form-control" v-model="form.hirdetesDatuma" readonly />
        </div>
        <div class="mb-3">
          <label for="description" class="form-label">Ingatlan leírása</label>
          <textarea class="form-control" v-model="form.leiras" rows="3"></textarea>
        </div>
        <div class="form-check mb-3">
          <input class="form-check-input" type="checkbox" v-model="form.tehermentes" id="creditFree" />
          <label class="form-check-label" for="creditFree">Tehermentes ingatlan</label>
        </div>
        <div class="mb-3">
          <label for="pictureUrl" class="form-label">Fénykép az ingatlanról</label>
          <input type="url" class="form-control" v-model="form.kepUrl" />
        </div>
        <div class="mb-3 text-center">
          <button class="btn btn-primary px-5" @click="submitForm">Küldés</button>
        </div>

        <div v-if="errorMessage" class="alert alert-danger alert-dismissible" role="alert">
          <strong>{{ errorMessage }}</strong>
          <button type="button" class="btn-close" @click="errorMessage = ''"></button>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue'
import { useRouter } from 'vue-router'
import axios from 'axios'

const router = useRouter()
const errorMessage = ref('')
const kategoriak = ref([])

const today = new Date().toISOString().split('T')[0]

const form = ref({
  kategoriaId: 0,
  hirdetesDatuma: today,
  leiras: '',
  tehermentes: true,
  kepUrl: ''
})

onMounted(async () => {
  try {
    const response = await axios.get('/api/kategoriak')
    kategoriak.value = response.data
  } catch (error) {
    console.error('Hiba a kategóriák lekérésekor:', error)
  }
})

async function submitForm() {
  try {
    await axios.post('/api/ujingatlan', form.value)
    router.push('/offers')
  } catch (error) {
    if (error.response) {
      errorMessage.value = error.response.data || 'Hiba történt a hirdetés elküldésekor!'
    } else {
      errorMessage.value = 'Hiba történt a hirdetés elküldésekor!'
    }
  }
}
</script>
