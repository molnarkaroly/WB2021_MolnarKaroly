<template>
    <div class="container">
        <h1 class="text-center">Új gyümölcs hozzáadása</h1>
        <p>POST kérés küldése a <code>/api/fruits</code> végpontra</p>

        <form>
            <div class="mb-3">
                <label for="name" class="form-label">Név</label>
                <input type="text" class="form-control" id="name" v-model="gyumolcs.name">
            </div>

            <div class="mb-3">
                <label for="categoryId" class="form-label">Kategória</label>
                <select id="categoryId" class="form-select" v-model="gyumolcs.categoryId">
                    <option value="0">Válassz egy kategóriát</option>
                    <option v-for="gyumolcs in gyumolcsok" :key="gyumolcs.id" :value="gyumolcs.category.id">
                        {{ gyumolcs.category.name }}
                    </option>
                </select>
            </div>

            <div class="mb-3">
                <label for="image" class="form-label">Kép URL</label>
                <input type="text" class="form-control" id="image" v-model="gyumolcs.image">
            </div>

            <div class="mb-3">
                <label for="price" class="form-label">Ár (Ft)</label>
                <input type="number" class="form-control" id="price" v-model="gyumolcs.price">
            </div>

            <div class="mb-3">
                <label for="description" class="form-label">Leírás</label>
                <textarea class="form-control" id="description" rows="3" v-model="gyumolcs.description"></textarea>
            </div>

            <button type="submit" class="btn btn-primary w-100" @click.prevent="addGyumolcs()">Hozzáadás</button>
        </form>

    </div>
</template>

<script>
import axios from 'axios';

export default {
    name: 'Add',
    data() {
        return {
            gyumolcs: {
                name: '',
                image: '',
                price: 0,
                description: '',
                category_id: 1
            },
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
    },
    methods: {  
        addGyumolcs() {
            axios.post('/fruits', this.gyumolcs)
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
