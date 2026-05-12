<template>
    <div class="container">
        <h1 class="text-center">Gyümölcsök kategória szerint</h1>
        <p>Szűrés kategória alapján</p>

        <label for="category" class="form-label">Kategória:</label>
        <select id="category" class="form-select" v-model="selectedCategory">
            <option value="0">Összes gyümölcs</option>
            <option v-for="gyumolcs in gyumolcsok" :key="gyumolcs.id" :value="gyumolcs.category.id">
                {{ gyumolcs.category.name }}
            </option>
        </select>

        <table class="table table-striped mt-3">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Név</th>
                    <th>Kép</th>
                    <th>Ár (Ft)</th>
                    <th>Leírás</th>
                    <th>Kategória</th>
                    <th>Műveletek</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="gyum in szurtGyumolcsok" :key="gyum.id">
                    <td>{{ gyum.id }}</td>
                    <td>{{ gyum.name }}</td>
                    <td>{{ gyum.image }}</td>
                    <td>{{ gyum.price }}</td>
                    <td>{{ gyum.description }}</td>
                    <td>{{ gyum.category.name }}</td>
                    <td>
                        <button class="btn btn-warning btn-sm" @click="modositGyumolcs(gyum.id)">Módosítás</button>
                        <button class="btn btn-danger btn-sm" @click="torolGyumolcs(gyum.id)">Törlés</button>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
import axios from 'axios';

export default {
    name: 'Category',
    data() {
        return {
            gyumolcsok: [],
            selectedCategory: 0
        }
    },
    computed: {
        szurtGyumolcsok() {
            if (this.selectedCategory == 0) {
                return this.gyumolcsok;
            }
            return this.gyumolcsok.filter(g => g.category.id == this.selectedCategory);
        }
    },
    mounted() {
        // Gyümölcsök lekérése
        axios.get('/fruits')
            .then(response => {
                this.gyumolcsok = response.data;
            });

    },
    methods: {
        modositGyumolcs(id) {
            this.$router.push('/update/' + id);
        },
        torolGyumolcs(id) {
            if (!confirm('Biztosan törli a gyümölcsöt?')) {
                return;
            } 
            axios.delete('/fruits/' + id)
                .then(response => {
                    // Frissítjük a listát a törlés után
                    this.gyumolcsok = this.gyumolcsok.filter(g => g.id !== id);
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