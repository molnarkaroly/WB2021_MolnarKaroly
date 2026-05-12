<template>
    <div class="container">
        <h1 class="text-center">Gyümölcs módosítása</h1>
        <p>PATCH kérés küldése a <code>/api/fruits/{id}</code> végpontra</p>

        <form v-if="gyumolcs">
            <div class="mb-3">
                <label for="name" class="form-label">Név</label>
                <input type="text" class="form-control" id="name" v-model="gyumolcs.name">
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

            <button type="submit" class="btn btn-warning w-100" @click.prevent="modositGyumolcs()">Módosítás</button>
        </form>

    </div>
</template>

<script>
import axios from 'axios';

export default {
    name: 'Update',
    data() {
        return {
            gyumolcs: {
                name: '',
                image: '',
                price: 0,
                description: '',
                category_id: 1
            }
        }
    },
    mounted(){
        const id = this.$route.params.id;
        
        // Gyümölcs adatainak lekérése
        axios.get('/fruits/' + id)
            .then(response => {
                this.gyumolcs = response.data;
            })
            .catch(error => {
                console.log(error);
            });
            
    },
    methods: {
        modositGyumolcs() {
            const id = this.$route.params.id;
            axios.put('/fruits/' + id, this.gyumolcs)
                .then(response => {
                    this.$router.push('/list');
                })
                .catch(error => {
                    alert("Hiba történt a módosítás során!");
                    console.log(error);
                });
        }
    }
}
</script>
