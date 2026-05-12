<template>
    <div class="container">
        <h1 class="text-center">Gyümölcsök</h1>
        <p>Get kérés kuldése a <code>/api/fruits</code> végpontra</p>
        <button class="btn btn-primary m-3" @click="this.$router.push('/')">Vissza a főoldalra</button>
        <table>
            <tr>
                <td>ID</td>
                <td>Gyümölcs neve</td>
                <td>Kép</td>
                <td>Ár (Ft)</td>
                <td>Leírás</td>
                <td>Kategória</td>
                <td>Kategória leírás</td>
            </tr>
            <tr v-for="gyum in gyumolcsok" :key="gyum.id">
                    <td>{{ gyum.id }}</td>
                    <td>{{ gyum.name }}</td>
                    <td>{{ gyum.image }}</td>
                    <td>{{ gyum.price }}</td>
                    <td>{{ gyum.description }}</td>
                    <td>{{ gyum.category.name }}</td>
                    <td>{{ gyum.category.description }}</td>
                </tr>
        </table>
</div>
</template>

<script>
import axios from 'axios';


export default {
    name: 'List',
    data() {
        return {
            gyumolcsok: []
        }
    },
    mounted() {
        axios.get('/fruits')
            .then(response => {
                this.gyumolcsok = response.data;
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