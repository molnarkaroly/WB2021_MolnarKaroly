# ÁLB Ingatlanügynökség – Vue 3 Projekt Jegyzet


### **Projekt létrehozása:**

```bash
npm create vue@latest
```
Ha kész, lépj be a mappába és indítsd el:

```bash
cd <project-name>
npm install
npm run dev
```

## Mappák és segédfájlok

A feladat mappája: `4_frontend/`

```
4_frontend/
├── Bootstrap UI/              ← segédfájlok (minta HTML + CSS)
│   ├── bootstrap.min.css      ← Bootstrap CSS (helyi másolat, mi npm-ből használjuk)
│   ├── openpage.html          ← nyitóoldal minta HTML
│   ├── openpage.css           ← nyitóoldal minta CSS
│   └── newad.html             ← új hirdetés űrlap minta HTML
├── backend/                   ← .NET backend szerver (IngatlanWebAPI.exe)
├── real-estate-agent.png      ← háttérkép a nyitóoldalhoz
└── frontend_feladat/          ← a Vue 3 projekt (itt dolgozunk)
```

---

## 1. Bootstrap telepítése

```bash
npm install bootstrap
```

Hol importáljuk? → `src/main.js` legelső sora:

```javascript
import 'bootstrap/dist/css/bootstrap.min.css'
```

**Miért ide?** A `main.js` az alkalmazás belépési pontja. Amit itt importálunk, az **globálisan** elérhető az összes komponensben. A Bootstrap CSS-t a `main.css` **elé** tettük, hogy a saját CSS-ünk felülírhassa ha kell.

---

## 2. Vue Router telepítése

```
npm install vue-router@4
```

**Miért `@4`?** Mert a Vue 3-hoz a Vue Router 4-es verziója tartozik.

Létrehozzuk: `src/router/index.js` (új mappa + fájl):

```javascript
import { createRouter, createWebHistory } from 'vue-router'
import OpenPage from '../components/OpenPage.vue'
import Offers from '../components/Offers.vue'
import NewAd from '../components/NewAd.vue'

const routes = [
    { path: '/', component: OpenPage },        // nyitóoldal
    { path: '/offers', component: Offers },     // ajánlatok táblázat
    { path: '/newad', component: NewAd }        // új hirdetés űrlap
]

const router = createRouter({
    history: createWebHistory(),
    routes
})

export default router
```

**Mit csinál?** Megmondja a Vue-nak, hogy melyik URL-nél melyik komponenst jelenítse meg. A `createWebHistory()` miatt "rendes" URL-eket kapunk (`/offers`, nem `/#/offers`).

Regisztráljuk a `main.js`-ben:

```javascript
import router from './router'
app.use(router)
```

---

## 3. Axios telepítése

```bash
npm install axios
```

Konfiguráljuk a `main.js`-ben:

```javascript
import axios from 'axios'
axios.defaults.baseURL = 'http://localhost:5000'
```

**Mit csinál a `baseURL`?** Ha a komponensben `axios.get('/api/ingatlan')`-t hívunk, az axios automatikusan hozzáfűzi a baseURL-t, tehát a tényleges kérés a `http://localhost:5000/api/ingatlan`-ra megy. **Így egyetlen helyen kell módosítani ha a szerver címe változik.**

### fetch vs axios különbségek

| fetch (régi) | axios (jelenlegi) |
|---|---|
| `const resp = await fetch('/api/ingatlan')` | `const resp = await axios.get('/api/ingatlan')` |
| `const data = await resp.json()` | `const data = resp.data` |
| `fetch(url, {method:'POST', headers:{...}, body: JSON.stringify(obj)})` | `axios.post(url, obj)` |
| `if (!resp.ok) { hiba }` | `catch (error) { error.response.data }` |

**Miért jobb az axios?**
- Automatikusan JSON-ba alakítja az adatokat (nem kell `JSON.stringify`)
- Automatikusan beállítja a `Content-Type: application/json` fejlécet
- A `baseURL` egy helyen kezelhető
- Hibakezelés egyszerűbb (try-catch)

---

## 4. Háttérkép bemásolása

```
copy "4_frontend\real-estate-agent.png" "frontend_feladat\src\assets\real-estate-agent.png"
```

