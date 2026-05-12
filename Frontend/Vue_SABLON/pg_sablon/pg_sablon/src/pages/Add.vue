<template>
    <div class="container">
        <h1 class="text-center">Túra hozzáadása</h1>
        <p>POST kérés küldése a <code>api/Turak</code> végpontra.</p>

        <form>
            <div class="mb-3">
                <label for="nev" class="form-label">Név:</label>
                <input type="text" id="nev" class="form-control" v-model="tura.nev">
            </div>
            <div class="mb-3">
                <label for="kategoria" class="form-label">Túra kategória</label>
                <select class="form-select" id="kategoria" v-model="tura.kategoriaId">
                    <option value=0>-- Válassz kategóriát --</option>
                    <option v-for="kategoria in kategoriak" :key="kategoria.id" :value="kategoria.id">
                        {{ kategoria.ikon }} {{ kategoria.nev }}
                    </option>
                </select>
            </div>
            <div class="mb-3">
                <label for="tavolsagKm" class="form-label">Távolság (km):</label>
                <input type="number" id="tavolsagKm" class="form-control" v-model="tura.tavolsagKm">
            </div>
            <div class="mb-3">
                <label for="nehezseg" class="form-label">Nehézség:</label>
                <input type="text" id="nehezseg" class="form-control" v-model="tura.nehezseg">
            </div>
            <div class="mb-3">
                <label for="szintkulonbseg" class="form-label">Szintkülönbség:</label>
                <input type="number" id="szintkulonbseg" class="form-control" v-model="tura.szintkulonbsegM">
            </div>
            <div class="mb-3">
                <label for="becsultIdoPerc" class="form-label">Becsült idő (perc):</label>
                <input type="number" id="becsultIdoPerc" class="form-control" v-model="tura.becsultIdoPerc">
            </div>
            <div class="mb-3">
                <label for="helyszin" class="form-label">Helyszín:</label>
                <input type="text" id="helyszin" class="form-control" v-model="tura.helyszin">
            </div>
            <div class="mb-3">
                <label for="leiras" class="form-label">Leírás:</label>
                <textarea id="leiras" class="form-control" v-model="tura.leiras"></textarea>
            </div>
            <div class="mb-3">
                <label for="kutyabarat" class="form-label">Kutyabarát: </label>
                <input type="checkbox" class="form-check-input" id="kutyabarat" v-model="tura.kutyaBarat">

            </div>
            <button type="submit" class="btn btn-primary" @click.prevent="hozzaadTura">Hozzáadás</button>
        </form>
    </div>
</template>

<script>
    import axios from 'axios';

    axios.defaults.baseURL = 'http://localhost:5000/api';

    export default {
        name: 'Add',
        data() {
            return {
                tura: {
                    nev: '',
                    kategoriaId: 0,
                    tavolsagKm: 0,
                    nehezseg: '',
                    szintkulonbsegM: 0,
                    becsultIdoPerc: 0,
                    helyszin: '',
                    leiras: '',
                    kutyaBarat: false
                },
                kategoriak: []
            }
        },
        mounted() {
            axios.get('/Kategoriak')
                .then(response => {
                    this.kategoriak = response.data;
                })
                .catch(error => {
                    console.error('Hiba a kategóriák lekérése során:', error);
                });
        },
        methods: {
            hozzaadTura() {
                axios.post('/Turak', this.tura)
                    .then(() => {
                        alert('Túra sikeresen hozzáadva.');
                        this.$router.push({ name: 'Category' }); // Visszairányítás a kategória oldalra
                    })
                    .catch(error => {
                        console.error('Hiba a túra hozzáadása során:', error);
                    });
                }
            }
        }
    
</script>