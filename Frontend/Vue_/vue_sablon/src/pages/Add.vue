<template>
    <div class="container">
        <h1 class="text-center">Új túra hozzáadása</h1>
        <p>POST kérés küldése a <code>/api/Turak</code> végpontra</p>

        <form>

            <div class="mb-3">
                <label for="nev" class="form-label">Név</label>
                <input type="text" class="form-control" id="nev" v-model="tura.nev">
            </div>

            <div class="mb-3">
                <label for="kategoriaId" class="form-label">Kategória</label>
                <select id="kategoriaId" class="form-select" v-model="tura.kategoriaId">
                    <option value="0">Válassz egy kategóriát</option>
                    <option v-for="kategoria in kategoriak" :key="kategoria.id" :value="kategoria.id">
                        {{ kategoria.ikon }} {{ kategoria.nev }}
                    </option>
                </select>
            </div>

            <div class="mb-3">
                <label for="tavolsagKm" class="form-label">Távolság (km)</label>
                <input type="number" class="form-control" id="tavolsagKm" v-model="tura.tavolsagKm">
            </div>

            <div class="mb-3">
                <label for="nehezseg" class="form-label">Nehézség</label>
                <input type="text" class="form-control" id="nehezseg" v-model="tura.nehezseg">
            </div>

            <div class="mb-3">
                <label for="szintkulonbsegM" class="form-label">Szintkülönbség (m)</label>
                <input type="number" class="form-control" id="szintkulonbsegM" v-model="tura.szintkulonbsegM">
            </div>

            <div class="mb-3">
                <label for="becsultIdoPerc" class="form-label">Becsült idő (perc)</label>
                <input type="number" class="form-control" id="becsultIdoPerc" v-model="tura.becsultIdoPerc">
            </div>

            <div class="mb-3">
                <label for="helyszin" class="form-label">Helyszín</label>
                <input type="text" class="form-control" id="helyszin" v-model="tura.helyszin">
            </div>

            <div class="mb-3">
                <label for="leiras" class="form-label">Leírás</label>
                <textarea class="form-control" id="leiras" rows="3" v-model="tura.leiras"></textarea>
            </div>

            <div class="mb-3 form-check">
                <input type="checkbox" class="form-check-input" id="kutyaBarat" v-model="tura.kutyaBarát">
                <label class="form-check-label" for="kutyaBarat">Kutyabarát</label>
            </div>

            <button type="submit" class="btn btn-primary w-100" @click.prevent="addTura()">Hozzáadás</button>
        </form>

    </div>
</template>

<script>
import axios from 'axios';

axios.defaults.baseURL = 'https://0fm7lfrj-5000.euw.devtunnels.ms/api';

export default {
    name: 'Add',
    data() {
        return {
            tura: {
                id: 0,
                nev: '',
                kategoriaId: 0,
                tavolsagKm: 0,
                nehezseg: '',
                szintkulonbsegM: 0,
                becsultIdoPerc: 0,
                helyszin: '',
                leiras: '',
                kutyaBarát: false
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
                console.log(error);
            });
    },
    methods: {  
        addTura() {
            axios.post('/Turak', this.tura)
                .then(response => {
                    this.$router.push('/list');
                })
                .catch(error => {
                    alert("Hiba történt a mentés során!");
                    console.log(error);
                });
        }
    }
}
</script>