**Miért `src/assets/`-ba?** A Vite ebből a mappából kezeli a statikus fájlokat. A `main.css`-ben a `url('real-estate-agent.png')` relatív hivatkozás megtalálja, mert mindkettő ebben a mappában van.

---

## 5. `main.css` – CSS stílusok (az openpage.css-ből)

Az eredeti `src/assets/main.css` tartalmát (Vue alapértelmezett stílusok) **teljesen kitöröltük** és helyette a `Bootstrap UI/openpage.css` tartalmát illesztettük be.

```css
.start {
    background-image: url('real-estate-agent.png');
    background-position: center;
    background-size: cover;
    min-height: 100vh;
}
/* ... többi stílus ... */
.container {
    background-color: rgb(217, 243, 240);
    min-height: 100vh;
}
```

**Miért globálisan és nem scoped?** Mert a `.container` osztályt több komponensben is használjuk, és a `scoped` stílus csak az adott komponensen belül érvényes.

---

## 6. `index.html` módosítása

```diff
-<html lang="">
+<html lang="hu">

-<title>Vite App</title>
+<title>ÁLB Ingatlanügynökség</title>
```

---

## 7. `App.vue` – Fő komponens

```vue
<script setup>
</script>

<template>
  <router-view />
</template>

<style scoped>
</style>
```

**Mit csinál a `<router-view />`?** Ez a Vue Router helyőrzője – ide rendereli a router az aktuális URL-hez tartozó komponenst.

---

## 8. `main.js` – Teljes tartalom

```javascript
import 'bootstrap/dist/css/bootstrap.min.css'
import './assets/main.css'

import { createApp } from 'vue'
import axios from 'axios'
import App from './App.vue'
import router from './router'

axios.defaults.baseURL = 'http://localhost:5000'

const app = createApp(App)
app.use(router)
app.mount('#app')
```

| Sor | Mit csinál |
|-----|-----------|
| 1 | Bootstrap CSS betöltése (globálisan) |
| 2 | Saját CSS betöltése (openpage.css tartalma) |
| 4 | Vue importálása |
| 5 | Axios importálása |
| 6 | Fő komponens importálása |
| 7 | Router importálása |
| 9 | Axios alap URL beállítása (a backend szerver címe) |
| 11 | Vue alkalmazás létrehozása |
| 12 | Router regisztrálása |
| 13 | Alkalmazás csatolása az `index.html` `<div id="app">` elemhez |

---

## 9. `OpenPage.vue` – Nyitóoldal

**Forrása:** `Bootstrap UI/openpage.html` – a `<body>` tartalmából (13–26. sor)

```vue
<template>
  <div class="container">
    <div class="start w-100">
      <h1 class="text-center pt-2 pt-lg-4">Á.L.B. Ingatlanügynöség</h1>
      <div class="row">
        <div class="col-12 col-sm-6 text-center">
          <a class="btn btn-primary" href="/offers">Nézze meg kínálatunkat!</a>
        </div>
        <div class="col-12 col-sm-6 text-center">
          <a class="btn btn-primary" href="/newad">Hirdessen nálunk!</a>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
</script>
```

**Mi változott az eredeti HTML-hez képest?**
- `href="#"` → `href="/offers"` és `href="/newad"` (navigáció a többi oldalra)

---

## 10. `Offers.vue` – Ajánlatok oldal

```vue
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
            <img v-if="ingatlan.kepUrl" :src="ingatlan.kepUrl" alt="Ingatlan kép"
                 style="max-height: 100px;" />
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
```

| Elem | Magyarázat |
|------|-----------|
| `v-for="ingatlan in ingatlanok"` | Végigmegy az adatokon, minden sorhoz renderel egy `<tr>`-t |
| `:key="ingatlan.id"` | Egyedi kulcs a Vue-nak (hatékony DOM frissítés) |
| `ref([])` | Reaktív változó – ha változik, a Vue újrarendereli a táblázatot |
| `onMounted` | Amikor a komponens megjelenik, lefut és letölti az adatokat |
| `axios.get('/api/ingatlan')` | GET kérés → `http://localhost:5000/api/ingatlan` |
| `response.data` | Az axios a JSON választ automatikusan parse-olja |

