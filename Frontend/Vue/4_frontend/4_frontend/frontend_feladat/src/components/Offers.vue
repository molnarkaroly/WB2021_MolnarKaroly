<template>
  <div class="container pt-3">
    <h2 class="mb-4 text-center">Ajánlataink</h2>
    <table class="table">
      <thead>
        <tr>
          <th>Kategória</th>
          <th>Leírás</th>
          <th>Hirdetés dátuma</th>
          <th>Tehermentes</th>
          <th>Fénykép</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="ingatlan in ingatlanok" :key="ingatlan.id">
          <td>{{ ingatlan.kategoriaId }}</td>
          <td>{{ ingatlan.leiras }}</td>
          <td>{{ ingatlan.hirdetesDatuma }}</td>
          <td class="text-success">{{ ingatlan.tehermentes ? 'Igen' : 'Nem' }}</td>
          <td>
            <img v-if="ingatlan.kepUrl" :src="ingatlan.kepUrl" alt="Ingatlan kép" style="max-height: 100px;" />
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue'
import axios from 'axios'

const ingatlanok = ref([])

onMounted(async () => {
  try {
    const response = await axios.get('/api/ingatlan')
    ingatlanok.value = response.data
  } catch (error) {
    console.error('Hiba az adatok lekérésekor:', error)
  }
})
</script>