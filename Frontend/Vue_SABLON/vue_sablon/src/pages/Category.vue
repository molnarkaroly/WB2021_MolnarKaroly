<template>
    <div class="container">
        <h1 class="text-center">Túrák listája kategorizálva</h1>
        <p>Get kérés kuldése a <code>/api/Kategoriak/{id}</code> végpontra</p>

        <label for="category" class="form-label">Kategória:</label>
        <select id="category" class="form-select" v-model="selectedCategory" @change="lekerdezTuraKategoria()">
            <option value="0">Válassz egy kategóriát</option>
            <option v-for="kategoria in kategoriak" :key="kategoria.id" :value="kategoria.id">{{ kategoria.ikon }} {{ kategoria.nev }}</option>
        </select>

    <table v-if="turak.length > 0" class="table table-striped mt-3">
            <tr>
                <td>ID</td>
                <td>Név</td>
                <td>Távolság</td>
                <td>Nehézség</td>
                <td>Becsült idő</td>
                <td>Helyszín</td>
                <td>Műveletek</td>
            </tr>
            <tr v-for="tura in turak" :key="tura.id">
                    <td>{{ tura.id }}</td>
                    <td>{{ tura.nev }}</td>
                    <td>{{ tura.tavolsagKm }}</td>
                    <td>{{ tura.nehezseg }}</td>
                    <td>{{ tura.becsultIdoPerc }}</td>
                    <td>{{ tura.helyszin }}</td>
                    <td>
                        <button class="btn btn-warning" @click="modositTura(tura.id)">Módosítás</button>
                        <button class="btn btn-danger" @click="torolTura(tura.id)">Törlés</button>
                    </td>
                </tr>
        </table>
    </div>
</template>

<script>

import axios from 'axios';

axios.defaults.baseURL = 'https://0fm7lfrj-5000.euw.devtunnels.ms/api';
//axios.defaults.baseURL = 'http://localhost:5000/api';

export default {
    name: 'Category',
    data() {
        return {
            kategoriak: [],
            selectedCategory: 0,
            turak: []
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
        lekerdezTuraKategoria() {
            axios.get('/Kategoriak/' + this.selectedCategory)
                .then(response => {
                    this.turak = response.data.turak;
                })
                .catch(error => {
                    console.log(error);
                });
        },
        modositTura(id) {
            this.$router.push('/update/' + id);
        },
        torolTura(id) {
            if (!confirm('Biztosan törli a túrát?')) {
                return;
            } 
            
            axios.delete('/Turak/' + id)
                .then(response => {
                    this.lekerdezTuraKategoria();
                })
                .catch(error => {
                    console.log(error);
                });
        }
    }


}

</script>


<style scoped>
table {
    width: 100%;
    border-collapse: collapse;
}

td {
    border: 1px solid #ddd;
    padding: 8px;
}

th {
    border: 1px solid #ddd;
    padding: 8px;
}

button {
    margin: 5px;
}

</style>