---

## 11. `NewAd.vue` – Új hirdetés űrlap

**Forrása:** `Bootstrap UI/newad.html` – a `<body>` tartalmából (13–57. sor)

### Mi változott az eredeti HTML-hez képest?

| Eredeti HTML | Vue komponensben |
|---|---|
| `<select name="kategoriaId">` statikus opciókkal | `v-model="form.kategoriaId"` + `v-for` a szerverről letöltött kategóriákkal |
| `<input type="date" name="hirdetesDatuma">` | `v-model="form.hirdetesDatuma" readonly` – mai dátum, nem szerkeszthető |
| `<textarea name="leiras">` | `v-model="form.leiras"` |
| `<input type="checkbox" name="tehermentes">` | `v-model="form.tehermentes"` |
| `<input type="url" name="kepUrl">` | `v-model="form.kepUrl"` |
| `<button>Küldés</button>` | `@click="submitForm"` |
| Statikus hibaüzenet | `v-if="errorMessage"` – csak hiba esetén jelenik meg |

### Script rész:

```javascript
import { ref, onMounted } from 'vue'
import { useRouter } from 'vue-router'
import axios from 'axios'

const router = useRouter()
const errorMessage = ref('')
const kategoriak = ref([])

const today = new Date().toISOString().split('T')[0]

const form = ref({
  kategoriaId: 0,
  hirdetesDatuma: today,
  leiras: '',
  tehermentes: true,
  kepUrl: ''
})

// Kategóriák letöltése oldal betöltésekor
onMounted(async () => {
  try {
    const response = await axios.get('/api/kategoriak')
    kategoriak.value = response.data
  } catch (error) {
    console.error('Hiba a kategóriák lekérésekor:', error)
  }
})

// Űrlap elküldése
async function submitForm() {
  try {
    await axios.post('/api/ujingatlan', form.value)
    router.push('/offers')  // siker → átnavigál az ajánlatok oldalra
  } catch (error) {
    if (error.response) {
      errorMessage.value = error.response.data || 'Hiba történt!'
    } else {
      errorMessage.value = 'Hiba történt a hirdetés elküldésekor!'
    }
  }
}
```

### API végpontok

| URL | Metódus | Mikor | Mit csinál |
|-----|---------|-------|-----------|
| `/api/kategoriak` | GET | Oldal betöltésekor | Kategória lista a lenyíló listához |
| `/api/ujingatlan` | POST | Küldés gombra kattintáskor | Új hirdetés elküldése |
| `/api/ingatlan` | GET | Offers oldal betöltésekor | Összes ingatlan lekérése |

---

## Végső fájlszerkezet

```
frontend_feladat/src/
├── main.js                          ← belépési pont (Bootstrap + Axios + Router)
├── App.vue                          ← csak <router-view /> van benne
├── assets/
│   ├── main.css                     ← openpage.css tartalma (globális stílusok)
│   └── real-estate-agent.png        ← háttérkép (ide másoltuk)
├── components/
│   ├── OpenPage.vue                 ← nyitóoldal (openpage.html-ből)
│   ├── Offers.vue                   ← ajánlatok táblázat (GET /api/ingatlan)
│   └── NewAd.vue                    ← új hirdetés űrlap (newad.html-ből)
└── router/
    └── index.js                     ← útvonalak: /, /offers, /newad
```

## Telepített npm csomagok

| Csomag | Parancs | Miért |
|--------|---------|-------|
| `bootstrap` | `npm install bootstrap` | CSS keretrendszer (gombok, táblázat, űrlap, grid) |
| `vue-router@4` | `npm install vue-router@4` | Oldalak közötti navigáció (SPA routing) |
| `axios` | `npm install axios` | HTTP kérések a backend szerverhez (GET, POST) |

## Adatfolyam

```
Böngésző URL → Router (index.js) → Melyik komponens?
    /           → OpenPage.vue     → Háttérkép + 2 gomb
    /offers     → Offers.vue       → axios.get('/api/ingatlan') → táblázat
    /newad      → NewAd.vue        → axios.get('/api/kategoriak') → űrlap
                                     axios.post('/api/ujingatlan') → siker/hiba
```
