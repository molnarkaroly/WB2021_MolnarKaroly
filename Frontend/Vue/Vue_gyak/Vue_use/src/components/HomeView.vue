<template>
  <div class="home-container">
    <!-- Hero Section -->
    <div class="hero-section text-center py-5">
      <div class="container">
        <h1 class="display-4 fw-bold mb-3">
          <i class="bi bi-house-door-fill me-2"></i>Üdvözöljük!
        </h1>
        <p class="lead text-muted mb-5">
          Kezelje a felhasználókat és rögzítsen új feladatokat egyszerűen és gyorsan.
        </p>

        <!-- Cards -->
        <div class="row justify-content-center g-4">
          <!-- Felhasználók megtekintése -->
          <div class="col-md-5 col-lg-4">
            <div class="card home-card shadow-lg border-0 h-100" @click="$router.push('/users')">
              <div class="card-body d-flex flex-column align-items-center justify-content-center p-5">
                <div class="icon-circle bg-primary mb-4">
                  <i class="bi bi-people-fill text-white"></i>
                </div>
                <h4 class="card-title fw-bold mb-3">Felhasználók megtekintése</h4>
                <p class="card-text text-muted mb-4">
                  Tekintse meg a regisztrált felhasználók listáját és részletes adataikat.
                </p>
                <router-link to="/users" class="btn btn-primary btn-lg px-5 rounded-pill">
                  <i class="bi bi-arrow-right-circle me-2"></i>Megtekintés
                </router-link>
              </div>
            </div>
          </div>

          
        

          <!-- Új feladat rögzítése -->
          <div class="col-md-5 col-lg-4">
            <div class="card home-card shadow-lg border-0 h-100" @click="$router.push('/newtask')">
              <div class="card-body d-flex flex-column align-items-center justify-content-center p-5">
                <div class="icon-circle bg-success mb-4">
                  <i class="bi bi-plus-circle-fill text-white"></i>
                </div>
                <h4 class="card-title fw-bold mb-3">Új feladat rögzítése</h4>
                <p class="card-text text-muted mb-4">
                  Adjon hozzá új feladatot gyorsan és egyszerűen a rendszerhez.
                </p>
                <router-link to="/newtask" class="btn btn-success btn-lg px-5 rounded-pill">
                  <i class="bi bi-plus-lg me-2"></i>Rögzítés
                </router-link>
              </div>
            </div>
          </div>

          <div class="col-md-5 col-lg-4">
            <div class="card home-card shadow-lg border-0 h-100" @click="$router.push('/photos')">
              <div class="card-body d-flex flex-column align-items-center justify-content-center p-5">
                <div class="icon-circle bg-success mb-4">
                  <i class="bi bi-image-fill text-white"></i>
                </div>
                <h4 class="card-title fw-bold mb-3">Képek</h4>
                <p class="card-text text-muted mb-4">
                  Képek megtekintése
                </p>
                <router-link to="/photos" class="btn btn-success btn-lg px-5 rounded-pill">
                  <i class="bi bi-image-fill me-2"></i>Photos
                </router-link>
              </div>
            </div>
          </div>

        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'HomeView'
}
</script>

<style scoped>
.home-container {
  min-height: 80vh;
  display: flex;
  align-items: center;
  background: linear-gradient(135deg, #f5f7fa 0%, #c3cfe2 100%);
}



.hero-section h1 {
  color: #2c3e50;
  font-size: 2.8rem;
}

.hero-section .lead {
  font-size: 1.25rem;
  margin-left: auto;
  margin-right: auto;
}

.home-card {
  border-radius: 20px;
  cursor: pointer;
  transition: transform 0.3s ease, box-shadow 0.3s ease;
  background: #ffffff;
}

.home-card:hover {
  transform: translateY(-10px);
  box-shadow: 0 20px 40px rgba(0, 0, 0, 0.15) !important;
}

.icon-circle {
  width: 90px;
  height: 90px;
  border-radius: 50%;
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 2.2rem;
  transition: transform 0.3s ease;
}

.home-card:hover .icon-circle {
  transform: scale(1.1);
}

.card-title {
  color: #2c3e50;
}

.card-text {
  font-size: 0.95rem;
  line-height: 1.6;
}

.btn {
  font-weight: 600;
  transition: all 0.3s ease;
}

.btn:hover {
  transform: scale(1.05);
}
</style>