<template>
    <div class="container">
        <h1 class="text-center">Túra módosítása</h1>
        <p>PATCH kérés küldése a <code>api/Turak/{id}</code> végpontra.</p>

        <form>
            <div class="mb-3">
                <label for="nev" class="form-label">Név:</label>
                <input type="text" id="nev" class="form-control" v-model="tura.nev">
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
                <label for="becsultIdoPerc" class="form-label">Becsült idő (perc):</label>
                <input type="number" id="becsultIdoPerc" class="form-control" v-model="tura.becsultIdoPerc">
            </div>
            <div class="mb-3">
                <label for="helyszin" class="form-label">Helyszín:</label>
                <input type="text" id="helyszin" class="form-control" v-model="tura.helyszin">
            </div>
            <button type="submit" class="btn btn-primary" @click.prevent="modositTura">Módosítás</button>
        </form>
    </div>
</template>

<script>
    import axios from 'axios';

    axios.defaults.baseURL = 'http://localhost:5000/api';

    export default {
        name: 'Update',
        data() {
            return {
                tura: {
                    nev: '',
                    tavolsagKm: 0,
                    nehezseg: '',
                    becsultIdoPerc: 0,
                    helyszin: ''
                }
            }
        },
        mounted() {
            const id = this.$route.params.id;
            axios.get(`/Turak/${id}`)
                .then(response => {
                    this.tura = response.data;
                })
                .catch(error => {
                    console.error('Hiba a túra adatainak lekérése során:', error);
                });
        },
        methods: {
            modositTura() {
                const id = this.$route.params.id;
                axios.patch(`/Turak/${id}`, this.tura)
                    .then(() => {
                        alert('Túra sikeresen módosítva.');
                        this.$router.push({ name: 'Category' }); // Visszairányítás a kategória oldalra
                    })
                    .catch(error => {
                        console.error('Hiba a túra módosítása során:', error);
                    });
                }
            }
        }
</script>