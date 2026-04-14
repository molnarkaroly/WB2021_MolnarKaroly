<template>
    <div class="container">
        <h1 class="text-center">Túrák</h1>
        <p>Get kérés kuldése a <code>/api/Turak</code> végpontra</p>
        <table>
            <tr>
                <td>ID</td>
                <td>Név</td>
                <td>Kategória</td>
                <td>Távolság</td>
                <td>Nehézség</td>
                <td>Szintkülönbség</td>
                <td>Becsült idő</td>
                <td>Helyszín</td>
                <td>Leírás</td>
                <td>Kutyabarát</td>
            </tr>
            <tr v-for="tura in turak" :key="tura.id">
                    <td>{{ tura.id }}</td>
                    <td>{{ tura.nev }}</td>
                    <td>{{ tura.kategoria.ikon }} {{ tura.kategoria.nev }}</td>
                    <td>{{ tura.tavolsagKm }}</td>
                    <td>{{ tura.nehezseg }}</td>
                    <td>{{ tura.szintkulonbsegM }}</td>
                    <td>{{ tura.becsultIdoPerc }}</td>
                    <td>{{ tura.helyszin }}</td>
                    <td>{{ tura.leiras }}</td>
                    <td class="text-center"  :class="tura.kutyaBarát ? 'text-green' : 'text-red'">{{ tura.kutyaBarát ? "Igen" : "Nem" }}</td>
                </tr>
        </table>
</div>
</template>

<script>
import axios from 'axios';

axios.defaults.baseURL = 'https://0fm7lfrj-5000.euw.devtunnels.ms/api';
//axios.defaults.baseURL = 'http://localhost:5000/api';

export default {
    name: 'List',
    data() {
        return {
            turak: []
        }
    },
    mounted() {
        axios.get('/Turak')
            .then(response => {
                this.turak = response.data;
            })
            .catch(error => {
                console.log(error);
            });
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


.text-green {
    color: rgb(16, 179, 16);
}

.text-red {
    color: red;
}

</style>